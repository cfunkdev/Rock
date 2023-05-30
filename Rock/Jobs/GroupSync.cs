﻿// <copyright>
// Copyright by the Spark Development Network
//
// Licensed under the Rock Community License (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.rockrms.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Humanizer;
using Rock;
using Rock.Attribute;
using Rock.Communication;
using Rock.Data;
using Rock.Model;
using Rock.Web.Cache;

namespace Rock.Jobs
{
    /// <summary>
    /// This job synchronizes the members of a group with the people in a Rock data view based on
    /// the configuration of data view and role found in the group. It is also responsible for
    /// sending any ExitSystemEmail or WelcomeSystemEmail as well as possibly creating any
    /// user login for the person.
    ///
    /// It should adhere to the following truth table:
    ///
    ///     In         In Group   In Group
    ///     DataView   Archived   !Archived   Result
    ///     --------   --------   ---------   ----------------------------
    ///            0          0           0   do nothing
    ///            0          0           1   remove from group
    ///            0          1           0   do nothing
    ///            1          0           0   add to group
    ///            1          0           1   do nothing
    ///            1          1           0   change IsArchived to false, unless they are also already in the group as Unarchived
    ///
    /// NOTE: It should do this regardless of the person's IsDeceased flag.
    /// NOTE: The job can sync new people at about 45/sec or 2650/minute.
    /// </summary>
    [DisplayName( "Group Sync" )]
    [Description( "Processes groups that are marked to be synced with a data view." )]

    [BooleanField( "Require Password Reset On New Logins", "Determines if new logins will require the individual to reset their password on the first log in.", Key = "RequirePasswordReset" )]
    [IntegerField( "Command Timeout", "Maximum amount of time (in seconds) to wait for each operation to complete. Leave blank to use the default for this job (180).", false, 3 * 60, "General", 1, "CommandTimeout" )]
    public class GroupSync : RockJob
    {
        /// <summary>
        /// Empty constructor for job initialization
        /// <para>
        /// Jobs require a public empty constructor so that the
        /// scheduler can instantiate the class whenever it needs.
        /// </para>
        /// </summary>
        public GroupSync()
        {
        }

        /// <inheritdoc cref="RockJob.Execute()"/>
        public override void Execute()
        {
            // Get the job setting(s)
            bool requirePasswordReset = GetAttributeValue( "RequirePasswordReset" ).AsBoolean();
            var commandTimeout = GetAttributeValue( "CommandTimeout" ).AsIntegerOrNull() ?? 180;

            // Counters for displaying results
            int deletedMemberCount = 0;
            int addedMemberCount = 0;
            int notAddedMemberCount = 0;

            var groupIdsSynced = new List<int>();
            var groupIdsChanged = new List<int>();

            int groupId = default;
            string groupName = string.Empty;
            string dataViewName = string.Empty;

            var warningMessages = new List<string>();
            var warningExceptions = new List<RockJobWarningException>();

            // get groups set to sync
            var activeSyncList = new List<GroupSyncInfo>();
            using ( var rockContextReadOnly = new RockContextReadOnly() )
            {
                // Get groups that are not archived and are still active.
                activeSyncList = new GroupSyncService( rockContextReadOnly )
                    .Queryable()
                    .AsNoTracking()
                    .AreNotArchived()
                    .AreActive()
                    .NeedToBeSynced()
                    .Select( x => new GroupSyncInfo { SyncId = x.Id, GroupName = x.Group.Name } )
                    .ToList();
            }

            foreach ( var syncInfo in activeSyncList )
            {
                int syncId = syncInfo.SyncId;
                bool hasSyncChanged = false;
                this.UpdateLastStatusMessage( $"Syncing group '{syncInfo.GroupName}'" );

                // Use a fresh rockContext per sync so that ChangeTracker doesn't get bogged down
                /*  
                    5/11/2023 - CWR

                    This needs to use the regular RockContext because
                    the change of group members' archive state versus a RockContextReadOnly version 
                    attempts a duplicate addition and causes a potential exception.
                */
                using ( var rockContext = new RockContext() )
                {
                    // increase the timeout just in case the data view source is slow
                    rockContext.Database.CommandTimeout = commandTimeout;
                    rockContext.SourceOfChange = "Group Sync";

                    // Get the Sync
                    var sync = new GroupSyncService( rockContext )
                        .Queryable()
                        .Include( a => a.Group )
                        .Include( a => a.SyncDataView )
                        .AsNoTracking()
                        .FirstOrDefault( s => s.Id == syncId );

                    if ( sync == null || sync.SyncDataView.EntityTypeId != EntityTypeCache.Get( typeof( Person ) ).Id )
                    {
                        // invalid sync or invalid SyncDataView
                        continue;
                    }

                    dataViewName = sync.SyncDataView.Name;
                    groupName = sync.Group.Name;
                    groupId = sync.Group.Id;

                    Stopwatch stopwatch = Stopwatch.StartNew();

                    // Get the person id's from the data view (source)
                    var dataViewGetQueryArgs = new DataViewGetQueryArgs
                    {
                        /*

                            11/28/2022 - CWR
                            In order to prevent potential context conflicts with allowing a new Rock context being created here,
                            this DbContext will stay set to the rockContext that was passed in.

                         */
                        DbContext = rockContext,
                        DatabaseTimeoutSeconds = commandTimeout
                    };

                    List<int> sourcePersonIds;

                    try
                    {
                        var dataViewQry = sync.SyncDataView.GetQuery( dataViewGetQueryArgs );
                        sourcePersonIds = dataViewQry.Select( q => q.Id ).ToList();
                    }
                    catch ( Exception ex )
                    {
                        // If any error occurred trying get the 'where expression' from the sync-data-view,
                        // just skip trying to sync that particular group's Sync Data View for now.
                        warningExceptions.Add( new RockJobWarningException( $"An error occurred while trying to GroupSync group '{groupName}' and data view '{dataViewName}' so the sync was skipped.", ex ) );
                        continue;
                    }

                    stopwatch.Stop();
                    DataViewService.AddRunDataViewTransaction( sync.SyncDataView.Id, Convert.ToInt32( stopwatch.Elapsed.TotalMilliseconds ) );

                    // Get the person id's in the group (target) for the role being synced.
                    // Note: targetPersonIds must include archived group members
                    // so we don't try to delete anyone who's already archived, and
                    // it must include deceased members so we can remove them if they
                    // are no longer in the data view.
                    var existingGroupMemberPersonList = new GroupMemberService( rockContext )
                        .Queryable( true, true ).AsNoTracking()
                        .Where( gm => gm.GroupId == sync.GroupId )
                        .Where( gm => gm.GroupRoleId == sync.GroupTypeRoleId )
                        .Select( gm => new
                        {
                            PersonId = gm.PersonId,
                            IsArchived = gm.IsArchived
                        } )
                        .ToList();

                    var targetPersonIdsToDelete = existingGroupMemberPersonList.Where( t => !sourcePersonIds.Contains( t.PersonId ) && t.IsArchived != true ).ToList();
                    if ( targetPersonIdsToDelete.Any() )
                    {
                        this.UpdateLastStatusMessage( $"Deleting or archiving {targetPersonIdsToDelete.Count()} group member records in '{groupName}' that are no longer in the sync data view." );
                    }

                    // Delete people from the group/role that are no longer in the data view --
                    // but not the ones that are already archived.
                    foreach ( var targetPerson in targetPersonIdsToDelete )
                    {
                        try
                        {
                            // Use a new context to limit the amount of change-tracking required
                            using ( var groupMemberContext = new RockContext() )
                            {
                                // Delete the records for that person's group and role.
                                // NOTE: just in case there are duplicate records, delete all group member records for that person and role
                                var groupMemberService = new GroupMemberService( groupMemberContext );
                                foreach ( var groupMember in groupMemberService
                                    .Queryable( true, true )
                                    .Where( m =>
                                        m.GroupId == sync.GroupId &&
                                        m.GroupRoleId == sync.GroupTypeRoleId &&
                                        m.PersonId == targetPerson.PersonId )
                                    .ToList() )
                                {
                                    groupMemberService.Delete( groupMember );
                                }

                                groupMemberContext.SaveChanges();

                                deletedMemberCount++;
                                if ( deletedMemberCount % 100 == 0 )
                                {
                                    this.UpdateLastStatusMessage( $"Deleted or archived {deletedMemberCount} of {targetPersonIdsToDelete.Count()} group member records for group '{groupName}'." );
                                }

                                hasSyncChanged = true;

                                // If the Group has an exit email, and person has an email address, send them the exit email
                                if ( sync.ExitSystemCommunication != null )
                                {
                                    var person = new PersonService( groupMemberContext ).Get( targetPerson.PersonId );
                                    if ( person.CanReceiveEmail( false ) )
                                    {
                                        // Send the exit email
                                        var mergeFields = new Dictionary<string, object>();
                                        mergeFields.Add( "Group", sync.Group );
                                        mergeFields.Add( "Person", person );
                                        var emailMessage = new RockEmailMessage( sync.ExitSystemCommunication );
                                        emailMessage.AddRecipient( new RockEmailMessageRecipient( person, mergeFields ) );
                                        var emailErrors = new List<string>();
                                        emailMessage.Send( out emailErrors );

                                        if ( emailErrors?.Any() == true )
                                        {
                                            emailErrors.ForEach( e => warningMessages.Add( $"Unable to send exit email to '{groupName}' group member with person ID {targetPerson.PersonId}. Error: {e}" ) );
                                        }
                                    }
                                }
                            }
                        }
                        catch ( Exception ex )
                        {
                            warningExceptions.Add( new RockJobWarningException( $"Unable to delete person with ID {targetPerson.PersonId} from group '{groupName}'.", ex ) );
                            continue;
                        }
                    }

                    // Now find all the people in the source list who are NOT already in the target list (as Unarchived)
                    var targetPersonIdsToAdd = sourcePersonIds.Where( s => !existingGroupMemberPersonList.Any( t => t.PersonId == s && t.IsArchived == false ) ).ToList();

                    // Make a list of PersonIds that have an Archived group member record
                    // if this person isn't already a member of the list as an Unarchived member, we can Restore the group member for that PersonId instead
                    var archivedTargetPersonIds = existingGroupMemberPersonList.Where( t => t.IsArchived == true ).Select( a => a.PersonId ).ToList();

                    this.UpdateLastStatusMessage( $"Adding {targetPersonIdsToAdd.Count()} group member records for group '{groupName}'." );
                    foreach ( var personId in targetPersonIdsToAdd )
                    {
                        if ( ( addedMemberCount + notAddedMemberCount ) % 100 == 0 )
                        {
                            string notAddedMessage = string.Empty;
                            if ( notAddedMemberCount > 0 )
                            {
                                notAddedMessage = $"{Environment.NewLine}There are {notAddedMemberCount} members that could not be added.";
                            }

                            this.UpdateLastStatusMessage( $"Added {addedMemberCount} of {targetPersonIdsToAdd.Count()} group member records to group '{groupName}'. {notAddedMessage}" );
                        }

                        try
                        {
                            // Use a new context to limit the amount of change-tracking required
                            using ( var groupMemberContext = new RockContext() )
                            {
                                var groupMemberService = new GroupMemberService( groupMemberContext );
                                var groupService = new GroupService( groupMemberContext );

                                // If this person is currently archived...
                                if ( archivedTargetPersonIds.Contains( personId ) )
                                {
                                    // ...then we'll just restore them;
                                    GroupMember archivedGroupMember = groupService.GetArchivedGroupMember( sync.Group, personId, sync.GroupTypeRoleId );

                                    if ( archivedGroupMember == null )
                                    {
                                        // shouldn't happen, but just in case
                                        continue;
                                    }

                                    archivedGroupMember.GroupMemberStatus = GroupMemberStatus.Active;

                                    // GroupMember.PreSave() will NOT call GroupMember.IsValidGroupMember() in this scenario - since we're restoring
                                    // a previously-archived member - so we must manually validate here before attempting to save.
                                    if ( archivedGroupMember.IsValidGroupMember( groupMemberContext ) )
                                    {
                                        addedMemberCount++;
                                        groupMemberService.Restore( archivedGroupMember );
                                        groupMemberContext.SaveChanges();
                                    }
                                    else
                                    {
                                        // Validation errors will have been added to the ValidationResults collection. Add those results to the log and then move on to the next person.
                                        warningMessages.Add( $"Unable to restore archived group member with person ID {personId} (group Member ID {archivedGroupMember.Id}) to group '{groupName}'. {archivedGroupMember.ValidationResults.AsDelimited( "; " )}" );
                                        notAddedMemberCount++;
                                        continue;
                                    }
                                }
                                else
                                {
                                    // ...otherwise we will add a new person to the group with the role specified in the sync.
                                    var newGroupMember = new GroupMember { Id = 0 };
                                    newGroupMember.PersonId = personId;
                                    newGroupMember.GroupId = sync.GroupId;
                                    newGroupMember.GroupMemberStatus = GroupMemberStatus.Active;
                                    newGroupMember.GroupRoleId = sync.GroupTypeRoleId;

                                    groupMemberService.Add( newGroupMember );

                                    try
                                    {
                                        // GroupMember.PreSave() WILL call GroupMember.IsValidGroupMember() in this scenario, so there is no need
                                        // to manually validate here before attempting to save. In fact, doing so would be redundant and result in
                                        // duplicate db queries. If this group member fails the validation check, we'll catch the exception below
                                        // and log all validation results.
                                        groupMemberContext.SaveChanges();
                                        addedMemberCount++;
                                    }
                                    catch ( GroupMemberValidationException ex )
                                    {
                                        // Validation errors will have been added to the ValidationResults collection. Add those results to the log and then move on to the next person.
                                        warningMessages.Add( $"Unable to add group member with person ID {personId} to group '{groupName}'. {newGroupMember.ValidationResults.AsDelimited( "; " )}" );
                                        notAddedMemberCount++;
                                        continue;
                                    }
                                }

                                hasSyncChanged = true;

                                // If the Group has a welcome email, and person has an email address, send them the welcome email and possibly create a login
                                if ( sync.WelcomeSystemCommunication != null )
                                {
                                    var person = new PersonService( groupMemberContext ).Get( personId );
                                    if ( person.CanReceiveEmail( false ) )
                                    {
                                        // If the group is configured to add a user account for anyone added to the group, and person does not yet have an
                                        // account, add one for them.
                                        string newPassword = string.Empty;
                                        bool createLogin = sync.AddUserAccountsDuringSync;

                                        // Only create a login if requested, no logins exist and we have enough information to generate a user name.
                                        if ( createLogin && !person.Users.Any() && !string.IsNullOrWhiteSpace( person.NickName ) && !string.IsNullOrWhiteSpace( person.LastName ) )
                                        {
                                            newPassword = System.Web.Security.Membership.GeneratePassword( 9, 1 );
                                            string username = Rock.Security.Authentication.Database.GenerateUsername( person.NickName, person.LastName );

                                            UserLogin login = UserLoginService.Create(
                                                groupMemberContext,
                                                person,
                                                AuthenticationServiceType.Internal,
                                                EntityTypeCache.Get( Rock.SystemGuid.EntityType.AUTHENTICATION_DATABASE.AsGuid() ).Id,
                                                username,
                                                newPassword,
                                                true,
                                                requirePasswordReset );
                                        }

                                        // Send the welcome email
                                        var mergeFields = new Dictionary<string, object>();
                                        mergeFields.Add( "Group", sync.Group );
                                        mergeFields.Add( "Person", person );
                                        mergeFields.Add( "NewPassword", newPassword );
                                        mergeFields.Add( "CreateLogin", createLogin );
                                        var emailMessage = new RockEmailMessage( sync.WelcomeSystemCommunication );
                                        emailMessage.AddRecipient( new RockEmailMessageRecipient( person, mergeFields ) );
                                        var emailErrors = new List<string>();
                                        emailMessage.Send( out emailErrors );

                                        if ( emailErrors?.Any() == true )
                                        {
                                            emailErrors.ForEach( e => warningMessages.Add( $"Unable to send welcome email to '{groupName}' group member with person ID {personId}. Error: {e}" ) );
                                        }
                                    }
                                }
                            }
                        }
                        catch ( Exception ex )
                        {
                            ExceptionLogService.LogException( ex );
                            continue;
                        }
                    }

                    if ( hasSyncChanged )
                    {
                        groupIdsChanged.Add( groupId );
                    }

                    groupIdsSynced.Add( groupId );
                }

                // Update last refresh datetime in different context to avoid side-effects.
                using ( var rockContext = new RockContext() )
                {
                    var sync = new GroupSyncService( rockContext )
                        .Queryable()
                        .FirstOrDefault( s => s.Id == syncId );

                    sync.LastRefreshDateTime = RockDateTime.Now;

                    rockContext.SaveChanges();
                }
            }

            // Format the result message
            var groupsSyncedCount = groupIdsSynced.Count();
            var groupsChangedCount = groupIdsChanged.Count();

            var resultSb = new StringBuilder();
            var circleSuccess = "<i class='fa fa-circle text-success'></i>";
            resultSb.AppendLine( $"{circleSuccess} {groupsSyncedCount} {"group".PluralizeIf( groupsSyncedCount != 1 ).Titleize()} Synced{( groupsSyncedCount > 0 ? $" ({groupIdsSynced.AsDelimited( ", " )})" : string.Empty )}" );
            resultSb.AppendLine( $"{circleSuccess} {groupsChangedCount} {"group".PluralizeIf( groupsChangedCount != 1 ).Titleize()} Changed{( groupsChangedCount > 0 ? $" ({groupIdsChanged.AsDelimited( ", " )})" : string.Empty )}" );

            if ( groupsChangedCount > 0 )
            {
                resultSb.AppendLine( $"{circleSuccess} {deletedMemberCount} {"person".PluralizeIf( deletedMemberCount != 1 ).Titleize()} Deleted" );
                resultSb.AppendLine( $"{circleSuccess} {addedMemberCount} {"person".PluralizeIf( addedMemberCount != 1 ).Titleize()} Added" );
            }

            var circleWarning = "<i class='fa fa-circle text-warning'></i>";
            if ( notAddedMemberCount > 0 )
            {
                resultSb.AppendLine( $"{circleWarning} {notAddedMemberCount} {"person".PluralizeIf( notAddedMemberCount != 1 ).Titleize()} Could Not be Added" );
            }

            this.Result = resultSb.ToString();

            if ( warningMessages.Any() || warningExceptions.Any() )
            {
                resultSb.AppendLine();

                var warningException = new RockJobWarningException( "GroupSync completed with warnings." );

                if ( warningMessages.Any() )
                {
                    resultSb.AppendLine( $"{circleWarning} Enable 'Warning' logging level for 'Jobs' domain in Rock Logs and re-run this job to get a full list of issues." );
                    Log( Logging.RockLogLevel.Warning, $"{warningMessages.Count} {"warning".PluralizeIf( warningMessages.Count > 1 ).Titleize()}: {warningMessages.AsDelimited( " | " )}" );
                }

                if ( warningExceptions.Any() )
                {
                    resultSb.AppendLine( $"{circleWarning} One or more exceptions occurred. See exception log for details." );

                    var exceptionList = new AggregateException( "One or more exceptions occurred in GroupSync.", warningExceptions );
                    warningException = new RockJobWarningException( "GroupSync completed with warnings.", exceptionList );
                }

                this.Result = resultSb.ToString();

                throw warningException;
            }
        }

        private class GroupSyncInfo
        {
            public int SyncId { get; set; }

            public string GroupName { get; set; }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
// <copyright>
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

using System;
using System.Linq;

using Rock.Attribute;
using Rock.Data;
using Rock.ViewModels;
using Rock.ViewModels.Entities;
using Rock.Web.Cache;

namespace Rock.Model
{
    /// <summary>
    /// Schedule Service class
    /// </summary>
    public partial class ScheduleService : Service<Schedule>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScheduleService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public ScheduleService(RockContext context) : base(context)
        {
        }

        /// <summary>
        /// Determines whether this instance can delete the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>
        ///   <c>true</c> if this instance can delete the specified item; otherwise, <c>false</c>.
        /// </returns>
        public bool CanDelete( Schedule item, out string errorMessage )
        {
            errorMessage = string.Empty;

            // ignoring AttendanceOccurrence,ScheduleId

            if ( new Service<EventItemOccurrence>( Context ).Queryable().Any( a => a.ScheduleId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Schedule.FriendlyTypeName, EventItemOccurrence.FriendlyTypeName );
                return false;
            }

            if ( new Service<Group>( Context ).Queryable().Any( a => a.ScheduleId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Schedule.FriendlyTypeName, Group.FriendlyTypeName );
                return false;
            }

            if ( new Service<GroupHistorical>( Context ).Queryable().Any( a => a.ScheduleId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Schedule.FriendlyTypeName, GroupHistorical.FriendlyTypeName );
                return false;
            }

            if ( new Service<GroupLocationHistoricalSchedule>( Context ).Queryable().Any( a => a.ScheduleId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Schedule.FriendlyTypeName, GroupLocationHistoricalSchedule.FriendlyTypeName );
                return false;
            }

            if ( new Service<GroupMemberAssignment>( Context ).Queryable().Any( a => a.ScheduleId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Schedule.FriendlyTypeName, GroupMemberAssignment.FriendlyTypeName );
                return false;
            }

            if ( new Service<GroupMemberScheduleTemplate>( Context ).Queryable().Any( a => a.ScheduleId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Schedule.FriendlyTypeName, GroupMemberScheduleTemplate.FriendlyTypeName );
                return false;
            }

            if ( new Service<Metric>( Context ).Queryable().Any( a => a.ScheduleId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Schedule.FriendlyTypeName, Metric.FriendlyTypeName );
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// Schedule View Model Helper
    /// </summary>
    [DefaultViewModelHelper( typeof( Schedule ) )]
    public partial class ScheduleViewModelHelper : ViewModelHelper<Schedule, ScheduleBag>
    {
        /// <summary>
        /// Converts the model to a view model.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public override ScheduleBag CreateViewModel( Schedule model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return default;
            }

            var viewModel = new ScheduleBag
            {
                Id = model.Id,
                IdKey = model.IdKey,
                Guid = model.Guid,
                AutoInactivateWhenComplete = model.AutoInactivateWhenComplete,
                CategoryId = model.CategoryId,
                CheckInEndOffsetMinutes = model.CheckInEndOffsetMinutes,
                CheckInStartOffsetMinutes = model.CheckInStartOffsetMinutes,
                Description = model.Description,
                EffectiveEndDate = model.EffectiveEndDate,
                EffectiveStartDate = model.EffectiveStartDate,
                iCalendarContent = model.iCalendarContent,
                IsActive = model.IsActive,
                Name = model.Name,
                Order = model.Order,
                WeeklyDayOfWeek = ( int? ) model.WeeklyDayOfWeek,
                CreatedDateTime = model.CreatedDateTime,
                ModifiedDateTime = model.ModifiedDateTime,
                CreatedByPersonAliasId = model.CreatedByPersonAliasId,
                ModifiedByPersonAliasId = model.ModifiedByPersonAliasId,
            };

            AddAttributesToViewModel( model, viewModel, currentPerson, loadAttributes );
            ApplyAdditionalPropertiesAndSecurityToViewModel( model, viewModel, currentPerson, loadAttributes );
            return viewModel;
        }
    }


    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static partial class ScheduleExtensionMethods
    {
        /// <summary>
        /// Clones this Schedule object to a new Schedule object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static Schedule Clone( this Schedule source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as Schedule;
            }
            else
            {
                var target = new Schedule();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this Schedule object to a new Schedule object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static Schedule CloneWithoutIdentity( this Schedule source )
        {
            var target = new Schedule();
            target.CopyPropertiesFrom( source );

            target.Id = 0;
            target.Guid = Guid.NewGuid();
            target.ForeignKey = null;
            target.ForeignId = null;
            target.ForeignGuid = null;
            target.CreatedByPersonAliasId = null;
            target.CreatedDateTime = RockDateTime.Now;
            target.ModifiedByPersonAliasId = null;
            target.ModifiedDateTime = RockDateTime.Now;

            return target;
        }

        /// <summary>
        /// Copies the properties from another Schedule object to this Schedule object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this Schedule target, Schedule source )
        {
            target.Id = source.Id;
            target.AutoInactivateWhenComplete = source.AutoInactivateWhenComplete;
            target.CategoryId = source.CategoryId;
            target.CheckInEndOffsetMinutes = source.CheckInEndOffsetMinutes;
            target.CheckInStartOffsetMinutes = source.CheckInStartOffsetMinutes;
            target.Description = source.Description;
            target.EffectiveEndDate = source.EffectiveEndDate;
            target.EffectiveStartDate = source.EffectiveStartDate;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.iCalendarContent = source.iCalendarContent;
            target.IsActive = source.IsActive;
            target.Name = source.Name;
            target.Order = source.Order;
            target.WeeklyDayOfWeek = source.WeeklyDayOfWeek;
            target.WeeklyTimeOfDay = source.WeeklyTimeOfDay;
            target.CreatedDateTime = source.CreatedDateTime;
            target.ModifiedDateTime = source.ModifiedDateTime;
            target.CreatedByPersonAliasId = source.CreatedByPersonAliasId;
            target.ModifiedByPersonAliasId = source.ModifiedByPersonAliasId;
            target.Guid = source.Guid;
            target.ForeignId = source.ForeignId;

        }

        /// <summary>
        /// Creates a view model from this entity
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson" >The currentPerson.</param>
        /// <param name="loadAttributes" >Load attributes?</param>
        public static ScheduleBag ToViewModel( this Schedule model, Person currentPerson = null, bool loadAttributes = false )
        {
            var helper = new ScheduleViewModelHelper();
            var viewModel = helper.CreateViewModel( model, currentPerson, loadAttributes );
            return viewModel;
        }

    }

}

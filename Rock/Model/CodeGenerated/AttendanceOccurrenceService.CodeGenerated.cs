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
using Rock.ViewModel;
using Rock.Web.Cache;

namespace Rock.Model
{
    /// <summary>
    /// AttendanceOccurrence Service class
    /// </summary>
    public partial class AttendanceOccurrenceService : Service<AttendanceOccurrence>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttendanceOccurrenceService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public AttendanceOccurrenceService(RockContext context) : base(context)
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
        public bool CanDelete( AttendanceOccurrence item, out string errorMessage )
        {
            errorMessage = string.Empty;

            // ignoring Attendance,OccurrenceId
            return true;
        }
    }

    /// <summary>
    /// AttendanceOccurrence View Model Helper
    /// </summary>
    [DefaultViewModelHelper( typeof( AttendanceOccurrence ) )]
    public partial class AttendanceOccurrenceViewModelHelper : ViewModelHelper<AttendanceOccurrence, Rock.ViewModel.AttendanceOccurrenceViewModel>
    {
        /// <summary>
        /// Converts the model to a view model.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public override Rock.ViewModel.AttendanceOccurrenceViewModel CreateViewModel( AttendanceOccurrence model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return default;
            }

            var viewModel = new Rock.ViewModel.AttendanceOccurrenceViewModel
            {
                Id = model.Id,
                Guid = model.Guid,
                AcceptConfirmationMessage = model.AcceptConfirmationMessage,
                AnonymousAttendanceCount = model.AnonymousAttendanceCount,
                AttendanceTypeValueId = model.AttendanceTypeValueId,
                DeclineConfirmationMessage = model.DeclineConfirmationMessage,
                DeclineReasonValueIds = model.DeclineReasonValueIds,
                DidNotOccur = model.DidNotOccur,
                GroupId = model.GroupId,
                LocationId = model.LocationId,
                Name = model.Name,
                Notes = model.Notes,
                OccurrenceDate = model.OccurrenceDate,
                ScheduleId = model.ScheduleId,
                ShowDeclineReasons = model.ShowDeclineReasons,
                StepTypeId = model.StepTypeId,
                SundayDate = model.SundayDate,
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
    public static partial class AttendanceOccurrenceExtensionMethods
    {
        /// <summary>
        /// Clones this AttendanceOccurrence object to a new AttendanceOccurrence object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static AttendanceOccurrence Clone( this AttendanceOccurrence source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as AttendanceOccurrence;
            }
            else
            {
                var target = new AttendanceOccurrence();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this AttendanceOccurrence object to a new AttendanceOccurrence object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static AttendanceOccurrence CloneWithoutIdentity( this AttendanceOccurrence source )
        {
            var target = new AttendanceOccurrence();
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
        /// Copies the properties from another AttendanceOccurrence object to this AttendanceOccurrence object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this AttendanceOccurrence target, AttendanceOccurrence source )
        {
            target.Id = source.Id;
            target.AcceptConfirmationMessage = source.AcceptConfirmationMessage;
            target.AnonymousAttendanceCount = source.AnonymousAttendanceCount;
            target.AttendanceTypeValueId = source.AttendanceTypeValueId;
            target.DeclineConfirmationMessage = source.DeclineConfirmationMessage;
            target.DeclineReasonValueIds = source.DeclineReasonValueIds;
            target.DidNotOccur = source.DidNotOccur;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.GroupId = source.GroupId;
            target.LocationId = source.LocationId;
            target.Name = source.Name;
            target.Notes = source.Notes;
            target.OccurrenceDate = source.OccurrenceDate;
            target.ScheduleId = source.ScheduleId;
            target.ShowDeclineReasons = source.ShowDeclineReasons;
            target.StepTypeId = source.StepTypeId;
            target.SundayDate = source.SundayDate;
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
        public static Rock.ViewModel.AttendanceOccurrenceViewModel ToViewModel( this AttendanceOccurrence model, Person currentPerson = null, bool loadAttributes = false )
        {
            var helper = new AttendanceOccurrenceViewModelHelper();
            var viewModel = helper.CreateViewModel( model, currentPerson, loadAttributes );
            return viewModel;
        }

    }

}

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
    /// DataView Service class
    /// </summary>
    public partial class DataViewService : Service<DataView>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataViewService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public DataViewService(RockContext context) : base(context)
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
        public bool CanDelete( DataView item, out string errorMessage )
        {
            errorMessage = string.Empty;

            if ( new Service<ConnectionStatusAutomation>( Context ).Queryable().Any( a => a.DataViewId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", DataView.FriendlyTypeName, ConnectionStatusAutomation.FriendlyTypeName );
                return false;
            }

            // ignoring DataViewFilter,DataViewId

            if ( new Service<DataViewFilter>( Context ).Queryable().Any( a => a.RelatedDataViewId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", DataView.FriendlyTypeName, DataViewFilter.FriendlyTypeName );
                return false;
            }

            if ( new Service<FinancialTransactionAlertType>( Context ).Queryable().Any( a => a.DataViewId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", DataView.FriendlyTypeName, FinancialTransactionAlertType.FriendlyTypeName );
                return false;
            }

            if ( new Service<GroupRequirementType>( Context ).Queryable().Any( a => a.DataViewId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", DataView.FriendlyTypeName, GroupRequirementType.FriendlyTypeName );
                return false;
            }

            if ( new Service<GroupRequirementType>( Context ).Queryable().Any( a => a.WarningDataViewId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", DataView.FriendlyTypeName, GroupRequirementType.FriendlyTypeName );
                return false;
            }

            if ( new Service<GroupSync>( Context ).Queryable().Any( a => a.SyncDataViewId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", DataView.FriendlyTypeName, GroupSync.FriendlyTypeName );
                return false;
            }

            if ( new Service<Metric>( Context ).Queryable().Any( a => a.DataViewId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", DataView.FriendlyTypeName, Metric.FriendlyTypeName );
                return false;
            }

            if ( new Service<PersonalizationSegment>( Context ).Queryable().Any( a => a.FilterDataViewId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", DataView.FriendlyTypeName, PersonalizationSegment.FriendlyTypeName );
                return false;
            }

            if ( new Service<Report>( Context ).Queryable().Any( a => a.DataViewId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", DataView.FriendlyTypeName, Report.FriendlyTypeName );
                return false;
            }

            if ( new Service<StepType>( Context ).Queryable().Any( a => a.AudienceDataViewId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", DataView.FriendlyTypeName, StepType.FriendlyTypeName );
                return false;
            }

            if ( new Service<StepType>( Context ).Queryable().Any( a => a.AutoCompleteDataViewId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", DataView.FriendlyTypeName, StepType.FriendlyTypeName );
                return false;
            }
            return true;
        }
    }

    /// <summary>
    /// DataView View Model Helper
    /// </summary>
    [DefaultViewModelHelper( typeof( DataView ) )]
    public partial class DataViewViewModelHelper : ViewModelHelper<DataView, DataViewBag>
    {
        /// <summary>
        /// Converts the model to a view model.
        /// </summary>
        /// <param name="model">The entity.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public override DataViewBag CreateViewModel( DataView model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return default;
            }

            var viewModel = new DataViewBag
            {
                IdKey = model.IdKey,
                CategoryId = model.CategoryId,
                DataViewFilterId = model.DataViewFilterId,
                Description = model.Description,
                EntityTypeId = model.EntityTypeId,
                IncludeDeceased = model.IncludeDeceased,
                IsSystem = model.IsSystem,
                LastRunDateTime = model.LastRunDateTime,
                Name = model.Name,
                PersistedLastRefreshDateTime = model.PersistedLastRefreshDateTime,
                PersistedLastRunDurationMilliseconds = model.PersistedLastRunDurationMilliseconds,
                PersistedScheduleIntervalMinutes = model.PersistedScheduleIntervalMinutes,
                RunCount = model.RunCount,
                RunCountLastRefreshDateTime = model.RunCountLastRefreshDateTime,
                TimeToRunDurationMilliseconds = model.TimeToRunDurationMilliseconds,
                TransformEntityTypeId = model.TransformEntityTypeId,
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
    public static partial class DataViewExtensionMethods
    {
        /// <summary>
        /// Clones this DataView object to a new DataView object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static DataView Clone( this DataView source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as DataView;
            }
            else
            {
                var target = new DataView();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this DataView object to a new DataView object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static DataView CloneWithoutIdentity( this DataView source )
        {
            var target = new DataView();
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
        /// Copies the properties from another DataView object to this DataView object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this DataView target, DataView source )
        {
            target.Id = source.Id;
            target.CategoryId = source.CategoryId;
            target.DataViewFilterId = source.DataViewFilterId;
            target.Description = source.Description;
            target.EntityTypeId = source.EntityTypeId;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.IncludeDeceased = source.IncludeDeceased;
            target.IsSystem = source.IsSystem;
            target.LastRunDateTime = source.LastRunDateTime;
            target.Name = source.Name;
            target.PersistedLastRefreshDateTime = source.PersistedLastRefreshDateTime;
            target.PersistedLastRunDurationMilliseconds = source.PersistedLastRunDurationMilliseconds;
            target.PersistedScheduleIntervalMinutes = source.PersistedScheduleIntervalMinutes;
            target.RunCount = source.RunCount;
            target.RunCountLastRefreshDateTime = source.RunCountLastRefreshDateTime;
            target.TimeToRunDurationMilliseconds = source.TimeToRunDurationMilliseconds;
            target.TransformEntityTypeId = source.TransformEntityTypeId;
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
        public static DataViewBag ToViewModel( this DataView model, Person currentPerson = null, bool loadAttributes = false )
        {
            var helper = new DataViewViewModelHelper();
            var viewModel = helper.CreateViewModel( model, currentPerson, loadAttributes );
            return viewModel;
        }

    }

}

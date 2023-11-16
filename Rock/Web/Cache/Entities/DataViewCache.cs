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
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

using Rock.Data;
using Rock.Model;
using Rock.Reporting;

namespace Rock.Web.Cache
{
    /// <summary>
    /// Information about a DataView that can be added to a short-term cache.
    /// </summary>
    [Serializable]
    [DataContract]
    public class DataViewCache : ModelCache<DataViewCache, DataView>, IDataViewDefinition
    {
        #region Properties

        /// <inheritdoc cref="Rock.Model.DataView.IsSystem" />
        [DataMember]
        public bool IsSystem { get; private set; }

        /// <inheritdoc cref="Rock.Model.DataView.Name" />
        [DataMember]
        public string Name { get; private set; }

        /// <inheritdoc cref="Rock.Model.DataView.Description" />
        [DataMember]
        public string Description { get; private set; }

        /// <inheritdoc cref="Rock.Model.DataView.CategoryId" />
        [DataMember]
        public int? CategoryId { get; private set; }

        /// <inheritdoc cref="Rock.Model.DataView.EntityTypeId" />
        [DataMember( IsRequired = true )]
        public int? EntityTypeId { get; private set; }

        /// <inheritdoc cref="Rock.Model.DataView.DataViewFilterId" />
        [DataMember]
        public int? DataViewFilterId { get; private set; }

        /// <inheritdoc cref="Rock.Model.DataView.TransformEntityTypeId" />
        [DataMember]
        public int? TransformEntityTypeId { get; private set; }

        /// <inheritdoc cref="Rock.Model.DataView.PersistedScheduleIntervalMinutes" />
        [DataMember]
        public int? PersistedScheduleIntervalMinutes { get; private set; }

        /// <inheritdoc cref="Rock.Model.DataView.PersistedLastRefreshDateTime" />
        [DataMember]
        public DateTime? PersistedLastRefreshDateTime { get; private set; }

        /// <inheritdoc cref="Rock.Model.DataView.IncludeDeceased" />
        [DataMember]
        public bool IncludeDeceased { get; private set; }

        /// <inheritdoc cref="Rock.Model.DataView.PersistedLastRunDurationMilliseconds" />
        [DataMember]
        public int? PersistedLastRunDurationMilliseconds { get; private set; }

        /// <inheritdoc cref="Rock.Model.DataView.LastRunDateTime" />
        [DataMember]
        public DateTime? LastRunDateTime { get; private set; }

        /// <inheritdoc cref="Rock.Model.DataView.RunCount" />
        [DataMember]
        public int? RunCount { get; private set; }

        /// <inheritdoc cref="Rock.Model.DataView.TimeToRunDurationMilliseconds" />
        [DataMember]
        public double? TimeToRunDurationMilliseconds { get; private set; }

        /// <inheritdoc cref="Rock.Model.DataView.RunCountLastRefreshDateTime" />
        [DataMember]
        public DateTime? RunCountLastRefreshDateTime { get; private set; }

        /// <inheritdoc cref="Rock.Model.DataView.DisableUseOfReadOnlyContext" />
        [DataMember]
        public bool DisableUseOfReadOnlyContext { get; private set; }

        /// <inheritdoc cref="Rock.Model.DataView.PersistedScheduleId" />
        [DataMember]
        public int? PersistedScheduleId { get; private set; }

        /// <summary>
        /// Gets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public CategoryCache Category
        {
            get
            {
                if ( CategoryId.HasValue )
                {
                    return CategoryCache.Get( CategoryId.Value );
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the type of the field.
        /// </summary>
        /// <value>
        /// The type of the field.
        /// </value>
        public EntityTypeCache EntityType
        {
            get
            {
                if ( EntityTypeId.HasValue )
                {
                    return EntityTypeCache.Get( EntityTypeId.Value );
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the top-level filter.
        /// </summary>
        /// <value>
        /// The data view filter.
        /// </value>
        public DataViewFilterCache DataViewFilter
        {
            get
            {
                if ( DataViewFilterId.HasValue )
                {
                    if ( !_dataViewFiltersLoaded )
                    {
                        // Load the entire filter tree into the cache.
                        LoadDataViewFilters();
                    }

                    return DataViewFilterCache.Get( DataViewFilterId.Value );
                }

                return null;
            }
        }

        #endregion

        #region IDataViewDefinition implementation

        IDataViewFilterDefinition IDataViewDefinition.DataViewFilter
        {
            get
            {
                return this.DataViewFilter;
            }
        }

        #endregion

        private bool _dataViewFiltersLoaded = false;
        private readonly object _childFiltersLock = new object();

        private void LoadDataViewFilters()
        {
            var rockContext = new RockContext();

            List<DataViewFilterInfo> dataViewFilterIdList = null;

            if ( _dataViewFiltersLoaded )
            {
                return;
            }

            lock ( _childFiltersLock )
            {
                // Re-test the load flag after gaining the lock.
                if ( _dataViewFiltersLoaded )
                {
                    return;
                }

                // Load all of the the DataViewFilters associated with this DataView
                // into the cache with a single query.
                dataViewFilterIdList = new DataViewFilterService( rockContext )
                .Queryable()
                .Where( f => f.DataViewId == Id )
                .Select( f => new DataViewFilterInfo { Id = f.Id, ParentId = f.ParentId } )
                .ToList();

                _dataViewFiltersLoaded = true;

                // Load the DataViewFilter objects into the cache.
                DataViewFilterCache.GetMany( dataViewFilterIdList.Select( t => t.Id ).ToList(), rockContext );

                // Populate the DataViewFilter cache entries with the key values of their immediate children.
                // These references are used to retrieve the cached entries when they are referenced.
                var parentFilter = DataViewFilterCache.Get( DataViewFilterId.Value );

                LoadChildFilters( parentFilter, dataViewFilterIdList );
            }
        }

        private void LoadChildFilters( DataViewFilterCache parentFilter, List<DataViewFilterInfo> filterList )
        {
            if ( parentFilter == null )
            {
                return;
            }

            // Get the immediate children of the specified parent.
            var childFilters = filterList.Where( f => f.ParentId == parentFilter.Id ).ToList();
            if ( childFilters == null || !childFilters.Any() )
            {
                return;
            }

            // Set the child references for the parent.
            parentFilter.SetChildFilterIdList( childFilters.Select( f => f.Id ).ToList() );

            // Set the child references for each immediate child of this parent.
            foreach ( var childFilter in childFilters )
            {
                var childFilterCache = DataViewFilterCache.Get( childFilter.Id );

                LoadChildFilters( childFilterCache, filterList );
            }
        }

        #region Public Methods

        /// <summary>
        /// Returns true if this DataView is configured to be Persisted.
        /// </summary>
        /// <returns><c>true</c> if this instance is persisted; otherwise, <c>false</c>.</returns>
        public bool IsPersisted()
        {
            return this.PersistedScheduleIntervalMinutes.HasValue || this.PersistedScheduleId.HasValue;
        }

        /// <summary>
        /// Copies from model.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void SetFromEntity( IEntity entity )
        {
            base.SetFromEntity( entity );

            var dataView = entity as DataView;
            if ( dataView == null )
            {
                return;
            }

            CategoryId = dataView.CategoryId;
            DataViewFilterId = dataView.DataViewFilterId;
            Description = dataView.Description;
            DisableUseOfReadOnlyContext = dataView.DisableUseOfReadOnlyContext;
            EntityTypeId = dataView.EntityTypeId;
            IncludeDeceased = dataView.IncludeDeceased;
            IsSystem = dataView.IsSystem;
            LastRunDateTime = dataView.LastRunDateTime;
            Name = dataView.Name;
            PersistedLastRefreshDateTime = dataView.PersistedLastRefreshDateTime;
            PersistedLastRunDurationMilliseconds = dataView.PersistedLastRunDurationMilliseconds;
            PersistedScheduleId = dataView.PersistedScheduleId;
            PersistedScheduleIntervalMinutes = dataView.PersistedScheduleIntervalMinutes;
            RunCount = dataView.RunCount;
            RunCountLastRefreshDateTime = dataView.RunCountLastRefreshDateTime;
            TimeToRunDurationMilliseconds = dataView.TimeToRunDurationMilliseconds;
            TransformEntityTypeId = dataView.TransformEntityTypeId;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Name;
        }

        #endregion

        #region ICacheable Implementation

        /// <summary>
        /// Removes a DataView from cache.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public new static void Remove( int id )
        {
            var dataViewCache = Get( id );
            if ( dataViewCache != null )
            {
                // Recursively remove all of the DataViewFilters associated with this DataView.
                DataViewFilterCache.Remove( dataViewCache.DataViewFilterId.GetValueOrDefault() );
            }

            Remove( id.ToString() );
        }

        #endregion

        #region Support classes

        private class DataViewFilterInfo
        {
            public int Id { get; set; }
            public int? ParentId { get; set; }
        }

        #endregion
    }
}
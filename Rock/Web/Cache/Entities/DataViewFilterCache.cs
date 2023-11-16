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
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;

using Rock.Data;
using Rock.Model;
using Rock.Reporting;

namespace Rock.Web.Cache
{
    /// <summary>
    /// A cache representation of a DataViewFilter.
    /// </summary>
    [Serializable]
    [DataContract]
    public class DataViewFilterCache : ModelCache<DataViewFilterCache, DataViewFilter>, IDataViewFilterDefinition
    {
        #region Properties

        /// <inheritdoc cref="Rock.Model.DataViewFilter.ExpressionType" />
        [DataMember]
        public FilterExpressionType ExpressionType { get; private set; }

        /// <inheritdoc cref="Rock.Model.DataViewFilter.ParentId" />
        [DataMember]
        public int? ParentId { get; private set; }

        /// <inheritdoc cref="Rock.Model.DataViewFilter.EntityTypeId" />
        [DataMember]
        public int? EntityTypeId { get; private set; }

        /// <inheritdoc cref="Rock.Model.DataViewFilter.Selection" />
        [DataMember]
        public string Selection { get; private set; }

        /// <inheritdoc cref="Rock.Model.DataViewFilter.DataViewId" />
        [DataMember]
        public int? DataViewId { get; private set; }

        /// <inheritdoc cref="Rock.Model.DataViewFilter.RelatedDataViewId" />
        [DataMember]
        public int? RelatedDataViewId { get; private set; }

        /// <summary>
        /// Gets the child filters of this filter.
        /// </summary>
        /// <value>
        /// The child filters.
        /// </value>
        public List<DataViewFilterCache> ChildFilters
        {
            get
            {
                var filters = new List<DataViewFilterCache>();

                var childFilterIdList = GetChildFilterIdList();
                if ( childFilterIdList == null )
                {
                    return filters;
                }

                // Materialize the child filters by retrieving them from the cache.
                foreach ( var id in childFilterIdList )
                {
                    var filter = DataViewFilterCache.Get( id );
                    if ( filter != null )
                    {
                        filters.Add( filter );
                    }
                }

                return filters;
            }
        }

        private List<int> _childFilterIdList;
        private object _childFilterLoadLock = new object();

        /// <summary>
        /// Get all of the filters that are immediate child filters of this filter.
        /// </summary>
        /// <returns></returns>
        private List<int> GetChildFilterIdList()
        {
            if ( _childFilterIdList == null )
            {
                lock ( _childFilterLoadLock )
                {
                    if ( _childFilterIdList == null )
                    {
                        using ( var rockContext = new RockContext() )
                        {
                            var dataViewService = new DataViewFilterService( rockContext );
                            _childFilterIdList = dataViewService.Queryable()
                                .AsNoTracking()
                                .Where( a => a.ParentId == this.Id )
                                .Select( v => v.Id )
                                .ToList();
                        }
                    }
                }
            }

            return _childFilterIdList;
        }

        /// <summary>
        /// Set the list of identifiers for the immediate child filters of this filter.
        /// </summary>
        /// <param name="childFilterIdList"></param>
        /// <remarks>
        /// To improve performance, the entire filter tree for a DataView is populated when the
        /// root filter of the DataView is accessed. See <see cref="DataViewCache.LoadDataViewFilters()" />
        /// </remarks>
        public void SetChildFilterIdList( List<int> childFilterIdList )
        {
            if ( childFilterIdList == null )
            {
                _childFilterIdList = new List<int>();
            }
            else
            {
                _childFilterIdList = new List<int>( childFilterIdList );
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the cached objects properties from the model/entity properties.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public override void SetFromEntity( IEntity entity )
        {
            base.SetFromEntity( entity );

            var dataViewFilter = entity as DataViewFilter;
            if ( dataViewFilter == null )
            {
                return;
            }

            ExpressionType = dataViewFilter.ExpressionType;
            ParentId = dataViewFilter.ParentId;
            EntityTypeId = dataViewFilter.EntityTypeId;
            Selection = dataViewFilter.Selection;
            DataViewId = dataViewFilter.DataViewId;
            RelatedDataViewId = dataViewFilter.RelatedDataViewId;

            _childFilterIdList = null;
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"[{ExpressionType}] DataViewId={DataViewId}, Selection={Selection}";
        }

        #endregion

        #region ICacheable implementation

        /// <summary>
        /// Removes a DataViewFilter from the cache.
        /// </summary>
        /// <param name="id">The identifier.</param>
        public new static void Remove( int id )
        {
            var filter = Get( id );
            if ( filter != null )
            {
                // Remove any child filters before removing this filter.
                foreach ( var childFilter in filter.ChildFilters )
                {
                    Remove( childFilter.Id );
                }
            }

            Remove( id.ToString() );
        }

        #endregion

        #region IDataViewFilterDefinition implementation

        Guid? IDataViewFilterDefinition.Guid => this.Guid;

        IDataViewDefinition IDataViewFilterDefinition.DataView
        {
            get
            {
                return DataViewCache.Get( this.DataViewId.GetValueOrDefault() );
            }
        }

        ICollection<IDataViewFilterDefinition> IDataViewFilterDefinition.ChildFilters
        {
            get
            {
                return ChildFilters.Cast<IDataViewFilterDefinition>().ToList();
            }
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
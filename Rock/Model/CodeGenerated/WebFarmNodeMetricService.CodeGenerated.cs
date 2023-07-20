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
using System.Collections.Generic;
using System.Linq;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// WebFarmNodeMetric Service class
    /// </summary>
    public partial class WebFarmNodeMetricService : Service<WebFarmNodeMetric>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebFarmNodeMetricService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public WebFarmNodeMetricService(RockContext context) : base(context)
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
        public bool CanDelete( WebFarmNodeMetric item, out string errorMessage )
        {
            errorMessage = string.Empty;
            return true;
        }
    }

    public partial class WebFarmNodeMetric : IHasQueryableAttributes<WebFarmNodeMetric.WebFarmNodeMetricQueryableAttributeValue>
    {
        /// <inheritdoc/>
        public virtual ICollection<WebFarmNodeMetricQueryableAttributeValue> EntityAttributeValues { get; set; } 

        /// <inheritdoc/>
        public class WebFarmNodeMetricQueryableAttributeValue : QueryableAttributeValue
        {
        }
    }

    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static partial class WebFarmNodeMetricExtensionMethods
    {
        /// <summary>
        /// Clones this WebFarmNodeMetric object to a new WebFarmNodeMetric object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static WebFarmNodeMetric Clone( this WebFarmNodeMetric source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as WebFarmNodeMetric;
            }
            else
            {
                var target = new WebFarmNodeMetric();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Clones this WebFarmNodeMetric object to a new WebFarmNodeMetric object with default values for the properties in the Entity and Model base classes.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public static WebFarmNodeMetric CloneWithoutIdentity( this WebFarmNodeMetric source )
        {
            var target = new WebFarmNodeMetric();
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
        /// Copies the properties from another WebFarmNodeMetric object to this WebFarmNodeMetric object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this WebFarmNodeMetric target, WebFarmNodeMetric source )
        {
            target.Id = source.Id;
            target.ForeignGuid = source.ForeignGuid;
            target.ForeignKey = source.ForeignKey;
            target.MetricType = source.MetricType;
            target.MetricValue = source.MetricValue;
            target.MetricValueDateTime = source.MetricValueDateTime;
            target.Note = source.Note;
            target.WebFarmNodeId = source.WebFarmNodeId;
            target.CreatedDateTime = source.CreatedDateTime;
            target.ModifiedDateTime = source.ModifiedDateTime;
            target.CreatedByPersonAliasId = source.CreatedByPersonAliasId;
            target.ModifiedByPersonAliasId = source.ModifiedByPersonAliasId;
            target.Guid = source.Guid;
            target.ForeignId = source.ForeignId;

        }
    }
}

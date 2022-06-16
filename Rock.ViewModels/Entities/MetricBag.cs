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
//

using System;
using System.Linq;

using Rock.ViewModels.Utility;

namespace Rock.ViewModels.Entities
{
    /// <summary>
    /// Metric View Model
    /// </summary>
    public partial class MetricBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets the admin person alias identifier.
        /// </summary>
        /// <value>
        /// The admin person alias identifier.
        /// </value>
        public int? AdminPersonAliasId { get; set; }

        /// <summary>
        /// If set to true this feature will auto partition the individuals in the data view based on their primary campus.
        /// </summary>
        /// <value>
        ///   true if [automatic partition on primary campus]; otherwise, false.
        /// </value>
        public bool AutoPartitionOnPrimaryCampus { get; set; }

        /// <summary>
        /// Gets or sets the data view identifier.
        /// </summary>
        /// <value>
        /// The data view identifier.
        /// </value>
        public int? DataViewId { get; set; }

        /// <summary>
        /// Gets or sets a user defined description of the Metric.
        /// </summary>
        /// <value>
        /// A System.String representing the description of the Metric.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable analytics].
        /// If this is enabled, a SQL View named 'AnalyticsFactMetric{{Metric.Name}}' will be made available that can be used by Analytic tools, such as Power BI
        /// </summary>
        /// <value>
        ///   true if [enable analytics]; otherwise, false.
        /// </value>
        public bool EnableAnalytics { get; set; }

        /// <summary>
        /// Gets or sets the icon CSS class.
        /// </summary>
        /// <value>
        /// The icon CSS class.
        /// </value>
        public string IconCssClass { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [is cumulative].
        /// </summary>
        /// <value>
        ///   true if [is cumulative]; otherwise, false.
        /// </value>
        public bool IsCumulative { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if this Metric is part of the Rock core system/framework. This property is required.
        /// </summary>
        /// <value>
        /// A System.Boolean that is true if the Metric is part of the core system/framework; otherwise false.
        /// </value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// For SQL or DataView based Metrics, this is the DateTime that the MetricValues where scheduled to be updated according to Schedule
        /// </summary>
        /// <value>
        /// The last run date time.
        /// </value>
        public DateTime? LastRunDateTime { get; set; }

        /// <summary>
        /// Gets or sets the metric champion person alias identifier.
        /// </summary>
        /// <value>
        /// The metric champion person alias identifier.
        /// </value>
        public int? MetricChampionPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the type of the numeric data that the values represent. Although all values
        /// are stored as a decimal, specifying the type here allows entry screens to use appropriate
        /// controls/validation when entering values.
        /// </summary>
        /// <value>
        /// The type of the numeric data.
        /// </value>
        public int NumericDataType { get; set; }

        /// <summary>
        /// Gets or sets the schedule identifier.
        /// </summary>
        /// <value>
        /// The schedule identifier.
        /// </value>
        public int? ScheduleId { get; set; }

        /// <summary>
        /// Gets or sets the Lava code that returns the data for the Metric.
        /// </summary>
        /// <value>
        /// A System.String that represents the Lava code that returns the data for the Metric.
        /// </value>
        public string SourceLava { get; set; }

        /// <summary>
        /// Gets or sets the SQL query that returns the data for the Metric.
        /// </summary>
        /// <value>
        /// A System.String that represents the SQL Query that returns the data for the Metric.
        /// </value>
        public string SourceSql { get; set; }

        /// <summary>
        /// Gets or sets the source value type identifier.
        /// </summary>
        /// <value>
        /// The source value type identifier.
        /// </value>
        public int? SourceValueTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Subtitle of the Metric.
        /// </summary>
        /// <value>
        /// A System.String representing the Subtitle of the Metric.
        /// </value>
        public string Subtitle { get; set; }

        /// <summary>
        /// Gets or sets the Title of this Metric.
        /// </summary>
        /// <value>
        /// A System.String representing the user defined title of this Metric. This property is required.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the type of the unit.
        /// </summary>
        /// <value>
        /// The type of the unit.
        /// </value>
        public int UnitType { get; set; }

        /// <summary>
        /// Gets or sets the x axis label.
        /// Note that in Rock, graphs typically actually use the MetricValue.MetricValueDateTime as the graph's X Axis.
        /// Therefore, in most cases, Metric.XAxisLabel and MetricValue.XAxis are NOT used
        /// </summary>
        /// <value>
        /// The x axis label.
        /// </value>
        public string XAxisLabel { get; set; }

        /// <summary>
        /// Gets or sets the y axis label.
        /// </summary>
        /// <value>
        /// The y axis label.
        /// </value>
        public string YAxisLabel { get; set; }

        /// <summary>
        /// Gets or sets the created date time.
        /// </summary>
        /// <value>
        /// The created date time.
        /// </value>
        public DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the modified date time.
        /// </summary>
        /// <value>
        /// The modified date time.
        /// </value>
        public DateTime? ModifiedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the created by person alias identifier.
        /// </summary>
        /// <value>
        /// The created by person alias identifier.
        /// </value>
        public int? CreatedByPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the modified by person alias identifier.
        /// </summary>
        /// <value>
        /// The modified by person alias identifier.
        /// </value>
        public int? ModifiedByPersonAliasId { get; set; }

    }
}

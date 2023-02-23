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
    /// Schedule View Model
    /// </summary>
    public partial class ScheduleBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets the shortened name of the attribute.
        /// If null or whitespace then the full name is returned.
        /// </summary>
        /// <value>
        /// The name of the abbreviated.
        /// </value>
        public string AbbreviatedName { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [auto inactivate when complete].
        /// </summary>
        /// <value>
        ///   true if [auto inactivate when complete]; otherwise, false.
        /// </value>
        public bool AutoInactivateWhenComplete { get; set; }

        /// <summary>
        /// Gets or sets the CategoryId of the Rock.Model.Category that this Schedule belongs to.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the CategoryId of the Rock.Model.Category that this Schedule belongs to. This property will be null
        /// if the Schedule does not belong to a Category.
        /// </value>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the number of minutes following schedule start that Check-in should be active. 0 represents that Check-in will only be available
        /// until the Schedule's start time.
        /// </summary>
        /// <value>
        /// A System.Int32 representing how many minutes following the Schedule's end time that Check-in should be active. 0 represents that Check-in
        /// will only be available until the Schedule's start time.
        /// </value>
        public int? CheckInEndOffsetMinutes { get; set; }

        /// <summary>
        /// Gets or sets the number of minutes prior to the Schedule's start time  that Check-in should be active. 0 represents that Check-in 
        /// will not be available to the beginning of the event.
        /// </summary>
        /// <value>
        /// A System.Int32 representing how many minutes prior the Schedule's start time that Check-in should be active. 
        /// 0 means that Check-in will not be available to the Schedule's start time. This schedule will not be available if this value is Null.
        /// </value>
        public int? CheckInStartOffsetMinutes { get; set; }

        /// <summary>
        /// Gets or sets a user defined Description of the Schedule.
        /// </summary>
        /// <value>
        /// A System.String representing the Description of the Schedule.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets that date that this Schedule expires and becomes inactive. This value is inclusive and the schedule will be inactive after this date.
        /// </summary>
        /// <value>
        /// A System.DateTime value that represents the date that this Schedule ends and becomes inactive.
        /// </value>
        public DateTime? EffectiveEndDate { get; set; }

        /// <summary>
        /// Gets or sets the Date that the Schedule becomes effective/active. This property is inclusive, and the schedule will be inactive before this date. 
        /// </summary>
        /// <value>
        /// A System.DateTime value that represents the date that this Schedule becomes active.
        /// </value>
        public DateTime? EffectiveStartDate { get; set; }

        /// <summary>
        /// Gets or sets the content lines of the iCalendar
        /// </summary>
        /// <value>
        /// A System.Stringrepresenting the  content of the iCalendar.
        /// </value>
        public string iCalendarContent { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if this is an active schedule. This value is required.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if this schedule is active, otherwise false.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if this Schedule is public.
        /// </summary>
        /// <value>
        ///  A System.Boolean that is true if this Schedule is public, otherwise false.
        /// </value>
        public bool? IsPublic { get; set; }

        /// <summary>
        /// Gets or sets the Name of the Schedule. This property is required.
        /// </summary>
        /// <value>
        /// A System.String that represents the Name of the Schedule.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// Use List&lt;Schedule&gt;().OrderByOrderAndNextScheduledDateTime
        /// to get the schedules in the desired order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the weekly day of week.
        /// </summary>
        /// <value>
        /// The weekly day of week.
        /// </value>
        public int? WeeklyDayOfWeek { get; set; }

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

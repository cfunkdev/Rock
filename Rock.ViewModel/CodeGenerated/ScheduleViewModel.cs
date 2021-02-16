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

namespace Rock.ViewModel
{
    /// <summary>
    /// Schedule View Model
    /// </summary>
    [ViewModelOf( typeof( Rock.Model.Schedule ) )]
    public partial class ScheduleViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the CategoryId.
        /// </summary>
        /// <value>
        /// The CategoryId.
        /// </value>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the CheckInEndOffsetMinutes.
        /// </summary>
        /// <value>
        /// The CheckInEndOffsetMinutes.
        /// </value>
        public int? CheckInEndOffsetMinutes { get; set; }

        /// <summary>
        /// Gets or sets the CheckInStartOffsetMinutes.
        /// </summary>
        /// <value>
        /// The CheckInStartOffsetMinutes.
        /// </value>
        public int? CheckInStartOffsetMinutes { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>
        /// The Description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the EffectiveEndDate.
        /// </summary>
        /// <value>
        /// The EffectiveEndDate.
        /// </value>
        public DateTime? EffectiveEndDate { get; set; }

        /// <summary>
        /// Gets or sets the EffectiveStartDate.
        /// </summary>
        /// <value>
        /// The EffectiveStartDate.
        /// </value>
        public DateTime? EffectiveStartDate { get; set; }

        /// <summary>
        /// Gets or sets the iCalendarContent.
        /// </summary>
        /// <value>
        /// The iCalendarContent.
        /// </value>
        public string iCalendarContent { get; set; }

        /// <summary>
        /// Gets or sets the IsActive.
        /// </summary>
        /// <value>
        /// The IsActive.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>
        /// The Name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Order.
        /// </summary>
        /// <value>
        /// The Order.
        /// </value>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the WeeklyDayOfWeek.
        /// </summary>
        /// <value>
        /// The WeeklyDayOfWeek.
        /// </value>
        public int? WeeklyDayOfWeek { get; set; }

        /// <summary>
        /// Gets or sets the WeeklyTimeOfDay.
        /// </summary>
        /// <value>
        /// The WeeklyTimeOfDay.
        /// </value>
        public TimeSpan? WeeklyTimeOfDay { get; set; }

        /// <summary>
        /// Gets or sets the CreatedDateTime.
        /// </summary>
        /// <value>
        /// The CreatedDateTime.
        /// </value>
        public DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedDateTime.
        /// </summary>
        /// <value>
        /// The ModifiedDateTime.
        /// </value>
        public DateTime? ModifiedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the CreatedByPersonAliasId.
        /// </summary>
        /// <value>
        /// The CreatedByPersonAliasId.
        /// </value>
        public int? CreatedByPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the ModifiedByPersonAliasId.
        /// </summary>
        /// <value>
        /// The ModifiedByPersonAliasId.
        /// </value>
        public int? ModifiedByPersonAliasId { get; set; }

    }
}
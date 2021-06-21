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

namespace Rock.ViewModel
{
    /// <summary>
    /// Assessment View Model
    /// </summary>
    public partial class AssessmentViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the AssessmentResultData.
        /// </summary>
        /// <value>
        /// The AssessmentResultData.
        /// </value>
        public string AssessmentResultData { get; set; }

        /// <summary>
        /// Gets or sets the AssessmentTypeId.
        /// </summary>
        /// <value>
        /// The AssessmentTypeId.
        /// </value>
        public int AssessmentTypeId { get; set; }

        /// <summary>
        /// Gets or sets the CompletedDateTime.
        /// </summary>
        /// <value>
        /// The CompletedDateTime.
        /// </value>
        public DateTime? CompletedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the LastReminderDate.
        /// </summary>
        /// <value>
        /// The LastReminderDate.
        /// </value>
        public DateTime? LastReminderDate { get; set; }

        /// <summary>
        /// Gets or sets the PersonAliasId.
        /// </summary>
        /// <value>
        /// The PersonAliasId.
        /// </value>
        public int PersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the RequestedDateTime.
        /// </summary>
        /// <value>
        /// The RequestedDateTime.
        /// </value>
        public DateTime? RequestedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the RequestedDueDate.
        /// </summary>
        /// <value>
        /// The RequestedDueDate.
        /// </value>
        public DateTime? RequestedDueDate { get; set; }

        /// <summary>
        /// Gets or sets the RequesterPersonAliasId.
        /// </summary>
        /// <value>
        /// The RequesterPersonAliasId.
        /// </value>
        public int? RequesterPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        /// <value>
        /// The Status.
        /// </value>
        public int Status { get; set; }

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

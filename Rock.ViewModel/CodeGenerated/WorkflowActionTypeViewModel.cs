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
    /// WorkflowActionType View Model
    /// </summary>
    public partial class WorkflowActionTypeViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the ActivityTypeId.
        /// </summary>
        /// <value>
        /// The ActivityTypeId.
        /// </value>
        public int ActivityTypeId { get; set; }

        /// <summary>
        /// Gets or sets the CriteriaAttributeGuid.
        /// </summary>
        /// <value>
        /// The CriteriaAttributeGuid.
        /// </value>
        public Guid? CriteriaAttributeGuid { get; set; }

        /// <summary>
        /// Gets or sets the CriteriaComparisonType.
        /// </summary>
        /// <value>
        /// The CriteriaComparisonType.
        /// </value>
        public int CriteriaComparisonType { get; set; }

        /// <summary>
        /// Gets or sets the CriteriaValue.
        /// </summary>
        /// <value>
        /// The CriteriaValue.
        /// </value>
        public string CriteriaValue { get; set; }

        /// <summary>
        /// Gets or sets the EntityTypeId.
        /// </summary>
        /// <value>
        /// The EntityTypeId.
        /// </value>
        public int EntityTypeId { get; set; }

        /// <summary>
        /// Gets or sets the IsActionCompletedOnSuccess.
        /// </summary>
        /// <value>
        /// The IsActionCompletedOnSuccess.
        /// </value>
        public bool IsActionCompletedOnSuccess { get; set; }

        /// <summary>
        /// Gets or sets the IsActivityCompletedOnSuccess.
        /// </summary>
        /// <value>
        /// The IsActivityCompletedOnSuccess.
        /// </value>
        public bool IsActivityCompletedOnSuccess { get; set; }

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
        /// Gets or sets the WorkflowFormId.
        /// </summary>
        /// <value>
        /// The WorkflowFormId.
        /// </value>
        public int? WorkflowFormId { get; set; }

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

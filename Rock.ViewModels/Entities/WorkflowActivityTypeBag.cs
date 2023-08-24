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
    /// WorkflowActivityType View Model
    /// </summary>
    public partial class WorkflowActivityTypeBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets the description or summary about this WorkflowActivityType.
        /// </summary>
        /// <value>
        /// A System.String containing a description or summary about this WorkflowActivityType.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating if this WorkflowActivityType is activated with the workflow.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if this instance is activated with workflow; otherwise, false.
        /// </value>
        public bool IsActivatedWithWorkflow { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if this WorkflowActivityType is active.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if the WorkflowActivityType is active; otherwise false.
        /// </value>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Gets or sets the friendly Name of this WorkflowActivityType. This property is required.
        /// </summary>
        /// <value>
        /// A System.String representing the friendly name of this WorkflowActivityType
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the order that this WorkflowActivityType will be executed in the WorkflowType's process. 
        /// </summary>
        /// <value>
        /// A System.Int32 indicating the order that this Activity will be executed in the Workflow.
        /// </value>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the WorkflowTypeId of the Rock.Model.WorkflowType that this WorkflowActivityType belongs to.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the WorkflowTypeId of the Rock.Model.WorkflowType that this WorkflowActivityType belongs to.
        /// </value>
        public int WorkflowTypeId { get; set; }

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
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
using Rock.Attribute;
using Rock.Model;
using Rock.Web.Cache;

namespace Rock.ViewModel
{
    /// <summary>
    /// StepWorkflowTrigger View Model
    /// </summary>
    [ViewModelOf( typeof( Rock.Model.StepWorkflowTrigger ) )]
    public partial class StepWorkflowTriggerViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the IsActive.
        /// </summary>
        /// <value>
        /// The IsActive.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the StepProgramId.
        /// </summary>
        /// <value>
        /// The StepProgramId.
        /// </value>
        public int? StepProgramId { get; set; }

        /// <summary>
        /// Gets or sets the StepTypeId.
        /// </summary>
        /// <value>
        /// The StepTypeId.
        /// </value>
        public int? StepTypeId { get; set; }

        /// <summary>
        /// Gets or sets the TriggerType.
        /// </summary>
        /// <value>
        /// The TriggerType.
        /// </value>
        public int TriggerType { get; set; }

        /// <summary>
        /// Gets or sets the TypeQualifier.
        /// </summary>
        /// <value>
        /// The TypeQualifier.
        /// </value>
        public string TypeQualifier { get; set; }

        /// <summary>
        /// Gets or sets the WorkflowName.
        /// </summary>
        /// <value>
        /// The WorkflowName.
        /// </value>
        public string WorkflowName { get; set; }

        /// <summary>
        /// Gets or sets the WorkflowTypeId.
        /// </summary>
        /// <value>
        /// The WorkflowTypeId.
        /// </value>
        public int WorkflowTypeId { get; set; }

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

        /// <summary>
        /// Sets the properties from.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="currentPerson">The current person.</param>
        /// <param name="loadAttributes">if set to <c>true</c> [load attributes].</param>
        public virtual void SetPropertiesFrom( Rock.Model.StepWorkflowTrigger model, Person currentPerson = null, bool loadAttributes = true )
        {
            if ( model == null )
            {
                return;
            }

            if ( loadAttributes && model is IHasAttributes hasAttributes )
            {
                if ( hasAttributes.Attributes == null )
                {
                    hasAttributes.LoadAttributes();
                }

                Attributes = hasAttributes.AttributeValues.Where( av =>
                {
                    var attribute = AttributeCache.Get( av.Value.AttributeId );
                    return attribute?.IsAuthorized( Rock.Security.Authorization.EDIT, currentPerson ) ?? false;
                } ).ToDictionary(
                    kvp => kvp.Key,
                    kvp => kvp.Value.ToViewModel<AttributeValueViewModel>() as object );
            }

            IsActive = model.IsActive;
            StepProgramId = model.StepProgramId;
            StepTypeId = model.StepTypeId;
            TriggerType = ( int ) model.TriggerType;
            TypeQualifier = model.TypeQualifier;
            WorkflowName = model.WorkflowName;
            WorkflowTypeId = model.WorkflowTypeId;
            CreatedDateTime = model.CreatedDateTime;
            ModifiedDateTime = model.ModifiedDateTime;
            CreatedByPersonAliasId = model.CreatedByPersonAliasId;
            ModifiedByPersonAliasId = model.ModifiedByPersonAliasId;

            SetAdditionalPropertiesFrom( model, currentPerson, loadAttributes );
        }

        /// <summary>
        /// Creates a view model from the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="currentPerson" >The current person.</param>
        /// <param name="loadAttributes" >if set to <c>true</c> [load attributes].</param>
        /// <returns></returns>
        public static StepWorkflowTriggerViewModel From( Rock.Model.StepWorkflowTrigger model, Person currentPerson = null, bool loadAttributes = true )
        {
            var viewModel = new StepWorkflowTriggerViewModel();
            viewModel.SetPropertiesFrom( model, currentPerson, loadAttributes );
            return viewModel;
        }
    }
}

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
    /// RegistrationTemplatePlacement View Model
    /// </summary>
    [ViewModelOf( typeof( Rock.Model.RegistrationTemplatePlacement ) )]
    public partial class RegistrationTemplatePlacementViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the AllowMultiplePlacements.
        /// </summary>
        /// <value>
        /// The AllowMultiplePlacements.
        /// </value>
        public bool AllowMultiplePlacements { get; set; }

        /// <summary>
        /// Gets or sets the Cost.
        /// </summary>
        /// <value>
        /// The Cost.
        /// </value>
        public decimal? Cost { get; set; }

        /// <summary>
        /// Gets or sets the GroupTypeId.
        /// </summary>
        /// <value>
        /// The GroupTypeId.
        /// </value>
        public int GroupTypeId { get; set; }

        /// <summary>
        /// Gets or sets the IconCssClass.
        /// </summary>
        /// <value>
        /// The IconCssClass.
        /// </value>
        public string IconCssClass { get; set; }

        /// <summary>
        /// Gets or sets the IsInternal.
        /// </summary>
        /// <value>
        /// The IsInternal.
        /// </value>
        public bool IsInternal { get; set; }

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
        /// Gets or sets the RegistrationTemplateId.
        /// </summary>
        /// <value>
        /// The RegistrationTemplateId.
        /// </value>
        public int RegistrationTemplateId { get; set; }

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
        public virtual void SetPropertiesFrom( Rock.Model.RegistrationTemplatePlacement model, Person currentPerson = null, bool loadAttributes = true )
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

            AllowMultiplePlacements = model.AllowMultiplePlacements;
            Cost = model.Cost;
            GroupTypeId = model.GroupTypeId;
            IconCssClass = model.IconCssClass;
            IsInternal = model.IsInternal;
            Name = model.Name;
            Order = model.Order;
            RegistrationTemplateId = model.RegistrationTemplateId;
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
        public static RegistrationTemplatePlacementViewModel From( Rock.Model.RegistrationTemplatePlacement model, Person currentPerson = null, bool loadAttributes = true )
        {
            var viewModel = new RegistrationTemplatePlacementViewModel();
            viewModel.SetPropertiesFrom( model, currentPerson, loadAttributes );
            return viewModel;
        }
    }
}

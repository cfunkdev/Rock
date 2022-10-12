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
    /// RegistrationTemplateFormField View Model
    /// </summary>
    public partial class RegistrationTemplateFormFieldBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets the Rock.Model.Attribute identifier.
        /// </summary>
        /// <value>
        /// The attribute identifier.
        /// </value>
        public int? AttributeId { get; set; }

        /// <summary>
        /// Gets or sets the source of the field value.
        /// </summary>
        /// <value>
        /// The applies to.
        /// </value>
        public int FieldSource { get; set; }

        /// <summary>
        /// JSON Serialized Rock.Model.RegistrationTemplateFormField.FieldVisibilityRules
        /// </summary>
        /// <value>
        /// The field visibility rules json.
        /// </value>
        public string FieldVisibilityRulesJSON { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is grid field.
        /// </summary>
        /// <value>
        /// true if this instance is grid field; otherwise, false.
        /// </value>
        public bool IsGridField { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this field is only for administrative, and not shown in the public form
        /// </summary>
        /// <value>
        /// true if this instance is internal; otherwise, false.
        /// </value>
        public bool IsInternal { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is required.
        /// </summary>
        /// <value>
        /// true if this instance is required; otherwise, false.
        /// </value>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is a 'shared value'. If so, the value entered will default to the value entered for first person registered.
        /// </summary>
        /// <value>
        ///   true if [common value]; otherwise, false.
        /// </value>
        public bool IsSharedValue { get; set; }

        /// <summary>
        /// Gets or sets the order.
        /// </summary>
        /// <value>
        /// The order.
        /// </value>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the type of the person field.
        /// </summary>
        /// <value>
        /// The type of the person field.
        /// </value>
        public int PersonFieldType { get; set; }

        /// <summary>
        /// Gets or sets the Post-HTML.
        /// </summary>
        /// <value>
        /// The post text.
        /// </value>
        public string PostText { get; set; }

        /// <summary>
        /// Gets or sets the Pre-HTML.
        /// </summary>
        /// <value>
        /// The pre text.
        /// </value>
        public string PreText { get; set; }

        /// <summary>
        /// Gets or sets the Rock.Model.RegistrationTemplateForm identifier.
        /// </summary>
        /// <value>
        /// The registration template form identifier.
        /// </value>
        public int RegistrationTemplateFormId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [show current value].
        /// </summary>
        /// <value>
        ///   true if [show current value]; otherwise, false.
        /// </value>
        public bool ShowCurrentValue { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the field should be shown on a waitlist.
        /// </summary>
        /// <value>
        ///   true if the field should be shown on a waitlist; otherwise, false.
        /// </value>
        public bool ShowOnWaitlist { get; set; }

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

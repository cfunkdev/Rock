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
    /// Tag View Model
    /// </summary>
    public partial class TagBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets the background color of each tag
        /// </summary>
        /// <value>
        /// The color of the tag.
        /// </value>
        public string BackgroundColor { get; set; }

        /// <summary>
        /// Gets or sets the category identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the EntityTypeId of the Rock.Model.EntityType containing the entities that can use this Tag. This property is required.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the EntityTypeId of the Rock.Model.EntityType that contains the entities that can use this Tag.
        /// </value>
        public int? EntityTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the column/property that contains the value that can narrow the scope of entities that can receive this Tag. Entities where this
        /// column contains the Rock.Model.Tag.EntityTypeQualifierValue will be eligible to have this Tag. This property must be used in conjunction with the Rock.Model.Tag.EntityTypeQualifierValue
        /// property. If all entities of the specified Rock.Model.EntityType are eligible to use this Tag, this property will be null.
        /// </summary>
        /// <value>
        /// A System.String representing the EntityTypeQualifierColumn.
        /// </value>
        public string EntityTypeQualifierColumn { get; set; }

        /// <summary>
        /// Gets or sets the value in the Rock.Model.Tag.EntityTypeQualifierColumn that narrows the scope of entities that can receive this Tag. Entities that contain this value
        /// in the Rock.Model.Tag.EntityTypeQualifierColumn are eligible to use this Tag. This property must be used in conjunction with the Rock.Model.Tag.EntityTypeQualifierColumn property.
        /// </summary>
        /// <value>
        /// A System.String representing the EntityTypeQualiferValue that limits which entities of the specified EntityType that can use this Tag.
        /// </value>
        public string EntityTypeQualifierValue { get; set; }

        /// <summary>
        /// Gets or sets the icon CSS class.
        /// </summary>
        /// <value>
        /// The icon CSS class.
        /// </value>
        public string IconCssClass { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   true if this instance is active; otherwise, false.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if this Tag is part of the Rock core system/framework.
        /// </summary>
        /// <value>
        /// A System.Boolean that is true if this Tag is part of the Rock core system/framework; otherwise false.
        /// </value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets the Name of the Tag. This property is required.
        /// </summary>
        /// <value>
        /// A System.String that represents the Name of the Tag
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the display order of the tag. the lower the number, the higher display priority that the Tag has.  For example the Tags with the lower Order could be displayed higher on the Tag list.
        /// This property is required.
        /// </summary>
        /// <value>
        /// A System.Int32 that represents the display Order of the Tag.
        /// </value>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets the owner person alias identifier.
        /// </summary>
        /// <value>
        /// The owner person alias identifier.
        /// </value>
        public int? OwnerPersonAliasId { get; set; }

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

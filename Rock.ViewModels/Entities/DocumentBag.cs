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
    /// Document View Model
    /// </summary>
    public partial class DocumentBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets a description of the document.
        /// </summary>
        /// <value>
        /// A System.String representing the description of the document.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the id of the Rock.Model.DocumentType that this document belongs to.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the Rock.Model.DocumentType.
        /// </value>
        public int DocumentTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Id of the entity that this document is related to.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the Id of the entity (object) that this document is related to.
        /// </value>
        public int EntityId { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if this document is part of the Rock core system/framework.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if this document is part of the core system/framework; otherwise false.
        /// </value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets the given Name of the document.
        /// </summary>
        /// <value>
        /// A System.String representing the given Name of the document. 
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the purpose key.
        /// </summary>
        /// <value>
        /// The purpose key.
        /// </value>
        public string PurposeKey { get; set; }

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
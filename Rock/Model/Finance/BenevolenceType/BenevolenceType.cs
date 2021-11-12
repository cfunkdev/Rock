﻿// Licensed under the Rock Community License (the "License");
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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// Represents a benevolence type that will be associated with a benevolence request.
    /// </summary>
    [RockDomain("Finance")]
    [Table("BenevolenceType")]
    [DataContract]
    public partial class BenevolenceType : Model<BenevolenceType>
    {

        #region entity properties
        /// <summary>
        /// Gets or sets the <see cref="Name"/> value on the <see cref="BenevolenceType"/>. This property is required.
        /// </summary>
        /// <value>
        /// A <see cref="System.String" /> containing the <see cref="Name"/>.
        /// </value>
        [Required]
        [MaxLength(50)]
        [DataMember(IsRequired = true)]
        [Previewable]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Description"/> value on the <see cref="BenevolenceType"/>. This property is required.
        /// </summary>
        /// <value>
        /// A <see cref="System.String" /> containing the <see cref="Description"/>.
        /// </value>
        [Required]
        [DataMember(IsRequired = true)]
        [Previewable]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="IsActive"/> value on the <see cref="BenevolenceType"/>. This property is required.
        /// </summary>
        /// <value>
        /// A <see cref="System.Boolean" /> containing the <see cref="IsActive"/>.
        /// </value>
        [Required]
        [DataMember(IsRequired = true)]
        [Previewable]
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="RequestLavaTemplate"/> value on the <see cref="BenevolenceType"/>. This property is required.
        /// </summary>
        /// <value>
        /// A <see cref="System.String" /> containing the <see cref="RequestLavaTemplate"/>.
        /// </value>
        [Required]
        [DataMember(IsRequired = true)]
        public string RequestLavaTemplate { get; set; }
        #endregion

    }
}

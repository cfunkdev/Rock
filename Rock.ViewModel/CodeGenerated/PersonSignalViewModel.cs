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
    /// PersonSignal View Model
    /// </summary>
    public partial class PersonSignalViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the ExpirationDate.
        /// </summary>
        /// <value>
        /// The ExpirationDate.
        /// </value>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the Note.
        /// </summary>
        /// <value>
        /// The Note.
        /// </value>
        public string Note { get; set; }

        /// <summary>
        /// Gets or sets the OwnerPersonAliasId.
        /// </summary>
        /// <value>
        /// The OwnerPersonAliasId.
        /// </value>
        public int OwnerPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the PersonId.
        /// </summary>
        /// <value>
        /// The PersonId.
        /// </value>
        public int PersonId { get; set; }

        /// <summary>
        /// Gets or sets the SignalTypeId.
        /// </summary>
        /// <value>
        /// The SignalTypeId.
        /// </value>
        public int SignalTypeId { get; set; }

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

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

namespace Rock.ViewModel
{
    /// <summary>
    /// Device View Model
    /// </summary>
    [ViewModelOf( typeof( Rock.Model.Device ) )]
    public partial class DeviceViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the CameraBarcodeConfigurationType.
        /// </summary>
        /// <value>
        /// The CameraBarcodeConfigurationType.
        /// </value>
        public int? CameraBarcodeConfigurationType { get; set; }

        /// <summary>
        /// Gets or sets the Description.
        /// </summary>
        /// <value>
        /// The Description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the DeviceTypeValueId.
        /// </summary>
        /// <value>
        /// The DeviceTypeValueId.
        /// </value>
        public int DeviceTypeValueId { get; set; }

        /// <summary>
        /// Gets or sets the HasCamera.
        /// </summary>
        /// <value>
        /// The HasCamera.
        /// </value>
        public bool HasCamera { get; set; }

        /// <summary>
        /// Gets or sets the IPAddress.
        /// </summary>
        /// <value>
        /// The IPAddress.
        /// </value>
        public string IPAddress { get; set; }

        /// <summary>
        /// Gets or sets the IsActive.
        /// </summary>
        /// <value>
        /// The IsActive.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets the LocationId.
        /// </summary>
        /// <value>
        /// The LocationId.
        /// </value>
        public int? LocationId { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        /// <value>
        /// The Name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the PrinterDeviceId.
        /// </summary>
        /// <value>
        /// The PrinterDeviceId.
        /// </value>
        public int? PrinterDeviceId { get; set; }

        /// <summary>
        /// Gets or sets the PrintFrom.
        /// </summary>
        /// <value>
        /// The PrintFrom.
        /// </value>
        public int PrintFrom { get; set; }

        /// <summary>
        /// Gets or sets the PrintToOverride.
        /// </summary>
        /// <value>
        /// The PrintToOverride.
        /// </value>
        public int PrintToOverride { get; set; }

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
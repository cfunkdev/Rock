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
    /// ContentChannel View Model
    /// </summary>
    public partial class ContentChannelBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets the channel URL.
        /// </summary>
        /// <value>
        /// The channel URL.
        /// </value>
        public string ChannelUrl { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether child items are manually ordered or not
        /// </summary>
        /// <value>
        /// true if [child items manually ordered]; otherwise, false.
        /// </value>
        public bool ChildItemsManuallyOrdered { get; set; }

        /// <summary>
        /// Gets or sets the Rock.Model.ContentChannelType identifier.
        /// </summary>
        /// <value>
        /// The content channel type identifier.
        /// </value>
        public int ContentChannelTypeId { get; set; }

        /// <summary>
        /// Gets or sets the type of the control to render when editing content for items of this type.
        /// </summary>
        /// <value>
        /// The type of the item control.
        /// </value>
        public int ContentControlType { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable personalization].
        /// </summary>
        /// <value>
        ///   true if [enable personalization]; otherwise, false.
        /// </value>
        public bool EnablePersonalization { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable RSS].
        /// </summary>
        /// <value>
        ///   true if [enable RSS]; otherwise, false.
        /// </value>
        public bool EnableRss { get; set; }

        /// <summary>
        /// Gets or sets the icon CSS class.
        /// </summary>
        /// <value>
        /// The icon CSS class.
        /// </value>
        public string IconCssClass { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is index enabled.
        /// </summary>
        /// <value>
        /// true if this instance is index enabled; otherwise, false.
        /// </value>
        public bool IsIndexEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this content is structured.
        /// </summary>
        /// <value>
        ///   true if this content is structured; otherwise, false.
        /// </value>
        public bool IsStructuredContent { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is tagging enabled.
        /// </summary>
        /// <value>
        ///   true if this instance is tagging enabled; otherwise, false.
        /// </value>
        public bool IsTaggingEnabled { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether items are manually ordered or not
        /// </summary>
        /// <value>
        /// true if [items manually ordered]; otherwise, false.
        /// </value>
        public bool ItemsManuallyOrdered { get; set; }

        /// <summary>
        /// Gets or sets the item tag category identifier.
        /// </summary>
        /// <value>
        /// The item tag category identifier.
        /// </value>
        public int? ItemTagCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the item URL.
        /// </summary>
        /// <value>
        /// The item URL.
        /// </value>
        public string ItemUrl { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [requires approval].
        /// </summary>
        /// <value>
        ///   true if [requires approval]; otherwise, false.
        /// </value>
        public bool RequiresApproval { get; set; }

        /// <summary>
        /// Gets or sets the root image directory to use when the HTML control type is used
        /// </summary>
        /// <value>
        /// The image root directory.
        /// </value>
        public string RootImageDirectory { get; set; }

        /// <summary>
        /// Gets or sets the Structure Content Tool Id.
        /// </summary>
        /// <value>
        /// The structure content tool value identifier.
        /// </value>
        public int? StructuredContentToolValueId { get; set; }

        /// <summary>
        /// Gets or sets the number of minutes a feed can stay cached before refreshing it from the source.
        /// </summary>
        /// <value>
        /// The time to live.
        /// </value>
        public int? TimeToLive { get; set; }

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

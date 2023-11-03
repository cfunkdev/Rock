﻿// <copyright>
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
using System.Collections.Generic;
using System.ComponentModel;
using System.Net.Http;
using System.Text;

using Rock.Attribute;
using Rock.Model;

namespace Rock.Blocks.Types.Mobile.Cms
{
    /// <summary>
    /// Lists items generated by Lava and allow the user to
    /// format how they are displayed with XAML.
    /// </summary>
    /// <seealso cref="Rock.Blocks.RockBlockType" />

    [DisplayName( "Lava Item List" )]
    [Category( "Mobile > Cms" )]
    [Description( "List items genreated by Lava." )]
    [IconCssClass( "fa fa-th" )]
    [SupportedSiteTypes( Model.SiteType.Mobile )]

    #region Block Attributes

    [TextField(
        "Page Size",
        Description = "The number of items to send per page.",
        Key = AttributeKeys.PageSize,
        DefaultValue = "50",
        Order = 0 )]

    [LinkedPage( "Detail Page",
        Description = "The page to redirect to when selecting an item.",
        Key = AttributeKeys.DetailPage,
        IsRequired = false,
        Order = 1 )]

    [CodeEditorField(
        "List Template",
        Description = "The Lava used to generate the JSON object structure for the item list.",
        Key = AttributeKeys.ListTemplate,
        Order = 2,
        EditorMode = Rock.Web.UI.Controls.CodeEditorMode.Lava,
        DefaultValue = defaultItemTemplate )]

    [CodeEditorField(
        "List Data Template",
        Description = "The XAML for the lists data template.",
        Key = AttributeKeys.ListDataTemplate,
        Order = 0,
        EditorMode = Rock.Web.UI.Controls.CodeEditorMode.Xml,
        DefaultValue = defaultDataTemplate,
        Category = "custommobile" )]

    #endregion

    [Rock.SystemGuid.EntityTypeGuid( Rock.SystemGuid.EntityType.MOBILE_LAVA_ITEM_LIST_BLOCK_TYPE )]
    [Rock.SystemGuid.BlockTypeGuid( "42B9ADBA-AE3E-4AC6-BE4C-7D3714ADF48D")]
    public class LavaItemList : RockBlockType
    {
        /// <summary>
        /// The key names of all block attributes used by the ContentChannelItemList block.
        /// </summary>
        public static class AttributeKeys
        {
            /// <summary>
            /// The page size key
            /// </summary>
            public const string PageSize = "PageSize";

            /// <summary>
            /// The list data template key
            /// </summary>
            public const string ListDataTemplate = "ListDataTemplate";

            /// <summary>
            /// The list template key
            /// </summary>
            public const string ListTemplate = "ListTemplate";

            /// <summary>
            /// The detail page key
            /// </summary>
            public const string DetailPage = "DetailPage";
        }

        #region Constants

        private const string defaultDataTemplate = @"<StackLayout HeightRequest=""50"" WidthRequest=""200"" Orientation=""Horizontal"" Padding=""0,5,0,5"">
    <Label Text=""{Binding Title}"" />
</StackLayout>";

        private const string defaultItemTemplate = @"[
  {
    ""Id"": 1,
    ""Title"": ""First Item""
  },
  {
    ""Id"": 2,
    ""Title"": ""Second Item""
  }
]";

        #endregion

        #region IRockMobileBlockType Implementation

        /// <inheritdoc/>
        public override Guid? MobileBlockTypeGuid => new Guid( "32f1da96-82a9-441f-80bb-a82218ddec8d" ); // CollectionViewList

        /// <inheritdoc/>
        public override Version RequiredMobileVersion => new Version( 1, 1 );

        /// <summary>
        /// Gets the property values that will be sent to the device in the application bundle.
        /// </summary>
        /// <returns>
        /// A collection of string/object pairs.
        /// </returns>
        public override object GetMobileConfigurationValues()
        {
            return new Dictionary<string, object>
            {
                { "ItemSelectedPage", GetAttributeValue( AttributeKeys.DetailPage ) },
                { "ItemSelectedParameter", "ItemId" },
                { "ItemSelectedKey", "Id" }
            };
        }

        #endregion

        #region Actions

        /// <summary>
        /// Gets the items that should be displayed on the given page.
        /// </summary>
        /// <param name="pageNumber">The page number whose items are returned, the first page being 0.</param>
        /// <returns>A JSON string that defines the items to be displayed.</returns>
        [BlockAction]
        public object GetItems( int pageNumber = 0 )
        {
            var mergeFields = RequestContext.GetCommonMergeFields();

            mergeFields.Add( "Page", pageNumber );
            mergeFields.Add( "PageSize", GetAttributeValue( AttributeKeys.PageSize ).AsInteger() );

            var lavaTemplate = GetAttributeValue( AttributeKeys.ListTemplate );

            var output = lavaTemplate.ResolveMergeFields( mergeFields );

            return ActionOk( new StringContent( output, Encoding.UTF8, "application/json" ) );
        }

        #endregion
    }
}

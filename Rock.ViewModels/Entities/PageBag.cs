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
    /// Page View Model
    /// </summary>
    public partial class PageBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets the additional settings.
        /// </summary>
        /// <value>
        /// The additional settings.
        /// </value>
        public string AdditionalSettings { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow indexing].
        /// </summary>
        /// <value>
        ///   true if [allow indexing]; otherwise, false.
        /// </value>
        public bool AllowIndexing { get; set; }

        /// <summary>
        /// Gets or sets the body CSS class.
        /// </summary>
        /// <value>
        /// The body CSS class.
        /// </value>
        public string BodyCssClass { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether icon is displayed in breadcrumb.
        /// </summary>
        /// <value>
        /// A System.Boolean that is true if the icon is displayed in the breadcrumb, otherwise false.
        /// </value>
        public bool BreadCrumbDisplayIcon { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Page Name is displayed in the breadcrumb.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if the Page's name should be displayed in breadcrumb, otherwise false.
        /// </value>
        public bool BreadCrumbDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the browser title to use for the page.
        /// </summary>
        /// <value>
        /// The browser title.
        /// </value>
        public string BrowserTitle { get; set; }

        /// <summary>
        /// Gets or sets the cache control header settings.
        /// </summary>
        /// <value>
        /// The cache control header settings.
        /// </value>
        public string CacheControlHeaderSettings { get; set; }

        /// <summary>
        /// Gets or sets a user defined description of the page.  This will be added as a meta tag for the page 
        /// </summary>
        /// <value>
        /// A System.String that represents the Page description.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets a value indicating when the Page should be displayed in the navigation.
        /// </summary>
        /// <value>
        /// An Rock.Model.Page.DisplayInNavWhen enum value that determines when to display in a navigation.
        /// 0 = When Security Allows
        /// 1 = Always
        /// 2 = Never   
        /// 
        /// Enum[DisplayInNavWhen].
        /// </value>
        public int DisplayInNavWhen { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if view state should be enabled on the page. 
        /// </summary>
        /// <value>
        /// A System.Boolean that is true if view state should be enabled on the page, otherwise false.
        /// </value>
        public bool EnableViewState { get; set; }

        /// <summary>
        /// Gets or sets HTML content to add to the page header area of the page when rendered.
        /// </summary>
        /// <value>
        /// The content of the header.
        /// </value>
        public string HeaderContent { get; set; }

        /// <summary>
        /// Gets or sets the icon binary file identifier.
        /// </summary>
        /// <value>
        /// The icon binary file identifier.
        /// </value>
        public int? IconBinaryFileId { get; set; }

        /// <summary>
        /// Gets or sets the icon CSS class name for a font vector based icon.
        /// </summary>
        /// <value>
        /// A System.String that represents the CSS Class Name of the icon being used. This value will be empty/null if a file based icon is being used.
        /// </value>
        public string IconCssClass { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if the admin footer should be displayed when a Site Administrator is logged in.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if admin footer is displayed; otherwise false.
        /// </value>
        public bool IncludeAdminFooter { get; set; }

        /// <summary>
        /// Gets or sets the internal name to use when administering this page
        /// </summary>
        /// <value>
        /// A System.String that represents the internal name of the Page.
        /// </value>
        public string InternalName { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if the Page is part of the Rock core system/framework.
        /// </summary>
        /// <value>
        /// A System.Boolean that is true if this Page is part of the Rock core system/framework, otherwise false.
        /// </value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets the key words.
        /// </summary>
        /// <value>
        /// The key words.
        /// </value>
        public string KeyWords { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Rock.Model.Layout that this Page uses.
        /// </summary>
        /// <value>
        /// An System.Int32 that represents the Id of the Rock.Model.Layout that this Page uses.
        /// </value>
        public int LayoutId { get; set; }

        /// <summary>
        /// Gets or sets the median page load time in seconds. Typically calculated from a set of
        /// Rock.Model.Interaction.InteractionTimeToServe values.
        /// </summary>
        /// <value>
        /// The median page load time in seconds.
        /// </value>
        public double? MedianPageLoadTimeDurationSeconds { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if the Page's children Pages should be displayed in the menu.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if the Page's child pages should be displayed, otherwise false.
        /// </value>
        public bool MenuDisplayChildPages { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if the Page description should be displayed in the menu.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if the description should be displayed, otherwise false.
        /// </value>
        public bool MenuDisplayDescription { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if the Page icon should be displayed in the menu.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if the Page description should be displayed, otherwise false.
        /// </value>
        public bool MenuDisplayIcon { get; set; }

        /// <summary>
        /// Gets or sets a number indicating the order of the page in the menu and in the site map.
        /// This will also affect the page order in the menu. This property is required.
        /// </summary>
        /// <value>
        /// A System.Int32 indicating the order of the page in the page hierarchy and sitemap.
        /// </value>
        public int Order { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether breadcrumbs are displayed on Page
        /// </summary>
        /// <value>
        /// A System.Boolean that is true if breadcrumbs should be displayed on the page, otherwise, false
        /// </value>
        public bool PageDisplayBreadCrumb { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Page description should be displayed on the page.
        /// </summary>
        /// <value>
        /// A System.Booleanvalue that is true if the description should be displayed; otherwise, false.
        /// </value>
        public bool PageDisplayDescription { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Page icon should be displayed on the Page.
        /// </summary>
        /// <value>
        ///   A System.Boolean that is true if the icon should be displayed otherwise false
        /// </value>
        public bool PageDisplayIcon { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the Page Title should be displayed on the page (if the Rock.Model.Layout supports it).
        /// </summary>
        /// <value>
        ///   A System.Boolean that is true if the title should be displayed on the Page, otherwise false.
        /// </value>
        public bool PageDisplayTitle { get; set; }

        /// <summary>
        /// Gets or sets the title of the of the Page to use as the page caption, in menu's, breadcrumb display etc.
        /// </summary>
        /// <value>
        /// A System.String that represents the page title of the Page.
        /// </value>
        public string PageTitle { get; set; }

        /// <summary>
        /// Gets or sets the Id of the parent Page.
        /// </summary>
        /// <value>
        /// An System.Int32 that represents the Id of the parent Page.
        /// </value>
        public int? ParentPageId { get; set; }

        /// <summary>
        /// Gets or sets the rate limit period.
        /// </summary>
        /// <value>
        /// The rate limit period.
        /// </value>
        public int? RateLimitPeriod { get; set; }

        /// <summary>
        /// Gets or sets the rate limit request per period.
        /// </summary>
        /// <value>
        /// The rate limit request per period.
        /// </value>
        public int? RateLimitRequestPerPeriod { get; set; }

        /// <summary>
        /// Gets or sets a flag that indicates if the Page requires SSL encryption.
        /// </summary>
        /// <value>
        /// A System.Boolean that is true if this Page requires encryption, otherwise false.
        /// </value>
        public bool RequiresEncryption { get; set; }

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

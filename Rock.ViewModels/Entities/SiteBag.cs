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
    /// Site View Model
    /// </summary>
    public partial class SiteBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets the additional settings.
        /// </summary>
        /// <value>
        /// The additional settings.
        /// </value>
        public string AdditionalSettings { get; set; }

        /// <summary>
        /// The Allowed Frame Domains designates which external domains/sites are allowed to embed iframes of this site.
        /// It controls what is put into the Content-Security-Policy HTTP response header.
        /// This is in accordance with the Content Security Policy described here http://w3c.github.io/webappsec-csp/#csp-header
        /// and here https://www.owasp.org/index.php/Content_Security_Policy_Cheat_Sheet
        /// </summary>
        /// <value>
        /// A space delimited list of domains.
        /// </value>
        public string AllowedFrameDomains { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [allow indexing].
        /// </summary>
        /// <value>
        ///   true if [allow indexing]; otherwise, false.
        /// </value>
        public bool AllowIndexing { get; set; }

        /// <summary>
        /// Gets or sets the change password page identifier.
        /// </summary>
        /// <value>
        /// The change password page identifier.
        /// </value>
        public int? ChangePasswordPageId { get; set; }

        /// <summary>
        /// Gets or sets the change password page route identifier.
        /// </summary>
        /// <value>
        /// The change password page route identifier.
        /// </value>
        public int? ChangePasswordPageRouteId { get; set; }

        /// <summary>
        /// Gets or sets the communication page identifier.
        /// </summary>
        /// <value>
        /// The communication page identifier.
        /// </value>
        public int? CommunicationPageId { get; set; }

        /// <summary>
        /// Gets or sets the communication page route identifier.
        /// </summary>
        /// <value>
        /// The communication page route identifier.
        /// </value>
        public int? CommunicationPageRouteId { get; set; }

        /// <summary>
        /// Gets or sets the configuration mobile phone binary file identifier.
        /// </summary>
        /// <value>
        /// The configuration mobile phone binary file identifier.
        /// </value>
        public int? ConfigurationMobilePhoneBinaryFileId { get; set; }

        /// <summary>
        /// Gets or sets the configuration tablet binary file identifier.
        /// </summary>
        /// <value>
        /// The configuration tablet binary file identifier.
        /// </value>
        public int? ConfigurationMobileTabletBinaryFileId { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Site's default Rock.Model.Page.
        /// </summary>
        /// <value>
        /// An System.Int32 containing the Id of the Site's default Rock.Model.Page. If the site doesn't have a default Rock.Model.Page
        /// this value will be null.
        /// </value>
        public int? DefaultPageId { get; set; }

        /// <summary>
        /// Gets or sets the default page route unique identifier.
        /// If this has a value (and the PageRoute can be found) use this instead of the DefaultPageId
        /// </summary>
        /// <value>
        /// The default page route unique identifier.
        /// </value>
        public int? DefaultPageRouteId { get; set; }

        /// <summary>
        /// Gets or sets a user defined description/summary  of the Site.
        /// </summary>
        /// <value>
        /// A System.String that contains the description of the Site. If no description is provided
        ///  this value will be an null string.
        /// </value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets whether predictable Ids are disabled.
        /// </summary>
        /// <value>
        /// true if predictable Ids are disabled; otherwise, false.
        /// </value>
        public bool DisablePredictableIds { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this site should be available to be used for shortlinks (the shortlink can still reference the URL of other sites).
        /// </summary>
        /// <value>
        ///   true if [enabled for shortening]; otherwise, false.
        /// </value>
        public bool EnabledForShortening { get; set; }

        /// <summary>
        /// Enabling this feature will prevent other sites from using this sites routes and prevent routes from other sites from working on this site.
        /// </summary>
        /// <value>
        ///   true if [enable exclusive routes]; otherwise, false.
        /// </value>
        public bool EnableExclusiveRoutes { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable mobile redirect].
        /// </summary>
        /// <value>
        /// true if [enable mobile redirect]; otherwise, false.
        /// </value>
        public bool EnableMobileRedirect { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether geo-location lookups should be performed on interactions.
        /// </summary>
        /// <value>
        /// true if [enable page view geo tracking]; otherwise, false.
        /// </value>
        public bool EnablePageViewGeoTracking { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to log Page Views into the Interaction tables for pages in this site
        /// </summary>
        /// <value>
        ///   true if [enable page views]; otherwise, false.
        /// </value>
        public bool EnablePageViews { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [enable personalization].
        /// </summary>
        /// <value>
        ///   true if [enable personalization]; otherwise, false.
        /// </value>
        public bool EnablePersonalization { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether /[enable visitor tracking].
        /// </summary>
        /// <value>
        ///   true if [enable visitor tracking]; otherwise, false.
        /// </value>
        public bool EnableVisitorTracking { get; set; }

        /// <summary>
        /// Gets or sets the path to the error page.
        /// </summary>
        /// <value>
        /// A System.String containing the path to the error page.
        /// </value>
        public string ErrorPage { get; set; }

        /// <summary>
        /// Gets or sets the external URL.
        /// </summary>
        /// <value>
        /// The external URL.
        /// </value>
        public string ExternalUrl { get; set; }

        /// <summary>
        /// Gets or sets the favicon binary file identifier.
        /// </summary>
        /// <value>
        /// The favicon binary file identifier.
        /// </value>
        public int? FavIconBinaryFileId { get; set; }

        /// <summary>
        /// Gets or sets the Google analytics code.
        /// </summary>
        /// <value>
        /// The Google analytics code.
        /// </value>
        public string GoogleAnalyticsCode { get; set; }

        /// <summary>
        /// Gets or sets the index starting location.
        /// </summary>
        /// <value>
        /// The index starting location.
        /// </value>
        public string IndexStartingLocation { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   true if this instance is active; otherwise, false.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is index enabled.
        /// </summary>
        /// <value>
        /// true if this instance is index enabled; otherwise, false.
        /// </value>
        public bool IsIndexEnabled { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if this Site was created by and is part of the Rock core system/framework. This property is required.
        /// </summary>
        /// <value>
        /// A System.Boolean that is true if this Site is part of the Rock core system/framework, otherwise false.
        /// </value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets the latest version date time.
        /// </summary>
        /// <value>
        /// The latest version date time.
        /// </value>
        public DateTime? LatestVersionDateTime { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Site's log in Rock.Model.Page
        /// </summary>
        /// <value>
        /// An System.Int32 containing the Id of the Site's log in Rock.Model.Page. If the site doesn't have a log in Rock.Model.Page
        /// this value will be null.
        /// </value>
        public int? LoginPageId { get; set; }

        /// <summary>
        /// Gets or sets the login page route unique identifier.
        /// If this has a value (and the PageRoute can be found) use this instead of the LoginPageId
        /// </summary>
        /// <value>
        /// The login page route unique identifier.
        /// </value>
        public int? LoginPageRouteId { get; set; }

        /// <summary>
        /// Gets or sets the mobile page identifier.
        /// </summary>
        /// <value>
        /// The mobile page identifier.
        /// </value>
        public int? MobilePageId { get; set; }

        /// <summary>
        /// Gets or sets the name of the Site. This property is required.
        /// </summary>
        /// <value>
        /// A System.String that represents the name of the Site.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the content of the page header.
        /// </summary>
        /// <value>
        /// The content of the page header.
        /// </value>
        public string PageHeaderContent { get; set; }

        /// <summary>
        /// Gets or sets the Id of the 404 Rock.Model.Page
        /// </summary>
        /// <value>
        /// An System.Int32 containing the Id of the Site's 404 Rock.Model.Page.
        /// </value>
        public int? PageNotFoundPageId { get; set; }

        /// <summary>
        /// Gets or sets the 404 page route unique identifier.
        /// </summary>
        /// <value>
        /// The 404 page route unique identifier.
        /// </value>
        public int? PageNotFoundPageRouteId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [redirect tablets].
        /// </summary>
        /// <value>
        ///   true if [redirect tablets]; otherwise, false.
        /// </value>
        public bool RedirectTablets { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Site's registration Rock.Model.Page
        /// </summary>
        /// <value>
        /// An System.Int32 containing the Id of the Site's registration Rock.Model.Page. If the site doesn't have a registration Rock.Model.Page
        /// this value will be null.
        /// </value>
        public int? RegistrationPageId { get; set; }

        /// <summary>
        /// Gets or sets the registration page route unique identifier.
        /// If this has a value (and the PageRoute can be found) use this instead of the RegistrationPageId
        /// </summary>
        /// <value>
        /// The registration page route unique identifier.
        /// </value>
        public int? RegistrationPageRouteId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [requires encryption].
        /// </summary>
        /// <value>
        ///   true if [requires encryption]; otherwise, false.
        /// </value>
        public bool RequiresEncryption { get; set; }

        /// <summary>
        /// Gets or sets the site logo binary file identifier.
        /// </summary>
        /// <value>
        /// The site logo binary file identifier.
        /// </value>
        public int? SiteLogoBinaryFileId { get; set; }

        /// <summary>
        /// Gets or sets the type of the site.
        /// </summary>
        /// <value>
        /// The type of the site.
        /// </value>
        public int SiteType { get; set; }

        /// <summary>
        /// Gets or sets the name of the Theme that is used on the Site.
        /// </summary>
        /// <value>
        /// A System.String that contains the name of the theme that is being used on the Site.
        /// </value>
        public string Theme { get; set; }

        /// <summary>
        /// Gets or sets the thumbnail binary file identifier.
        /// </summary>
        /// <value>
        /// The thumbnail  file identifier.
        /// </value>
        public int? ThumbnailBinaryFileId { get; set; }

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
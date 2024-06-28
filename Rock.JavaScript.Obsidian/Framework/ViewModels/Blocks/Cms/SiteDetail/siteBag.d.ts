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

import { Guid } from "@Obsidian/Types";
import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";
import { PublicAttributeBag } from "@Obsidian/ViewModels/Utility/publicAttributeBag";
import { PublicEditableAttributeBag } from "@Obsidian/ViewModels/Utility/publicEditableAttributeBag";

export type SiteBag = {
    /**
     * The Allowed Frame Domains designates which external domains/sites are allowed to embed iframes of this site.
     * It controls what is put into the Content-Security-Policy HTTP response header.
     * This is in accordance with the Content Security Policy described here http://w3c.github.io/webappsec-csp/#csp-header
     * and here https://www.owasp.org/index.php/Content_Security_Policy_Cheat_Sheet
     */
    allowedFrameDomains?: string | null;

    /** Gets or sets a value indicating whether [allow indexing]. */
    allowIndexing: boolean;

    /** Gets or sets a value indicating whether the site's theme allows compiling. */
    allowsCompile: boolean;

    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;

    /** Gets or sets the binary file type identifier. */
    binaryFileTypeGuid: Guid;

    /** Gets or sets the change password page. */
    changePasswordPage?: ListItemBag | null;

    /** Gets or sets the change password page route. */
    changePasswordPageRoute?: ListItemBag | null;

    /** Gets or sets the communication page. */
    communicationPage?: ListItemBag | null;

    /** Gets or sets the communication page route. */
    communicationPageRoute?: ListItemBag | null;

    /** Gets or sets the default Rock.Model.Page page for the site. */
    defaultPage?: ListItemBag | null;

    /** Gets or sets the default Rock.Model.PageRoute page route for this site. If this value is null, the DefaultPage will be used */
    defaultPageRoute?: ListItemBag | null;

    /** Gets or sets a user defined description/summary  of the Site. */
    description?: string | null;

    /** Gets or sets whether predictable Ids are disabled. */
    disablePredictableIds: boolean;

    /** Gets or sets a value indicating whether this site should be available to be used for shortlinks (the shortlink can still reference the URL of other sites). */
    enabledForShortening: boolean;

    /** Enabling this feature will prevent other sites from using this sites routes and prevent routes from other sites from working on this site. */
    enableExclusiveRoutes: boolean;

    /** Gets or sets a value indicating whether [enable mobile redirect]. */
    enableMobileRedirect: boolean;

    /** Gets or sets a value indicating whether to log Page Views into the Interaction tables for pages in this site */
    enablePageViews: boolean;

    /** Gets or sets a value indicating whether [enable personalization]. */
    enablePersonalization: boolean;

    /** Gets or sets a value indicating whether /[enable visitor tracking]. */
    enableVisitorTracking: boolean;

    /** Gets or sets the path to the error page. */
    errorPage?: string | null;

    /** Gets or sets the external URL. */
    externalUrl?: string | null;

    /** Gets or sets the favicon binary file. */
    favIconBinaryFile?: ListItemBag | null;

    /** Gets or sets the Google analytics code. */
    googleAnalyticsCode?: string | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets the index starting location. */
    indexStartingLocation?: string | null;

    /** Gets or sets a value indicating whether this instance is active. */
    isActive: boolean;

    /** Gets or sets a value indicating whether this instance is index enabled. */
    isIndexEnabled: boolean;

    /** Gets or sets a flag indicating if this Site was created by and is part of the Rock core system/framework. This property is required. */
    isSystem: boolean;

    /** Gets or sets the login Rock.Model.Page page for the site. */
    loginPage?: ListItemBag | null;

    /** Gets or sets the login Rock.Model.PageRoute page route for this site. If this value is null, the LoginPage will be used */
    loginPageRoute?: ListItemBag | null;

    /** Gets or sets the mobile page. */
    mobilePage?: ListItemBag | null;

    /** Gets or sets the name of the Site. This property is required. */
    name?: string | null;

    /** Gets or sets the content of the page header. */
    pageHeaderContent?: string | null;

    /** Gets or sets the 404 Rock.Model.Page page for the site. */
    pageNotFoundPage?: ListItemBag | null;

    /** Gets or sets the 404 Rock.Model.PageRoute page route for this site. */
    pageNotFoundPageRoute?: ListItemBag | null;

    /** Gets or sets a value indicating whether [redirect tablets]. */
    redirectTablets: boolean;

    /** Gets or sets the registration Rock.Model.Page page for the site. */
    registrationPage?: ListItemBag | null;

    /** Gets or sets the registration Rock.Model.PageRoute page route for this site. If this value is null, the RegistrationPage will be used */
    registrationPageRoute?: ListItemBag | null;

    /** Gets or sets a value indicating whether [requires encryption]. */
    requiresEncryption: boolean;

    /** Gets or sets the number of days to keep page views logged. */
    retentionDuration?: number | null;

    /** The site Attributes */
    siteAttributes?: PublicEditableAttributeBag[] | null;

    /** Gets or sets the site domains. */
    siteDomains?: string | null;

    /** Gets or sets the site logo binary file. */
    siteLogoBinaryFile?: ListItemBag | null;

    /** Gets or sets the site URL. */
    siteUrl?: string | null;

    /** Gets or sets the name of the Theme that is used on the Site. */
    theme?: string | null;
};

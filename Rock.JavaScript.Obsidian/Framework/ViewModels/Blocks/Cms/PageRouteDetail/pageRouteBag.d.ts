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

import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";
import { PublicAttributeBag } from "@Obsidian/ViewModels/Utility/publicAttributeBag";

export type PageRouteBag = {
    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** If true then the route will be accessible from all sites regardless if EnableExclusiveRoutes is set on the site */
    isGlobal: boolean;

    /** Gets or sets a flag indicating if the PageRoute is part of the Rock core system/framework. This property is required. */
    isSystem: boolean;

    /** Gets or sets the Rock.Model.Page associated with the RoutePath. */
    page?: ListItemBag | null;

    /**
     * Gets or sets the format of the route path. Route examples include: Page NewAccount or Checkin/Welcome. 
     * A specific group Group/{GroupId} (i.e. Group/16). A person's history Person/{PersonId}/History (i.e. Person/12/History).
     * This property is required.
     */
    route?: string | null;

    /** Gets or sets the site. */
    site?: string | null;
};

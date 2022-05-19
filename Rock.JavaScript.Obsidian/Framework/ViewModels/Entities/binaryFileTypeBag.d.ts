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

import { PublicAttributeBag } from "@Obsidian/ViewModels/Utility/publicAttributeBag";

/** BinaryFileType View Model */
export type BinaryFileTypeBag = {
    /** Gets or sets the cache control header settings. */
    cacheControlHeaderSettings?: string | null;

    /** Gets or sets a flag indicating whether the file on any Rock.Model.BinaryFile child entities should be cached to the server. */
    cacheToServerFileSystem: boolean;

    /** Gets or sets a description of the BinaryFileType. */
    description?: string | null;

    /** Gets or sets the CSS class that is used for a vector/CSS icon. */
    iconCssClass?: string | null;

    /** Gets or sets a flag indicating if this BinaryFileType is part of the Rock core system/framework. This property is required. */
    isSystem: boolean;

    /** Gets or sets a value indicating the maximum height of a file type. */
    maxHeight?: number | null;

    /** Gets or sets a value indicating the maximum width of a file type. */
    maxWidth?: number | null;

    /** Gets or sets the given Name of the BinaryFileType. This value is an alternate key and is required. */
    name?: string | null;

    /** Gets or sets the preferred color depth of the file type. */
    preferredColorDepth: number;

    /** Gets or sets the preferred format of the file type. */
    preferredFormat: number;

    /** Gets or sets a value indicating whether the preferred attributes of the file type are required */
    preferredRequired: boolean;

    /** Gets or sets the preferred resolution of the file type. */
    preferredResolution: number;

    /** Gets or sets a value indicating whether security should be checked when displaying files of this type */
    requiresViewSecurity: boolean;

    /** Gets or sets the Id of the storage service Rock.Model.EntityType that is used to store files of this type. */
    storageEntityTypeId?: number | null;

    /** Gets or sets the created date time. */
    createdDateTime?: string | null;

    /** Gets or sets the modified date time. */
    modifiedDateTime?: string | null;

    /** Gets or sets the created by person alias identifier. */
    createdByPersonAliasId?: number | null;

    /** Gets or sets the modified by person alias identifier. */
    modifiedByPersonAliasId?: number | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;
};

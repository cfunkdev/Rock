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

/** BinaryFile View Model */
export type BinaryFileBag = {
    /** Gets or sets the id of the Rock.Model.BinaryFileType that this file belongs to. */
    binaryFileTypeId?: number | null;

    /** Gets or sets the content last modified. */
    contentLastModified?: string | null;

    /** Gets or sets a user defined description of the file. */
    description?: string | null;

    /** Gets or sets the name of the file, including any extensions. This name is usually captured when the file is uploaded to Rock and this same name will be used when the file is downloaded. This property is required. */
    fileName?: string | null;

    /** Gets or sets the size of the file (in bytes) */
    fileSize?: number | null;

    /** Gets or sets a value indicating the height of a file type. */
    height?: number | null;

    /** Gets or sets a flag indicating if this file is part of the Rock core system/framework. */
    isSystem: boolean;

    /** Gets or sets a flag indicating if this is a temporary file. This property is required. */
    isTemporary: boolean;

    /** Gets or sets the Mime Type for the file. This property is required */
    mimeType?: string | null;

    /** Gets or sets a path to the file that is understandable by the storage provider. */
    path?: string | null;

    /** Gets or sets the storage entity settings. */
    storageEntitySettings?: string | null;

    /** Gets or sets a value indicating the width of a file type. */
    width?: number | null;

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

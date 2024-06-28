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

import { NoteFormatType } from "@Obsidian/Enums/Core/noteFormatType";
import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";
import { PublicAttributeBag } from "@Obsidian/ViewModels/Utility/publicAttributeBag";

export type NoteTypeBag = {
    /** Gets or sets a value indicating whether attachments are allowed for this note type. */
    allowsAttachments: boolean;

    /** Gets or sets a value indicating whether [allows replies]. */
    allowsReplies: boolean;

    /** Gets or sets a value indicating whether [allows watching]. */
    allowsWatching: boolean;

    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;

    /** Gets or sets a value indicating whether [automatic watch authors]. */
    autoWatchAuthors: boolean;

    /** Gets or sets the Rock.Model.BinaryFileType that will be used for attachments. */
    binaryFileType?: ListItemBag | null;

    /** Gets or sets the color of each note. */
    color?: string | null;

    /** Gets or sets the Rock.Model.EntityType of the entities that Notes of this NoteType  */
    entityType?: ListItemBag | null;

    /** Gets or sets the type of formatting used by notes of this type. */
    formatType: NoteFormatType;

    /** Gets or sets the name of an icon CSS class.  */
    iconCssClass?: string | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets a flag indicating if mentions are supported on this note type. */
    isMentionEnabled: boolean;

    /** Gets or sets a flag indicating that this NoteType is part of the Rock core system/framework. This property is required. */
    isSystem: boolean;

    /** Gets or sets the maximum reply depth. */
    maxReplyDepth?: string | null;

    /** Gets or sets the Name of the NoteType. This property is required. */
    name?: string | null;

    /** Gets or sets a value indicating whether to show the entity type picker to allow user selection. */
    showEntityTypePicker: boolean;

    /** Gets or sets a value indicating whether the type is user selectable. */
    userSelectable: boolean;
};

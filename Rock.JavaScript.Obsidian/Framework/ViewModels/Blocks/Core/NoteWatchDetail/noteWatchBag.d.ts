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

/** Contains the NoteWatch details. */
export type NoteWatchBag = {
    /**
     * Set AllowOverride to False to prevent people from adding an IsWatching=False on NoteWatch with the same filter that is marked as IsWatching=True
     * In other words, if a group is configured a NoteWatch, an individual shouldn't be able to add an un-watch if AllowOverride=False (and any un-watches that may have been already added would be ignored)
     */
    allowOverride: boolean;

    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;

    /** Gets or sets the watch entity. */
    entityId?: number | null;

    /** Gets or sets the name of the entity. */
    entityName?: string | null;

    /** Gets or sets the type of the entity. */
    entityType?: ListItemBag | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Set IsWatching to False to disable this NoteWatch (or specifically don't watch based on the notewatch criteria) */
    isWatching: boolean;

    /** Gets or sets the note. */
    note?: ListItemBag | null;

    /** Gets or sets the type of the note. */
    noteType?: ListItemBag | null;

    /** Gets or sets the watched entity. */
    watchedEntity?: ListItemBag | null;

    /** Gets or sets the watched note text. */
    watchedNoteText?: string | null;

    /** Gets or sets the group that is watching this note watch */
    watcherGroup?: ListItemBag | null;

    /** Gets or sets the person alias of the person watching this note watch */
    watcherPersonAlias?: ListItemBag | null;
};

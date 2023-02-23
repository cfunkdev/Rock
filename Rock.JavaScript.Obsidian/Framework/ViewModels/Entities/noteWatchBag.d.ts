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

/** NoteWatch View Model */
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

    /** Gets or sets the created by person alias identifier. */
    createdByPersonAliasId?: number | null;

    /** Gets or sets the created date time. */
    createdDateTime?: string | null;

    /**
     * Set EntityTypeId and EntityId to watch all notes for a specific entity
     * NOTE: If EntityType is Person, make sure to watch the Person's PersonAlias' Persons
     */
    entityId?: number | null;

    /** Set EntityTypeId and EntityId to watch all notes for a specific entity */
    entityTypeId?: number | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Set IsWatching to False to disable this NoteWatch (or specifically don't watch based on the notewatch criteria) */
    isWatching: boolean;

    /** Gets or sets the modified by person alias identifier. */
    modifiedByPersonAliasId?: number | null;

    /** Gets or sets the modified date time. */
    modifiedDateTime?: string | null;

    /** Set NoteId to watch a specific note */
    noteId?: number | null;

    /**
     * Set NoteTypeId to watch all notes of a specific note type
     * Set NoteTypeId and EntityId to watch all notes of a specific type as it relates to a specific entity 
     */
    noteTypeId?: number | null;

    /** Gets or sets the group that is watching this note watch */
    watcherGroupId?: number | null;

    /** Gets or sets the person alias id of the person watching this note watch */
    watcherPersonAliasId?: number | null;

    /** Gets or sets a value indicating whether [watch replies]. */
    watchReplies: boolean;
};

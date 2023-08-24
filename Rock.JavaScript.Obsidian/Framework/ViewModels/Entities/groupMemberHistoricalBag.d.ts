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

/** GroupMemberHistorical View Model */
export type GroupMemberHistoricalBag = {
    /** Gets or sets the PersonAliasId that archived (soft deleted) this group member at this point in history */
    archivedByPersonAliasId?: number | null;

    /** Gets or sets the archived date time value of this group member at this point in history */
    archivedDateTime?: string | null;

    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;

    /** Gets or sets the created by person alias identifier. */
    createdByPersonAliasId?: number | null;

    /** Gets or sets the created date time. */
    createdDateTime?: string | null;

    /**
     * Gets or sets a value indicating whether [current row indicator].
     * This will be True if this represents the same values as the current tracked record for this
     */
    currentRowIndicator: boolean;

    /**
     * Gets or sets the effective date.
     * This is the starting date that the tracked record had the values reflected in this record
     */
    effectiveDateTime?: string | null;

    /**
     * Gets or sets the expire date time
     * This is the last date that the tracked record had the values reflected in this record
     * For example, if a tracked record's Name property changed on '2016-07-14', the ExpireDate of the previously current record will be '2016-07-13', and the EffectiveDate of the current record will be '2016-07-14'
     * If this is most current record, the ExpireDate will be '9999-01-01'
     */
    expireDateTime?: string | null;

    /** Gets or sets GroupId for this group member record at this point in history */
    groupId: number;

    /** Gets or sets the group member id of the group member for this group member historical record */
    groupMemberId: number;

    /** Gets or sets the group member status of this group member at this point in history */
    groupMemberStatus: number;

    /** Gets or sets the group role id for this group member at this point in history */
    groupRoleId: number;

    /** Gets or sets the group role name at this point in history */
    groupRoleName?: string | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets the InActiveDateTime value of the group member at this point in history (the time when the group member status was changed to GroupMemberStatus.Inactive) */
    inactiveDateTime?: string | null;

    /** Gets or sets a value indicating whether this group member was archived at this point in history */
    isArchived: boolean;

    /** Gets or sets a value indicating whether the group member was IsLeader (which is determined by GroupRole.IsLeader) at this point in history */
    isLeader: boolean;

    /** Gets or sets the modified by person alias identifier. */
    modifiedByPersonAliasId?: number | null;

    /** Gets or sets the modified date time. */
    modifiedDateTime?: string | null;
};
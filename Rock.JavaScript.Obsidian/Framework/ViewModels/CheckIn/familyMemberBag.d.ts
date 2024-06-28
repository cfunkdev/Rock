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

import { PersonBag } from "@Obsidian/ViewModels/CheckIn/personBag";

/**
 * A single member of a family. A family member may not belong to the actual
 * family as they may be assocaited via a "can check-in" relationship. This
 * can be determined by the Rock.ViewModels.CheckIn.FamilyMemberBag.FamilyId value being different
 * from the id on the family object.
 */
export type FamilyMemberBag = {
    /** Gets or sets the primary family identifier this person belongs to. */
    familyId?: string | null;

    /** Gets or sets the person that represents this family member. */
    person?: PersonBag | null;

    /**
     * Gets or sets the group role order. This can be used to order parents
     * above children.
     */
    roleOrder: number;
};

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

/**
 * The request parameters to use when requesting the list of
 * members for a family.
 */
export type FamilyMembersOptionsBag = {
    /**
     * Gets or sets the area identifiers that will be used to
     * determine which options are available for each family member.
     */
    areaIds?: string[] | null;

    /** Gets or sets the configuration template identifier. */
    configurationTemplateId?: string | null;

    /** Gets or sets the family identifier. */
    familyId?: string | null;

    /** Gets or sets the kiosk identifier. */
    kioskId?: string | null;
};

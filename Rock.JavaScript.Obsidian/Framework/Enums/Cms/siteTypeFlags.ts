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
 * Flags for the Rock.Model.SiteType. This enum was introduced with the motivation to improve performance.
 * Prior to this, reflection was the only way to get the SiteTypes on a BlockType which turned out to be expensive.
 * With this enum, the computed SiteTypes could be stored in the database to be read later.
 * The developer should ensure that the values in this enum is in sync with the ones in Rock.Model.SiteType enum.
 */
export const SiteTypeFlags = {
    /** The default Site Type flag. */
    None: 0x0000,

    /** Websites */
    Web: 0x0001,

    /** Mobile applications */
    Mobile: 0x0002,

    /** TV Apps */
    Tv: 0x0004
} as const;

/**
 * Flags for the Rock.Model.SiteType. This enum was introduced with the motivation to improve performance.
 * Prior to this, reflection was the only way to get the SiteTypes on a BlockType which turned out to be expensive.
 * With this enum, the computed SiteTypes could be stored in the database to be read later.
 * The developer should ensure that the values in this enum is in sync with the ones in Rock.Model.SiteType enum.
 */
export const SiteTypeFlagsDescription: Record<number, string> = {
    0: "None",

    1: "Web",

    2: "Mobile",

    4: "Tv"
};

/**
 * Flags for the Rock.Model.SiteType. This enum was introduced with the motivation to improve performance.
 * Prior to this, reflection was the only way to get the SiteTypes on a BlockType which turned out to be expensive.
 * With this enum, the computed SiteTypes could be stored in the database to be read later.
 * The developer should ensure that the values in this enum is in sync with the ones in Rock.Model.SiteType enum.
 */
export type SiteTypeFlags = number;

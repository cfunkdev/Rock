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
 * A single mention source item used to display the possible matches
 * when adding a new mention reference.
 */
export type NoteMentionItemBag = {
    /** Gets or sets the name of the campus this mention belongs to. */
    campusName?: string | null;

    /** Gets or sets the name to display for this mention source. */
    displayName?: string | null;

    /** Gets or sets the e-mail address for this mention source. */
    email?: string | null;

    /** Gets or sets the identifier to store with the mention. */
    identifier?: string | null;

    /** Gets or sets the image to display with name. */
    imageUrl?: string | null;
};

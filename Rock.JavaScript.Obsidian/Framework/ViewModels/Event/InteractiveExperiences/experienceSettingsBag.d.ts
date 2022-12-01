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

import { InteractiveExperienceCampusBehavior } from "@Obsidian/Enums/Event/interactiveExperienceCampusBehavior";

/** Contents of the ExperienceSettingsJson property on an InteractiveExperience. */
export type ExperienceSettingsBag = {
    /**
     * The behavior of campus choices for this experience. See the description
     * of the individual enum values for specific functionality.
     */
    campusBehavior: InteractiveExperienceCampusBehavior;

    /**
     * The default campus to use when recording an Interaction if no other
     * campus could be determined.
     */
    defaultCampusId?: number | null;
};

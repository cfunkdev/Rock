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

import { Guid } from "@Obsidian/Types";
import { LearningActivityCompletionBag } from "../LearningActivityCompletionDetail/learningActivityCompletionBag";
import { LearningClassFacilitatorBag } from "../LearningClassDetail/learningClassFacilitatorBag";
import { LearningParticipantBag } from "../LearningParticipantDetail/learningParticipantBag";
import { BlockBox } from "@Obsidian/ViewModels/Blocks/blockBox";
import { ConfigurationMode } from "@Obsidian/Enums/Lms/configurationMode";

export type PublicLearningClassWorkspaceBox = {
    /** Gets or sets the list of activities for this learning class. */
    activities?: Array<LearningActivityCompletionBag>;

    /** Gets or sets the id for the class. */
    classIdKey?: string;

    /** Gets or sets the id for the course. */
    courseIdKey?: string;

    /** Gets or sets the Guid of the image for the course. */
    courseImageGuid?: Guid;

    /** Gets or sets the name of the course. */
    courseName?: string;

    /** Gets or sets the summary of the course. */
    courseSummary?: string;

    /** Gets or sets the list of facilitators for the learning class. */
    facilitators?: Array<LearningClassFacilitatorBag>;

    /** Gets or sets the HTML to be rendered for the class workspace header content. */
    headerHtml?: string | null;

    /** Gets or sets the participant accessing the course for the learning class. */
    numberOfNotificationsToShow: number;

    /** Gets or sets the participant accessing the course for the learning class. */
    participantBag?: LearningParticipantBag;

    /** Gets or sets the Learning Program's configuration mode. */
    programConfigurationMode: ConfigurationMode;

    /** Whether to show grades on the class overview page. */
    showGrades: boolean;
} & BlockBox;

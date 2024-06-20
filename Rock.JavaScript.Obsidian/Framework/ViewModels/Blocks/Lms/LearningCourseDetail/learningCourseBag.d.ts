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

import { LearningCourseRequirementBag } from "@Obsidian/ViewModels/Blocks/Lms/LearningCourseRequirement/learningCourseRequirementBag";
import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";
import { PublicAttributeBag } from "@Obsidian/ViewModels/Utility/publicAttributeBag";

export type LearningCourseBag = {
    /** Indicates whether or not this course allows students to access after completion. */
    allowHistoricalAccess: boolean;

    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;

    /** Gets or sets the Rock.Model.LearningCourse.Category for the LearningCourse. */
    category?: ListItemBag | null;

    /** Gets or sets the Rock.Model.Category highlight color. */
    categoryColor?: string | null;

    /** Gets or sets the Rock.Model.WorkflowType of the LearningCourse. */
    completionWorkflowType?: ListItemBag | null;

    /** Gets or sets the code for the course. */
    courseCode?: string | null;

    /** Gets or sets the course requirements for this course. */
    courseRequirements?: LearningCourseRequirementBag[] | null;

    /** Gets or sets the number of credits awarded for successful completion of the course. */
    credits: number;

    /** Gets or sets the IdKey of the default learning class for the course. */
    defaultLearningClassIdKey?: string | null;

    /** Gets or sets the description of the course. */
    description?: string | null;

    /** Gets or sets the description of the course as HTML. */
    descriptionAsHtml?: string | null;

    /** Indicates whether or not this course allows announcements. */
    enableAnnouncements: boolean;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets the ImageBinaryFile for the LearningCourse. */
    imageBinaryFile?: ListItemBag | null;

    /** Gets or sets a value indicating whether this course is active. */
    isActive: boolean;

    /**
     * Indicates whether or not this course should 
     * be displayed in public contexts (e.g. on a public site).
     */
    isPublic: boolean;

    /** Gets or sets the number of students at which to stop accepting enrollments. */
    maxStudents?: number | null;

    /** Gets or sets the name of the course. */
    name?: string | null;

    /** Gets or sets the color of the highlight for the the learning program. */
    programHighlightColor?: string | null;

    /** Gets or sets the icon CSS class for the the learning program. */
    programIconCssClass?: string | null;

    /** Gets or sets the public name of the course. */
    publicName?: string | null;

    /** Gets or sets the summary text of the course. */
    summary?: string | null;
};

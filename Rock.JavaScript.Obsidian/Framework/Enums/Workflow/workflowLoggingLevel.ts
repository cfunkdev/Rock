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

/** The level of details to log */
export const WorkflowLoggingLevel = {
    /** Don't log any details */
    None: 0,

    /** Log workflow events */
    Workflow: 1,

    /** Log workflow and activity events */
    Activity: 2,

    /** Log workflow, activity, and action events */
    Action: 3
} as const;

/** The level of details to log */
export const WorkflowLoggingLevelDescription: Record<number, string> = {
    0: "None",

    1: "Workflow",

    2: "Activity",

    3: "Action"
};

/** The level of details to log */
export type WorkflowLoggingLevel = typeof WorkflowLoggingLevel[keyof typeof WorkflowLoggingLevel];

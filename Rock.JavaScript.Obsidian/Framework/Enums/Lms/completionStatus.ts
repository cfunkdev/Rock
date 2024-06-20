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

/** Determines the completion status of a LearningProgramCompletion. */
export const CompletionStatus = {
    /** The program is pending completion. */
    Pending: 0,

    /** The program was completed. */
    Completed: 1,

    /** The program not completed before expiring. */
    Expired: 2
} as const;

/** Determines the completion status of a LearningProgramCompletion. */
export const CompletionStatusDescription: Record<number, string> = {
    0: "Pending",

    1: "Completed",

    2: "Expired"
};

/** Determines the completion status of a LearningProgramCompletion. */
export type CompletionStatus = typeof CompletionStatus[keyof typeof CompletionStatus];

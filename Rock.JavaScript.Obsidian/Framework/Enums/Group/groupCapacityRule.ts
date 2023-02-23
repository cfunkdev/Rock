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

/** Group Capacity Rule */
export const GroupCapacityRule = {
    /** The group does not have capacity limitations */
    None: 0,

    /** The group can not go over capacity */
    Hard: 1,

    /** A warning will be shown if a group is going to go over capacity */
    Soft: 2
} as const;

/** Group Capacity Rule */
export const GroupCapacityRuleDescription: Record<number, string> = {
    0: "None",

    1: "Hard",

    2: "Soft"
};

/** Group Capacity Rule */
export type GroupCapacityRule = typeof GroupCapacityRule[keyof typeof GroupCapacityRule];

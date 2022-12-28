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

/** The type of Metric Value that a Metric Value represents */
export const MetricValueType = {
    /** Metric Value represents something that was measured (for example: Fundraising Total) */
    Measure: 0,

    /** Metric Value represents a goal (for example: Fundraising Goal) */
    Goal: 1
} as const;

/** The type of Metric Value that a Metric Value represents */
export const MetricValueTypeDescription: Record<number, string> = {
    0: "Measure",

    1: "Goal"
};

/** The type of Metric Value that a Metric Value represents */
export type MetricValueType = typeof MetricValueType[keyof typeof MetricValueType];

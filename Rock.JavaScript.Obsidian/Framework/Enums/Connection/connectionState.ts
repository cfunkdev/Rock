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

/** Type of connection state */
export const ConnectionState = {
    /** Active */
    Active: 0,

    /** Inactive */
    Inactive: 1,

    /** Future Follow-up */
    FutureFollowUp: 2,

    /** Connected */
    Connected: 3
} as const;

/** Type of connection state */
export const ConnectionStateDescription: Record<number, string> = {
    0: "Active",

    1: "Inactive",

    2: "Future Follow Up",

    3: "Connected"
};

/** Type of connection state */
export type ConnectionState = typeof ConnectionState[keyof typeof ConnectionState];

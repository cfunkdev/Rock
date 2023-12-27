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

/** The age bracket of a person */
export const AgeBracket = {
    /** Unknown Age range */
    Unknown: 0,

    /** Age range 0 - 5 */
    ZeroToFive: 9,

    /** Age range 6 - 12 */
    SixToTwelve: 1,

    /** Age range 13 - 17 */
    ThirteenToSeventeen: 2,

    /** Age range 18 - 24 */
    EighteenToTwentyFour: 3,

    /** Age range 25 - 34 */
    TwentyFiveToThirtyFour: 4,

    /** Age range 35 - 44 */
    ThirtyFiveToFortyFour: 5,

    /** Age range 45 - 54 */
    FortyFiveToFiftyFour: 6,

    /** Age range 55 - 64 */
    FiftyFiveToSixtyFour: 7,

    /** Age range 65+ */
    SixtyFiveOrOlder: 8
} as const;

/** The age bracket of a person */
export const AgeBracketDescription: Record<number, string> = {
    0: "Unknown",

    9: "0 - 5",

    1: "6 - 12",

    2: "13 - 17",

    3: "18 - 24",

    4: "25 - 34",

    5: "35 - 44",

    6: "40 - 54",

    7: "55 - 64",

    8: "65+"
};

/** The age bracket of a person */
export type AgeBracket = typeof AgeBracket[keyof typeof AgeBracket];

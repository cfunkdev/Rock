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

/** Represents the preferred color depth of the binary file type. */
export const ColorDepth = {
    /** An undefined color depth. */
    Undefined: -1,

    /** A preferred color depth of Black and White. */
    BlackWhite: 0,

    /** A preferred color depth of 8-bit Grayscale. */
    Grayscale8bit: 1,

    /** A preferred color depth of 24-bit Grayscale. */
    Grayscale24bit: 2,

    /** A preferred color depth of 8-bit Color. */
    Color8bit: 3,

    /** A preferred color depth of 24-bit Color. */
    Color24bit: 4
} as const;

/** Represents the preferred color depth of the binary file type. */
export const ColorDepthDescription: Record<number, string> = {
    [-1]: "Undefined",

    0: "Black White",

    1: "Grayscale 8bit",

    2: "Grayscale 2 4bit",

    3: "Color 8bit",

    4: "Color 2 4bit"
};

/** Represents the preferred color depth of the binary file type. */
export type ColorDepth = typeof ColorDepth[keyof typeof ColorDepth];

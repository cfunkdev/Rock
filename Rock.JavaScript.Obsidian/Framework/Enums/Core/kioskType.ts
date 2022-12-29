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

/** The various types of checkin clients that a Check-in Kiosk could be using. */
export const KioskType = {
    /** The Kiosk is using IPad iOS Checkin Client app. */
    IPad: 0,

    /** The Kiosk is using Windows Checkin Client. */
    WindowsApp: 1,

    /** This kiosk is using a browser */
    Browser: 2
} as const;

/** The various types of checkin clients that a Check-in Kiosk could be using. */
export const KioskTypeDescription: Record<number, string> = {
    0: "iPad",

    1: "Windows App",

    2: "Browser"
};

/** The various types of checkin clients that a Check-in Kiosk could be using. */
export type KioskType = typeof KioskType[keyof typeof KioskType];

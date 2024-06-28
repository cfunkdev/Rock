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

import { Gender } from "@Obsidian/Enums/Crm/gender";
import { CheckInItemBag } from "@Obsidian/ViewModels/CheckIn/checkInItemBag";

/** A family member that identifies a single individual for check-in. */
export type PersonBag = {
    /** Gets or sets the current ability level of the person. */
    abilityLevel?: CheckInItemBag | null;

    /** Gets or sets the age. */
    age?: number | null;

    /** Gets or sets the precise age as a floating point number. */
    agePrecise?: number | null;

    /**
     * Gets or sets the birth date. If this date is used, the time zone
     * information should be thrown away so that just the raw date is
     * left. Otherwise the birthdate might shift by one day depending
     * on the time zone.
     */
    birthDate?: string | null;

    /** Gets or sets the birth day. */
    birthDay?: number | null;

    /** Gets or sets the birth month. */
    birthMonth?: number | null;

    /** Gets or sets the birth year. */
    birthYear?: number | null;

    /** Gets or sets the first name. */
    firstName?: string | null;

    /** Gets or sets the full name. */
    fullName?: string | null;

    /** Gets or sets the person's gender. */
    gender: Gender;

    /** Gets or sets the grade formatted for display purposes. */
    gradeFormatted?: string | null;

    /**
     * Gets or sets the grade offset, this should only be used for sorting
     * purposes. To display the grade use the GradeFormatted property.
     */
    gradeOffset?: number | null;

    /** Gets or sets the identifier of the Person. */
    id?: string | null;

    /** Gets or sets the last name. */
    lastName?: string | null;

    /** Gets or sets the person's nick name. */
    nickName?: string | null;

    /** Gets or sets the photo URL. */
    photoUrl?: string | null;
};

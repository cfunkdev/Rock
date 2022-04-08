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

import { IEntity } from "../entity";

export type NcoaHistory = IEntity & {
    addressInvalidReason?: number;
    addressStatus?: number;
    attributeValues?: Record<string, unknown>;
    familyId?: number;
    locationId?: number | null;
    matchFlag?: number;
    moveDate?: string | null;
    moveDistance?: number | null;
    moveType?: number;
    ncoaNote?: string | null;
    ncoaRunDateTime?: string;
    ncoaType?: number;
    originalCity?: string | null;
    originalPostalCode?: string | null;
    originalState?: string | null;
    originalStreet1?: string | null;
    originalStreet2?: string | null;
    personAliasId?: number;
    processed?: number;
    updatedAddressType?: number;
    updatedBarcode?: string | null;
    updatedCity?: string | null;
    updatedCountry?: string | null;
    updatedPostalCode?: string | null;
    updatedState?: string | null;
    updatedStreet1?: string | null;
    updatedStreet2?: string | null;
    createdDateTime?: string | null;
    modifiedDateTime?: string | null;
    createdByPersonAliasId?: number | null;
    modifiedByPersonAliasId?: number | null;
};

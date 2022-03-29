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

export type Location = IEntity & {
    assessorParcelId?: string | null;
    attributeValues?: Record<string, unknown>;
    barcode?: string | null;
    city?: string | null;
    country?: string | null;
    county?: string | null;
    firmRoomThreshold?: number | null;
    geocodeAttemptedDateTime?: string | null;
    geocodeAttemptedResult?: string | null;
    geocodeAttemptedServiceType?: string | null;
    geocodedDateTime?: string | null;
    geoFence?: Record<string, unknown>;
    geoPoint?: Record<string, unknown>;
    imageId?: number | null;
    isActive?: boolean;
    isGeoPointLocked?: boolean | null;
    locationTypeValueId?: number | null;
    name?: string | null;
    parentLocationId?: number | null;
    postalCode?: string | null;
    printerDeviceId?: number | null;
    softRoomThreshold?: number | null;
    standardizeAttemptedDateTime?: string | null;
    standardizeAttemptedResult?: string | null;
    standardizeAttemptedServiceType?: string | null;
    standardizedDateTime?: string | null;
    state?: string | null;
    street1?: string | null;
    street2?: string | null;
    createdDateTime?: string | null;
    modifiedDateTime?: string | null;
    createdByPersonAliasId?: number | null;
    modifiedByPersonAliasId?: number | null;
};

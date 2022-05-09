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

import { Guid } from "@Obsidian/Types";
import { PublicAttributeBag } from "@Obsidian/ViewModels/Utility/publicAttributeBag";

/** Location View Model */
export type LocationBag = {
    /** Gets or sets the AssessorParcelId. */
    assessorParcelId?: string | null;

    /** Gets or sets the Barcode. */
    barcode?: string | null;

    /** Gets or sets the City. */
    city?: string | null;

    /** Gets or sets the Country. */
    country?: string | null;

    /** Gets or sets the County. */
    county?: string | null;

    /** Gets or sets the FirmRoomThreshold. */
    firmRoomThreshold?: number | null;

    /** Gets or sets the GeocodeAttemptedDateTime. */
    geocodeAttemptedDateTime?: string | null;

    /** Gets or sets the GeocodeAttemptedResult. */
    geocodeAttemptedResult?: string | null;

    /** Gets or sets the GeocodeAttemptedServiceType. */
    geocodeAttemptedServiceType?: string | null;

    /** Gets or sets the GeocodedDateTime. */
    geocodedDateTime?: string | null;

    /** Gets or sets the GeoFence. */
    geoFence?: unknown;

    /** Gets or sets the GeoPoint. */
    geoPoint?: unknown;

    /** Gets or sets the ImageId. */
    imageId?: number | null;

    /** Gets or sets the IsActive. */
    isActive: boolean;

    /** Gets or sets the IsGeoPointLocked. */
    isGeoPointLocked?: boolean | null;

    /** Gets or sets the LocationTypeValueId. */
    locationTypeValueId?: number | null;

    /** Gets or sets the Name. */
    name?: string | null;

    /** Gets or sets the ParentLocationId. */
    parentLocationId?: number | null;

    /** Gets or sets the PostalCode. */
    postalCode?: string | null;

    /** Gets or sets the PrinterDeviceId. */
    printerDeviceId?: number | null;

    /** Gets or sets the SoftRoomThreshold. */
    softRoomThreshold?: number | null;

    /** Gets or sets the StandardizeAttemptedDateTime. */
    standardizeAttemptedDateTime?: string | null;

    /** Gets or sets the StandardizeAttemptedResult. */
    standardizeAttemptedResult?: string | null;

    /** Gets or sets the StandardizeAttemptedServiceType. */
    standardizeAttemptedServiceType?: string | null;

    /** Gets or sets the StandardizedDateTime. */
    standardizedDateTime?: string | null;

    /** Gets or sets the State. */
    state?: string | null;

    /** Gets or sets the Street1. */
    street1?: string | null;

    /** Gets or sets the Street2. */
    street2?: string | null;

    /** Gets or sets the CreatedDateTime. */
    createdDateTime?: string | null;

    /** Gets or sets the ModifiedDateTime. */
    modifiedDateTime?: string | null;

    /** Gets or sets the CreatedByPersonAliasId. */
    createdByPersonAliasId?: number | null;

    /** Gets or sets the ModifiedByPersonAliasId. */
    modifiedByPersonAliasId?: number | null;

    /** Gets or sets the Id. */
    id: number;

    /** Gets or sets the Guid. */
    guid?: Guid | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;
};

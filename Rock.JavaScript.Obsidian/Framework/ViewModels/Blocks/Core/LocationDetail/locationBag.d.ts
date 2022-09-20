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

import { AddressControlBag } from "@Obsidian/ViewModels/Controls/addressControlBag";
import { ListItemBag } from "@Obsidian/ViewModels/Utility/listItemBag";
import { PublicAttributeBag } from "@Obsidian/ViewModels/Utility/publicAttributeBag";

export type LocationBag = {
    /** Gets or sets threshold that will prevent checkin (no option to override) */
    firmRoomThreshold?: number | null;

    /** Gets or sets the image identifier. */
    imageId?: number | null;

    /** Gets or sets a value indicating whether this instance is active. */
    isActive: boolean;

    /** Gets or sets flag indicating if GeoPoint is locked (shouldn't be geocoded again) */
    isGeoPointLocked?: boolean | null;

    /**
     * Gets or sets the Id of the LocationType Rock.Model.DefinedValue that is used to identify the type of Rock.Model.Location
     * that this is. Examples: Campus, Building, Room, etc
     */
    locationTypeValue?: ListItemBag | null;

    /** Gets or sets the Location's Name. */
    name?: string | null;

    /** Gets or sets the if the location's parent Location.  */
    parentLocation?: ListItemBag | null;

    /** Gets or sets the Rock.Model.Device Id of the printer (if any) associated with the location. */
    printerDevice?: ListItemBag | null;

    /** Gets or sets a threshold that will prevent checkin unless a manager overrides */
    softRoomThreshold?: number | null;

    /** Gets or sets the address fields. */
    addressFields?: AddressControlBag | null;

    /** Gets or sets the formatted HTML address. */
    formattedHtmlAddress?: string | null;

    /** Gets or sets the GeoFence image HTML. */
    geoFenceImageHtml?: string | null;

    /** Gets or sets the GeoPoint image HTML. */
    geoPointImageHtml?: string | null;

    geoPoint_WellKnownText?: string | null;

    geoFence_WellKnownText?: string | null;

    /** Gets or sets the identifier key of this entity. */
    idKey?: string | null;

    /** Gets or sets the attributes. */
    attributes?: Record<string, PublicAttributeBag> | null;

    /** Gets or sets the attribute values. */
    attributeValues?: Record<string, string> | null;
};

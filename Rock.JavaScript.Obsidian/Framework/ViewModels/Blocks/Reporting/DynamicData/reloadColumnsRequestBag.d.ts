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

import { ColumnConfigurationBag } from "@Obsidian/ViewModels/Blocks/Reporting/DynamicData/columnConfigurationBag";

/** A bag that contains information needed to reload columns for the dynamic data block. */
export type ReloadColumnsRequestBag = {
    /**
     * Gets or sets the existing configuration objects describing how each column of the
     * grid results should be displayed, as well as rules for filtering, exporting, Etc.
     */
    existingColumnConfigurations?: ColumnConfigurationBag[] | null;

    /** Gets or sets whether the query represents the name of a stored procedure to execute. */
    isStoredProcedure: boolean;

    /** Gets or sets the parameters required by the query or stored procedure. */
    parameters?: string | null;

    /** Gets or sets the SQL query or stored procedure name to execute. */
    query?: string | null;

    /** Gets or sets the amount of time in seconds to allow the query to run before timing out. */
    timeout?: number | null;
};
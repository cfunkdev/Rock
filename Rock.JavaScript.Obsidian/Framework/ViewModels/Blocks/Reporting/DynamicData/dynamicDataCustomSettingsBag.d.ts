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

/** The settings that will be edited in the custom settings panel for the dynamic data block. */
export type DynamicDataCustomSettingsBag = {
    /**
     * Gets or sets configuration objects describing how each column of the grid
     * results should be displayed, as well as rules for filtering, exporting, Etc.
     */
    columnConfigurations?: ColumnConfigurationBag[] | null;

    /** Gets or sets the column name(s) that should be available to use as merge fields for the communication. */
    communicationMergeFields?: string | null;

    /** Gets or sets the column name(s) that contain a person ID field to use as the recipient for a communication. */
    communicationRecipientFields?: string | null;

    /** Gets or sets whether to disable paging on the grid. */
    disablePaging: boolean;

    /** Gets or sets whether to show 'Bulk Update' button in the grid. */
    enableBulkUpdate: boolean;

    /** Gets or sets whether to show 'Communicate' button in the grid. */
    enableCommunications: boolean;

    /** Gets or sets whether to show 'Export to Excel' and 'Export to CSV' buttons in the grid. */
    enableExport: boolean;

    /** Get or sets whether to show 'Launch Workflow' button in the grid. */
    enableLaunchWorkflow: boolean;

    /** Gets or sets whether to show 'Merge Template' button in the grid. */
    enableMergeTemplate: boolean;

    /** Gets or sets whether to enable the updating of the parent page's name and description. */
    enablePageUpdate: boolean;

    /** Gets or sets whether to show 'Merge Person Records' button in the grid. */
    enablePersonMerge: boolean;

    /** Gets or sets whether the header on the grid will be sticky at the top of the page. */
    enableStickyHeader: boolean;

    /** Gets or sets a comma-separated list of field names that need to be decrypted before displaying their value. */
    encryptedFields?: string | null;

    /** Gets or set the Lava template to be rendered below the grid. */
    gridFooterContent?: string | null;

    /** Gets or sets the Lava template to be rendered above the grid. */
    gridHeaderContent?: string | null;

    /** Gets or sets the grid's title. */
    gridTitle?: string | null;

    /** Gets or sets whether the query returns a list of people. */
    isPersonReport: boolean;

    /** Gets or sets whether the query represents the name of a stored procedure to execute. */
    isStoredProcedure: boolean;

    /** Gets or sets the formatting to apply to the returned results. */
    lavaTemplate?: string | null;

    /** Gets or sets the page description. */
    pageDescription?: string | null;

    /** Gets or sets the page name. */
    pageName?: string | null;

    /** Gets or sets optional Lava for setting the page title. */
    pageTitleLava?: string | null;

    /** Gets or sets the parameters required by the query or stored procedure. */
    parameters?: string | null;

    /** Gets or sets the SQL query or stored procedure name to execute. */
    query?: string | null;

    /** Gets or sets how the results should be displayed. */
    resultsDisplayMode?: string | null;

    /** Gets or sets the URL to redirect individual to when they click on a row in the grid. */
    selectionUrl?: string | null;

    /** Gets or sets whether to show the checkbox select column on the grid as the first column. */
    showCheckboxSelectionColumn: boolean;

    /** Gets or sets the amount of time in seconds to allow the query to run before timing out. */
    timeout?: number | null;
};
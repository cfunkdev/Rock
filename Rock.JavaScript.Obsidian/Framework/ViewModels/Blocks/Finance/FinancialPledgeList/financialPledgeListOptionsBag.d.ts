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

/** The additional configuration options for the Financial Pledge List block. */
export type FinancialPledgeListOptionsBag = {
    /** Determines if the results should be limited to pledges for the current person. */
    limitPledgesToCurrentPerson: boolean;

    /** Determines if the accounts column should be displayed. */
    showAccountsColumn: boolean;

    /** Determines if the account summary should be displayed at the bottom of the list. */
    showAccountSummary: boolean;

    /** Determines if the group column should be displayed. */
    showGroupColumn: boolean;

    /** Determines if the last modified date column should be displayed. */
    showLastModifiedDateColumn: boolean;
};

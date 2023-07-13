﻿// <copyright>
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

using System;

namespace Rock.Plugin.HotFixes
{
    /// <summary>
    /// Plug-in migration
    /// </summary>
    /// <seealso cref="Rock.Plugin.Migration" />
    [MigrationNumber( 183, "1.15.1" )]
    public class MigrationRollupsForV15_2_2 : Migration
    {
        
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            AddSystemSettingsForRaceAndEthnicityPickerLabel();
            AddAttributeForAssessmentList();
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            // Down migrations are not yet supported in plug-in migrations.
        }

        /// <summary>
        /// KA: Migration to add SystemSettings for Race and Ethnicity Picker Labels
        /// </summary>
        private void AddSystemSettingsForRaceAndEthnicityPickerLabel()
        {
            RockMigrationHelper.AddGlobalAttribute( Rock.SystemGuid.FieldType.TEXT, Rock.Model.Attribute.SYSTEM_SETTING_QUALIFIER, string.Empty, "core_Person Ethnicity Label", "", 0, "Ethnicity", Guid.NewGuid().ToString(),
                Rock.SystemKey.SystemSetting.PERSON_ETHNICITY_LABEL, false );

            RockMigrationHelper.AddGlobalAttribute( Rock.SystemGuid.FieldType.TEXT, Rock.Model.Attribute.SYSTEM_SETTING_QUALIFIER, string.Empty, "core_Person Race Label", "", 0, "Race", Guid.NewGuid().ToString(),
                Rock.SystemKey.SystemSetting.PERSON_RACE_LABEL, false );
        }

        /// <summary>
        /// GJ: Assessment List Template Update
        /// </summary>
        private void AddAttributeForAssessmentList()
        {
            RockMigrationHelper.AddOrUpdateBlockTypeAttribute( "0AD1D108-4ABF-4AED-B3B7-4AAEA16D10E4", "1D0D3794-C210-48A8-8C68-3FBEC08A6BA5", "Lava Template", "LavaTemplate", "", @"The lava template to use to format the entire block.  <span class='tip tip-lava'></span> <span class='tip tip-html'></span>", 3, @"<div class=""panel panel-default"">
    <div class=""panel-heading"">Assessments</div>
    <div class=""panel-body"">
            {% for assessmenttype in AssessmentTypes %}
                {% if assessmenttype.LastRequestObject %}
                    {% if assessmenttype.LastRequestObject.Status == 'Complete' %}
                        <div class='panel panel-success'>
                            <div class=""panel-heading"">{{ assessmenttype.Title }}<br />
                                Completed: {{ assessmenttype.LastRequestObject.CompletedDate | Date:'sd' }} <br />
                                <div>
                                <a href=""{{ assessmenttype.AssessmentResultsPath}}"" class=""d-inline-block"">View Results</a> {% if assessmenttype.AssessmentRetakePath != '' %}<br/><a href=""{{ assessmenttype.AssessmentRetakePath }}"" class=""d-inline-block mt-2"">Retake Assessment</a>{% endif %}</div>
                            </div>
                        </div>
                    {% elseif assessmenttype.LastRequestObject.Status == 'Pending' %}
                        <div class=""panel panel-warning"">
                            <div class=""panel-heading"">
                                {{ assessmenttype.Title }}<br />
                                Requested: {{assessmenttype.LastRequestObject.Requester}} ({{ assessmenttype.LastRequestObject.RequestedDate | Date:'sd'}})<br />
                                <a href=""{{ assessmenttype.AssessmentPath}}"">Start Assessment</a>
                            </div>
                        </div>
                    {% endif %}
                    {% else %}
                        <div class=""panel panel-default"">
                            <div class=""panel-heading"">{{ assessmenttype.Title }}<br/>
                                Available<br />
                                <a href=""{{ assessmenttype.AssessmentPath}}"">Start Assessment</a>
                            </div>
                        </div>
                {% endif %}
            {% endfor %}
    </div>
</div>", "044D444A-ECDC-4B7A-8987-91577AAB227C" );
        }
    }
}

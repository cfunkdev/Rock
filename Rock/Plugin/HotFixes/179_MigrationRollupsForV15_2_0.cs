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

namespace Rock.Plugin.HotFixes
{
    /// <summary>
    /// Plug-in migration
    /// </summary>
    /// <seealso cref="Rock.Plugin.Migration" />
    [MigrationNumber( 179, "1.15.1" )]
    public class MigrationRollupsForV15_2_0 : Migration
    {
        
        /// <summary>
        /// Operations to be performed during the upgrade process.
        /// </summary>
        public override void Up()
        {
            UpdateStockWorkflowEmailLavaTemplates();
            MobileGroupMembersTemplateUp();
            GetCurrentPersonImpersonationSecurityUp();
        }

        /// <summary>
        /// Operations to be performed during the downgrade process.
        /// </summary>
        public override void Down()
        {
            // Down migrations are not yet supported in plug-in migrations.
        }

        /// <summary>
        /// KA: Migration to update stock workflow email lava templates
        /// </summary>
        private void UpdateStockWorkflowEmailLavaTemplates()
        {
            Sql( @"UPDATE AttributeValue
SET Value = CASE
	WHEN Value LIKE '%{[%] if Workflow | Attribute:''ApprovalNotes'' != null [%]}%' THEN
		REPLACE(Value,'{% if Workflow | Attribute:''ApprovalNotes'' != null %}','{% assign approvalNotes = Workflow | Attribute:''ApprovalNotes'' %}{% if approvalNotes != empty %}')
	WHEN Value LIKE '%{[%] if Workflow | Attribute:''Resolution'' != Empty [%]}%' THEN
		REPLACE(Value,'{% if Workflow | Attribute:''Resolution'' != Empty %}','{% assign resolution = Workflow | Attribute:''Resolution'' %}{% if resolution != empty %}')
	ELSE
		Value
	END
WHERE AttributeId = (SELECT Id FROM Attribute WHERE Guid = '4D245B9E-6B03-46E7-8482-A51FBA190E4D')" );
        }

        /// <summary>
        /// Adds the default template for the mobile group members block.
        /// BC: Group Members Block Template
        /// </summary>
        private void MobileGroupMembersTemplateUp()
        {
            const string standardIconSvg = "PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9Im5vIj8+CjwhRE9DVFlQRSBzdmcgUFVCTElDICItLy9XM0MvL0RURCBTVkcgMS4xLy9FTiIgImh0dHA6Ly93d3cudzMub3JnL0dyYXBoaWNzL1NWRy8xLjEvRFREL3N2ZzExLmR0ZCI+Cjxzdmcgd2lkdGg9IjEwMCUiIGhlaWdodD0iMTAwJSIgdmlld0JveD0iMCAwIDY0MCAyNDAiIHZlcnNpb249IjEuMSIgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB4bWxuczp4bGluaz0iaHR0cDovL3d3dy53My5vcmcvMTk5OS94bGluayIgeG1sOnNwYWNlPSJwcmVzZXJ2ZSIgeG1sbnM6c2VyaWY9Imh0dHA6Ly93d3cuc2VyaWYuY29tLyIgc3R5bGU9ImZpbGwtcnVsZTpldmVub2RkO2NsaXAtcnVsZTpldmVub2RkO3N0cm9rZS1saW5lam9pbjpyb3VuZDtzdHJva2UtbWl0ZXJsaW1pdDoyOyI+CiAgICA8ZyB0cmFuc2Zvcm09Im1hdHJpeCgxLjEwMTU1LDAsMCwxLC0zMC44NDM0LC0zMSkiPgogICAgICAgIDxyZWN0IHg9IjI4IiB5PSIzMSIgd2lkdGg9IjU4MSIgaGVpZ2h0PSIxOCIgc3R5bGU9ImZpbGw6cmdiKDIzMSwyMzEsMjMxKTsiLz4KICAgIDwvZz4KICAgIDxnIHRyYW5zZm9ybT0ibWF0cml4KDAuOTY1NTc3LDAsMCwxLC0yNy4wMzYxLDEyKSI+CiAgICAgICAgPHJlY3QgeD0iMjgiIHk9IjMxIiB3aWR0aD0iNTgxIiBoZWlnaHQ9IjE4IiBzdHlsZT0iZmlsbDpyZ2IoMjMxLDIzMSwyMzEpOyIvPgogICAgPC9nPgogICAgPGcgdHJhbnNmb3JtPSJtYXRyaXgoMS4wMjA2NSwwLDAsMSwtMjguNTc4Myw1NSkiPgogICAgICAgIDxyZWN0IHg9IjI4IiB5PSIzMSIgd2lkdGg9IjU4MSIgaGVpZ2h0PSIxOCIgc3R5bGU9ImZpbGw6cmdiKDIzMSwyMzEsMjMxKTsiLz4KICAgIDwvZz4KICAgIDxnIHRyYW5zZm9ybT0ibWF0cml4KDAuOTg0NTA5LDAsMCwxLC0yNy41NjYzLDk4KSI+CiAgICAgICAgPHJlY3QgeD0iMjgiIHk9IjMxIiB3aWR0aD0iNTgxIiBoZWlnaHQ9IjE4IiBzdHlsZT0iZmlsbDpyZ2IoMjMxLDIzMSwyMzEpOyIvPgogICAgPC9nPgogICAgPGcgdHJhbnNmb3JtPSJtYXRyaXgoMS4wNTY4LDAsMCwxLC0yOS41OTA0LDE0MSkiPgogICAgICAgIDxyZWN0IHg9IjI4IiB5PSIzMSIgd2lkdGg9IjU4MSIgaGVpZ2h0PSIxOCIgc3R5bGU9ImZpbGw6cmdiKDIzMSwyMzEsMjMxKTsiLz4KICAgIDwvZz4KICAgIDxnIHRyYW5zZm9ybT0ibWF0cml4KDEuMDc5MTcsMCwwLDEsLTMwLjIxNjksMTg0KSI+CiAgICAgICAgPHJlY3QgeD0iMjgiIHk9IjMxIiB3aWR0aD0iNTgxIiBoZWlnaHQ9IjE4IiBzdHlsZT0iZmlsbDpyZ2IoMjMxLDIzMSwyMzEpOyIvPgogICAgPC9nPgo8L3N2Zz4K";

            RockMigrationHelper.UpdateDefinedValue( SystemGuid.DefinedType.TEMPLATE_BLOCK,
              "Mobile > Crm > Group Members",
              string.Empty,
              SystemGuid.DefinedValue.BLOCK_TEMPLATE_MOBILE_GROUP_MEMBERS );

            RockMigrationHelper.AddOrUpdateTemplateBlockTemplate(
              "13470DDB-5F8C-4EA2-93FD-B738F37C9AFC",
              Rock.SystemGuid.DefinedValue.BLOCK_TEMPLATE_MOBILE_GROUP_MEMBERS,
              "Default",
              @"{% for group in Groups %}
    <StackLayout>
        <Label Text=""{{ group.Group.Name }}"" 
            StyleClass=""h3"" />
        
        <Frame StyleClass=""p-0""
            HasShadow=""False"">
            <Grid
                ColumnDefinitions=""*, 32"">
                <ScrollView Orientation=""Horizontal""
                    Grid.Column=""0""
                    HorizontalScrollBarVisibility=""Never"">
                    <StackLayout Orientation=""Horizontal"">
                      {% for member in group.Group.Members %}
                        <!-- We want to exclude the actual person from this list -->
                        {% if Person.Id != member.Person.Id %}
                            <StackLayout>
                            {% assign publicApplicationRoot = 'Global' | Attribute:'PublicApplicationRoot' %}
                            {% assign photoUrl = publicApplicationRoot | Append:member.Person.PhotoUrl %}
                            <Rock:Image Source=""{{ photoUrl | Escape }}""
                                WidthRequest=""48""
                                HeightRequest=""48"">
                                <Rock:CircleTransformation />
                            </Rock:Image>
                            <Label Text=""{{ member.Person.NickName }}""
                                HorizontalTextAlignment=""Center"" />
                        </StackLayout>
                        {% else %}
                            <ContentView />
                        {% endif %}
                      {% endfor %}

                    {% if EditPage and group.CanEdit %}
                    <StackLayout.GestureRecognizers>
                        <TapGestureRecognizer Command=""{Binding PushPage}""
                            CommandParameter=""{{ EditPage }}?GroupGuid={{ group.Group.Guid }}"" />
                    </StackLayout.GestureRecognizers>
                    {% endif %}
                    </StackLayout>
                </ScrollView>
                {% if EditPage and group.CanEdit %}
                    <Rock:Icon Grid.Column=""1""
                        IconClass=""chevron-right""
                        WidthRequest=""32""
                        HeightRequest=""32"" 
                        VerticalTextAlignment=""Center""
                        HorizontalTextAlignment=""End"" /> 
                    <Grid.GestureRecognizers>
                        <TapGestureRecognizer Command=""{Binding PushPage}""
                            CommandParameter=""{{ EditPage }}?GroupGuid={{ group.Group.Guid }}"" />
                    </Grid.GestureRecognizers>
                {% endif %}
            </Grid>
        </Frame>
    </StackLayout>
{% endfor %}",
              standardIconSvg,
              "standard-template.svg",
              "image/svg+xml" );
        }

        /// <summary>
        /// Removes the default template for the mobile group members block.
        /// </summary>
        private void MobileGroupMembersTemplateDown()
        {
            RockMigrationHelper.DeleteTemplateBlockTemplate( "13470DDB-5F8C-4EA2-93FD-B738F37C9AFC" );
            RockMigrationHelper.DeleteDefinedValue( SystemGuid.DefinedValue.BLOCK_TEMPLATE_MOBILE_GROUP_MEMBERS );
        }

        /// <summary>
        /// Adds access for all authenticated users to receive an impersonation token using this endpoint.
        /// BC: Mobile Current Person Impersonation Token Endpoint Security
        /// </summary>
        private void GetCurrentPersonImpersonationSecurityUp()
        {
            var restActionPath = "People^String GetCurrentPersonImpersonationToken(Nullable`1[DateTimeOffset], Nullable`1[Int32], Nullable`1[Int32])";
            RockMigrationHelper.AddSecurityAuthForRestAction( "GET", restActionPath,
            0,
            Rock.Security.Authorization.VIEW,
            true,
            string.Empty,
            Rock.Model.SpecialRole.AllAuthenticatedUsers,
            "22697EFE-6C6F-4F59-9D01-974AF1197F2F" );

            RockMigrationHelper.AddSecurityAuthForRestAction( "GET", "People^String GetCurrentPersonImpersonationToken(Nullable`1[DateTimeOffset], Nullable`1[Int32], Nullable`1[Int32])",
            0,
            Rock.Security.Authorization.VIEW,
            true,
            Rock.SystemGuid.Group.GROUP_MOBILE_APPLICATION_USERS,
            Model.SpecialRole.None,
            "93AFF421-D2B9-46A7-8420-70EC2FF8CD38" );
        }

        /// <summary>
        /// Removes access for all authenticated users to receive an impersonation token using this endpoint.
        /// </summary>
        private void GetCurrentPersonImpersonationSecurityDown()
        {
            RockMigrationHelper.DeleteSecurityAuth( "22697EFE-6C6F-4F59-9D01-974AF1197F2F" );
            RockMigrationHelper.DeleteSecurityAuth( "93AFF421-D2B9-46A7-8420-70EC2FF8CD38" );
        }
    }
}

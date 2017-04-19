﻿// <copyright>
// Copyright by the Central Christian Church
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
using Rock.Plugin;

namespace com.centralaz.RoomManagement.Migrations
{
    [MigrationNumber( 6, "1.6.0" )]
    public class OptionalResourceLocation : Migration
    {
        public override void Up()
        {
            AddColumn( "[dbo].[_com_centralaz_RoomManagement_Resource]", "LocationId", c => c.Int() );
            //AddForeignKey( "[dbo].[_com_centralaz_RoomManagement_Resource]", "LocationId", "dbo.Location", "Id" );
            Sql( @"
                ALTER TABLE [dbo].[_com_centralaz_RoomManagement_Resource]  WITH CHECK ADD  CONSTRAINT [FK__com_centralaz_RoomManagement_Resource_Location] FOREIGN KEY([LocationId])
                REFERENCES [dbo].[Location] ([Id])
" );
            RockMigrationHelper.AddBlockAttributeValue( "AF897B42-21AA-4A56-B0D7-9E5303D4CE53", "1322186A-862A-4CF1-B349-28ECB67229BA", @"{% include '~~/Assets/Lava/PageListAsTabs.lava' %}<hr class='margin-t-sm'></hr>" ); // Template

            // Add New Reservation Detail page to the Available Resources block page.
            RockMigrationHelper.AddBlockAttributeValue( "1B4F3A33-656B-4FCB-A446-D481782DE8B4", "85ECB608-B64E-43C0-986C-FC8FD38F9D81", "4CBD2B96-E076-46DF-A576-356BCA5E577F" ); // Detail Page
        }

        public override void Down()
        {
            DropForeignKey( "[dbo].[_com_centralaz_RoomManagement_Resource]", "LocationId" );
            DropColumn( "[dbo].[_com_centralaz_RoomManagement_Resource]", "LocationId" );
        }
    }
}

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
//

using System;
using System.ComponentModel;
using System.Data;
using System.Collections.Generic;
using Rock.Attribute;
using Rock.Model;
using Rock.Data;
using Rock.ViewModels.Utility;
using Rock.ViewModels.Blocks.Engagement.Steps;
using Rock.Web.Cache;

namespace Rock.Blocks.Engagement.Steps
{
    /// <summary>
    /// An example block.
    /// </summary>
    /// <seealso cref="Rock.Blocks.RockObsidianBlockType" />

    [DisplayName( "Step Flow" )]
    [Category( "Steps" )]
    [Description( "Show the flow of individuals as they move through the four step types in the Discipleship Path program." )]
    [IconCssClass( "fa fa-users" )]
    [Rock.SystemGuid.EntityTypeGuid( "308D8252-7712-4A45-8DE4-737C3EEAEA8F" )]
    [Rock.SystemGuid.BlockTypeGuid( "2B4E0128-BCDF-48BF-AEC9-85001169DA3E" )]

    #region Block Attributes

    [IntegerField(
        "Node Width",
        Key = AttributeKey.NodeWidth,
        Description = "How many pixels wide should the nodes be?",
        DefaultValue = "12",
        Order = 1 )]

    [IntegerField(
        "Node Vertical Spacing",
        Key = AttributeKey.NodeVerticalSpacing,
        Description = "How many pixels should separate the nodes vertically?",
        DefaultValue = "12",
        Order = 2 )]

    [IntegerField(
        "Node Horizontal Spacing",
        Key = AttributeKey.NodeHorizontalSpacing,
        Description = "How many pixels wide should the flow paths be between the nodes?",
        DefaultValue = "200",
        Order = 3 )]

    [IntegerField(
        "Chart Height",
        Key = AttributeKey.ChartHeight,
        Description = "How tall should the chart be (in pixels)?",
        DefaultValue = "900",
        Order = 4 )]

    #endregion Block Attributes

    public class StepFlow : RockObsidianBlockType
    {
        #region Attribute Keys

        private static class AttributeKey
        {
            public const string NodeWidth = "NodeWidth";
            public const string NodeVerticalSpacing = "NodeVerticalSpacing";
            public const string NodeHorizontalSpacing = "NodeHorizontalSpacing";
            public const string ChartHeight = "ChartHeight";
        }

        #endregion Attribute Keys

        #region PageParameterKeys

        private static class PageParameterKey
        {
            public const string StepProgramId = "ProgramId";
        }

        #endregion PageParameterKeys

        public List<ListItemBag> Campuses { get; set; }
        private int currentColorIndex = 0;
        private string[] defaultColors = { "#ea5545", "#f46a9b", "#ef9b20", "#edbf33", "#ede15b", "#bdcf32", "#87bc45", "#27aeef", "#b33dc6" };

        #region Base Overrides

        /// <summary>
        /// Gets the property values that will be sent to the browser and available to the client side code as it initializes.
        /// </summary>
        /// <returns>
        /// A collection of string/object pairs.
        /// </returns>
        public override object GetObsidianBlockInitialization()
        {
            var rockContext = new RockContext();
            var campusClientService = new Rock.ClientService.Core.Campus.CampusClientService( rockContext, RequestContext.CurrentPerson );
            Campuses = campusClientService.GetCampusesAsListItems();

            return new StepFlowInitializationBox
            {
                Campuses = Campuses,
                NodeWidth = GetAttributeValue( AttributeKey.NodeWidth ).AsInteger(),
                NodeVerticalSpacing = GetAttributeValue( AttributeKey.NodeVerticalSpacing ).AsInteger(),
                NodeHorizontalSpacing = GetAttributeValue( AttributeKey.NodeHorizontalSpacing ).AsInteger(),
                ChartHeight = GetAttributeValue( AttributeKey.ChartHeight ).AsInteger()
            };
        }

        #endregion Base Overloads

        #region Block Actions

        /// <summary>
        /// Block action to get the data for the diagram
        /// </summary>
        /// <param name="startDate">Filter dataset to only include steps that took place after this date.</param>
        /// <param name="endDate">Filter dataset to only include steps that took place before this date.</param>
        /// <param name="maxLevels">The maximum number of levels for any one person to complete</param>
        /// <param name="campus">The campus where the steps take place</param>
        /// <returns></returns>
        [BlockAction]
        public BlockActionResult GetData( DateTimeOffset startDate, DateTimeOffset endDate, int maxLevels, Guid campus )
        {
            List<StepTypeCache> stepTypes = StepProgramCache.Get( PageParameter( PageParameterKey.StepProgramId ).AsInteger() ).StepTypes;
            var nodeResults = new List<FlowNodeDiagramNodeBag>();
            int order = 0;

            foreach ( StepTypeCache step in stepTypes )
            {
                nodeResults.Add( new FlowNodeDiagramNodeBag
                {
                    Id = step.Id,
                    Order = ++order,
                    Name = step.Name,
                    Color = step.HighlightColor ?? GetNextDefaultColor()
                } );
            }

            var parameters = GetParameters( maxLevels, startDate, endDate, campus );
            var flowEdgeData = new DbService( new RockContext() ).GetDataTableFromSqlCommand( "spSteps_StepFlow", System.Data.CommandType.StoredProcedure, parameters );
            var flowEdgeResults = new List<FlowNodeDiagramEdgeBag>();

            foreach ( DataRow flowEdgeRow in flowEdgeData.Rows )
            {
                int level = flowEdgeRow["Level"].ToIntSafe();
                int units = flowEdgeRow["StepCount"].ToIntSafe();
                int sourceId = flowEdgeRow["SourceStepTypeId"].ToIntSafe();
                int targetId = flowEdgeRow["TargetStepTypeId"].ToIntSafe();

                var source = stepTypes.Find( stepType => stepType.Id == sourceId );
                var target = stepTypes.Find( stepType => stepType.Id == targetId );

                flowEdgeResults.Add( new FlowNodeDiagramEdgeBag
                {
                    TargetId = targetId,
                    SourceId = sourceId,
                    Level = level,
                    Units = units,
                    Tooltip = level > 1 ? BuildTooltip( source, target, units, flowEdgeRow["AvgNumberOfDaysBetweenSteps"].ToIntSafe() ) : ""
                });
            }

            return ActionOk( new StepFlowGetDataBag
            {
                Edges = flowEdgeResults,
                Nodes = nodeResults
            } );
        }

        #endregion Block Actions

        /// <summary>
        /// Get the parameters dictionary for sending in to the DB query
        /// </summary>
        /// <param name="maxLevels">The maximum number of levels for any one person to complete</param>
        /// <param name="dateRangeStartDate">Filter dataset to only include steps that took place after this date.</param>
        /// <param name="dateRangeEndDate">Filter dataset to only include steps that took place before this date.</param>
        /// <param name="campusGuid">The campus where the steps take place</param>
        /// <returns></returns>
        private Dictionary<string, object> GetParameters( int maxLevels, DateTimeOffset dateRangeStartDate, DateTimeOffset dateRangeEndDate, Guid campusGuid )
        {
            var parameters = new Dictionary<string, object>();

            if ( maxLevels > 0 )
            {
                parameters.Add( "MaxLevels", maxLevels );
            }

            if ( dateRangeStartDate != null )
            {
                parameters.Add( "DateRangeStartDate", dateRangeStartDate.DateTime );
            }

            if ( dateRangeEndDate != null )
            {
                parameters.Add( "DateRangeEndDate", dateRangeEndDate.DateTime );
            }

            if ( campusGuid != null && campusGuid != Guid.Empty )
            {
                parameters.Add( "CampusId", CampusCache.GetId( campusGuid ) );
            }
            else
            {
                parameters.Add( "CampusId", DBNull.Value );
            }

            parameters.Add( "StepProgramId", PageParameter( PageParameterKey.StepProgramId ).AsInteger() );
            parameters.Add( "DataViewId", DBNull.Value );

            return parameters;
        }

        private string GetNextDefaultColor()
        {
            if ( currentColorIndex >= defaultColors.Length )
            {
                currentColorIndex = 0;
            }

            return defaultColors[currentColorIndex++];
        }

        private string BuildTooltip( StepTypeCache source, StepTypeCache target, int units, int? days )
        {
            string dayString = days == null ? "Unknown" : $"{ days }";

            return $"<p><strong>{source.Name} > {target.Name}</strong></p>" +
                $"Steps Taken: {units}<br/>" +
                $"Avg Days Between Steps: {dayString}";
        }
    }
}

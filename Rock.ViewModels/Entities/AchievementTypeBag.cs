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

using System;
using System.Linq;

using Rock.ViewModels.Utility;

namespace Rock.ViewModels.Entities
{
    /// <summary>
    /// AchievementType View Model
    /// </summary>
    public partial class AchievementTypeBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets the Id of the Rock.Model.WorkflowType to be triggered when an achievement is failed (closed and not successful)
        /// </summary>
        public int? AchievementFailureWorkflowTypeId { get; set; }

        /// <summary>
        /// Gets or sets the icon CSS class.
        /// </summary>
        public string AchievementIconCssClass { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Rock.Model.WorkflowType to be triggered when an achievement is started
        /// </summary>
        public int? AchievementStartWorkflowTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Rock.Model.StepStatus of which a Rock.Model.Step will be created when an achievement is completed
        /// </summary>
        public int? AchievementStepStatusId { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Rock.Model.StepType of which a Rock.Model.Step will be created when an achievement is completed
        /// </summary>
        public int? AchievementStepTypeId { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Rock.Model.WorkflowType to be triggered when an achievement is successful
        /// </summary>
        public int? AchievementSuccessWorkflowTypeId { get; set; }

        /// <summary>
        /// Gets or sets the achiever entity type. The achiever is the object that earns the achievement.
        /// The original achiever was a Rock.Model.PersonAlias via Rock.Model.Streak.PersonAliasId.
        /// </summary>
        public int AchieverEntityTypeId { get; set; }

        /// <summary>
        /// Gets or sets whether over achievement is allowed. This cannot be true if Rock.Model.AchievementType.MaxAccomplishmentsAllowed is greater than 1.
        /// </summary>
        /// <value>
        /// The allow over achievement.
        /// </value>
        public bool AllowOverAchievement { get; set; }

        /// <summary>
        /// An alternate image that can be used for custom purposes.
        /// </summary>
        /// <value>
        /// The image binary file identifier.
        /// </value>
        public int? AlternateImageBinaryFileId { get; set; }

        /// <summary>
        /// Gets or sets the lava template used to render a badge.
        /// </summary>
        public string BadgeLavaTemplate { get; set; }

        /// <summary>
        /// Gets or sets the Rock.Model.Category identifier.
        /// </summary>
        /// <value>
        /// The category identifier.
        /// </value>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the configuration from the Rock.Model.AchievementType.ComponentEntityTypeId.
        /// </summary>
        public string ComponentConfigJson { get; set; }

        /// <summary>
        /// Gets or sets the Id of the achievement component Rock.Model.EntityType
        /// </summary>
        public int ComponentEntityTypeId { get; set; }

        /// <summary>
        /// Gets or sets the lava template used to render the status summary of the achievement.
        /// </summary>
        /// <value>
        /// The custom summary lava template.
        /// </value>
        public string CustomSummaryLavaTemplate { get; set; }

        /// <summary>
        /// Gets or sets a description of the achievement type.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the color of the highlight.
        /// </summary>
        /// <value>
        /// The color of the highlight.
        /// </value>
        public string HighlightColor { get; set; }

        /// <summary>
        /// Gets or sets the image binary file identifier. This would be the image
        /// that would be shown in the achievement summary (for example, a trophy).
        /// </summary>
        /// <value>
        /// The image binary file identifier.
        /// </value>
        public int? ImageBinaryFileId { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   true if this instance is active; otherwise, false.
        /// </value>
        public bool IsActive { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is public.
        /// </summary>
        /// <value>
        ///   true if this instance is public; otherwise, false.
        /// </value>
        public bool IsPublic { get; set; }

        /// <summary>
        /// Gets or sets the maximum accomplishments allowed.
        /// </summary>
        /// <value>
        /// The maximum accomplishments allowed.
        /// </value>
        public int? MaxAccomplishmentsAllowed { get; set; }

        /// <summary>
        /// Gets or sets the name of the achievement type. This property is required.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the lava template used to render results.
        /// </summary>
        public string ResultsLavaTemplate { get; set; }

        /// <summary>
        /// Gets or sets the source entity type. The source supplies the data framework from which achievements are computed.
        /// The original achievement sources were Streaks.
        /// </summary>
        public int? SourceEntityTypeId { get; set; }

        /// <summary>
        /// Gets or sets the created date time.
        /// </summary>
        /// <value>
        /// The created date time.
        /// </value>
        public DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the modified date time.
        /// </summary>
        /// <value>
        /// The modified date time.
        /// </value>
        public DateTime? ModifiedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the created by person alias identifier.
        /// </summary>
        /// <value>
        /// The created by person alias identifier.
        /// </value>
        public int? CreatedByPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the modified by person alias identifier.
        /// </summary>
        /// <value>
        /// The modified by person alias identifier.
        /// </value>
        public int? ModifiedByPersonAliasId { get; set; }

    }
}

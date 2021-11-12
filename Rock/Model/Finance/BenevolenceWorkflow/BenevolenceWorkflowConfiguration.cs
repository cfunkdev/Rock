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

using System.Data.Entity.ModelConfiguration;

namespace Rock.Model
{
    /// <summary>
    /// BenevolenceWorkflow Configuration class.
    /// </summary>
    public partial class BenevolenceWorkflowConfiguration : EntityTypeConfiguration<BenevolenceWorkflow>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BenevolenceWorkflowConfiguration" /> class.
        /// </summary>
        public BenevolenceWorkflowConfiguration()
        {
            this.HasRequired( p => p.BenevolenceTypeId ).WithMany( p => p.ConnectionWorkflows ).HasForeignKey( p => p.ConnectionTypeId ).WillCascadeOnDelete( true );
            //this.HasOptional( p => p.ConnectionOpportunity ).WithMany( p => p.ConnectionWorkflows ).HasForeignKey( p => p.ConnectionOpportunityId ).WillCascadeOnDelete( true );
            //this.HasRequired( p => p.WorkflowType ).WithMany().HasForeignKey( p => p.WorkflowTypeId ).WillCascadeOnDelete( true );

        }
    }
}

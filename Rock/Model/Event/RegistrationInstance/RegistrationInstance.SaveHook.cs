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

using Rock.Data;

namespace Rock.Model
{
    public partial class RegistrationInstance
    {
        /// <summary>
        /// SaveHook implementation for RegistrationInstance
        /// </summary>
        /// <seealso cref="Rock.Data.EntitySaveHook{TEntity}" />
        internal class SaveHook : EntitySaveHook<RegistrationInstance>
        {
            /// <summary>
            /// Called before the save operation is executed.
            /// </summary>
            protected override void PreSave()
            {
                if ( State == EntityContextState.Deleted )
                {
                    new RegistrationInstanceService( DbContext as RockContext ).RelatedEntities.DeleteRelatedEntities( Entity );
                }

                base.PreSave();
            }
        }
    }
}

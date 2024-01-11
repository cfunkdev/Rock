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
using Rock.Attribute;

using System.Collections.Generic;

namespace Rock.AdditionalSettings
{
    /// <summary>
    /// Additional settings for the page model.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         <strong>This is an internal API</strong> that supports the Rock
    ///         infrastructure and not subject to the same compatibility standards
    ///         as public APIs. It may be changed or removed without notice in any
    ///         release and should therefore not be directly used in any plug-ins.
    ///     </para>
    /// </remarks>
    [RockInternal( "1.16.2" )]
    public class ContentChannelItemAdditionalSettings
    {
        /// <summary>
        /// Keys to support a categorized structure within the additional settings object.
        /// </summary>
        public class CategoryKey
        {
            /// <summary>
            /// Site-wide additional settings category key.
            /// </summary>
            public const string SiteSettings = nameof( SiteSettings );
        }

        /// <summary>
        /// Site-wide additional settings.
        /// </summary>
        public class SiteSettings
        {
            /// <summary>
            /// Intent defined value identifiers.
            /// </summary>
            public List<int> ContentChannelItemIntentValueIds { get; set; }
        }
    }
}

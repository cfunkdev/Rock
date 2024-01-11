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

namespace Rock.Web.Cache
{
    /// <summary>
    /// Represents a cache that supports reading categorized, additional settings.
    /// </summary>
    public interface IReadAdditionalSettings
    {
        /// <summary>
        /// Gets the additional settings JSON string.
        /// <para>
        /// DO NOT read from this property directly. Instead, use the <see cref="IReadAdditionalSettings"/>
        /// extension methods to ensure data is properly deserialized from this property.
        /// </para>
        /// </summary>
        /// <value>
        /// The additional settings JSON string.
        /// </value>
        /// <remarks>
        ///     <para>
        ///         <strong>This is an internal API</strong> that supports the Rock
        ///         infrastructure and not subject to the same compatibility standards
        ///         as public APIs. It may be changed or removed without notice in any
        ///         release and should therefore not be directly used in any plug-ins.
        ///     </para>
        /// </remarks>
        [RockInternal( "1.16.2" )]
        string AdditionalSettingsJson { get; }
    }
}

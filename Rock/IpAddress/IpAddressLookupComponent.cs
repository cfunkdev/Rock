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
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using Rock.Attribute;
using Rock.Extension;

namespace Rock.IpAddress
{
    /// <summary>
    /// Internal IP Address Lookup Component
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         <strong>This is an internal API</strong> that supports the Rock
    ///         infrastructure and not subject to the same compatibility standards
    ///         as public APIs. It may be changed or removed without notice in any
    ///         release and should therefore not be directly used in any plug-ins.
    ///     </para>
    /// </remarks>
    [RockInternal]
    public abstract class IpAddressLookupComponent : Component
    {
        /// <summary>
        /// Gets all the IP Address result
        /// </summary>
        public virtual LookupResult Lookup( List<string> ipAddresses, out string resultMsg )
        {
            throw new NotImplementedException();
        }

    }

    #region Nested Classes

    /// <summary>
    /// The Lookup result
    /// </summary>
    public class LookupResult
    {
        /// <summary>
        /// Gets or sets the success count.
        /// </summary>
        public int SuccessCount { get; set; }

        /// <summary>
        /// Gets or sets the failed count.
        /// </summary>
        public int FailedCount { get; set; }
    }

    #endregion
}
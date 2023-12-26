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
using System.Collections.Generic;
using System.Linq;

using Rock.ViewModels.Utility;

namespace Rock.Field.Types
{
    /// <summary>
    /// General purpose picker field type that allows one or more enum values to
    /// be picked by the person.
    /// </summary>
    /// <typeparam name="TEnum">The type of the enum to be represented.</typeparam>
    public abstract class UniversalEnumPickerFieldType<TEnum> : UniversalItemPickerFieldType
        where TEnum : Enum
    {
        /// <inheritdoc/>
        protected override List<ListItemBag> GetItemBags( IEnumerable<string> values, Dictionary<string, string> privateConfigurationValues )
        {
            return GetListItems( privateConfigurationValues )
                .Where( bag => values.Contains( bag.Value ) )
                .ToList();
        }

        /// <inheritdoc/>
        protected override List<ListItemBag> GetListItems( Dictionary<string, string> privateConfigurationValues )
        {
            return Enum.GetValues( typeof( TEnum ) )
                .Cast<TEnum>()
                .Select( value => new ListItemBag
                {
                    Value = value.ConvertToInt().ToString(),
                    Text = value.GetDescription() ?? value.ToString().SplitCase()
                } )
                .ToList();
        }
    }

    [Rock.SystemGuid.FieldTypeGuid( "6d27b1eb-8e04-429f-bd47-5a513ff93d28" )]
    public class DanielEnumFieldType : UniversalEnumPickerFieldType<Rock.Model.KioskType>
    {
    }
}

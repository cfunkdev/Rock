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
using System.Web.UI;
using System.Web.UI.WebControls;

using Rock.Attribute;
using Rock.Reporting;
using Rock.ViewModels.Utility;
using Rock.Web.UI.Controls;

namespace Rock.Field.Types
{
    /// <summary>
    /// General purpose picker field type that allows one or more items to
    /// be picked by the person in a tree list.
    /// </summary>
    [RockPlatformSupport( Utility.RockPlatform.WebForms, Utility.RockPlatform.Obsidian )]
    [UniversalFieldTypeGuid( "c7485f3f-0c10-4db6-9574-c10b195617e4" )]
    public abstract class UniversalTreeItemPickerFieldType : UniversalItemFieldType
    {
        /// <inheritdoc/>
        public sealed override bool HasFilterControl()
        {
            return true;
        }

        /// <inheritdoc/>
        public sealed override Dictionary<string, string> GetPublicConfigurationValues( Dictionary<string, string> privateConfigurationValues, ConfigurationValueUsage usage, string value )
        {
            if ( usage == ConfigurationValueUsage.View )
            {
                return new Dictionary<string, string>();
            }
            else if ( usage == ConfigurationValueUsage.Edit )
            {
                return new Dictionary<string, string>
                {
                    ["iconCssClass"] = GetItemIconCssClass( privateConfigurationValues ),
                    ["isMultiple"] = IsMultipleSelection.ToString(),
                    ["rootRestUrl"] = GetRootRestUrl( privateConfigurationValues )
                };
            }

            return base.GetPublicConfigurationValues( privateConfigurationValues, usage, value );
        }

        #region Protected Methods

        /// <summary>
        /// Gets the URL to use when retrieving the root items of the tree view.
        /// This will also be used to expand child items if the parent item does
        /// not specify its own URL.
        /// </summary>
        /// <param name="privateConfigurationValues">The private (database) configuration values.</param>
        /// <returns>A string that represents the URL.</returns>
        protected abstract string GetRootRestUrl( Dictionary<string, string> privateConfigurationValues );

        /// <summary>
        /// Gets the CSS icon class to use on the picker when it is clsoed.
        /// </summary>
        /// <param name="privateConfigurationValues">The private (database) configuration values.</param>
        /// <returns>A string that represents the icon class.</returns>
        protected abstract string GetItemIconCssClass( Dictionary<string, string> privateConfigurationValues );

        #endregion

#if WEBFORMS

        #region WebForms - Edit Controls

        /// <inheritdoc/>
        public sealed override void SetEditValue( Control control, Dictionary<string, ConfigurationValue> configurationValues, string value )
        {
            if ( control is UniversalItemTreePicker picker )
            {
                var privateConfigurationValues = configurationValues.ToDictionary( v => v.Key, v => v.Value.Value );
                var values = GetItemBags( GetValueAsList( value ), privateConfigurationValues ) ?? new List<ListItemBag>();

                picker.ItemIds = values.Select( v => v.Value );
                picker.ItemNames = values.Select( v => v.Text );
            }
        }

        /// <inheritdoc/>
        public sealed override string GetEditValue( Control control, Dictionary<string, ConfigurationValue> configurationValues )
        {
            if ( control is UniversalItemTreePicker picker )
            {
                return picker.ItemIds.Where( id => id != "0" ).JoinStrings( "," );
            }

            return string.Empty;
        }

        /// <inheritdoc/>
        public sealed override Control EditControl( Dictionary<string, ConfigurationValue> configurationValues, string id )
        {
            var privateConfigurationValues = configurationValues.ToDictionary( k => k.Key, v => v.Value.Value );

            var picker = new UniversalItemTreePicker
            {
                ID = id,
                IconCssClass = GetItemIconCssClass( privateConfigurationValues ),
                AllowMultiSelect = IsMultipleSelection
            };

            picker.SetItemRestUrl( GetRootRestUrl( privateConfigurationValues ) );

            return picker;
        }

        #endregion

        #region WebForms - Filter Controls

        /// <inheritdoc/>
        public sealed override Control FilterValueControl( Dictionary<string, ConfigurationValue> configurationValues, string id, bool required, FilterMode filterMode )
        {
            id = $"{id ?? string.Empty}_ctlCompareValue";

            var control = ( UniversalItemTreePicker ) EditControl( configurationValues, $"{id ?? string.Empty}_ctlCompareValue" );

            control.AddCssClass( "js-filter-control" );

            // Invert multiple selection on the filter control. We don't
            // allow a many-to-many style filtering.
            control.AllowMultiSelect = !IsMultipleSelection;

            return control;
        }

        /// <inheritdoc/>
        public sealed override string GetFilterValueValue( Control control, Dictionary<string, ConfigurationValue> configurationValues )
        {
            return GetEditValue( control, configurationValues );
        }

        /// <inheritdoc/>
        public sealed override void SetFilterValueValue( Control control, Dictionary<string, ConfigurationValue> configurationValues, string value )
        {
            SetEditValue( control, configurationValues, value );
        }

        /// <inheritdoc/>
        public sealed override string FormatFilterValueValue( Dictionary<string, ConfigurationValue> configurationValues, string value )
        {
            var privateConfigurationValues = configurationValues.ToDictionary( v => v.Key, v => v.Value.Value );
            var textValues = GetItemBags( GetValueAsList( value ), privateConfigurationValues )
                ?.Select( b => b.Text )
                .ToList()
                ?? new List<string>();

            return AddQuotes( textValues.AsDelimited( "' OR '" ) );
        }

        #endregion

#endif
    }

    [Rock.SystemGuid.FieldTypeGuid( "8ba19292-e46a-445a-9b54-9a547b9d9521" )]
    [FieldTypeUsage( FieldTypeUsage.Advanced )]
    public class DanielTreeTestFieldType : UniversalTreeItemPickerFieldType
    {
        /// <inheritdoc/>
        protected override string GetRootRestUrl( Dictionary<string, string> privateConfigurationValues )
        {
            return "/api/v2/Controls/TestItems";
        }

        /// <inheritdoc/>
        protected override string GetItemIconCssClass( Dictionary<string, string> privateConfigurationValues )
        {
            return "fa fa-user";
        }

        /// <inheritdoc/>
        protected override List<ListItemBag> GetItemBags( IEnumerable<string> privateValues, Dictionary<string, string> privateConfigurationValues )
        {
            return privateValues.AsGuidList()
                .Select( guid => Rock.Web.Cache.CategoryCache.Get( guid ) )
                .Where( c => c != null )
                .ToListItemBagList();
        }
    }
}

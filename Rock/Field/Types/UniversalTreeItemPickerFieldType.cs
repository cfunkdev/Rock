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
    [ClientFieldTypeGuid( "c7485f3f-0c10-4db6-9574-c10b195617e4" )]
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
                };
            }

            return base.GetPublicConfigurationValues( privateConfigurationValues, usage, value );
        }

        #region Protected Methods

        protected abstract List<ListItemBag> GetValueItems( IEnumerable<string> privateValues, Dictionary<string, string> privateConfiguratinValues );

        #endregion

#if WEBFORMS

        #region WebForms - Edit Controls

        /// <inheritdoc/>
        public sealed override void SetEditValue( Control control, Dictionary<string, ConfigurationValue> configurationValues, string value )
        {
            if ( control is UniversalItemTreePicker picker )
            {
                var values = GetValueItems( value.Split( ',' ), configurationValues.ToDictionary( item => item.Key, item => item.Value.Value ) );
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

            return new UniversalItemTreePicker
            {
                ID = id,
                IconCssClass = "fa fa-user",
                UseCategorySelection = true,
                // ItemRestUrl = ""
            };
        }

        #endregion

        #region WebForms - Filter Controls

        /// <inheritdoc/>
        public sealed override Control FilterValueControl( Dictionary<string, ConfigurationValue> configurationValues, string id, bool required, FilterMode filterMode )
        {
            var privateConfigurationValues = configurationValues.ToDictionary( k => k.Key, v => v.Value.Value );
            id = $"{id ?? string.Empty}_ctlCompareValue";

            var control = new UniversalItemTreePicker
            {
                ID = id,
                IconCssClass = "fa fa-user",
                UseCategorySelection = true,
            };

            control.AddCssClass( "js-filter-control" );

            return control;
        }

        /// <inheritdoc/>
        public sealed override string GetFilterValueValue( Control control, Dictionary<string, ConfigurationValue> configurationValues )
        {
            if ( control is UniversalItemTreePicker picker )
            {
                return picker.ItemIds.Where( id => id != "0" ).JoinStrings( "," );
            }

            return string.Empty;
        }

        /// <inheritdoc/>
        public sealed override void SetFilterValueValue( Control control, Dictionary<string, ConfigurationValue> configurationValues, string value )
        {
            if ( control is UniversalItemTreePicker picker )
            {
                var values = GetValueItems( value.Split( ',' ), configurationValues.ToDictionary( item => item.Key, item => item.Value.Value ) );
                picker.ItemIds = values.Select( v => v.Value );
                picker.ItemNames = values.Select( v => v.Text );
            }
        }

        /// <inheritdoc/>
        public sealed override string FormatFilterValueValue( Dictionary<string, ConfigurationValue> configurationValues, string value )
        {
            // TODO
            var textValues = new List<string>();

            return AddQuotes( textValues.ToList().AsDelimited( "' OR '" ) );
        }

        #endregion

#endif
    }

    [Rock.SystemGuid.FieldTypeGuid( "8ba19292-e46a-445a-9b54-9a547b9d9521" )]
    public class DanielTreeTestFieldType : UniversalTreeItemPickerFieldType
    {
        protected override List<ListItemBag> GetValueItems( IEnumerable<string> privateValues, Dictionary<string, string> privateConfiguratinValues )
        {
            return privateValues.AsGuidList()
                .Select( guid => Rock.Web.Cache.CategoryCache.Get( guid ) )
                .Where( c => c != null )
                .ToListItemBagList();
        }

        public override string GetItemTextValue( string privateValue, Dictionary<string, string> privateConfigurationValues )
        {
            return "";
        }
    }
}

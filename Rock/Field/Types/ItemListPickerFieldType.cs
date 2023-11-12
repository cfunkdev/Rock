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
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI;
using System.Web.UI.WebControls;

using Rock.Attribute;
using Rock.Data;
using Rock.Reporting;
using Rock.ViewModels.Utility;
using Rock.Web.Cache;
using Rock.Web.UI.Controls;

namespace Rock.Field.Types
{
    /// <summary>
    /// Base logic provider for field types that have shared UI comonents
    /// on the client to handle working with the field values.
    /// </summary>
    public abstract class PublicFieldType : FieldType
    {
        #region Properties

        /// <inheritdoc/>
        public sealed override string AttributeValueFieldName => base.AttributeValueFieldName;

        /// <inheritdoc/>
        public sealed override Type AttributeValueFieldType => base.AttributeValueFieldType;

        /// <inheritdoc/>
        public sealed override Model.ComparisonType FilterComparisonType
        {
            get => SelectionMode == ValuePickerSelectionMode.Multiple
                ? ComparisonHelper.ContainsFilterComparisonTypes
                : ComparisonHelper.BinaryFilterComparisonTypes;
        }

        /// <inheritdoc/>
        public sealed override bool HasDefaultControl => true;

        /// <summary>
        /// The selection mode of this field type. Field types configured for
        /// multiple selection will be stored as a comma seperated list of values.
        /// </summary>
        protected virtual ValuePickerSelectionMode SelectionMode => ValuePickerSelectionMode.Single;

        #endregion

        #region Protected Methods

        /// <summary>
        /// Gets the configuration keys that should trigger and automatic updates
        /// of the configuartion options and the default value control.
        /// </summary>
        /// <returns>A list of key names.</returns>
        protected virtual List<string> GetAutoUpdatingConfigurationKeys()
        {
            return new List<string>();
        }

        /// <summary>
        /// Gets the value as a list of string values. If the field type is
        /// configured for single selection then this returns an array of
        /// either 0 or 1 items. If the field type is configured for multiple
        /// selection then this will return an array that contains all the
        /// selected values.
        /// </summary>
        /// <param name="privateValue">The private value stored in the database.</param>
        /// <returns>A list of strings that represent the individual values.</returns>
        protected List<string> GetValueAsList( string privateValue )
        {
            return privateValue.Split( new[] { ',' }, StringSplitOptions.RemoveEmptyEntries ).ToList();
        }

        #endregion

        #region General Sealed Methods

        /// <inheritdoc/>
        public sealed override List<string> ConfigurationKeys()
        {
            return GetConfigurationAttributes().Select( a => a.Key ).ToList();
        }

        /// <inheritdoc/>
        public sealed override ConstantExpression AttributeConstantExpression( string value )
        {
            return base.AttributeConstantExpression( value );
        }

        /// <inheritdoc/>
        public sealed override object ConvertValueToPropertyType( string value, Type propertyType, bool isNullableType )
        {
            return base.ConvertValueToPropertyType( value, propertyType, isNullableType );
        }

        /// <inheritdoc/>
        public sealed override string GetCopyValue( string originalValue, RockContext rockContext )
        {
            return base.GetCopyValue( originalValue, rockContext );
        }

        /// <inheritdoc/>
        public sealed override Expression AttributeFilterExpression( Dictionary<string, ConfigurationValue> configurationValues, List<string> filterValues, ParameterExpression parameterExpression )
        {
            if ( SelectionMode == ValuePickerSelectionMode.Single && filterValues.Count == 1 )
            {
                var selectedValues = GetValueAsList( filterValues[0] );
                var propertyExpression = Expression.Property( parameterExpression, "Value" );

                if ( selectedValues.Count == 0 )
                {
                    // No Value specified, so return NoAttributeFilterExpression ( which means don't filter )
                    return new NoAttributeFilterExpression();
                }
                else if ( selectedValues.Count == 1 )
                {
                    // only one value, so do an Equal instead of Contains which might compile a little bit faster
                    return ComparisonHelper.ComparisonExpression( Rock.Model.ComparisonType.EqualTo, propertyExpression, AttributeConstantExpression( selectedValues[0] ) );
                }
                else
                {
                    ConstantExpression constantExpression = Expression.Constant( selectedValues, typeof( List<string> ) );
                    return Expression.Call( constantExpression, typeof( List<string> ).GetMethod( "Contains", new Type[] { typeof( string ) } ), propertyExpression );
                }
            }

            return base.AttributeFilterExpression( configurationValues, filterValues, parameterExpression );
        }

        /// <inheritdoc/>
        public sealed override string FormatFilterValues( Dictionary<string, ConfigurationValue> configurationValues, List<string> filterValues )
        {
            return base.FormatFilterValues( configurationValues, filterValues );
        }

        /// <inheritdoc/>
        public override string GetEqualToCompareValue()
        {
            if ( SelectionMode == ValuePickerSelectionMode.Single )
            {
                return null;
            }

            return base.GetEqualToCompareValue();
        }

        /// <inheritdoc/>
        public sealed override string GetFilterFormatScript( Dictionary<string, ConfigurationValue> configurationValues, string title )
        {
            return base.GetFilterFormatScript( configurationValues, title );
        }

        /// <inheritdoc/>
        public sealed override string GetPrivateFilterValue( ComparisonValue publicValue, Dictionary<string, string> privateConfigurationValues )
        {
            return base.GetPrivateFilterValue( publicValue, privateConfigurationValues );
        }

        public sealed override string GetPublicEditValue( string privateValue, Dictionary<string, string> privateConfigurationValues )
        {
            return base.GetPublicEditValue( privateValue, privateConfigurationValues );
        }

        /// <inheritdoc/>
        public sealed override ComparisonValue GetPublicFilterValue( string privateValue, Dictionary<string, string> privateConfigurationValues )
        {
            return base.GetPublicFilterValue( privateValue, privateConfigurationValues );
        }

        /// <inheritdoc/>
        public sealed override bool IsComparedToValue( List<string> filterValues, string value )
        {
            return base.IsComparedToValue( filterValues, value );
        }

        /// <inheritdoc/>
        public sealed override bool IsEqualToValue( List<string> filterValues, string value )
        {
            return base.IsEqualToValue( filterValues, value );
        }

        #endregion

        #region Custom Configuration Value Methods

        /// <inheritdoc/>
        public sealed override string GetPersistedValuePlaceholder( Dictionary<string, string> privateConfigurationValues )
        {
            return base.GetPersistedValuePlaceholder( privateConfigurationValues );
        }

        public sealed override string GetPrivateEditValue( string publicValue, Dictionary<string, string> privateConfigurationValues )
        {
            return base.GetPrivateEditValue( publicValue, privateConfigurationValues );
        }

        public sealed override string GetPublicValue( string privateValue, Dictionary<string, string> privateConfigurationValues )
        {
            return base.GetPublicValue( privateValue, privateConfigurationValues );
        }

        /// <inheritdoc/>
        public sealed override bool IsSensitive()
        {
            return false;
        }

        /// <inheritdoc/>
        public sealed override bool IsValid( string value, bool required, out string message )
        {
            return base.IsValid( value, required, out message );
        }

        /// <inheritdoc/>
        public sealed override object ValueAsFieldType( string value, Dictionary<string, ConfigurationValue> configurationValues )
        {
            return value;
        }

        /// <inheritdoc/>
        public sealed override Expression PropertyFilterExpression( Dictionary<string, ConfigurationValue> configurationValues, List<string> filterValues, Expression parameterExpression, string propertyName, Type propertyType )
        {
            return base.PropertyFilterExpression( configurationValues, filterValues, parameterExpression, propertyName, propertyType );
        }

        #endregion

        #region Private Methods

        private List<FieldAttribute> GetConfigurationAttributes()
        {
            return GetType()
                .GetCustomAttributes( true )
                .Where( a => typeof( FieldAttribute ).IsAssignableFrom( a.GetType() ) )
                .Cast<FieldAttribute>()
                .OrderBy( a => a.Order )
                .ToList();
        }

        #endregion

        #region Configuration Methods

        public sealed override Dictionary<string, string> GetPrivateConfigurationValues( Dictionary<string, string> publicConfigurationValues )
        {
            return base.GetPrivateConfigurationValues( publicConfigurationValues );
        }

        public sealed override Dictionary<string, string> GetPublicConfigurationValues( Dictionary<string, string> privateConfigurationValues, ConfigurationValueUsage usage, string value )
        {
            return base.GetPublicConfigurationValues( privateConfigurationValues, usage, value );
        }

        public sealed override Dictionary<string, string> GetPublicEditConfigurationProperties( Dictionary<string, string> privateConfigurationValues )
        {
            return base.GetPublicEditConfigurationProperties( privateConfigurationValues );
        }

        #endregion

#if WEBFORMS

        #region WebForms - General Sealed

        /// <inheritdoc/>
        public sealed override bool HasChangeHandler( Control editControl )
        {
            return base.HasChangeHandler( editControl );
        }

        /// <inheritdoc/>
        public sealed override void AddChangeHandler( Control editControl, Action action )
        {
            base.AddChangeHandler( editControl, action );
        }

        /// <inheritdoc/>
        public sealed override IQueryable<T> ApplyAttributeQueryFilter<T>( IQueryable<T> qry, Control filterControl, AttributeCache attribute, IService serviceInstance, FilterMode filterMode )
        {
            return base.ApplyAttributeQueryFilter( qry, filterControl, attribute, serviceInstance, filterMode );
        }

        /// <inheritdoc/>
        public sealed override HorizontalAlign AlignValue => base.AlignValue;

        #endregion

        #region WebForms - Configuration Controls

        /// <inheritdoc/>
        public sealed override List<Control> ConfigurationControls()
        {
            var controls = new List<Control>();
            var fieldTypeAttributes = GetConfigurationAttributes();
            var autoUpdateKeys = GetAutoUpdatingConfigurationKeys();

            for ( int i = 0; i < fieldTypeAttributes.Count; i++ )
            {
                var fieldTypeAttribute = fieldTypeAttributes[i];
                var field = Helper.InstantiateFieldType( fieldTypeAttribute.FieldTypeAssembly, fieldTypeAttribute.FieldTypeClass );

                if ( field != null )
                {
                    var control = field.EditControl( fieldTypeAttribute.FieldConfigurationValues, $"cfg_{i}" );

                    if ( control is IRockControl rockControl )
                    {
                        rockControl.Required = fieldTypeAttribute.IsRequired;
                        rockControl.Label = fieldTypeAttribute.Name;
                        rockControl.Help = fieldTypeAttribute.Description;
                    }

                    if ( autoUpdateKeys?.Contains( fieldTypeAttribute.Key ) == true )
                    {
                        AddChangeHandler( control, () => OnQualifierUpdated( control, new EventArgs() ) );
                    }

                    controls.Add( control );
                }
                else
                {
                    controls.Add( new Literal { ID = $"cfg_{i}" } );
                }
            }

            return controls;
        }

        /// <inheritdoc/>
        public sealed override Dictionary<string, ConfigurationValue> ConfigurationValues( List<Control> controls )
        {
            var configurationValues = new Dictionary<string, ConfigurationValue>();
            var fieldTypeAttributes = GetConfigurationAttributes();

            for ( int i = 0; i < fieldTypeAttributes.Count; i++ )
            {
                var fieldTypeAttribute = fieldTypeAttributes[i];
                var field = Helper.InstantiateFieldType( fieldTypeAttribute.FieldTypeAssembly, fieldTypeAttribute.FieldTypeClass );

                if ( field != null && controls.Count > i )
                {
                    var value = field.GetEditValue( controls[i], fieldTypeAttribute.FieldConfigurationValues );
                    configurationValues.AddOrIgnore( fieldTypeAttribute.Key, new ConfigurationValue( value ) );
                }
            }

            return configurationValues;
        }

        /// <inheritdoc/>
        public sealed override void SetConfigurationValues( List<Control> controls, Dictionary<string, ConfigurationValue> configurationValues )
        {
            var fieldTypeAttributes = GetConfigurationAttributes();

            for ( int i = 0; i < fieldTypeAttributes.Count; i++ )
            {
                var fieldTypeAttribute = fieldTypeAttributes[i];
                var field = Helper.InstantiateFieldType( fieldTypeAttribute.FieldTypeAssembly, fieldTypeAttribute.FieldTypeClass );

                if ( field != null && controls.Count > i )
                {
                    var value = configurationValues.ContainsKey( fieldTypeAttribute.Key )
                        ? configurationValues[fieldTypeAttribute.Key].Value
                        : null;

                    field.SetEditValue( controls[i], fieldTypeAttribute.FieldConfigurationValues, value );
                }
            }
        }

        #endregion

        #region WebForms - Formatting Controls

        /// <inheritdoc/>
        public sealed override object SortValue( Control parentControl, string value, Dictionary<string, ConfigurationValue> configurationValues )
        {
            return value;
        }

        /// <inheritdoc/>
        public sealed override object ValueAsFieldType( Control parentControl, string value, Dictionary<string, ConfigurationValue> configurationValues )
        {
            return value;
        }

        /// <inheritdoc/>
        public sealed override string FormatValue( Control parentControl, int? entityTypeId, int? entityId, string value, Dictionary<string, ConfigurationValue> configurationValues, bool condensed )
        {
            return condensed
                ? GetCondensedTextValue( value, configurationValues.ToDictionary( k => k.Key, v => v.Value.Value ) )
                : GetTextValue( value, configurationValues.ToDictionary( k => k.Key, v => v.Value.Value ) );
        }

        /// <inheritdoc/>
        public sealed override string FormatValue( Control parentControl, string value, Dictionary<string, ConfigurationValue> configurationValues, bool condensed )
        {
            return condensed
                ? GetCondensedTextValue( value, configurationValues.ToDictionary( k => k.Key, v => v.Value.Value ) )
                : GetTextValue( value, configurationValues.ToDictionary( k => k.Key, v => v.Value.Value ) );
        }

        /// <inheritdoc/>
        public sealed override string FormatValueAsHtml( Control parentControl, int? entityTypeId, int? entityId, string value, Dictionary<string, ConfigurationValue> configurationValues, bool condensed = false )
        {
            return condensed
                ? GetCondensedHtmlValue( value, configurationValues.ToDictionary( k => k.Key, v => v.Value.Value ) )
                : GetHtmlValue( value, configurationValues.ToDictionary( k => k.Key, v => v.Value.Value ) );
        }

        /// <inheritdoc/>
        public sealed override string FormatValueAsHtml( Control parentControl, string value, Dictionary<string, ConfigurationValue> configurationValues, bool condensed = false )
        {
            return condensed
                ? GetCondensedHtmlValue( value, configurationValues.ToDictionary( k => k.Key, v => v.Value.Value ) )
                : GetHtmlValue( value, configurationValues.ToDictionary( k => k.Key, v => v.Value.Value ) );
        }

        #endregion

        #region WebForms - Filter Controls

        /// <inheritdoc/>
        public sealed override void SetFilterValues( Control filterControl, Dictionary<string, ConfigurationValue> configurationValues, List<string> filterValues )
        {
            base.SetFilterValues( filterControl, configurationValues, filterValues );
        }

        /// <inheritdoc/>
        public sealed override void SetFilterCompareValue( Control control, string value )
        {
            if ( SelectionMode == ValuePickerSelectionMode.Multiple )
            {
                base.SetFilterCompareValue( control, value );
            }
        }

        /// <inheritdoc/>
        public override string GetFilterCompareValue( Control control, FilterMode filterMode )
        {
            if ( control is Label )
            {
                return null;
            }

            return base.GetFilterCompareValue( control, filterMode );
        }

        /// <inheritdoc/>
        public sealed override List<string> GetFilterValues( Control filterControl, Dictionary<string, ConfigurationValue> configurationValues, FilterMode filterMode )
        {
            return base.GetFilterValues( filterControl, configurationValues, filterMode );
        }

        /// <inheritdoc/>
        public sealed override Control FilterControl( Dictionary<string, ConfigurationValue> configurationValues, string id, bool required )
        {
            return base.FilterControl( configurationValues, id, required );
        }

        /// <inheritdoc/>
        public sealed override Control FilterControl( Dictionary<string, ConfigurationValue> configurationValues, string id, bool required, FilterMode filterMode )
        {
            return base.FilterControl( configurationValues, id, required, filterMode );
        }

        /// <inheritdoc/>
        public override Control FilterCompareControl( Dictionary<string, ConfigurationValue> configurationValues, string id, bool required, FilterMode filterMode )
        {
            if ( SelectionMode == ValuePickerSelectionMode.Single )
            {
                var lbl = new Label
                {
                    ID = string.Format( "{0}_lIs", id ),
                    Text = "Is",
                    Visible = filterMode != FilterMode.SimpleFilter
                };

                lbl.AddCssClass( "data-view-filter-label" );

                return lbl;
            }

            return base.FilterCompareControl( configurationValues, id, required, filterMode );
        }

        #endregion

#endif
    }

    /// <summary>
    /// General purpose picker field type that allows one or more items to
    /// be picked by the person.
    /// </summary>
    [ClientFieldTypeGuid( "b69b5a61-6fcd-4e3b-bb45-5f6802514953" )]
    public abstract class ItemListPickerFieldType : PublicFieldType
    {
        /// <inheritdoc/>
        public sealed override bool HasFilterControl()
        {
            return true;
        }

        #region Protected Methods

        /// <summary>
        /// Gets the number of columns to use when displaying the values in list
        /// display mode.
        /// </summary>
        /// <param name="privateConfigurationValues">The configuration values that describe the field type.</param>
        /// <returns>An integer that contains the number of columns to use or <c>null</c> to use the default.</returns>
        protected virtual int? GetColumnCount( Dictionary<string, string> privateConfigurationValues )
        {
            return null;
        }

        /// <summary>
        /// Gets the display mode to use when rendering the edit control.
        /// </summary>
        /// <param name="privateConfigurationValues">The configuration values that describe the field type.</param>
        /// <returns>The mode to display the edit control in.</returns>
        protected virtual ItemValuePickerDisplayMode GetDisplayMode( Dictionary<string, string> privateConfigurationValues )
        {
            return ItemValuePickerDisplayMode.Auto;
        }

        /// <summary>
        /// Gets a value that indicates if the edit control should be rendered
        /// with enhanced selection mode. This provides search capabilities to
        /// the list of items in condensed display mode.
        /// </summary>
        /// <param name="privateConfigurationValues">The configuration values that describe the field type.</param>
        /// <returns><c>true</c> if the list of items should provide search capabilities; otherwise <c>false</c>.</returns>
        protected virtual bool GetEnhanceForLongLists( Dictionary<string, string> privateConfigurationValues )
        {
            return false;
        }

        /// <summary>
        /// Gets the list of items to be displayed in the picker.
        /// </summary>
        /// <param name="privateConfigurationValues">The configuration values that describe the field type.</param>
        /// <returns>A list of item bags that will be rendered in the picker.</returns>
        protected virtual List<ListItemBag> GetListItems( Dictionary<string, string> privateConfigurationValues )
        {
            return new List<ListItemBag>();
        }

        #endregion

        /// <inheritdoc/>
        public abstract override string GetTextValue( string privateValue, Dictionary<string, string> privateConfigurationValues );

#if WEBFORMS

        #region WebForms - Edit Controls

        /// <inheritdoc/>
        public sealed override void SetEditValue( Control control, Dictionary<string, ConfigurationValue> configurationValues, string value )
        {
            if ( control is RockDropDownList ddl )
            {
                ddl.SetValue( value );
            }
            else if ( control is RockListBox rlb )
            {
                rlb.SetValues( GetValueAsList( value ) );
            }
            else if ( control is RockCheckBoxList cbl )
            {
                cbl.SetValues( GetValueAsList( value ) );
            }
            else if ( control is RockRadioButtonList rbl )
            {
                rbl.SetValue( value );
            }
        }

        /// <inheritdoc/>
        public sealed override string GetEditValue( Control control, Dictionary<string, ConfigurationValue> configurationValues )
        {
            if ( control is RockDropDownList ddl )
            {
                return ddl.SelectedValue;
            }
            else if ( control is RockListBox rlb )
            {
                return rlb.SelectedValues.JoinStrings( "," );
            }
            else if ( control is RockCheckBoxList cbl )
            {
                return cbl.SelectedValues.JoinStrings( "," );
            }
            else if ( control is RockRadioButtonList rbl )
            {
                return rbl.SelectedValue;
            }

            return string.Empty;
        }

        /// <inheritdoc/>
        public sealed override Control EditControl( Dictionary<string, ConfigurationValue> configurationValues, string id )
        {
            var privateConfigurationValues = configurationValues.ToDictionary( k => k.Key, v => v.Value.Value );
            var displayMode = GetDisplayMode( privateConfigurationValues );

            if ( displayMode == ItemValuePickerDisplayMode.List )
            {
                return SelectionMode == ValuePickerSelectionMode.Single
                    ? GetSingleSelectionListEditControl( privateConfigurationValues, id )
                    : GetMultipleSelectionListEditControl( privateConfigurationValues, id );
            }
            else
            {
                return SelectionMode == ValuePickerSelectionMode.Single
                    ? GetSingleSelectionCondensedEditControl( privateConfigurationValues, id )
                    : GetMultipleSelectionCondensedEditControl( privateConfigurationValues, id );
            }
        }

        private Control GetMultipleSelectionListEditControl( Dictionary<string, string> privateConfigurationValues, string id )
        {
            var columnCount = GetColumnCount( privateConfigurationValues ) ?? 4;

            var cbl = new RockCheckBoxList
            {
                ID = id,
                RepeatDirection = RepeatDirection.Horizontal,
                RepeatColumns = columnCount
            };

            foreach ( var item in GetListItems( privateConfigurationValues ) )
            {
                cbl.Items.Add( new ListItem( item.Text, item.Value ) );
            }

            return cbl;
        }

        private Control GetSingleSelectionListEditControl( Dictionary<string, string> privateConfigurationValues, string id )
        {
            var columnCount = GetColumnCount( privateConfigurationValues ) ?? 4;

            var rbl = new RockRadioButtonList
            {
                ID = id,
                RepeatDirection = RepeatDirection.Horizontal,
                RepeatColumns = columnCount
            };

            foreach ( var item in GetListItems( privateConfigurationValues ) )
            {
                rbl.Items.Add( new ListItem( item.Text, item.Value ) );
            }

            return rbl;
        }

        private Control GetMultipleSelectionCondensedEditControl( Dictionary<string, string> privateConfigurationValues, string id )
        {
            var rlb = new RockListBox
            {
                ID = id,
                DisplayDropAsAbsolute = true
            };

            foreach ( var item in GetListItems( privateConfigurationValues ) )
            {
                rlb.Items.Add( new ListItem( item.Text, item.Value ) );
            }

            return rlb;
        }

        private Control GetSingleSelectionCondensedEditControl( Dictionary<string, string> privateConfigurationValues, string id )
        {
            var ddl = new RockDropDownList
            {
                ID = id,
                DisplayEnhancedAsAbsolute = true,
                EnhanceForLongLists = GetEnhanceForLongLists( privateConfigurationValues )
            };

            ddl.Items.Add( new ListItem() );
            foreach ( var item in GetListItems( privateConfigurationValues ) )
            {
                ddl.Items.Add( new ListItem( item.Text, item.Value ) );
            }

            return ddl;
        }

        #endregion

        #region WebForms - Filter Controls

        /// <inheritdoc/>
        public sealed override Control FilterValueControl( Dictionary<string, ConfigurationValue> configurationValues, string id, bool required, FilterMode filterMode )
        {
            var privateConfigurationValues = configurationValues.ToDictionary( k => k.Key, v => v.Value.Value );
            id = $"{id ?? string.Empty}_ctlCompareValue";

            var control = SelectionMode == ValuePickerSelectionMode.Single
                ? GetMultipleSelectionListEditControl( privateConfigurationValues, id )
                : GetSingleSelectionCondensedEditControl( privateConfigurationValues, id );

            if ( control is WebControl webControl )
            {
                webControl.AddCssClass( "js-filter-control" );
            }

            return control;
        }

        /// <inheritdoc/>
        public sealed override string GetFilterValueValue( Control control, Dictionary<string, ConfigurationValue> configurationValues )
        {
            if ( control is RockDropDownList ddl )
            {
                return ddl.SelectedValue;
            }
            else if ( control is RockCheckBoxList cbl )
            {
                return cbl.SelectedValues.JoinStrings( "," );
            }

            return string.Empty;
        }

        /// <inheritdoc/>
        public sealed override void SetFilterValueValue( Control control, Dictionary<string, ConfigurationValue> configurationValues, string value )
        {
            if ( control is RockDropDownList ddl )
            {
                ddl.SetValue( value );
            }
            else if ( control is RockCheckBoxList cbl )
            {
                cbl.SetValues( GetValueAsList( value ) );
            }
        }

        /// <inheritdoc/>
        public sealed override string FormatFilterValueValue( Dictionary<string, ConfigurationValue> configurationValues, string value )
        {
            var privateConfigurationValues = configurationValues.ToDictionary( k => k.Key, v => v.Value.Value );
            var items = GetListItems( privateConfigurationValues );
            var textValues = new List<string>();

            var values = GetValueAsList( value );

            foreach ( string key in values )
            {
                var item = items.FirstOrDefault( i => i.Value == key );

                if ( item != null )
                {
                    textValues.Add( item.Text );
                }
            }

            return AddQuotes( textValues.ToList().AsDelimited( "' OR '" ) );
        }

        #endregion

#endif
    }

    [IntegerField( "Value Count",
        Description = "The number of values this field has.",
        IsRequired = true,
        DefaultIntegerValue = 5,
        Order = 0,
        Key = "ValueCount" )]
    [BooleanField( "As List", Key = "AsList", Order = 1 )]
    [IntegerField( "Column Count", Key = "ColumnCount", IsRequired = false, Order = 2 )]
    [BooleanField( "LongList", Key = "LongList", Order = 3 )]
    [RockPlatformSupport( Utility.RockPlatform.WebForms, Utility.RockPlatform.Obsidian )]
    [Rock.SystemGuid.FieldTypeGuid( "47622385-3fd7-4344-80f4-0e51890d8489" )]
    public class DanielTestFieldType : ItemListPickerFieldType
    {
        /// <inheritdoc/>
        protected override ValuePickerSelectionMode SelectionMode => ValuePickerSelectionMode.Single;

        /// <inheritdoc/>
        public override string GetTextValue( string privateValue, Dictionary<string, string> privateConfigurationValues )
        {
            if ( privateValue.IsNullOrWhiteSpace() )
            {
                return string.Empty;
            }

            var intValues = GetValueAsList( privateValue ).AsIntegerList();

            return intValues.Select( value => $"Item {value}" ).JoinStrings( ", " );
        }

        /// <inheritdoc/>
        protected override int? GetColumnCount( Dictionary<string, string> privateConfigurationValues )
        {
            return privateConfigurationValues.GetValueOrNull( "ColumnCount" ).AsIntegerOrNull();
        }

        /// <inheritdoc/>
        protected override ItemValuePickerDisplayMode GetDisplayMode( Dictionary<string, string> privateConfigurationValues )
        {
            return privateConfigurationValues.GetValueOrNull( "AsList" ).AsBoolean() ? ItemValuePickerDisplayMode.List : ItemValuePickerDisplayMode.Condensed;
        }

        /// <inheritdoc/>
        protected override bool GetEnhanceForLongLists( Dictionary<string, string> privateConfigurationValues )
        {
            return privateConfigurationValues.GetValueOrNull( "LongList" ).AsBoolean();
        }

        /// <inheritdoc/>
        protected override List<ListItemBag> GetListItems( Dictionary<string, string> privateConfigurationValues )
        {
            var count = privateConfigurationValues.GetValueOrNull( "ValueCount" ).AsIntegerOrNull() ?? 4;
            var items = new List<ListItemBag>();

            for ( int i = 0; i < count; i++ )
            {
                items.Add( new ListItemBag { Text = $"Item {i + 1}", Value = ( i + 1 ).ToString() } );
            }

            return items;
        }

        /// <inheritdoc/>
        protected override List<string> GetAutoUpdatingConfigurationKeys()
        {
            return new List<string>
            {
                "ValueCount",
                "ColumnCount"
            };
        }
    }

    [IntegerField( "Value Count",
        Description = "The number of values this field has.",
        IsRequired = true,
        DefaultIntegerValue = 5,
        Order = 0,
        Key = "ValueCount" )]
    [BooleanField( "As List", Key = "AsList", Order = 1 )]
    [IntegerField( "Column Count", Key = "ColumnCount", IsRequired = false, Order = 2 )]
    [BooleanField( "LongList", Key = "LongList", Order = 3 )]
    [RockPlatformSupport( Utility.RockPlatform.WebForms, Utility.RockPlatform.Obsidian )]
    [Rock.SystemGuid.FieldTypeGuid( "5ec8c7f9-a2d4-4760-a272-9fbe259e45b9" )]
    public class DanielMultiTestFieldType : ItemListPickerFieldType
    {
        /// <inheritdoc/>
        protected override ValuePickerSelectionMode SelectionMode => ValuePickerSelectionMode.Multiple;

        /// <inheritdoc/>
        public override string GetTextValue( string privateValue, Dictionary<string, string> privateConfigurationValues )
        {
            if ( privateValue.IsNullOrWhiteSpace() )
            {
                return string.Empty;
            }

            var intValues = GetValueAsList( privateValue ).AsIntegerList();

            return intValues.Select( value => $"Item {value}" ).JoinStrings( ", " );
        }

        /// <inheritdoc/>
        protected override int? GetColumnCount( Dictionary<string, string> privateConfigurationValues )
        {
            return privateConfigurationValues.GetValueOrNull( "ColumnCount" ).AsIntegerOrNull();
        }

        /// <inheritdoc/>
        protected override ItemValuePickerDisplayMode GetDisplayMode( Dictionary<string, string> privateConfigurationValues )
        {
            return privateConfigurationValues.GetValueOrNull( "AsList" ).AsBoolean() ? ItemValuePickerDisplayMode.List : ItemValuePickerDisplayMode.Condensed;
        }

        /// <inheritdoc/>
        protected override bool GetEnhanceForLongLists( Dictionary<string, string> privateConfigurationValues )
        {
            return privateConfigurationValues.GetValueOrNull( "LongList" ).AsBoolean();
        }

        /// <inheritdoc/>
        protected override List<ListItemBag> GetListItems( Dictionary<string, string> privateConfigurationValues )
        {
            var count = privateConfigurationValues.GetValueOrNull( "ValueCount" ).AsIntegerOrNull() ?? 4;
            var items = new List<ListItemBag>();

            for ( int i = 0; i < count; i++ )
            {
                items.Add( new ListItemBag { Text = $"Item {i + 1}", Value = ( i + 1 ).ToString() } );
            }

            return items;
        }

        /// <inheritdoc/>
        protected override List<string> GetAutoUpdatingConfigurationKeys()
        {
            return new List<string>
            {
                "ValueCount",
                "ColumnCount"
            };
        }
    }

    /// <summary>
    /// The selection mode the item value picker will operate in.
    /// </summary>
    public enum ValuePickerSelectionMode
    {
        /// <summary>
        /// The person is only allowed to single one item.
        /// </summary>
        Single = 0,

        /// <summary>
        /// The person is allowed to select multiple items.
        /// </summary>
        Multiple = 1
    }

    /// <summary>
    /// The way to display the items for the item value pickers.
    /// </summary>
    public enum ItemValuePickerDisplayMode
    {
        /// <summary>
        /// Let the system decide the best way to display the list of options.
        /// </summary>
        Auto = 0,

        /// <summary>
        /// Display the list of options as a long list of items. For example,
        /// as a list of checkboxes or radio buttons.
        /// </summary>
        List = 1,

        /// <summary>
        /// Display the list of options in a condensed format. For example,
        /// as a drop down list.
        /// </summary>
        Condensed = 2
    }
}

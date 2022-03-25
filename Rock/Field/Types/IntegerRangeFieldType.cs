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

using Rock.Attribute;
using Rock.Web.UI.Controls;

namespace Rock.Field.Types
{
    /// <summary>
    /// Field used to save and display a pair of integer values
    /// Stored as a comma-delimited pair of integers
    /// </summary>
    [Serializable]
    [FieldTypeUsage( FieldTypeUsage.Common )]
    [RockPlatformSupport( Utility.RockPlatform.WebForms, Utility.RockPlatform.Obsidian )]
    [IconSvg( @"<svg xmlns=""http://www.w3.org/2000/svg"" viewBox=""0 0 16 16""><path d=""M11.45,2.72h-1l.18-1.05A.58.58,0,0,0,10.11,1a.59.59,0,0,0-.67.47l-.2,1.24H7.53l.18-1.05a.58.58,0,0,0-1.14-.19L6.36,2.72H5.13a.58.58,0,0,0-.58.58.57.57,0,0,0,.58.57h1l-.38,2.3H4.55A.57.57,0,0,0,4,6.75a.56.56,0,0,0,.57.56h1l-.18,1A.58.58,0,0,0,5.89,9a.12.12,0,0,0,.1,0,.57.57,0,0,0,.56-.48l.21-1.24H8.47L8.29,8.39a.57.57,0,0,0,.48.66h.09a.58.58,0,0,0,.57-.48l.21-1.24h1.23a.57.57,0,1,0,0-1.14h-1l.38-2.29h1.24A.57.57,0,0,0,12,3.35.6.6,0,0,0,11.45,2.72ZM8.66,6.17H7l.39-2.3H9.05Z""/><path d=""M13.14,12a.64.64,0,0,1,0,.93l-2.08,1.87a.63.63,0,0,1-.88,0,.64.64,0,0,1,0-.89l.88-.78H4.91l.87.78a.64.64,0,0,1,0,.89.63.63,0,0,1-.88,0L2.87,13a.62.62,0,0,1,0-.93l2.07-1.86a.62.62,0,1,1,.84.92l-.87.78H11.1l-.88-.78a.62.62,0,1,1,.84-.92Z""/></svg>" )]
    public class IntegerRangeFieldType : FieldType
    {

        #region Formatting

        /// <inheritdoc/>
        public override string GetTextValue( string value, Dictionary<string, string> configurationValues )
        {
            if ( value == null )
            {
                return string.Empty;
            }

            string[] valuePair = value.Split( new char[] { ',' }, StringSplitOptions.None );

            if ( valuePair.Length == 2 )
            {
                string lowerValue = string.IsNullOrWhiteSpace( valuePair[0] ) ? Rock.Constants.None.TextHtml : valuePair[0];
                string upperValue = string.IsNullOrWhiteSpace( valuePair[1] ) ? Rock.Constants.None.TextHtml : valuePair[1];

                if ( !string.IsNullOrWhiteSpace( lowerValue ) || !string.IsNullOrWhiteSpace( upperValue ) )
                {
                    return string.Format( "{0} to {1}", lowerValue, upperValue );
                }
                else
                {
                    return string.Empty;
                }
            }

            // Something unexpected, return the raw value.
            return value;
        }

        /// <summary>
        /// Returns the field's current value(s)
        /// </summary>
        /// <param name="parentControl">The parent control.</param>
        /// <param name="value">Information about the value</param>
        /// <param name="configurationValues">The configuration values.</param>
        /// <param name="condensed">Flag indicating if the value should be condensed (i.e. for use in a grid column)</param>
        /// <returns></returns>
        public override string FormatValue( System.Web.UI.Control parentControl, string value, System.Collections.Generic.Dictionary<string, ConfigurationValue> configurationValues, bool condensed )
        {
            return !condensed
                ? GetTextValue( value, configurationValues.ToDictionary( k => k.Key, k => k.Value.Value ) )
                : GetCondensedTextValue( value, configurationValues.ToDictionary( k => k.Key, k => k.Value.Value ) );
        }

        #endregion

        #region Edit Control

        /// <summary>
        /// Creates the control(s) necessary for prompting user for a new value
        /// </summary>
        /// <param name="configurationValues">The configuration values.</param>
        /// <param name="id"></param>
        /// <returns>
        /// The control
        /// </returns>
        public override System.Web.UI.Control EditControl( System.Collections.Generic.Dictionary<string, ConfigurationValue> configurationValues, string id )
        {
            var numberRangeEditor = new NumberRangeEditor { ID = id };
            numberRangeEditor.NumberType = System.Web.UI.WebControls.ValidationDataType.Integer;
            return numberRangeEditor;
        }

        /// <summary>
        /// Reads new values entered by the user for the field
        /// </summary>
        /// <param name="control">Parent control that controls were added to in the CreateEditControl() method</param>
        /// <param name="configurationValues">The configuration values.</param>
        /// <returns></returns>
        public override string GetEditValue( System.Web.UI.Control control, System.Collections.Generic.Dictionary<string, ConfigurationValue> configurationValues )
        {
            NumberRangeEditor editor = control as NumberRangeEditor;
            if ( editor != null && ( editor.LowerValue.HasValue || editor.UpperValue.HasValue ) )
            {
                return string.Format( "{0},{1}", editor.LowerValue, editor.UpperValue );
            }

            return null;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="control">The control.</param>
        /// <param name="configurationValues">The configuration values.</param>
        /// <param name="value">The value.</param>
        public override void SetEditValue( System.Web.UI.Control control, System.Collections.Generic.Dictionary<string, ConfigurationValue> configurationValues, string value )
        {
            NumberRangeEditor editor = control as NumberRangeEditor;
            if ( editor != null )
            {
                if ( value != null )
                {
                    string[] valuePair = value.Split( new char[] { ',' }, StringSplitOptions.None );
                    if ( valuePair.Length == 2 )
                    {
                        int result;

                        if ( int.TryParse( valuePair[0], out result ) )
                        {
                            editor.LowerValue = result;
                        }

                        if ( int.TryParse( valuePair[1], out result ) )
                        {
                            editor.UpperValue = result;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Tests the value to ensure that it is a valid value.  If not, message will indicate why
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        /// <param name="message">The message.</param>
        /// <returns>
        ///   <c>true</c> if the specified value is valid; otherwise, <c>false</c>.
        /// </returns>
        public override bool IsValid( string value, bool required, out string message )
        {
            if ( !string.IsNullOrWhiteSpace( value ) )
            {
                int result;
                string[] valuePair = value.Split( new char[] { ',' }, StringSplitOptions.None );
                if ( valuePair.Length <= 2 )
                {
                    foreach ( string v in valuePair )
                    {
                        if ( !string.IsNullOrWhiteSpace( v ) )
                        {
                            if ( !string.IsNullOrWhiteSpace( v ) )
                            {
                                if ( !int.TryParse( v, out result ) )
                                {
                                    message = "The input provided contains invalid integer values";
                                    return false;
                                }
                            }
                        }
                    }
                }
                else
                {
                    message = "The input provided is not a valid integer range.";
                    return false;
                }
            }

            return base.IsValid( value, required, out message );
        }

        #endregion

        #region Filter Control

        /// <summary>
        /// Creates the control needed to filter (query) values using this field type.
        /// </summary>
        /// <param name="configurationValues">The configuration values.</param>
        /// <param name="id">The identifier.</param>
        /// <param name="required">if set to <c>true</c> [required].</param>
        /// <param name="filterMode">The filter mode.</param>
        /// <returns></returns>
        public override System.Web.UI.Control FilterControl( System.Collections.Generic.Dictionary<string, ConfigurationValue> configurationValues, string id, bool required, Rock.Reporting.FilterMode filterMode )
        {
            // This field type does not support filtering
            return null;
        }

        /// <summary>
        /// Determines whether this filter has a filter control
        /// </summary>
        /// <returns></returns>
        public override bool HasFilterControl()
        {
            return false;
        }

        #endregion

    }
}
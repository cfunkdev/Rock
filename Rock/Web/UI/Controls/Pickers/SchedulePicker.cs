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
using System.Web.UI;
using System.Web.UI.WebControls;

using Rock.Data;
using Rock.Model;
using Rock.Web.Cache;

namespace Rock.Web.UI.Controls
{
    /// <summary>
    /// Control that can be used to select a schedule
    /// </summary>
    public class SchedulePicker : ItemPicker
    {

        /// <summary>
        /// Gets or sets a value indicating whether to allow selection of inactive schedules.  Default is true.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [allow inactive selection]; otherwise, <c>false</c>.
        /// </value>
        public bool AllowInactiveSelection { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether [show only public].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [show only public]; otherwise, <c>false</c>.
        /// </value>
        public bool ShowOnlyPublic
        {
            get
            {
                return ViewState["ShowOnlyPublic"] as bool? ?? false;
            }

            set
            {
                ViewState["ShowOnlyPublic"] = value;
            }
        }

        #region Controls

        /// <summary>
        /// The checkbox to show inactive groups
        /// </summary>
        private RockCheckBox _cbShowInactiveSchedules;

        #endregion

        /// <summary>
        /// Called by the ASP.NET page framework to notify server controls that use composition-based implementation to create any child controls they contain in preparation for posting back or rendering.
        /// </summary>
        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            if ( AllowInactiveSelection )
            {
                _cbShowInactiveSchedules = new RockCheckBox();
                _cbShowInactiveSchedules.ContainerCssClass = "pull-right";
                _cbShowInactiveSchedules.SelectedIconCssClass = "fa fa-check-square-o";
                _cbShowInactiveSchedules.UnSelectedIconCssClass = "fa fa-square-o";
                _cbShowInactiveSchedules.ID = this.ID + "_cbShowInactiveSchedules";
                _cbShowInactiveSchedules.Text = "Show Inactive";
                _cbShowInactiveSchedules.AutoPostBack = true;
                _cbShowInactiveSchedules.CheckedChanged += _cbShowInactiveSchedules_CheckedChanged;
                this.Controls.Add( _cbShowInactiveSchedules );
            }
        }

        /// <summary>
        /// Raises the <see cref="E:System.Web.UI.Control.Init" /> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs" /> object that contains the event data.</param>
        protected override void OnInit( EventArgs e )
        {
            SetExtraRestParams();

            this.IconCssClass = "fa fa-calendar";
            base.OnInit( e );
        }

        /// <summary>
        /// Sets the value from cache.
        /// </summary>
        /// <param name="schedule">The schedule.</param>
        private void SetValueFromCache( NamedScheduleCache schedule )
        {
            if ( schedule != null )
            {
                // If setting the value to an inactive schedule, enable the "Show Inactive Schedules" checkbox.
                if ( AllowInactiveSelection && !schedule.IsActive )
                {
                    _cbShowInactiveSchedules.Checked = true;
                    SetExtraRestParams( true );
                }

                ItemId = schedule.Id.ToString();

                string parentCategoryIds = string.Empty;
                var parentCategory = schedule.Category;
                while ( parentCategory != null )
                {
                    parentCategoryIds = parentCategory.Id + "," + parentCategoryIds;
                    parentCategory = parentCategory.ParentCategory;
                }

                ExpandedCategoryIds = parentCategoryIds.TrimEnd( new[] { ',' } );
                ItemName = schedule.Name;
            }
            else
            {
                ItemId = Constants.None.IdValue;
                ItemName = Constants.None.TextHtml;
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="schedule">The schedule.</param>
        public void SetValue( Schedule schedule )
        {
            if ( schedule == null )
            {
                SetValueFromCache( null );
            }
            else
            {
                SetValueFromCache( NamedScheduleCache.Get( schedule.Id ) );
            }
        }

        /// <summary>
        /// Sets the values from cache.
        /// </summary>
        /// <param name="schedules">The schedules.</param>
        private void SetValuesFromCache( IEnumerable<NamedScheduleCache> schedules )
        {
            var scheduleList = schedules.ToList();

            if ( scheduleList.Any() )
            {
                var ids = new List<string>();
                var names = new List<string>();
                var parentCategoryIds = string.Empty;

                foreach ( var schedule in scheduleList )
                {
                    if ( schedule != null )
                    {
                        // If setting the value to an inactive schedule, enable the "Show Inactive Schedules" checkbox.
                        if ( AllowInactiveSelection && !schedule.IsActive )
                        {
                            _cbShowInactiveSchedules.Checked = true;
                            SetExtraRestParams( true );
                        }

                        ids.Add( schedule.Id.ToString() );
                        names.Add( schedule.Name );
                        var parentCategory = schedule.Category;

                        while ( parentCategory != null )
                        {
                            parentCategoryIds = parentCategory.Id + "," + parentCategoryIds;
                            parentCategory = parentCategory.ParentCategory;
                        }
                    }
                }

                ExpandedCategoryIds = parentCategoryIds.TrimEnd( new[] { ',' } );
                ItemIds = ids;
                ItemNames = names;
            }
            else
            {
                ItemId = Constants.None.IdValue;
                ItemName = Constants.None.TextHtml;
            }
        }

        /// <summary>
        /// Sets the values.
        /// </summary>
        /// <param name="schedules">The schedules.</param>
        public void SetValues( IEnumerable<Schedule> schedules )
        {
            SetValuesFromCache( schedules.Select( a => NamedScheduleCache.Get( a.Id ) ).ToList() );
        }

        /// <summary>
        /// Sets the value on select.
        /// </summary>
        protected override void SetValueOnSelect()
        {
            SetValueFromCache( NamedScheduleCache.Get( ItemId.AsInteger() ) );
        }

        /// <summary>
        /// Sets the values on select.
        /// </summary>
        protected override void SetValuesOnSelect()
        {
            this.SetValuesFromCache( ItemIds.AsIntegerList().Select( a => NamedScheduleCache.Get( a ) ).ToList() );
        }

        /// <summary>
        /// Gets the item rest URL.
        /// </summary>
        /// <value>
        /// The item rest URL.
        /// </value>
        public override string ItemRestUrl => "~/api/Categories/GetChildren/";

        /// <summary>
        /// Render any additional picker actions
        /// </summary>
        /// <param name="writer">The writer.</param>
        public override void RenderCustomPickerActions( HtmlTextWriter writer )
        {
            base.RenderCustomPickerActions( writer );

            if ( AllowInactiveSelection )
            {
                _cbShowInactiveSchedules.RenderControl( writer );
            }
        }

        /// <summary>
        /// Sets the extra rest parameters.
        /// </summary>
        private void SetExtraRestParams( bool includeInactiveSchedules = false )
        {
            ItemRestUrlExtraParams = "?getCategorizedItems=true&showUnnamedEntityItems=false&showCategoriesThatHaveNoChildren=false";
            ItemRestUrlExtraParams += "&entityTypeId=" + EntityTypeCache.Get( Rock.SystemGuid.EntityType.SCHEDULE.AsGuid() ).Id;
            if ( ShowOnlyPublic )
            {
                ItemRestUrlExtraParams += "&itemFilterPropertyName=IsPublic";
                ItemRestUrlExtraParams += "&itemFilterPropertyValue=" + ShowOnlyPublic.ToTrueFalse();
            }

            ItemRestUrlExtraParams += "&includeInactiveItems=" + includeInactiveSchedules.ToTrueFalse();
            ItemRestUrlExtraParams += "&lazyLoad=false";
        }

        /// <summary>
        /// Handles the CheckedChanged event of the _cbShowInactiveSchedules control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        public void _cbShowInactiveSchedules_CheckedChanged( object sender, EventArgs e )
        {
            ShowDropDown = true;
            SetExtraRestParams( _cbShowInactiveSchedules.Checked );
        }
    }
}
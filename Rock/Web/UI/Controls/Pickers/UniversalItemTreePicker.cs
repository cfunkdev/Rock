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
using System.Web.UI;

namespace Rock.Web.UI.Controls
{
    public sealed class UniversalItemTreePicker : ItemPicker
    {
        /// <inheritdoc/>
        public override string ItemRestUrl => "/api/v2/Controls/TestItems";

        internal override string InternalCategoryPrefix => string.Empty;

        protected override void SetValueOnSelect()
        {
            ItemName = "selected";
            ExpandedCategoryIds = "";
        }

        protected override void SetValuesOnSelect()
        {
            ItemNames = new string[] { "selected 1", "selected 2" };
            ExpandedCategoryIds = "";
        }

        // I think the tree needs a few things:
        // 1. Root URL (this will be restUrl) that will return the root items, and then the URLs to the child items.
        // 2. NO - URL to get the path to items (i.e. ["parentA", "parentB", "itemId"]
        //    This should take an array of item ids and return a dictionary of arrays.
        // 3. Both URLs should be POST calls, each taking a security grant token,
        //    a generic context string, and in the case of #2 an array of item guids. #1 should also get ParentGuid.
        // 4. When getting the root items, the currently selected item identifiers
        //    should be included, this allows the API to auto-expand the tree nodes required
        //    to reach the selected item(s).
        // 5. TreeItemBag, should it be updated to include an optional childUrl to specify
        //    the URL to use to load children? If not should it be a custom subclass for use
        //    specifically by the universal tree picker?
        protected override void RegisterJavaScript()
        {
            string treeViewScript =
$@"Rock.controls.itemPicker.initialize({{
    controlId: '{this.ClientID}',
    universalItemPicker: true,
    restUrl: '{this.ResolveUrl( ItemRestUrl )}',
    allowMultiSelect: {this.AllowMultiSelect.ToString().ToLower()},
    allowCategorySelection: {this.UseCategorySelection.ToString().ToLower()},
    categoryPrefix: '',
    defaultText: '{this.DefaultText}',
    expandedIds: [{this.InitialItemParentIds}],
    expandedCategoryIds: [{this.ExpandedCategoryIds}],
    showSelectChildren: {this.ShowSelectChildren.ToString().ToLower()}
}});
";
            ScriptManager.RegisterStartupScript( this, this.GetType(), "item_picker-treeviewscript_" + this.ClientID, treeViewScript, true );

            // Search Control

        }
    }
}
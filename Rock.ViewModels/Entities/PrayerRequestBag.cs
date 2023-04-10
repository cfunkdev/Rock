﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
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
using System.Linq;

using Rock.ViewModels.Utility;

namespace Rock.ViewModels.Entities
{
    /// <summary>
    /// PrayerRequest View Model
    /// </summary>
    public partial class PrayerRequestBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets a flag indicating  whether or not comments can be made against the request.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if comments are allowed; otherwise false.
        /// </value>
        public bool? AllowComments { get; set; }

        /// <summary>
        /// Gets or sets a description of the way that God has answered the prayer.
        /// </summary>
        /// <value>
        /// A System.String that contains a description of how God answered the prayer request.
        /// </value>
        public string Answer { get; set; }

        /// <summary>
        /// Gets or sets the PersonId of the Rock.Model.Person who approved this prayer request.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the PersonId of the Rock.Model.Person who approved this prayer request.
        /// </value>
        public int? ApprovedByPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the date this prayer request was approved.
        /// </summary>
        /// <value>
        /// A System.DateTime representing the date that this prayer request was approved.
        /// </value>
        public DateTime? ApprovedOnDateTime { get; set; }

        /// <summary>
        /// Gets or sets the campus identifier.
        /// </summary>
        /// <value>
        /// The campus identifier.
        /// </value>
        public int? CampusId { get; set; }

        /// <summary>
        /// Gets or sets the CategoryId of the Rock.Model.Category that the PrayerRequest belongs to.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the CategoryId of the Rock.Model.Category that the PrayerRequest belongs to.
        /// </value>
        public int? CategoryId { get; set; }

        /// <summary>
        /// Gets or sets the email address of the person requesting prayer.
        /// </summary>
        /// <value>
        /// A System.String containing the email address of the person requesting prayer.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the date that this prayer request was entered.
        /// </summary>
        /// <value>
        /// A System.DateTime representing the date that this prayer request was entered.
        /// </value>
        public DateTime EnteredDateTime { get; set; }

        /// <summary>
        /// Gets or sets the date that the prayer request expires. 
        /// </summary>
        /// <value>
        /// A System.DateTime representing the date that the prayer request expires.
        /// </value>
        public DateTime? ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets the First Name of the person that this prayer request is about. This property is required.
        /// </summary>
        /// <value>
        /// A System.String containing the first name of the person that this prayer request is about.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the number of times this request has been flagged.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the number of times that this prayer request has been flagged.
        /// </value>
        public int? FlagCount { get; set; }

        /// <summary>
        /// TODO: GET CLARIFICATION AND DOCUMENT
        /// Gets or sets the group id.
        /// </summary>
        /// <value>
        /// A System.Int32 representing a Group's GroupId.
        /// </value>
        public int? GroupId { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if this prayer request is active.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if the prayer request is active; otherwise false.
        /// </value>
        public bool? IsActive { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if the prayer request has been approved. 
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if this prayer request has been approved; otherwise false.
        /// </value>
        public bool? IsApproved { get; set; }

        /// <summary>
        /// Gets or sets the flag indicating whether or not the request is public.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if the prayer request is public; otherwise false.
        /// </value>
        public bool? IsPublic { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if this is an urgent prayer request.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if this prayer request is urgent; otherwise false.
        /// </value>
        public bool? IsUrgent { get; set; }

        /// <summary>
        /// Gets or sets the DefinedValueId of the Rock.Model.DefinedValue that represents the Language for this prayer request.
        /// </summary>
        /// <value>
        /// A System.Int32 representing DefinedValueId of the Language's Rock.Model.DefinedValue for this prayer request.
        /// </value>
        public int? LanguageValueId { get; set; }

        /// <summary>
        /// Gets or sets the Last Name of the person that this prayer request is about. This property is required.
        /// </summary>
        /// <value>
        /// A System.String containing the last name of the person that this prayer request is about.  
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the number of times that this prayer request has been prayed for.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the number of times that this prayer request has been prayed for.
        /// </value>
        public int? PrayerCount { get; set; }

        /// <summary>
        /// Gets or sets the PersonId of the Rock.Model.Person who is submitting the PrayerRequest
        /// </summary>
        /// <value>
        /// A System.Int32 representing the PersonId of Rock.Model.Person submitting the PrayerRequest.
        /// </value>
        public int? RequestedByPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the text/content of the request.
        /// </summary>
        /// <value>
        /// A System.String representing the text/content of the request.
        /// </value>
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the created date time.
        /// </summary>
        /// <value>
        /// The created date time.
        /// </value>
        public DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the modified date time.
        /// </summary>
        /// <value>
        /// The modified date time.
        /// </value>
        public DateTime? ModifiedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the created by person alias identifier.
        /// </summary>
        /// <value>
        /// The created by person alias identifier.
        /// </value>
        public int? CreatedByPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the modified by person alias identifier.
        /// </summary>
        /// <value>
        /// The modified by person alias identifier.
        /// </value>
        public int? ModifiedByPersonAliasId { get; set; }

        /// <summary>
        /// Gets or sets the FullName of the request.
        /// </summary>
        /// <value>
        /// A System.String representing the FullName of the request.
        /// </value>
        public string FullName { get; set; }
    }
}

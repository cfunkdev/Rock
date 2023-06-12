//------------------------------------------------------------------------------
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
    /// Person View Model
    /// </summary>
    public partial class PersonBag : EntityBagBase
    {
        /// <summary>
        /// Gets or sets the person's account protection profile, which is used by the duplication detection and merge processes.
        /// </summary>
        /// <value>
        /// The account protection profile.
        /// </value>
        public int AccountProtectionProfile { get; set; }

        /// <summary>
        /// Gets the Person's age.
        /// </summary>
        /// <value>
        /// An System.Int32 representing the person's age. Returns null if the birthdate or birthyear is not available.
        /// </value>
        public int? Age { get; set; }

        /// <summary>
        /// Gets or sets the age bracket.
        /// </summary>
        /// <value>
        /// The age range.
        /// </value>
        public int AgeBracket { get; set; }

        /// <summary>
        /// Gets or sets the age classification of the Person.
        /// Note: This is computed on save, so any manual changes to this will be ignored.
        /// </summary>
        /// <value>
        /// A Rock.Model.AgeClassification enum value representing the Person's age classification.  Valid values are AgeClassification.Unknown if the Person's age is unknown,
        /// AgeClassification.Adult if the Person's age falls under Adult Range, AgeClassification.Child if the Person is under the age of 18
        /// </value>
        public int AgeClassification { get; set; }

        /// <summary>
        /// Gets or sets the date of the Person's wedding anniversary.  This property is nullable if the Person is not married or their anniversary date is not known.
        /// </summary>
        /// <value>
        /// A System.DateTime representing the anniversary date of the Person's wedding. If the anniversary date is not known or they are not married this value will be null.
        /// </value>
        public DateTime? AnniversaryDate { get; set; }

        /// <summary>
        /// Gets or sets the birth date key.
        /// </summary>
        /// <value>
        /// The birth date key.
        /// </value>
        public int? BirthDateKey { get; set; }

        /// <summary>
        /// Gets or sets the day of the month portion of the Person's birth date.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the day of the month portion of the Person's birth date. If their birth date is not known
        /// this value will be null.
        /// </value>
        public int? BirthDay { get; set; }

        /// <summary>
        /// Gets or sets the month portion of the Person's birth date.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the month portion of the Person's birth date. If the birth date is not known this value will be null.
        /// </value>
        public int? BirthMonth { get; set; }

        /// <summary>
        /// Gets or sets the year portion of the Person's birth date.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the year portion of the Person's birth date. If the birth date is not known this value will be null.
        /// </value>
        public int? BirthYear { get; set; }

        /// <summary>
        /// Gets or sets the communication preference.
        /// </summary>
        /// <value>
        /// The communication preference.
        /// </value>
        public int CommunicationPreference { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Defined Value Rock.Model.DefinedValue representing the connection status of the Person.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the connection status of the Person.
        /// </value>
        public int? ConnectionStatusValueId { get; set; }

        /// <summary>
        /// Gets or sets the person's default financial account gift designation.
        /// </summary>
        /// <value>
        /// The financial account id.
        /// </value>
        public int? ContributionFinancialAccountId { get; set; }

        /// <summary>
        /// Gets or sets the deceased date.
        /// </summary>
        /// <value>
        /// The deceased date.
        /// </value>
        public DateTime? DeceasedDate { get; set; }

        /// <summary>
        /// Gets or sets the Person's email address.
        /// </summary>
        /// <value>
        /// A System.String containing the Person's email address.
        /// </value>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a note about the Person's email address.
        /// </summary>
        /// <value>
        /// A System.String representing a note about the Person's email address.
        /// </value>
        public string EmailNote { get; set; }

        /// <summary>
        /// Gets or sets the email preference.
        /// </summary>
        /// <value>
        /// The email preference.
        /// </value>
        public int EmailPreference { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Ethnicity Rock.Model.DefinedValue representing the ethnicity of this person
        /// </summary>
        /// <value>
        /// A System.Int32 representing the Id of the Ethnicity Rock.Model.DefinedValue representing the ethnicity of this person.
        /// </value>
        public int? EthnicityValueId { get; set; }

        /// <summary>
        /// Gets or sets the first name of the Person.
        /// </summary>
        /// <value>
        /// A System.String representing the first name of the Person.
        /// </value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the First Name pronunciation override.
        /// </summary>
        /// <value>
        /// A string with a pronunciation of the first name.
        /// </value>
        public string FirstNamePronunciationOverride { get; set; }

        /// <summary>
        /// Gets or sets the gender of the Person. This property is required.
        /// </summary>
        /// <value>
        /// A Rock.Model.Gender enum value representing the Person's gender.  Valid values are Gender.Unknown if the Person's gender is unknown,
        /// Gender.Male if the Person's gender is Male, Gender.Female if the Person's gender is Female.
        /// </value>
        public int Gender { get; set; }

        /// <summary>
        /// Gets or sets the giving group id.  If an individual would like their giving to be grouped with the rest of their family,
        /// this will be the id of their family group.  If they elect to contribute on their own, this value will be null.
        /// </summary>
        /// <value>
        /// The giving group id.
        /// </value>
        public int? GivingGroupId { get; set; }

        /// <summary>
        /// Gets or sets the giving leader's Person Id.
        /// Note: This is computed on save, so any manual changes to this will be ignored.
        /// </summary>
        /// <value>
        /// The giving leader identifier.
        /// </value>
        public int GivingLeaderId { get; set; }

        /// <summary>
        /// Gets or sets the date of the Person's projected or actual high school graduation year. This value is used to determine what grade a student is in.
        /// </summary>
        /// <value>
        /// The Person's projected or actual high school graduation year
        /// </value>
        public int? GraduationYear { get; set; }

        /// <summary>
        /// Gets or sets the Inactive Reason Note
        /// </summary>
        /// <value>
        /// A System.String representing an Inactive Reason Note.
        /// </value>
        public string InactiveReasonNote { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if the Person is deceased.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if the Person is deceased; otherwise false.
        /// </value>
        public bool IsDeceased { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if the Person's email address is active.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if the email address is active, otherwise false.
        /// </value>
        public bool IsEmailActive { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if the Person is locked as child.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if the Person is locked as child; otherwise false.
        /// </value>
        public bool IsLockedAsChild { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating if this Person is part of the Rock core system/framework. This property is required.
        /// </summary>
        /// <value>
        /// A System.Boolean value that is true if this Person is part of the Rock core system/framework. This property is required.
        /// </value>
        public bool IsSystem { get; set; }

        /// <summary>
        /// Gets or sets the last name (Sir Name) of the Person.
        /// </summary>
        /// <value>
        /// A System.String that represents the Last Name of the Person.
        /// </value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the last Name pronunciation override.
        /// </summary>
        /// <value>
        /// A string with a pronunciation of the last name.
        /// </value>
        public string LastNamePronunciationOverride { get; set; }

        /// <summary>
        /// Gets or sets Id of the Marital Status Rock.Model.DefinedValue representing the Person's marital status.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the Id of the Marital Status Rock.Model.DefinedValue representing the Person's marital status.  This value is nullable.
        /// </value>
        public int? MaritalStatusValueId { get; set; }

        /// <summary>
        /// Gets or sets the middle name of the Person.
        /// </summary>
        /// <value>
        /// A System.String that represents the middle name of the Person.
        /// </value>
        public string MiddleName { get; set; }

        /// <summary>
        /// Gets or sets the nick name of the Person.  If a nickname was not entered, the first name is used.
        /// </summary>
        /// <value>
        /// A System.String representing the nick name of the Person.
        /// </value>
        public string NickName { get; set; }

        /// <summary>
        /// Gets or sets the nick Name pronunciation override.
        /// </summary>
        /// <value>
        /// A string with a pronunciation of the nick name.
        /// </value>
        public string NickNamePronunciationOverride { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Rock.Model.BinaryFile that contains the photo of the Person.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the Id of the Rock.Model.BinaryFile containing the photo of the Person.
        /// </value>
        public int? PhotoId { get; set; }

        /// <summary>
        /// Gets or sets the DefinedValueId of the Rock.Model.DefinedValue that represents the Preferred Language for this person.
        /// </summary>
        /// <value>
        /// A System.Int32 representing DefinedValueId of the Preferred Language Rock.Model.DefinedValue for this person.
        /// </value>
        public int? PreferredLanguageValueId { get; set; }

        /// <summary>
        /// Gets or sets the campus id for the primary family.
        /// Note: This is computed on save, so any manual changes to this will be ignored.
        /// </summary>
        /// <value>
        /// The campus id of the primary family.
        /// </value>
        public int? PrimaryCampusId { get; set; }

        /// <summary>
        /// Gets or sets the group id for the Rock.Model.Person.PrimaryFamily.
        /// Note: This is computed on save, so any manual changes to this will be ignored.
        /// </summary>
        /// <value>
        /// The primary family id.
        /// </value>
        public int? PrimaryFamilyId { get; set; }

        /// <summary>
        /// Gets or sets the notes for the pronunciation.
        /// </summary>
        /// <value>
        /// A string with notes on the pronunciation.
        /// </value>
        public string PronunciationNote { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Race Rock.Model.DefinedValue representing the race of this person
        /// </summary>
        /// <value>
        /// A System.Int32 representing the Id of the Race Rock.Model.DefinedValue representing the race of this person.
        /// </value>
        public int? RaceValueId { get; set; }

        /// <summary>
        /// Gets or sets the record status last modified date time.
        /// </summary>
        /// <value>
        /// The record status last modified date time.
        /// </value>
        public DateTime? RecordStatusLastModifiedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Record Status Reason Rock.Model.DefinedValue representing the reason why a person record status would have a set status.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the Id of the Record Status Reason Rock.Model.DefinedValue representing the reason why a person entity would have a set status.
        /// </value>
        public int? RecordStatusReasonValueId { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Record Status Rock.Model.DefinedValue representing the status of this entity
        /// </summary>
        /// <value>
        /// A System.Int32 representing the Id of the Record Status Rock.Model.DefinedValue representing the status of this entity.
        /// </value>
        public int? RecordStatusValueId { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Person Record Type Rock.Model.DefinedValue representing what type of Person Record this is.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the Id of the Rock.Model.DefinedValue identifying the person record type. If no value is selected this can be null.
        /// </value>
        public int? RecordTypeValueId { get; set; }

        /// <summary>
        /// Gets or sets the reminder count associated with the Person.
        /// </summary>
        /// <value>
        /// An System.Int32 representing the reminder count that is associated with the Person.
        /// </value>
        public int? ReminderCount { get; set; }

        /// <summary>
        /// Gets or sets notes about why a person profile needs to be reviewed
        /// </summary>
        /// <value>
        /// A System.String representing an Review Reason Note.
        /// </value>
        public string ReviewReasonNote { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Defined Value Rock.Model.DefinedValue representing the reason a record needs to be reviewed.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the reason a record needs to be reviewed.
        /// </value>
        public int? ReviewReasonValueId { get; set; }

        /// <summary>
        /// Gets or sets the Id of the Person's name Suffix Rock.Model.DefinedValue.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the Id of the Person's name Suffix Rock.Model.DefinedValue. If the Person
        /// does not have a suffix as part of their name this value will be null.
        /// </value>
        public int? SuffixValueId { get; set; }

        /// <summary>
        /// Gets or sets the System Note
        /// </summary>
        /// <value>
        /// A System.String representing a System Note.
        /// </value>
        public string SystemNote { get; set; }

        /// <summary>
        /// Gets or sets Id of the (Salutation) Tile Rock.Model.DefinedValue that is associated with the Person
        /// </summary>
        /// <value>
        /// An System.Int32 representing the Title Rock.Model.DefinedValue that is associated with the Person.
        /// </value>
        public int? TitleValueId { get; set; }

        /// <summary>
        /// Gets or sets the name of the top signal color. This property is used to indicate the icon color
        /// on a person if they have a related signal.
        /// </summary>
        /// <value>
        /// A System.String representing the CSS color.
        /// </value>
        public string TopSignalColor { get; set; }

        /// <summary>
        /// Gets or sets the name of the top signal CSS class. This property is used to indicate which icon to display
        /// on a person if they have a related signal.
        /// </summary>
        /// <value>
        /// A System.String representing the name of the signal CSS class.
        /// </value>
        public string TopSignalIconCssClass { get; set; }

        /// <summary>
        /// Gets or sets the highest priority PersonSignal associated with this person.
        /// </summary>
        /// <value>
        /// A System.Int32 representing a PersonSignal Id of the Rock.Model.PersonSignal.
        /// </value>
        public int? TopSignalId { get; set; }

        /// <summary>
        /// Gets or sets the count of the number of times that the Person has been viewed.
        /// </summary>
        /// <value>
        /// A System.Int32 representing the number of times that the Person has been viewed.
        /// </value>
        public int? ViewedCount { get; set; }

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

    }
}

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
using Rock;
using Rock.Communication;

public class PersonCsvMapper
{
    public static Slingshot.Core.Model.Person Map( IDictionary<string, object> csvEntryLookup, Dictionary<string, string> csvHeaderMapper, out HashSet<string> parserErrors )
    {
        var person = new Slingshot.Core.Model.Person();
        parserErrors = new HashSet<string>();

        #region Required Fields

        person.Id = csvEntryLookup[csvHeaderMapper["Id"]].ToIntSafe();

        string csvColumnFamilyId = csvHeaderMapper["Family Id"];
        person.FamilyId = csvEntryLookup[csvColumnFamilyId].ToIntSafe();

        string csvColumnFamilyRole = csvHeaderMapper["Family Role"];
        string familyRoleString = csvEntryLookup[csvColumnFamilyRole].ToStringSafe();
        person.FamilyRole = ( Slingshot.Core.Model.FamilyRole ) Enum.Parse( typeof( Slingshot.Core.Model.FamilyRole ), familyRoleString );

        string csvColumnFirstName = csvHeaderMapper["First Name"];
        person.FirstName = csvEntryLookup[csvColumnFirstName].ToStringSafe();

        string csvColumnLastName = csvHeaderMapper["Last Name"];
        person.LastName = csvEntryLookup[csvColumnLastName].ToStringSafe();

        #endregion Required Fields

        #region Optionals Fields
        // These may not be present in the csvHeaderMapper thus needs to be checked.

        {
            if ( csvHeaderMapper.TryGetValue( "Nick Name", out string csvColumnNickName ) )
            {
                person.NickName = csvEntryLookup[csvColumnNickName].ToStringSafe();
            }
        }

        {
            if ( csvHeaderMapper.TryGetValue( "Middle Name", out string csvColumnMiddleName ) )
            {
                person.MiddleName = csvEntryLookup[csvColumnMiddleName].ToStringSafe();
            }
        }

        {
            if ( csvHeaderMapper.TryGetValue( "Suffix", out string csvColumnSuffix ) )
            {
                person.Suffix = csvEntryLookup[csvColumnSuffix].ToStringSafe();
            }
        }

        {
            if ( csvHeaderMapper.TryGetValue( "Email", out string csvColumnEmail ) )
            {
                person.Email = csvEntryLookup[csvColumnEmail].ToStringSafe();
                bool isEmailValid = EmailAddressFieldValidator.Validate( person.Email, allowMultipleAddresses: false, allowLava: false ) == EmailFieldValidationResultSpecifier.Valid;
                if ( !isEmailValid )
                {
                    parserErrors.Add( $"Email Address {person.Email} could not be read" );
                    person.Email = string.Empty;
                }
            }
        }

        {
            if ( csvHeaderMapper.TryGetValue( "Gender", out string csvColumnGender ) )
            {
                string genderString = csvEntryLookup[csvColumnGender].ToStringSafe();
                if ( Enum.TryParse( genderString, out Slingshot.Core.Model.Gender GenderEnum ) )
                {
                    person.Gender = GenderEnum;
                }
                else
                {
                    parserErrors.Add( $"Gender {genderString} is invalid defaulting to {person.Gender}" );
                }
            }
        }

        {
            if ( csvHeaderMapper.TryGetValue( "Email Preference", out string csvColumnEmailPreference ) )
            {
                string emailPreferenceString = csvEntryLookup[csvColumnEmailPreference].ToStringSafe();
                if ( Enum.TryParse( emailPreferenceString, out Slingshot.Core.Model.EmailPreference EmailPreferenceEnum ) )
                {
                    person.EmailPreference = EmailPreferenceEnum;
                }
                else
                {
                    parserErrors.Add( $"Email Preference {emailPreferenceString} is invalid defaulting to {person.EmailPreference}" );
                }
            }
        }

        {
            if ( csvHeaderMapper.TryGetValue( "Salutation", out string csvColumnSalutation ) )
            {
                person.Salutation = csvEntryLookup[csvColumnSalutation].ToStringSafe();
            }
        }

        {
            person.MaritalStatus = Slingshot.Core.Model.MaritalStatus.Unknown;
            if ( csvHeaderMapper.TryGetValue( "Marital Status", out string csvColumnMaritalStatus ) )
            {
                string martialStatusString = csvEntryLookup[csvColumnMaritalStatus].ToStringSafe();
                if ( Enum.TryParse( martialStatusString, out Slingshot.Core.Model.MaritalStatus maritalStatusEnum ) )
                {
                    person.MaritalStatus = maritalStatusEnum;
                }
                else
                {
                    parserErrors.Add( $"Marital Status {martialStatusString} is invalid defaulting to {person.MaritalStatus}" );
                }
            }
        }

        {
            if ( csvHeaderMapper.TryGetValue( "Birthdate", out string csvColumnBirthdate ) )
            {
                string birthdateString = csvEntryLookup[csvColumnBirthdate].ToStringSafe();
                if ( DateTime.TryParse( birthdateString, out DateTime birthdateDateTime ) )
                {
                    person.Birthdate = birthdateDateTime;
                }
                else
                {
                    parserErrors.Add( $"Birthdate {birthdateString} could not be read" );
                }
            }
        }

        {
            if ( csvHeaderMapper.TryGetValue( "Anniversary Date", out string csvColumnAnniversaryDate ) )
            {
                string anniversaryDateString = csvEntryLookup[csvColumnAnniversaryDate].ToStringSafe();
                if ( DateTime.TryParse( anniversaryDateString, out DateTime AnniversaryDateTime ) )
                {
                    person.AnniversaryDate = AnniversaryDateTime;
                }
                else
                {
                    parserErrors.Add( $"Anniversary Date {anniversaryDateString} could not be read" );
                }
            }
        }

        {
            if ( csvHeaderMapper.TryGetValue( "Record Status", out string csvColumnRecordStatus ) )
            {
                string recordStatusString = csvEntryLookup[csvColumnRecordStatus].ToStringSafe();
                if ( Enum.TryParse( recordStatusString, out Slingshot.Core.Model.RecordStatus RecordStatusEnum ) )
                {
                    person.RecordStatus = RecordStatusEnum;
                }
                else
                {
                    parserErrors.Add( $"Record Status {recordStatusString} is invalid defaulting to {person.RecordStatus}" );
                }
            }
        }

        {
            if ( csvHeaderMapper.TryGetValue( "Inactive Reason", out string csvColumnInactiveReason ) )
            {
                person.InactiveReason = csvEntryLookup[csvColumnInactiveReason].ToStringSafe();
            }
        }

        {
            if ( csvHeaderMapper.TryGetValue( "Is Deceased", out string csvColumnIsDeceased ) )
            {
                string isDeceasedString = csvEntryLookup[csvColumnIsDeceased].ToStringSafe();
                if ( Boolean.TryParse( isDeceasedString, out bool isDeceasedBoolean ) )
                {
                    person.IsDeceased = isDeceasedBoolean;
                }
                else
                {
                    parserErrors.Add( $"Could not set Is Deceased to {isDeceasedString} defaulting to \'{person.IsDeceased}\'" );
                }
            }
        }

        {
            if ( csvHeaderMapper.TryGetValue( "Connection Status", out string csvColumnConnectionStatus ) )
            {
                person.ConnectionStatus = csvEntryLookup[csvColumnConnectionStatus].ToStringSafe();
            }
        }

        {
            if ( csvHeaderMapper.TryGetValue( "Grade", out string csvColumnGrade ) )
            {
                person.Grade = csvEntryLookup[csvColumnGrade].ToStringSafe();
            }
        }

        {
            if ( csvHeaderMapper.TryGetValue( "Campus Id", out string csvColumnCampusId ) )
            {
                person.Campus.CampusId = csvEntryLookup[csvColumnCampusId].ToIntSafe();
            }
        }

        {
            if ( csvHeaderMapper.TryGetValue( "Campus Name", out string csvColumnCampusName ) )
            {
                person.Campus.CampusName = csvEntryLookup[csvColumnCampusName].ToStringSafe();
            }
        }

        {
            if ( csvHeaderMapper.TryGetValue( "Give Individually", out string csvColumnGivingIndividually ) )
            {
                string givingIndividuallyString = csvEntryLookup[csvColumnGivingIndividually].ToStringSafe();
                if ( Boolean.TryParse( givingIndividuallyString, out bool givingIndividuallyBoolean ) )
                {
                    person.GiveIndividually = givingIndividuallyBoolean;
                }
                else
                {
                    parserErrors.Add( $"Could not set Give Individually to {givingIndividuallyString} defaulting to \'{person.GiveIndividually}\'" );
                }
            }
        }

        {
            if ( csvHeaderMapper.TryGetValue( "Created Date Time", out string csvColumnCreatedDateTime ) )
            {
                string createdDateTimeString = csvEntryLookup[csvColumnCreatedDateTime].ToStringSafe();
                if ( DateTime.TryParse( createdDateTimeString, out DateTime createdDateTime ) )
                {
                    person.CreatedDateTime = createdDateTime;
                }
                else
                {
                    parserErrors.Add( $"Created Date Time {createdDateTimeString} could not be read" );
                }
            }
        }

        {
            if ( csvHeaderMapper.TryGetValue( "Modified Date Time", out string csvColumnModifiedDateTime ) )
            {
                string modifiedDateTimeString = csvEntryLookup[csvColumnModifiedDateTime].ToStringSafe();
                if ( DateTime.TryParse( modifiedDateTimeString, out DateTime modifiedDateTime ) )
                {
                    person.ModifiedDateTime = modifiedDateTime;
                }
                else
                {
                    parserErrors.Add( $"Modified Date Time {modifiedDateTimeString} could not be read" );
                }
            }
        }

        #endregion Optionals Fields

        return person;
    }
}
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the Rock.CodeGeneration project
//     Changes to this file will be lost when the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
//
// THIS WORK IS LICENSED UNDER A CREATIVE COMMONS ATTRIBUTION-NONCOMMERCIAL-
// SHAREALIKE 3.0 UNPORTED LICENSE:
// http://creativecommons.org/licenses/by-nc-sa/3.0/
//

using System;
using System.Linq;

using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// Person Service class
    /// </summary>
    public partial class PersonService : Service<Person>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonService"/> class
        /// </summary>
        public PersonService()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonService"/> class
        /// </summary>
        /// <param name="repository">The repository.</param>
        public PersonService(IRepository<Person> repository) : base(repository)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public PersonService(RockContext context) : base(context)
        {
        }

        /// <summary>
        /// Determines whether this instance can delete the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="errorMessage">The error message.</param>
        /// <returns>
        ///   <c>true</c> if this instance can delete the specified item; otherwise, <c>false</c>.
        /// </returns>
        public bool CanDelete( Person item, out string errorMessage )
        {
            errorMessage = string.Empty;
            
            // ignoring Communication,ReviewerPersonId 
            
            // ignoring Communication,SenderPersonId 
 
            if ( new Service<CommunicationRecipient>().Queryable().Any( a => a.PersonId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Person.FriendlyTypeName, CommunicationRecipient.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<FinancialBatch>().Queryable().Any( a => a.CreatedByPersonId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Person.FriendlyTypeName, FinancialBatch.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<FinancialPledge>().Queryable().Any( a => a.PersonId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Person.FriendlyTypeName, FinancialPledge.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<FinancialScheduledTransaction>().Queryable().Any( a => a.AuthorizedPersonId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Person.FriendlyTypeName, FinancialScheduledTransaction.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<FinancialTransaction>().Queryable().Any( a => a.AuthorizedPersonId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Person.FriendlyTypeName, FinancialTransaction.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<HtmlContent>().Queryable().Any( a => a.ApprovedByPersonId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Person.FriendlyTypeName, HtmlContent.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<MarketingCampaign>().Queryable().Any( a => a.ContactPersonId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Person.FriendlyTypeName, MarketingCampaign.FriendlyTypeName );
                return false;
            }  
            
            // ignoring PersonViewed,TargetPersonId 
            
            // ignoring PersonViewed,ViewerPersonId 
 
            if ( new Service<PhoneNumber>().Queryable().Any( a => a.PersonId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Person.FriendlyTypeName, PhoneNumber.FriendlyTypeName );
                return false;
            }  
            
            // ignoring PrayerRequest,ApprovedByPersonId 
            
            // ignoring PrayerRequest,RequestedByPersonId 
 
            if ( new Service<Tag>().Queryable().Any( a => a.OwnerId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Person.FriendlyTypeName, Tag.FriendlyTypeName );
                return false;
            }  
            return true;
        }
    }

    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static partial class PersonExtensionMethods
    {
        /// <summary>
        /// Clones this Person object to a new Person object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static Person Clone( this Person source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as Person;
            }
            else
            {
                var target = new Person();
                target.IsSystem = source.IsSystem;
                target.RecordTypeValueId = source.RecordTypeValueId;
                target.RecordStatusValueId = source.RecordStatusValueId;
                target.RecordStatusReasonValueId = source.RecordStatusReasonValueId;
                target.PersonStatusValueId = source.PersonStatusValueId;
                target.IsDeceased = source.IsDeceased;
                target.TitleValueId = source.TitleValueId;
                target.GivenName = source.GivenName;
                target.NickName = source.NickName;
                target.MiddleName = source.MiddleName;
                target.LastName = source.LastName;
                target.SuffixValueId = source.SuffixValueId;
                target.PhotoId = source.PhotoId;
                target.BirthDay = source.BirthDay;
                target.BirthMonth = source.BirthMonth;
                target.BirthYear = source.BirthYear;
                target.Gender = source.Gender;
                target.MaritalStatusValueId = source.MaritalStatusValueId;
                target.AnniversaryDate = source.AnniversaryDate;
                target.GraduationDate = source.GraduationDate;
                target.GivingGroupId = source.GivingGroupId;
                target.Email = source.Email;
                target.IsEmailActive = source.IsEmailActive;
                target.EmailNote = source.EmailNote;
                target.DoNotEmail = source.DoNotEmail;
                target.SystemNote = source.SystemNote;
                target.ViewedCount = source.ViewedCount;
                target.Id = source.Id;
                target.Guid = source.Guid;

            
                return target;
            }
        }
    }
}

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
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Rock.Data;

namespace Rock.Model
{
    /// <summary>
    /// Service/Data access class for <see cref="Rock.Model.Reminder"/> entity objects.
    /// </summary>
    public partial class ReminderService
    {
        /// <summary>
        /// Recalculate the reminder count for a person.
        /// </summary>
        /// <param name="personId">The person identifier.</param>
        /// <returns>The updated reminder count.</returns>
        public int RecalculateReminderCount( int personId )
        {
            var rockContext = this.Context as RockContext;
            var person = new PersonService( rockContext ).Get( personId );
            var currentReminderCount = person.ReminderCount ?? 0;
            int updatedReminderCount = GetByPerson( person.Id )
                .ToList()
                .Where( r => r.IsActive )
                .Count();

            if ( updatedReminderCount != currentReminderCount )
            {
                person.ReminderCount = updatedReminderCount;
                rockContext.SaveChanges();
            }

            return updatedReminderCount;
        }

        /// <summary>
        /// Gets the appropriate set of reminders for the provided input (must have a person identifier, at minimum).
        /// </summary>
        /// <param name="personId">The person identifier.</param>
        /// <param name="entityTypeId">The entity type identifier.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="reminderTypeId">The entity type identifier.</param>
        /// <returns></returns>
        public IQueryable<Reminder> GetReminders( int personId, int? entityTypeId, int? entityId, int? reminderTypeId )
        {
            if ( entityTypeId.HasValue )
            {
                if ( entityId.HasValue )
                {
                    if ( reminderTypeId.HasValue )
                    {
                        return GetByReminderTypeEntityAndPerson( reminderTypeId.Value, entityTypeId.Value, entityId.Value, personId );
                    }

                    return GetByEntityAndPerson( entityTypeId.Value, entityId.Value, personId );

                }
                else if ( reminderTypeId.HasValue )
                {
                    return GetByReminderTypeEntityTypeAndPerson( reminderTypeId.Value, entityTypeId.Value, personId );
                }

                return GetByEntityTypeAndPerson( entityTypeId.Value, personId );
            }
            else if ( reminderTypeId.HasValue )
            {
                return GetByReminderTypeAndPerson( reminderTypeId.Value, personId );
            }

            return GetByPerson( personId );
        }

        /// <summary>
        /// Gets reminders by person.
        /// </summary>
        /// <param name="personId">The person identifier.</param>
        /// <returns></returns>
        public IQueryable<Reminder> GetByPerson( int personId )
        {
            return this.Queryable()
                .Where( r => r.PersonAlias.PersonId == personId );
        }

        /// <summary>
        /// Gets reminders by entity type and person.
        /// </summary>
        /// <param name="entityTypeId">The entity type identifier.</param>
        /// <param name="personId">The person identifier.</param>
        /// <returns></returns>
        public IQueryable<Reminder> GetByEntityTypeAndPerson( int entityTypeId, int personId )
        {
            return this.Queryable()
                .Where( r => r.ReminderType.EntityTypeId == entityTypeId
                    && r.PersonAlias.PersonId == personId );
        }

        /// <summary>
        /// Gets reminders by entity and person.
        /// </summary>
        /// <param name="entityTypeId">The entity type identifier.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="personId">The person identifier.</param>
        /// <returns></returns>
        public IQueryable<Reminder> GetByEntityAndPerson( int entityTypeId, int entityId, int personId )
        {
            return this.Queryable()
                .Where( r => r.ReminderType.EntityTypeId == entityTypeId
                    && r.PersonAlias.PersonId == personId
                    && r.EntityId == entityId );
        }

        /// <summary>
        /// Gets reminders by reminder type and person.
        /// </summary>
        /// <param name="reminderTypeId">The entity type identifier.</param>
        /// <param name="personId">The person identifier.</param>
        /// <returns></returns>
        public IQueryable<Reminder> GetByReminderTypeAndPerson( int reminderTypeId, int personId )
        {
            return this.Queryable()
                .Where( r => r.ReminderTypeId == reminderTypeId
                    && r.PersonAlias.PersonId == personId );
        }

        /// <summary>
        /// Gets reminders by reminder type, entity type and person.
        /// </summary>
        /// <param name="reminderTypeId">The entity type identifier.</param>
        /// <param name="entityTypeId">The entity type identifier.</param>
        /// <param name="personId">The person identifier.</param>
        /// <returns></returns>
        public IQueryable<Reminder> GetByReminderTypeEntityTypeAndPerson( int reminderTypeId, int entityTypeId, int personId )
        {
            return this.Queryable()
                .Where( r => r.ReminderType.EntityTypeId == entityTypeId
                    && r.ReminderTypeId == reminderTypeId
                    && r.PersonAlias.PersonId == personId );
        }

        /// <summary>
        /// Gets reminders by reminder type, entity and person.
        /// </summary>
        /// <param name="reminderTypeId">The entity type identifier.</param>
        /// <param name="entityTypeId">The entity type identifier.</param>
        /// <param name="entityId">The entity identifier.</param>
        /// <param name="personId">The person identifier.</param>
        /// <returns></returns>
        public IQueryable<Reminder> GetByReminderTypeEntityAndPerson( int reminderTypeId, int entityTypeId, int entityId, int personId )
        {
            return this.Queryable()
                .Where( r => r.ReminderType.EntityTypeId == entityTypeId
                    && r.ReminderTypeId == reminderTypeId
                    && r.PersonAlias.PersonId == personId
                    && r.EntityId == entityId );
        }

        /// <summary>
        /// Gets entity types associated with reminders by person.
        /// </summary>
        /// <param name="personId">The person identifier.</param>
        /// <returns></returns>
        public IQueryable<EntityType> GetReminderEntityTypesByPerson( int personId )
        {
            var entityTypeIds = GetByPerson( personId ).Select( r => r.ReminderType.EntityTypeId ).Distinct();
            var entityTypes = new EntityTypeService( this.Context as RockContext ).Queryable()
                .Where( t => entityTypeIds.Contains( t.Id ) );
            return entityTypes;
        }

        /// <summary>
        /// Gets active reminders based on the current date.
        /// </summary>
        /// <param name="currentDate">The current date (e.g., RockDateTime.Now).</param>
        /// <param name="includedReminderTypeIds">The included reminder type ids.</param>
        /// <param name="excludedReminderTypeIds">The excluded reminder type ids.</param>
        /// <returns>IQueryable&lt;Reminder&gt;.</returns>
        public IQueryable<Reminder> GetActiveReminders( DateTime currentDate, List<int> includedReminderTypeIds = null, List<int> excludedReminderTypeIds = null )
        {
            includedReminderTypeIds = includedReminderTypeIds ?? new List<int>();
            excludedReminderTypeIds = excludedReminderTypeIds ?? new List<int>();

            var activeReminders = this
                .Queryable()                                // Get reminders that:
                .Where( r => r.ReminderType.IsActive        //   have active reminder types;
                        && !r.IsComplete                    //   are not complete; and
                        && r.ReminderDate <= currentDate )  //   are active (i.e., reminder date has passed).
                .Include( r => r.ReminderType )             // Make sure to include the ReminderType
                .Include( r => r.PersonAlias.Person );      // and Person.

            if ( includedReminderTypeIds.Any() )
            {
                activeReminders = activeReminders.Where( r => includedReminderTypeIds.Contains( r.ReminderTypeId ) );
            }
            else if ( excludedReminderTypeIds.Any() )
            {
                activeReminders = activeReminders.Where( r => !excludedReminderTypeIds.Contains( r.ReminderTypeId ) );
            }

            return activeReminders;
        }

        /// <summary>
        /// Gets reminder types by person.
        /// </summary>
        /// <param name="entityTypeId">The optional entity type identifier.</param>
        /// <param name="person">The person.</param>
        /// <returns></returns>
        public List<ReminderType> GetReminderTypesByPerson( int? entityTypeId, Person person )
        {
            var reminderTypeService = new ReminderTypeService( this.Context as RockContext );

            var reminderTypesQuery = reminderTypeService.Queryable().Where( t => t.IsActive );
            if ( entityTypeId.HasValue )
            {
                reminderTypesQuery = reminderTypesQuery.Where( t => t.EntityTypeId == entityTypeId );
            }

            var authorizedReminderTypes = reminderTypesQuery
                .ToList() // Execute EF query so LINQ can use IsAuthorized().
                .Where( t => t.IsAuthorized( Rock.Security.Authorization.VIEW, person ) )
                .ToList();

            return authorizedReminderTypes;
        }

        /// <summary>
        /// Gets the reminder entities in a dictionary indexed by the Reminder Id./>.
        /// </summary>
        /// <param name="reminders">The reminders.</param>
        /// <returns>Dictionary&lt;System.Int32, IEntity&gt;.</returns>
        public Dictionary<int, IEntity> GetReminderEntities( IQueryable<Reminder> reminders )
        {
            var rockContext = this.Context as RockContext;
            var reminderEntities = new Dictionary<int, IEntity>();

            var entityTypes = reminders.Select( r => r.ReminderType.EntityType ).Distinct().ToList();
            foreach ( var entityType in entityTypes )
            {
                var systemType = Rock.Web.Cache.EntityTypeCache.Get( entityType ).GetEntityType();
                var serviceInstance = Reflection.GetServiceForEntityType( systemType, rockContext );
                var remindersByEntity = reminders.Where( r => r.ReminderType.EntityTypeId == entityType.Id );
                var reminderEntityIds = remindersByEntity.Select( r => r.EntityId );

                MethodInfo qryMethod = serviceInstance.GetType().GetMethod( "Queryable", new Type[] { } );
                var entityQry = qryMethod.Invoke( serviceInstance, new object[] { } ) as IQueryable<IEntity>;
                entityQry = entityQry.Where( e => reminderEntityIds.Contains( e.Id ) );

                var joinedQuery = remindersByEntity.Join(
                    entityQry,
                    r => r.EntityId,
                    e => e.Id,
                    ( r, e ) => new { ReminderId = r.Id, Entity = e } );

                var dictionaryForEntityType = joinedQuery.ToDictionary( a => a.ReminderId, a => a.Entity );
                foreach ( var reminderId in dictionaryForEntityType.Keys )
                {
                    reminderEntities.Add( reminderId, dictionaryForEntityType[reminderId] );
                }
            }

            return reminderEntities;
        }

    }
}

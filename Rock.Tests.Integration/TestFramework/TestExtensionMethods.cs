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
using Rock.Data;

namespace Rock.Tests.Integration
{
    public static class TestExtensionMethods
    {
        /// <summary>
        /// Get an Entity from a collection by matching the specified identifier, either an ID, a Guid value or a Name.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public static T GetByIdentifier<T>( this IQueryable<T> entities, object identifier )
        where T : IEntity
        {
            T result = default( T );

            if ( identifier == null )
            {
                return result;
            }

            var key = identifier.ToStringSafe();

            var id = key.AsIntegerOrNull();
            if ( id.HasValue )
            {
                DebugHelper.SQLLoggingStart();
                result = entities.FirstOrDefault( e => e.Id == id.Value );
                DebugHelper.SQLLoggingStop();
                return result;
            }

            var guid = key.AsGuidOrNull();
            if ( guid.HasValue )
            {
                // Construct a predicate expression for a match with the Guid field, and return the first match.
                var parameter = Expression.Parameter( typeof( T ), "entity" );
                var expEquals = Expression.Equal( Expression.Property( parameter, "Guid" ), Expression.Constant( guid.Value, typeof( Guid ) ) );
                var expLambda = Expression.Lambda<Func<T, bool>>( expEquals, parameter );

                result = entities.FirstOrDefault( expLambda );
                return result;
            }

            result = GetByName( entities, key );

            return result;
        }

        /// <inheritdoc cref="TestExtensionMethods.GetByIdentifier{T}(IQueryable{T}, object)" />
        public static T GetByIdentifier<T>( this IEnumerable<T> entities, object identifier )
            where T : IEntity
        {
            return GetByIdentifier( entities.AsQueryable(), identifier );
        }

        /// <inheritdoc cref="TestExtensionMethods.GetByIdentifier{T}(IQueryable{T}, object)" />
        public static T GetByIdentifierOrThrow<T>( this IQueryable<T> entities, object identifier )
            where T : IEntity
        {
            var result = GetByIdentifier( entities, identifier );
            if ( result == null )
            {
                throw new Exception( $"Invalid Entity Reference. [EntityType={typeof( T ).Name}, Identifier={identifier}]" );
            }

            return result;
        }

        /// <inheritdoc cref="TestExtensionMethods.GetByIdentifier{T}(IQueryable{T}, object)" />
        public static T GetByIdentifierOrThrow<T>( this IEnumerable<T> entities, object identifier )
            where T : IEntity
        {
            return GetByIdentifierOrThrow( entities.AsQueryable(), identifier );
        }

        /// <summary>
        /// Get an Entity from a collection by matching a value in the Name property, if it exists.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entities"></param>
        /// <param name="name"></param>
        /// <param name="nameProperty"></param>
        /// <returns></returns>
        public static T GetByName<T>( this IQueryable<T> entities, object name, string nameProperty = "Name" )
        where T : IEntity
        {
            T result = default( T );

            if ( name == null )
            {
                return result;
            }

            // If the name field does not exist, return the default value.
            var entityType = typeof( T );
            if ( entityType.GetProperty( nameProperty ) == null )
            {
                return result;
            }

            // Construct a predicate expression for a match with the specified name field, and return the first match.
            var parameter = Expression.Parameter( entityType, "entity" );
            var expEquals = Expression.Equal( Expression.Property( parameter, nameProperty ), Expression.Constant( name.ToStringSafe() ) );
            var expLambda = Expression.Lambda<Func<T, bool>>( expEquals, parameter );

            result = entities.FirstOrDefault( expLambda );
            return result;
        }
    }
}

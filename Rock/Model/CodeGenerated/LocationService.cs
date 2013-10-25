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
    /// Location Service class
    /// </summary>
    public partial class LocationService : Service<Location>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationService"/> class
        /// </summary>
        public LocationService()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationService"/> class
        /// </summary>
        /// <param name="repository">The repository.</param>
        public LocationService(IRepository<Location> repository) : base(repository)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationService"/> class
        /// </summary>
        /// <param name="context">The context.</param>
        public LocationService(RockContext context) : base(context)
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
        public bool CanDelete( Location item, out string errorMessage )
        {
            errorMessage = string.Empty;
 
            if ( new Service<Campus>().Queryable().Any( a => a.LocationId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Location.FriendlyTypeName, Campus.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<Device>().Queryable().Any( a => a.LocationId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Location.FriendlyTypeName, Device.FriendlyTypeName );
                return false;
            }  
 
            if ( new Service<Location>().Queryable().Any( a => a.ParentLocationId == item.Id ) )
            {
                errorMessage = string.Format( "This {0} is assigned to a {1}.", Location.FriendlyTypeName, Location.FriendlyTypeName );
                return false;
            }  
            return true;
        }
    }

    /// <summary>
    /// Generated Extension Methods
    /// </summary>
    public static partial class LocationExtensionMethods
    {
        /// <summary>
        /// Clones this Location object to a new Location object
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="deepCopy">if set to <c>true</c> a deep copy is made. If false, only the basic entity properties are copied.</param>
        /// <returns></returns>
        public static Location Clone( this Location source, bool deepCopy )
        {
            if (deepCopy)
            {
                return source.Clone() as Location;
            }
            else
            {
                var target = new Location();
                target.CopyPropertiesFrom( source );
                return target;
            }
        }

        /// <summary>
        /// Copies the properties from another Location object to this Location object
        /// </summary>
        /// <param name="target">The target.</param>
        /// <param name="source">The source.</param>
        public static void CopyPropertiesFrom( this Location target, Location source )
        {
            target.ParentLocationId = source.ParentLocationId;
            target.Name = source.Name;
            target.IsActive = source.IsActive;
            target.GeoPoint = source.GeoPoint;
            target.GeoFence = source.GeoFence;
            target.LocationTypeValueId = source.LocationTypeValueId;
            target.IsLocation = source.IsLocation;
            target.Street1 = source.Street1;
            target.Street2 = source.Street2;
            target.City = source.City;
            target.State = source.State;
            target.Country = source.Country;
            target.Zip = source.Zip;
            target.FullAddress = source.FullAddress;
            target.AssessorParcelId = source.AssessorParcelId;
            target.StandardizeAttemptedDateTime = source.StandardizeAttemptedDateTime;
            target.StandardizeAttemptedServiceType = source.StandardizeAttemptedServiceType;
            target.StandardizeAttemptedResult = source.StandardizeAttemptedResult;
            target.StandardizedDateTime = source.StandardizedDateTime;
            target.GeocodeAttemptedDateTime = source.GeocodeAttemptedDateTime;
            target.GeocodeAttemptedServiceType = source.GeocodeAttemptedServiceType;
            target.GeocodeAttemptedResult = source.GeocodeAttemptedResult;
            target.GeocodedDateTime = source.GeocodedDateTime;
            target.PrinterDeviceId = source.PrinterDeviceId;
            target.Id = source.Id;
            target.Guid = source.Guid;

        }
    }
}

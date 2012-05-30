using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web.Models;

namespace web.Views.DataContracts.Assemblers
{
    public class LocationAssembler
    {
        public static LocationData Assemble(Location location)
        {
            return new LocationData
            {
                ID = location.ID,
                Latitude = location.Latitude,
                Longitude = location.Longitud,
                Name = location.Name
            };
        }

        public static IEnumerable<LocationData> Assemble(IQueryable<Location> locations)
        {
            return locations.Select(l => LocationAssembler.Assemble(l));
        }
    }
}
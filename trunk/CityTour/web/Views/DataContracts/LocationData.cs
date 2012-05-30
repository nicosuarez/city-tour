using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace web.Views.DataContracts
{
    [DataContract]
    public class LocationData
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "long")]
        public decimal Longitude { get; set; }

        [DataMember(Name = "lat")]
        public decimal Latitude { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

    }
}
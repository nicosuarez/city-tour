using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace web.Views.DataContracts
{
    [DataContract]
    public class CommerceData
    {
        [DataMember(Name="name")]
        public string Name { get; set; }

        [DataMember(Name = "address")]
        public string Address { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "location")]
        public LocationData Location { get; set; }
    }
}
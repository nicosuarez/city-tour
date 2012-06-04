using System.Runtime.Serialization;

namespace web.Views.DataContracts
{
    [DataContract]
    public class ReservationData
    {
        [DataMember(Name = "id")]
        public int ID { get; set; }

        [DataMember(Name = "accepted")]
        public bool Accepted { get; set; }
    }
}
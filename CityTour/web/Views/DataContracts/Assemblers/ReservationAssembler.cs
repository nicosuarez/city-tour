using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web.Models;

namespace web.Views.DataContracts.Assemblers
{
    public class ReservationAssembler
    {
        public static ReservationData Assemble(Reservation reservation)
        {
            return new ReservationData
            {
                ID = reservation.ID,
                Accepted = reservation.Accepted
            };
        }
    }
}
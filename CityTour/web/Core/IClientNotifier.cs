using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using web.Models;

namespace web.Core
{
    public interface IClientNotifier
    {
        void NotifyReservationConfirmed(Reservation reservation);
    }
}
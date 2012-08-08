using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using web.Models;

namespace web.Areas.Mobile.Controllers
{
    public class ReservationsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            List<Reservation> reservations = null;

            using (CityTourEntities entities = new CityTourEntities())
            {
                reservations = entities.Reservation.Include(@"BookingCommerce.Commerce").Where(r => r.PersonID == CityTourContext.CurrentPerson.ID).ToList();
            }

            return View(reservations);
        }
    }
}

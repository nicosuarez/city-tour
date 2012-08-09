using System;
using System.Linq;
using System.Web.Mvc;
using web.Models;

namespace web.Areas.Api.Controllers
{
    public class ReservationsController : Controller
    {
        private static int Patente = 678;

        [HttpPost]
        public JsonResult Taxi(string address)
        {
            string patente = String.Concat(@"CFK", Patente);

            using (CityTourEntities entities = new CityTourEntities())
            {
                try
                {
                    Reservation reservation = new Reservation()
                    {
                        Accepted = false,
                        BookingCommerceID = CityTourContext.TaxiBookingCommerce.ID,
                        PersonID = CityTourContext.CurrentPerson.ID,
                        Detail = String.Format(@"Taxi patente {0}, enviado a {1}", patente, address),
                        Price = 0,
                        ReservationDate = DateTime.Now
                    };

                    entities.Reservation.AddObject(reservation);
                    entities.SaveChanges();
                    Patente++;
                }
                catch
                {
                    // boo :(
                }
            }

            string message = String.Format(@"TAXI PREMIUM patente {0}, arriva en 10 minutos a {1}", patente, address);
            return Json(new { sms = message }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult PagoTaxi(string patent, string amount)
        {
            using (CityTourEntities entities = new CityTourEntities())
            {
                try
                {
                    Reservation reservation = entities.Reservation.FirstOrDefault(r => r.Detail.Contains(patent) && !r.Accepted && r.Price == 0);

                    reservation.Accepted = true;
                    reservation.Price = Convert.ToDecimal(amount);

                    entities.SaveChanges();
                }
                catch
                {
                    // boo :(
                }
            }

            string message = @"Su pago ha sido registrado. Gracias por usar CityTour";
            return Json(new { sms = message }, JsonRequestBehavior.AllowGet);
        }
    }
}

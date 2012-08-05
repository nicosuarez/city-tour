using System;
using System.Web.Mvc;

namespace web.Areas.Api.Controllers
{
    public class ReservationsController : Controller
    {
        [HttpPost]
        public JsonResult Taxi(string address)
        {
            string message = String.Concat(@"TAXI PREMIUM patente CFK 678, arriva en 10 minutos a ", address);
            return Json(new { sms = message }, JsonRequestBehavior.AllowGet);
        }
    }
}

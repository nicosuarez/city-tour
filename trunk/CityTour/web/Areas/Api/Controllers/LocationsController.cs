using System.Linq;
using System.Web.Mvc;
using web.Models;

namespace web.Areas.Api.Controllers
{
    public class LocationsController : Controller
    {
        [HttpGet]
        public JsonResult GetNear(decimal latitude, decimal longitude)
        {
            using (CityTourEntities entities = new CityTourEntities())
            {
                var locationsQuery = from l in entities.Location
                                     let offset = 0.01M // Aprox +-10 cuadras.
                                     let insideLatitude = (latitude - offset) <= l.Latitude && l.Latitude <= (latitude + offset)
                                     let insideLongitude = (longitude - offset) <= l.Longitud && l.Longitud <= (longitude + offset)
                                     where insideLatitude && insideLongitude
                                     select new { name = l.Name, lat = l.Latitude, @long = l.Longitud };

                return Json(locationsQuery.ToList(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}

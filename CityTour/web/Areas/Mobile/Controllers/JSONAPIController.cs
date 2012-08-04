using System.Linq;
using System.Web.Mvc;
using web.Models;

namespace web.Areas.Mobile.Controllers
{
    public class JSONAPIController : Controller
    {
        [HttpGet]
        public JsonResult GetNearLocations(decimal latitude, decimal longitude)
        {
            using (CityTourEntities entities = new CityTourEntities())
            {
                var locationsQuery = from l in entities.Location
                                     let offset = 0.004M
                                     let insideLatitude = (latitude - offset) <= l.Latitude && l.Latitude <= (latitude + offset)
                                     let insideLongitude = (longitude - offset) <= l.Longitud && l.Longitud <= (longitude + offset)
                                     where insideLatitude && insideLongitude
                                     select new { name = l.Name, lat = l.Latitude, @long = l.Longitud };

                return Json(locationsQuery.ToList(), JsonRequestBehavior.AllowGet);
            }
        }
    }
}

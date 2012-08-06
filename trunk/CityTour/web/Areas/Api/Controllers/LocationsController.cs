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
                var query = from c in entities.Commerce
                            let offset = 0.01M // Aprox +-10 cuadras.
                            let insideLatitude = (latitude - offset) <= c.Location.Latitude && c.Location.Latitude <= (latitude + offset)
                            let insideLongitude = (longitude - offset) <= c.Location.Longitud && c.Location.Longitud <= (longitude + offset)
                            where insideLatitude && insideLongitude
                            select new { location = c.Location, id = c.ID };

                var locations = query.ToList().Select(q => new { name = q.location.Name, lat = q.location.Latitude, @long = q.location.Longitud, url = Url.Action(@"Index", @"Commerce", new { area = @"Mobile", id = q.id }) });

                return Json(locations, JsonRequestBehavior.AllowGet);
            }
        }
    }
}

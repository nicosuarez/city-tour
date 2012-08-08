using System.Linq;
using System.Web.Mvc;
using web.Models;

namespace web.Areas.Api.Controllers
{
    public class LocationsController : Controller
    {
        private const decimal LocationOffset = 0.01M; // Aprox +-10 cuadras.

        [HttpGet]
        public JsonResult GetNear(decimal latitude, decimal longitude)
        {
            using (CityTourEntities entities = new CityTourEntities())
            {
                var query = from c in entities.Commerce
                            let insideLatitude = (latitude - LocationOffset) <= c.Location.Latitude && c.Location.Latitude <= (latitude + LocationOffset)
                            let insideLongitude = (longitude - LocationOffset) <= c.Location.Longitud && c.Location.Longitud <= (longitude + LocationOffset)
                            where insideLatitude && insideLongitude
                            select new { location = c.Location, id = c.ID };

                var locations = query.ToList().Select(q => new { name = q.location.Name, lat = q.location.Latitude, @long = q.location.Longitud, url = Url.Action(@"Index", @"Commerce", new { area = @"Mobile", id = q.id }) });

                return Json(locations, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetNearAudioGuides(decimal latitude, decimal longitude)
        {
            using (CityTourEntities entities = new CityTourEntities())
            {
                var query = from c in entities.Commerce
                            from a in entities.AudioGuide
                            let insideLatitude = (latitude - LocationOffset) <= c.Location.Latitude && c.Location.Latitude <= (latitude + LocationOffset)
                            let insideLongitude = (longitude - LocationOffset) <= c.Location.Longitud && c.Location.Longitud <= (longitude + LocationOffset)
                            where a.CommerceID == c.ID && insideLatitude && insideLongitude
                            select new { location = c.Location, audioGuide = a };

                var locations = query.ToList().Select(q => new { name = q.audioGuide.Description, lat = q.location.Latitude, @long = q.location.Longitud, url = Url.Action(@"Play", @"AudioGuides", new { area = @"Mobile", id = q.audioGuide.ID }) });

                return Json(locations, JsonRequestBehavior.AllowGet);
            }
        }
    }
}

using System.Linq;
using System.Web.Mvc;
using web.Models;

namespace web.Areas.Mobile.Controllers
{
    public class CommerceController : Controller
    {
        [HttpGet]
        public ActionResult Index(int id)
        {
            Commerce commerce;

            using (CityTourEntities entities = new CityTourEntities())
            {
                commerce = entities.Commerce.FirstOrDefault(c => c.ID == id);
                commerce.LocationReference.Load();
            }

            return View(commerce);
        }
    }
}

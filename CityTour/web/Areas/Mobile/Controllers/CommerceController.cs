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
            Commerce commerce = null;

            using (CityTourEntities entities = new CityTourEntities())
            {
                commerce = entities.Commerce.Include(@"Location").FirstOrDefault(c => c.ID == id);
            }

            return View(commerce);
        }
    }
}

using System.Web.Mvc;

namespace web.Areas.Mobile.Controllers
{
    public class LocationsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string searchAddress)
        {
            ViewBag.SearchAddress = searchAddress;
            return View();
        }

        [HttpGet]
        public ActionResult Search()
        {
            return View();
        }
    }
}

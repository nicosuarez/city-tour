using System.Web.Mvc;

namespace web.Areas.Mobile.Controllers
{
    public class ItineraryController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}

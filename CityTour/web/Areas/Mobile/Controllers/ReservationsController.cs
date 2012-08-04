using System.Web.Mvc;

namespace web.Areas.Mobile.Controllers
{
    public class ReservationsController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}

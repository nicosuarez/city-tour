﻿using System.Web.Mvc;

namespace web.Areas.Mobile.Controllers
{
    public class MainController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}

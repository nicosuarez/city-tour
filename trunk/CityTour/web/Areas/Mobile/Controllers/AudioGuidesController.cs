﻿using System.Web.Mvc;

namespace web.Areas.Mobile.Controllers
{
    public class AudioGuidesController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
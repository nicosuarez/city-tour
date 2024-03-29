﻿using System.Web.Mvc;
using web.Models;
using System.Linq;
using System;

namespace web.Areas.Mobile.Controllers
{
    public class AudioGuidesController : Controller
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

        [HttpGet]
        public ActionResult Play(int id)
        {
            AudioGuide audioGuide = null;

            using (CityTourEntities entities = new CityTourEntities())
            {
                audioGuide = entities.AudioGuide.Include(@"PersonAudioGuide").FirstOrDefault(a => a.ID == id);
            }

            audioGuide.Link = Url.Content(@"~/content/audioguides/" + audioGuide.Link);

            return View(audioGuide);
        }
    }
}

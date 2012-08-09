using System;
using System.Linq;
using System.Web.Mvc;
using web.Models;

namespace web.Areas.Api.Controllers
{
    public class AudioGuiaController : Controller
    {
        [HttpPost]
        public JsonResult Index(int code)
        {
            using (CityTourEntities entities = new CityTourEntities())
            {
                AudioGuide audioGuide = entities.AudioGuide.FirstOrDefault(a => a.ID == code);

                if (audioGuide != null)
                {
                    entities.AddToPersonAudioGuide(new PersonAudioGuide()
                    {
                        AudioGuideID = audioGuide.ID,
                        BuyDate = DateTime.Now,
                        PersonID = CityTourContext.CurrentPerson.ID
                    });

                    entities.SaveChanges();
                }
            }

            string message = @"Gracias por adquirir la audio guía. En breve recibirá un MMS. Mientras puede escucharla a través de CityTour mobile.";
            return Json(new { sms = message }, JsonRequestBehavior.AllowGet);
        }
    }
}

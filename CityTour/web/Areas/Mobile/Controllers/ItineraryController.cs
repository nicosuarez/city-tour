using System;
using System.Linq;
using System.Web.Mvc;
using web.Models;

namespace web.Areas.Mobile.Controllers
{
    public class ItineraryController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            Tour tour = null;

            using (CityTourEntities entities = new CityTourEntities())
            {
                tour = GetCurrentTour(entities);
            }

            return View(tour);
        }

        [HttpGet]
        public ActionResult AddEvent(int id)
        {
            Event tourEvent = new Event() { EventDate = DateTime.Now };

            using (CityTourEntities entities = new CityTourEntities())
            {
                tourEvent.Commerce = entities.Commerce.Include(@"Location").FirstOrDefault(c => c.ID == id);
            }

            ViewBag.Action = Url.Action(@"AddEvent", "Itinerary", new { id = tourEvent.Commerce.ID });

            return View(@"Options", tourEvent);
        }

        [HttpPost]
        public ActionResult AddEvent(int id, string datetime, string description)
        {
            Event tourEvent = new Event() { EventDate = Convert.ToDateTime(datetime), Description = description, CommerceID = id };

            using (CityTourEntities entities = new CityTourEntities())
            {
                entities.Event.AddObject(tourEvent);

                Tour tour = GetCurrentTour(entities);
                tour.Event.Add(tourEvent);

                entities.SaveChanges();
            }

            return RedirectToAction(@"Index");
        }

        [HttpGet]
        public ActionResult Options(int id)
        {
            Event tourEvent = null;

            using (CityTourEntities entities = new CityTourEntities())
            {
                tourEvent = entities.Event.Include(@"Commerce.Location").FirstOrDefault(e => e.ID == id);
            }

            ViewBag.Action = Url.Action(@"Options", "Itinerary", new { id = tourEvent.ID });

            return View(tourEvent);
        }

        [HttpPost]
        public ActionResult Options(int id, string datetime, string description)
        {
            using (CityTourEntities entities = new CityTourEntities())
            {
                Event tourEvent = entities.Event.FirstOrDefault(e => e.ID == id);

                if (tourEvent != null)
                {
                    tourEvent.EventDate = Convert.ToDateTime(datetime);
                    tourEvent.Description = description;
                    entities.SaveChanges();
                }
            }

            return RedirectToAction(@"Index");
        }

        [HttpPost]
        public ActionResult DeleteEvent(int id)
        {
            using (CityTourEntities entities = new CityTourEntities())
            {
                Event tourEvent = entities.Event.Include(@"Tour").FirstOrDefault(e => e.ID == id);

                if (tourEvent != null)
                {
                    tourEvent.Tour.Clear();

                    entities.Event.DeleteObject(tourEvent);
                    entities.SaveChanges();
                }
            }

            return RedirectToAction(@"Index");
        }

        [NonAction]
        private Tour GetCurrentTour(CityTourEntities entities)
        {
            Tour tour = entities.Tour.Include(@"Event.Commerce.Location").FirstOrDefault(t => t.PersonID == CityTourContext.CurrentPerson.ID);
            return tour;
        }
    }
}

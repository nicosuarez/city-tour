using System;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using web.Core;
using web.Models;
using web.Views.DataContracts;
using web.Views.DataContracts.Assemblers;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IClientNotifier notifier = new MailNotifier();

        public ActionResult Index()
        {
            //CreateDummyEvents();
            //CreateDummyReservations();
            //CreateDummyAudioGuides();
            //CreateDummyTour();

            using (CityTourEntities entities = new CityTourEntities())
            {
                //Person currentUser = GetCurrentUser();

                //ViewData["Events"] = GetTour(currentUser).Event.AsEnumerable().OrderBy(e => e.EventDate).ToList();
                //ViewData["SearchBy"] = new List<SearchBy> {new SearchBy()};
                //ViewData["SearchBy"] = new SearchBy();
                ViewData["ScheduledReservations"] = entities.Reservation.Include(@"BookingCommerce.Commerce").Include(@"Person").OrderBy(r => r.ReservationDate).ToList();
                //ViewData["AudioGuides"] = entities.AudioGuide.ToList();
            }

            return View();
        }

        //private void CreateDummyTour()
        //{
        //    Person currentUser = GetCurrentUser();
        //    Tour tour = entities.Tour.Where(t => t.PersonID == currentUser.ID).FirstOrDefault();
        //    if (tour == null)
        //    {
        //        tour = new Tour
        //        {
        //            Person = currentUser,
        //            Created = DateTime.Now
        //        };
        //        entities.Tour.AddObject(tour);

        //        var allEvents = entities.Event.ToList();

        //        tour.Event.Add(allEvents.Where(e => e.Commerce.Name.Contains("Paseo")).First());
        //        tour.Event.Add(allEvents.Where(e => e.Commerce.Name.Contains("Las Heras")).First());
        //        tour.Event.Add(allEvents.Where(e => e.Commerce.Name.Contains("Sheraton")).First());

        //        entities.SaveChanges();
        //    }
        //}

        //private Person GetCurrentUser()
        //{
        //    return entities.Person.First();
        //    //return CreateDummyPerson("Ruben", "dummy@mail.com");
        //}

        //private Tour GetTour(Person person)
        //{
        //    return entities.Tour.Where(t => t.PersonID == person.ID).FirstOrDefault();
        //}

        //public ActionResult SearchBy()
        //{
        //    return View();
        //}

        //private void CreateDummyEvents()
        //{
        //    const int eventsToCreate = 2;

        //    Commerce commerce1 = CreateDummyCommerce("Fiuba Paseo Colon", CreateDummyLocation("Facultad de Ingeniería de la UBA - Sede Paseo Colon", -34.617617M, -58.368495M));
        //    Commerce commerce2 = CreateDummyCommerce("Fiuba Las Heras", CreateDummyLocation("Facultad de Ingeniería de la UBA - Sede Las Heras", -34.588399M, -58.396277M));
        //    for (int i = 0; i < eventsToCreate; i++)
        //    {
        //        string eventDescription = string.Format("Evento numero {0}", i);
        //        Event myEvent = entities.Event.Where(e => e.Description == eventDescription).FirstOrDefault();
        //        if (myEvent == null)
        //        {
        //            myEvent = new Event
        //            {
        //                EventDate = DateTime.Now.AddDays(i),
        //                Description = eventDescription,
        //                Commerce = (eventsToCreate % (i + 1)) < 1 ? commerce1 : commerce2
        //            };

        //            if (!entities.Event.Any(e => e.Description == myEvent.Description))
        //            {
        //                entities.Event.AddObject(myEvent);
        //            }    
        //        }
        //    }

        //    entities.SaveChanges();                    	        
        //}

        //private Commerce CreateDummyCommerce(string commerceName, Location location)
        //{  
        //    Commerce commerce = entities.Commerce.Where(c => c.Name == commerceName).FirstOrDefault();
        //    if (commerce == null)
        //    {   
        //        commerce = new Commerce
        //        {
        //            Name = commerceName,
        //            Description = "Dummy Commerce",
        //            Address = "Dummy Address"                    
        //        };

        //        Company company = CreateDummyCompany();
        //        commerce.Location = location;
        //        commerce.CompanyID = company.ID;
        //        entities.Commerce.AddObject(commerce);
        //        entities.SaveChanges();

        //        BookingCommerce bookingCommerce = CreateBookingCommerce(commerce);
        //    }               

        //    return commerce;
        //}

        //private BookingCommerce CreateBookingCommerce(Commerce commerce)
        //{
        //    BookingCommerce bookingCommerce = new BookingCommerce { ID = commerce.ID };
        //    entities.BookingCommerce.AddObject(bookingCommerce);
        //    entities.SaveChanges();

        //    return bookingCommerce;
        //}

        //private Location CreateDummyLocation(string name, decimal latitude, decimal longitude)
        //{           
        //    Location location = entities.Location.Where(l => l.Name == name).FirstOrDefault();

        //    if (location == null)
        //    {
        //        location = new Location { Name = name, Latitude = latitude, Longitud = longitude };
        //        entities.Location.AddObject(location);
        //        entities.SaveChanges();
        //    }

        //    return location;            
        //}

        //public JsonResult GetEventLocations()
        //{
        //    var locations = entities.Event.Select(e => e.Commerce.Location).Distinct().ToList();

        //    return new DataContractJsonResult
        //    {
        //        Data = locations.Select(l => LocationAssembler.Assemble(l)).ToList(),
        //        JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //    };
        //}

        //private Company CreateDummyCompany()
        //{
        //    const string companyName = "Dummy Company Name";
        //    Company company = entities.Company.Where(l => l.Name == companyName).FirstOrDefault();
        //    if (company == null)
        //    {
        //        Business business = CreateDummyBusiness();
        //        company = new Company { Name = companyName, CUIT = "123456789", BusinessID = business.ID };
        //        entities.Company.AddObject(company);
        //        entities.SaveChanges();
        //    }

        //    return company;
        //}

        //private Business CreateDummyBusiness()
        //{
        //    const string businessName = "Dummy business Name";
        //    Business business = entities.Business.Where(l => l.Name == businessName).FirstOrDefault();

        //    if (business == null)
        //    {
        //        int id = 0;
        //        business = new Business { ID = ++id, Name = "Cine" };
        //        entities.Business.AddObject(business);
        //        int a=entities.SaveChanges();
        //        entities.Business.AddObject(new Business { ID = ++id, Name = "Bar"});
        //        a = entities.SaveChanges();
        //        entities.Business.AddObject(new Business { ID = ++id, Name = "Restaurant" });
        //        entities.Business.AddObject(new Business { ID = ++id, Name = "Museo" });
        //        entities.Business.AddObject(new Business { ID = ++id, Name = "Teatro" });
        //        entities.SaveChanges();
        //    }
        //    return business;
        //}

        //private Reservation CreateDummyReservation(decimal price, BookingCommerce bookingCommerce, Person person, DateTime reservationDate)
        //{
        //    Reservation reservation = entities.Reservation.Where(
        //        r => r.ReservationDate.Year == reservationDate.Year
        //        && r.ReservationDate.Month == reservationDate.Month
        //        && r.ReservationDate.Day == reservationDate.Day    
        //        && r.PersonID == person.ID
        //        && r.BookingCommerceID == bookingCommerce.ID
        //    ).FirstOrDefault();

        //    if (reservation == null)
        //    {
        //        reservation = new Reservation
        //        {
        //            Price = price,
        //            BookingCommerce = bookingCommerce,
        //            Person = person,
        //            ReservationDate = reservationDate                    
        //        };
        //        entities.Reservation.AddObject(reservation);
        //        entities.SaveChanges();
        //    }            

        //    return reservation;
        //}

        //private void CreateDummyReservations()
        //{    
        //    Location location = CreateDummyLocation("Sheraton Retiro", -34.592802M, -58.372765M);
        //    Commerce commerce = CreateDummyCommerce("Sheraton Retiro", location);

        //    Person booker1 = CreateDummyPerson("Vanesa", "dummy@dummy.com");
        //    Person booker2 = CreateDummyPerson("Ruben", "dummy@dummy.com");
        //    Person booker3 = CreateDummyPerson("Marisol", "dummy@dummy.com");
        //    Person booker4 = CreateDummyPerson("Ariel", "dummy@dummy.com");

        //    DateTime oneDay = new DateTime(2012, 6, 10);
        //    DateTime anotherDay = new DateTime(2012, 10, 3);

        //    CreateDummyReservation(100, commerce.BookingCommerce, booker1, oneDay);
        //    CreateDummyReservation(200, commerce.BookingCommerce, booker2, oneDay);
        //    CreateDummyReservation(300, commerce.BookingCommerce, booker3, anotherDay);
        //    CreateDummyReservation(400, commerce.BookingCommerce, booker4, anotherDay);

        //    entities.SaveChanges();           
        //}

        //private void CreateDummyAudioGuides()
        //{
        //    Commerce commerce = entities.Commerce.Where(c => c.Name.ToUpper().Contains("FIUBA")).FirstOrDefault();
        //    if (commerce != null)
        //    {
        //        AudioGuide ag = entities.AudioGuide.Where(a => a.Description == commerce.Name).FirstOrDefault();
        //        if (ag == null)
        //        {
        //            AudioGuide audioGuide1 = new AudioGuide
        //            {
        //                Commerce = commerce,
        //                Description = commerce.Name,
        //                Link = string.Format("{0}Market/market.html", HttpContext.Request.Url.AbsoluteUri)
        //            };

        //            AudioGuide audioGuide2 = new AudioGuide
        //            {
        //                Commerce = commerce,
        //                Description = commerce.Name,
        //                Link = string.Format("{0}Market/market.html", HttpContext.Request.Url.AbsoluteUri)
        //            };

        //            entities.AudioGuide.AddObject(audioGuide1);
        //            entities.AudioGuide.AddObject(audioGuide1);

        //            entities.SaveChanges();
        //        }		       
        //    }           
        //}

        //private Person CreateDummyPerson(string name, string emailAddress)
        //{
        //    Person person = entities.Person.Where(p => p.Name == name).FirstOrDefault();
        //    if (person == null)
        //    {
        //        person = new Person
        //        {
        //            Name = name,
        //            EmailAddress = emailAddress,
        //            Created = DateTime.Now
        //        };
        //    }

        //    return person;
        //}

        public JsonResult ToggleReservation(int reservationID, string message, string name, string email)
        {
            Reservation reservation = null;

            using (CityTourEntities entities = new CityTourEntities())
            {
                reservation = entities.Reservation.Where(r => r.ID == reservationID).FirstOrDefault();

                if (reservation != null)
                {
                    if (reservation.Accepted)
                    {
                        reservation.Accepted = false;
                        reservation.CancellationDate = DateTime.Now;
                        notifier.NotifyReservationCancelled(reservation, name, email, message);
                    }
                    else
                    {
                        reservation.Accepted = true;
                        reservation.CancellationDate = null;
                        notifier.NotifyReservationConfirmed(reservation, name, email, message);
                    }

                    entities.SaveChanges();
                }
            }

            return new DataContractJsonResult
            {
                Data = ReservationAssembler.Assemble(reservation),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        /// <summary>
        /// Calcula la distancia en metros.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        //private decimal CalculateDistance(Location source, Location target)
        //{
        //    var sourceCoordinate = new GeoCoordinate((double)source.Latitude, (double)source.Longitud);
        //    var targetCoordinate = new GeoCoordinate((double)target.Latitude, (double)target.Longitud);

        //    return (decimal)targetCoordinate.GetDistanceTo(sourceCoordinate);
        //}

        //public JsonResult GetNearLocations(decimal latitude, decimal longitude)
        //{
        //    decimal maxDistance = 1000; //Distancia en metros;
        //    var nearLocations = entities.Location.ToList().Where(l => CalculateDistance(l, new Location { Latitude = latitude, Longitud = longitude }) < maxDistance);

        //    return new DataContractJsonResult
        //    {
        //        Data = nearLocations.Select(l => LocationAssembler.Assemble(l)).ToList(),
        //        JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //    };
        //}
    }
}

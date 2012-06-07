using System.Web.Mvc;
using System.Collections.Generic;
using web.Models;
using System.Linq;
using System;
using web.Views.DataContracts.Assemblers;
using System.Web.Helpers;
using web.Views.DataContracts;
using System.Web.Script.Serialization;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private static CityTourEntities entities = new CityTourEntities();

        public ActionResult Index()
        {
            CreateDummyEvents();
            CreateDummyReservations();
            ViewData["Events"] = entities.Event.AsEnumerable().OrderBy(e => e.EventDate).ToList();
            ViewData["SearchBy"] = new List<SearchBy> {new SearchBy()};
            ViewData["ScheduledReservations"] = entities.Reservation.OrderBy(r => r.ReservationDate).ToList(); 
            return View();          
        }

        public ActionResult SearchBy()
        {
            return View();
        }

        private void CreateDummyEvents()
        {
            const int eventsToCreate = 4;
            
            Commerce commerce1 = CreateDummyCommerce("Fiuba Paseo Colon", CreateDummyLocation("Facultad de Ingeniería de la UBA - Sede Paseo Colon", -34.617617M, -58.368495M));
            Commerce commerce2 = CreateDummyCommerce("Fiuba Las Heras", CreateDummyLocation("Facultad de Ingeniería de la UBA - Sede Las Heras", -34.588399M, -58.396277M));
            //for (int i = 0; i < eventsToCreate; i++)
            //{
            //    string eventDescription = string.Format("Evento numero {0}", i);
            //    Event myEvent = entities.Event.Where(e => e.Description == eventDescription).FirstOrDefault();
            //    if (myEvent == null)
            //    {
            //        myEvent = new Event
            //        {
            //            EventDate = DateTime.Now.AddDays(i),
            //            Description = eventDescription,
            //            Commerce = (eventsToCreate % (i + 1)) < 1 ? commerce1 : commerce2
            //        };

            //        if (!entities.Event.Any(e => e.Description == myEvent.Description))
            //        {
            //            entities.Event.AddObject(myEvent);
            //        }    
            //    }
            //}

            //entities.SaveChanges();                    	        
        }

        private Commerce CreateDummyCommerce(string commerceName, Location location)
        {  
            Commerce commerce = entities.Commerce.Where(c => c.Name == commerceName).FirstOrDefault();
            if (commerce == null)
            {   
                commerce = new Commerce
                {
                    Name = commerceName,
                    Description = "Dummy Commerce",
                    Address = "Dummy Address"                    
                };

                Company company = CreateDummyCompany();
                commerce.Location = location;
                commerce.CompanyID = company.ID;
                entities.Commerce.AddObject(commerce);
                entities.SaveChanges();

                BookingCommerce bookingCommerce = CreateBookingCommerce(commerce);
            }               

            return commerce;
        }

        private BookingCommerce CreateBookingCommerce(Commerce commerce)
        {
            BookingCommerce bookingCommerce = new BookingCommerce { ID = commerce.ID };
            entities.BookingCommerce.AddObject(bookingCommerce);
            entities.SaveChanges();

            return bookingCommerce;
        }

        private Location CreateDummyLocation(string name, decimal latitude, decimal longitude)
        {           
            Location location = entities.Location.Where(l => l.Name == name).FirstOrDefault();

            if (location == null)
            {
                location = new Location { Name = name, Latitude = latitude, Longitud = longitude };
                entities.Location.AddObject(location);
                entities.SaveChanges();
            }

            return location;            
        }

        public JsonResult GetEventLocations() 
        {
            var locations = entities.Event.Select( e => e.Commerce.Location ).Distinct().ToList();
           
            return new DataContractJsonResult{
                Data = locations.Select(l => LocationAssembler.Assemble(l)).ToList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        private Company CreateDummyCompany()
        {
            const string companyName = "Dummy Company Name";
            Company company = entities.Company.Where(l => l.Name == companyName).FirstOrDefault();
            if (company == null)
            {
                Business business = CreateDummyBusiness();
                company = new Company { Name = companyName, CUIT = "123456789", BusinessID = business.ID };
                entities.Company.AddObject(company);
                entities.SaveChanges();
            }

            return company;
        }

        private Business CreateDummyBusiness()
        {
            const string businessName = "Dummy business Name";
            Business business = entities.Business.Where(l => l.Name == businessName).FirstOrDefault();

            if (business == null)
            {
                int id = 0;
                business = new Business { ID = ++id, Name = "Cine" };
                entities.Business.AddObject(business);
                int a=entities.SaveChanges();
                entities.Business.AddObject(new Business { ID = ++id, Name = "Bar"});
                a = entities.SaveChanges();
                entities.Business.AddObject(new Business { ID = ++id, Name = "Restaurant" });
                entities.Business.AddObject(new Business { ID = ++id, Name = "Museo" });
                entities.Business.AddObject(new Business { ID = ++id, Name = "Teatro" });
                entities.SaveChanges();
            }
            return business;
        }

        private Reservation CreateDummyReservation(decimal price, BookingCommerce bookingCommerce, Person person, DateTime reservationDate)
        {
            Reservation reservation = entities.Reservation.Where(
                r => r.ReservationDate.Year == reservationDate.Year
                && r.ReservationDate.Month == reservationDate.Month
                && r.ReservationDate.Day == reservationDate.Day    
                && r.PersonID == person.ID
                && r.BookingCommerceID == bookingCommerce.ID
            ).FirstOrDefault();

            if (reservation == null)
            {
                reservation = new Reservation
                {
                    Price = price,
                    BookingCommerce = bookingCommerce,
                    Person = person,
                    ReservationDate = reservationDate                    
                };
                entities.Reservation.AddObject(reservation);
                entities.SaveChanges();
            }            

            return reservation;
        }

        private void CreateDummyReservations()
        {    
            Location location = CreateDummyLocation("Sheraton Retiro", -34.592802M, -58.372765M);
            Commerce commerce = CreateDummyCommerce("Sheraton Retiro", location);
            
            Person booker1 = CreateDummyPerson("Vanesa");
            Person booker2 = CreateDummyPerson("Ruben");
            Person booker3 = CreateDummyPerson("Marisol");
            Person booker4 = CreateDummyPerson("Ariel");

            DateTime oneDay = new DateTime(2012, 6, 10);
            DateTime anotherDay = new DateTime(2012, 10, 3);

            //CreateDummyReservation(100, commerce.BookingCommerce, booker1, oneDay);
            //CreateDummyReservation(200, commerce.BookingCommerce, booker2, oneDay);
            //CreateDummyReservation(300, commerce.BookingCommerce, booker3, anotherDay);
            //CreateDummyReservation(400, commerce.BookingCommerce, booker4, anotherDay);
           
            entities.SaveChanges();           
        }

        private Person CreateDummyPerson(string name)
        {
            Person person = entities.Person.Where(p => p.Name == name).FirstOrDefault();
            if (person == null)
            {
                person = new Person
                {
                    Name = name,
                    EmailAddress = "dummy@dummy.com",
                    Created = DateTime.Now
                };
            }

            return person;
        }

        public JsonResult ToggleReservation(int reservationID)
        {
            Reservation reservation = entities.Reservation.Where(r => r.ID == reservationID).FirstOrDefault();
            
            if (reservation != null)
            {
                if (reservation.Accepted)
                {
                    reservation.Accepted = false;
                    reservation.CancellationDate = DateTime.Now;
                }
                else
                {
                    reservation.Accepted = true;
                    reservation.CancellationDate = null;
                }

                entities.SaveChanges();
            }

            return new DataContractJsonResult
            {
                Data = ReservationAssembler.Assemble(reservation),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}

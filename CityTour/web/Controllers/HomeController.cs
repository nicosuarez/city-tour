using System.Web.Mvc;
using System.Collections.Generic;
using web.Models;
using System.Linq;
using System;

namespace web.Controllers
{
    public class HomeController : Controller
    {
        private static CityTourEntities entities = new CityTourEntities();

        public ActionResult Index()
        {   
            CreateDummyEvents();
            using (CityTourEntities entities = new CityTourEntities())
            {
                ViewData["Events"] = entities.Event.AsEnumerable().OrderBy(e => e.EventDate).ToList();
                return View();
            }
        }

        private void CreateDummyEvents()
        {
            const int eventsToCreate = 4;
            
            Commerce commerce = CreateDummyCommerce();
            for (int i = 0; i < eventsToCreate; i++)
			{
                string eventDescription = string.Format("Evento numero {0}", i);
                Event myEvent = entities.Event.Where(e => e.Description == eventDescription).FirstOrDefault();
                if (myEvent == null)
                {
                    myEvent = new Event
                    {
                        EventDate = DateTime.Now.AddDays(i),
                        Description = eventDescription,
                        Commerce = commerce
                    };

                    if (!entities.Event.Any(e => e.Description == myEvent.Description))
                    {
                        entities.Event.AddObject(myEvent);
                    }    
                }
			}

            entities.SaveChanges();                    	        
        }

        private Commerce CreateDummyCommerce()
        {    
            const string commerceName = "Dummy Commerce Name";
            Commerce commerce = entities.Commerce.Where(c => c.Name == commerceName).FirstOrDefault();
            if (commerce == null)
            {   
                commerce = new Commerce
                {
                    Name = commerceName,
                    Description = "Dummy Commerce",
                    Address = "Dummy Address"                    
                };

                Location location = CreateDummyLocation();
                Company company = CreateDummyCompany();
                commerce.LocationID = location.ID;
                commerce.CompanyID = company.ID;
                entities.Commerce.AddObject(commerce);
                entities.SaveChanges();

                BookingCommerce bookingCommerce = new BookingCommerce { ID = commerce.ID};
                entities.BookingCommerce.AddObject(bookingCommerce);
                entities.SaveChanges();
            }               

            return commerce;
        }

        private Location CreateDummyLocation()
        {
            const string locationName = "Dummy Location Name";
            Location location = entities.Location.Where(l => l.Name == locationName).FirstOrDefault();

            if (location == null)
            {
                location = new Location { Name = locationName };
                entities.Location.AddObject(location);
                entities.SaveChanges();
            }

            return location;            
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
                business = new Business { Name = businessName };
                entities.Business.AddObject(business);
                entities.SaveChanges();
            }

            return business;
        }
    }
}

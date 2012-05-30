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
            using (CityTourEntities entities = new CityTourEntities())
            {
                ViewData["Events"] = entities.Event.AsEnumerable().OrderBy(e => e.EventDate).ToList();
                return View();
            }
        }

        private void CreateDummyEvents()
        {
            const int eventsToCreate = 4;
            
            Commerce commerce1 = CreateDummyCommerce("Fiuba Paseo Colon", CreateDummyLocation("Facultad de Ingeniería de la UBA - Sede Paseo Colon", -34.617617M, -58.368495M));
            Commerce commerce2 = CreateDummyCommerce("Fiuba Las Heras", CreateDummyLocation("Facultad de Ingeniería de la UBA - Sede Las Heras", -34.588399M, -58.396277M));
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
                        Commerce = (eventsToCreate % (i + 1)) < 1 ? commerce1 : commerce2
                    };

                    if (!entities.Event.Any(e => e.Description == myEvent.Description))
                    {
                        entities.Event.AddObject(myEvent);
                    }    
                }
			}

            entities.SaveChanges();                    	        
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

                BookingCommerce bookingCommerce = new BookingCommerce { ID = commerce.ID};
                entities.BookingCommerce.AddObject(bookingCommerce);
                entities.SaveChanges();
            }               

            return commerce;
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
                business = new Business { Name = businessName };
                entities.Business.AddObject(business);
                entities.SaveChanges();
            }

            return business;
        }
    }
}

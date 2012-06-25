using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;
using web.Views.DataContracts;
using web.Views.DataContracts.Assemblers;

namespace web.Controllers
{
    public class SearchByController : Controller
    {
        //
        // GET: /SearchBy/

        public ActionResult Index()
        {
            
            return View(new SearchBy());
        }

        [HttpPost]
        public ActionResult Index(string comecommerceName, string commerceDescription, string commerceCategoryID)
        {
            SearchBy search = new SearchBy()
                                  {
                                      Name = comecommerceName,
                                      Description = commerceDescription,
                                      BussinesID = commerceCategoryID
                                  };
            search.Search();
            //return RedirectToAction("Index", "SearchBy", search);
            //return PartialView("Index", search);
            return RedirectToAction("Index");
        }

        public JsonResult GetLocations()
        {
            //var locations = search.SearchResult.Select(s=> s.Location).Distinct().ToList();
            var locations = new SearchBy().DataBaseCommerce.Select(s => s.Location).Distinct().ToList();
            return new DataContractJsonResult
            {
                Data = locations.Select(l => LocationAssembler.Assemble(l)).ToList(),
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }
    }
}

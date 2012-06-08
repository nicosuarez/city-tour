using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web.Models;

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

        public ActionResult Search(string comecommerceName, string commerceDescription, string commerceCategoryID)
        {
            SearchBy search = new SearchBy()
                                  {
                                      Name = comecommerceName,
                                      Description = commerceDescription,
                                      BussinesID = commerceCategoryID
                                  };
            search.Search();
            return RedirectToAction("Index", "SearchBy", search);
        }

    }
}

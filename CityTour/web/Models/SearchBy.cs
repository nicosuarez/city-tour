using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class SearchBy
    {
        public String Name { get; set; }

        public String Description { get; set; }

        public String Location { get; set; }

        public String Category { get; set; }

        public List<String> Categories()
        {
            List<String> categories= new List<String>();
            

            return categories;
        }

    }
}
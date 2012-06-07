using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace web.Models
{
    public class SearchBy
    {
        private static CityTourEntities entities = new CityTourEntities();

        public String Name { get; set; }

        public String Description { get; set; }

        //public Location Location { get; set; }

        //public String Category { get; set; }

        //public Company Company { get; set; }

        //public String Direction { get; set; }

        //public Business Business { get; set; }

        public List<Commerce> DataBaseCommerce { get; set; }

        public SearchBy()
        {
            DataBaseCommerce = entities.Commerce.ToList();
            SearchResult = new List<Commerce>();
        }

        public List<Commerce> SearchResult { get; set; }

        static public List<SearchBy> Load()
        {
            List<SearchBy> list= new List<SearchBy>();
            SearchBy search= new SearchBy{ DataBaseCommerce =entities.Commerce.ToList(), SearchResult = new List<Commerce>()};
            list.Add(search);
            return list;

        }


    }
}
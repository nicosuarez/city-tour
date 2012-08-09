using System.Linq;
using web.Models;

namespace web.Areas
{
    public static class CityTourContext
    {
        private static Person _person;
        private static BookingCommerce _taxiBookingCommerce;

        public static Person CurrentPerson
        {
            get { return _person; }
        }

        public static BookingCommerce TaxiBookingCommerce
        {
            get { return _taxiBookingCommerce; }
        }

        public static void Initialize()
        {
            using (CityTourEntities entities = new CityTourEntities())
            {
                _person = entities.Person.FirstOrDefault();
                _taxiBookingCommerce = entities.BookingCommerce.FirstOrDefault(b => b.ID == 17);
            }
        }
    }
}
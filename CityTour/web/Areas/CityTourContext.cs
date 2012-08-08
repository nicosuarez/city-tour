using System.Linq;
using web.Models;

namespace web.Areas
{
    public static class CityTourContext
    {
        private static Person _person;
        private static BookingCommerce _bookingCommerce;

        public static Person CurrentPerson
        {
            get { return _person; }
        }

        public static BookingCommerce CurrentBookingCommerce
        {
            get { return _bookingCommerce; }
        }

        public static void Initialize()
        {
            using (CityTourEntities entities = new CityTourEntities())
            {
                _person = entities.Person.FirstOrDefault();
                _bookingCommerce = entities.BookingCommerce.FirstOrDefault();
            }
        }
    }
}
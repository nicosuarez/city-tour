using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using web.Models;
using web.Core;
using System;

namespace SampleTesting
{   
    [TestClass]
    public class ModelTest
    {
        [TestMethod]
        public void GetAllPersonsMustSucceed()
        {
            CityTourEntities entities = new CityTourEntities();
            IEnumerable<Person> persons = entities.Person;

            Assert.IsTrue(persons.Count() > 0);
        }

        [TestMethod]
        public void MailNotifierMustSendEmail()
        {
            IClientNotifier notifier = new MailNotifier();
            Person person = new Person
            {
                Name = "Fulanito",
                EmailAddress = "FareakyRat@mailinator.com"            
            };

            BookingCommerce bookingCommerce = new BookingCommerce
            {
                Commerce =  new Commerce
                {
                    Name = "Teatro Maipo"
                },
                ContactMail = "commerce@mail.com",
                ContactPhone = "555-6666"
            };



            Reservation reservation = new Reservation
            {
                Accepted = true,
                Person = person,
                BookingCommerce = bookingCommerce,
                Price = 100,
                ReservationDate = DateTime.Now
            };

            notifier.NotifyReservationConfirmed(reservation);
        }
    }
} 

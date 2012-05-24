using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using web.Models;

namespace SampleTesting
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
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
    }
}

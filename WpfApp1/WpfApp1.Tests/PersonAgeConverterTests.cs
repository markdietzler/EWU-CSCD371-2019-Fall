using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace WpfApp1.Tests
{
    [TestClass]
    public class PersonAgeConverterTests
    {
        [TestMethod]
        public void Convert_GetPersonAge()
        {
            var converter = new PersonAgeConverter();

            Person p = new Person("FirstName", "LastName", DateTime.Now.Subtract(TimeSpan.FromDays(21 * 365)));

            int age = (int)converter.Convert(p);

            Assert.AreEqual(21, age);
        }
    }
}

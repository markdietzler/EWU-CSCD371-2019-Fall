using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static Assignment.SampleData;

namespace Assignment.Tests
{
    [TestClass]
    public class SampleDataTests
    {
        [TestMethod]
        public void SelectStateWithChildAddressesTest()
        {
            SampleData data = new SampleData();
            List<(string State, IEnumerable<Address> Addresses)> actual = data.SelectStateWithChildAddresses().ToList();

            IEnumerable<string> lines = File.ReadAllLines("People.csv")
                .Skip(1)
                .Where(item => !string.IsNullOrWhiteSpace(item)).ToList();

            Assert.AreEqual<int>(
                lines.Select(line => line.Split(',')[(int)Column.State])
                .Distinct()
                .Count(),
                actual.Count());

            Assert.AreEqual<int>(
                lines.Count(),
                actual.Sum(item => item.Addresses.Count()));

            Assert.IsTrue(actual.All(item =>
                item.Addresses.All(address =>
                    address.State == item.State)));
        }
    }
}
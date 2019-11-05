using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.IO;

namespace Mailbox.Tests
{
    [TestClass]
    public class DataLoaderTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_DoesntAcceptNullStream()
        {

            DataLoader nullDataLoader = new DataLoader(null);

        }

        [TestMethod]
        public void LoadAndSave_Mailboxes()
        {

            Mailboxes tenByTenMailboxesArray = new Mailboxes(new Mailbox[10, 10]);
            Person testPerson = new Person("Joel", "Kalich");

            while (!tenByTenMailboxesArray.FindValidLocation(testPerson).Equals((-1, -1)))
            {

                (int, int) testMailBoxPositionFromPerson = tenByTenMailboxesArray.FindValidLocation(testPerson);
                tenByTenMailboxesArray.mMailBoxesArray[testMailBoxPositionFromPerson.Item1, testMailBoxPositionFromPerson.Item2] = new Mailbox(new Sizes(), testMailBoxPositionFromPerson, testPerson);

            }

            DataLoader testDataLoader = new DataLoader(File.Open("Mailboxes.json", FileMode.OpenOrCreate, FileAccess.ReadWrite));

            testDataLoader.Save(tenByTenMailboxesArray.mMailBoxesArray);
            Mailbox[,] result = testDataLoader.Load();

            Assert.AreEqual(tenByTenMailboxesArray.mMailBoxesArray.ToString(), result.ToString());
        }
    }
}
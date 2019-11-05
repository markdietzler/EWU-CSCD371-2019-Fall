using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mailbox.Tests
{
    [TestClass]
    public class PersonTests
    {

        [TestMethod]
        public void Person_Comparison_Equal()
        {
            Person player1 = new Person("Inigo", "Montoya");
            Person player2 = new Person("Inigo", "Montoya");
            Person player3 = new Person("Miracle", "Max");

            Assert.IsTrue(player1.Equals(player2));
            Assert.IsTrue(player2.Equals(player1));
            Assert.IsFalse(player1.Equals(player3));
            Assert.IsFalse(player3.Equals(player1));
        }
    }
}
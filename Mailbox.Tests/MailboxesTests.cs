using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Mailbox.Tests
{
    [TestClass]
    public class MailboxesTests
    {
        [TestMethod]
        public void FindValidLocation_NoAdjacentPeopleWithLikeNames()
        {

            Mailboxes threeByThreeMailboxArray = new Mailboxes(new Mailbox[3, 3]);
            Person testPerson = new Person("Joel", "Kalich");
            Mailbox[,] expectedThreeByThreeMailboxArray = new Mailbox[3, 3];
            expectedThreeByThreeMailboxArray[0, 0] = new Mailbox(new Sizes(), (0, 0), testPerson);
            expectedThreeByThreeMailboxArray[2, 2] = new Mailbox(new Sizes(), (0, 0), testPerson);

            while (!threeByThreeMailboxArray.FindValidLocation(testPerson).Equals((-1, -1)))
            {
                (int, int) testMailBoxLocation = threeByThreeMailboxArray.FindValidLocation(testPerson);
                threeByThreeMailboxArray.mMailBoxesArray[testMailBoxLocation.Item1, testMailBoxLocation.Item2] = new Mailbox(new Sizes(), testMailBoxLocation, testPerson);
            }

            Assert.AreEqual(expectedThreeByThreeMailboxArray.ToString(), threeByThreeMailboxArray.mMailBoxesArray.ToString());
        }

        [TestMethod]
        public void FindValidLocation_ReturnsNegativeXAndYIfNotValidLocation()
        {
            Mailboxes zeroByZeroArrayOfMailboxes = new Mailboxes(new Mailbox[0, 0]);

            Assert.AreEqual((-1, -1), zeroByZeroArrayOfMailboxes.FindValidLocation(new Person("test", "test")));
        }

        [TestMethod]
        public void FindValidLocation_TallArraySize()
        {
            Mailboxes oneByTwentyMailboxArray = new Mailboxes(new Mailbox[1, 20]);
            Person testPerson = new Person("Joel", "Kalich");
            Mailbox[,] expected = new Mailbox[1, 20];
            for (int walker = 0; walker < expected.Length; walker += 2)
            {
                expected[0, walker] = new Mailbox(new Sizes(), (0, walker), testPerson);
            }

            while (!oneByTwentyMailboxArray.FindValidLocation(testPerson).Equals((-1, -1)))
            {

                (int, int) temp = oneByTwentyMailboxArray.FindValidLocation(testPerson);
                oneByTwentyMailboxArray.mMailBoxesArray[temp.Item1, temp.Item2] = new Mailbox(new Sizes(), temp, testPerson);
            }

            Assert.AreEqual(expected.ToString(), oneByTwentyMailboxArray.mMailBoxesArray.ToString());
        }

        [TestMethod]
        public void FindValidLocation_LongArraySize()
        {
            Mailboxes twentyByOneMailboxArray = new Mailboxes(new Mailbox[20, 1]);
            Person testPerson = new Person("Joel", "Kalich");
            Mailbox[,] expected = new Mailbox[20, 1];
            for (int walker = 0; walker < expected.Length; walker += 2)
            {

                expected[walker, 0] = new Mailbox(new Sizes(), (walker, 0), testPerson);
            }

            while (!twentyByOneMailboxArray.FindValidLocation(testPerson).Equals((-1, -1)))
            {
                (int, int) temp = twentyByOneMailboxArray.FindValidLocation(testPerson);
                twentyByOneMailboxArray.mMailBoxesArray[temp.Item1, temp.Item2] = new Mailbox(new Sizes(), temp, testPerson);
            }

            Assert.AreEqual(expected.ToString(), twentyByOneMailboxArray.mMailBoxesArray.ToString());
        }

        [TestMethod]
        public void FindValidLocation_OneByOneArraySize()
        {
            Mailboxes oneByOneMailboxArray = new Mailboxes(new Mailbox[1, 1]);
            Person testPerson = new Person("Joel", "Kalich");
            Mailbox[,] expected = new Mailbox[1, 1];
            expected[0, 0] = new Mailbox(new Sizes(), (0, 0), testPerson);

            while (!oneByOneMailboxArray.FindValidLocation(testPerson).Equals((-1, -1)))
            {

                (int, int) temp = oneByOneMailboxArray.FindValidLocation(testPerson);
                oneByOneMailboxArray.mMailBoxesArray[temp.Item1, temp.Item2] = new Mailbox(new Sizes(), temp, testPerson);
            }

            Assert.AreEqual(expected.ToString(), oneByOneMailboxArray.mMailBoxesArray.ToString());
        }

        [TestMethod]
        public void FindValidLocation_OneHundredByOneHundredArraySize()
        {
            Mailboxes bigAssed = new Mailboxes(new Mailbox[100, 100]);
            Person testPerson = new Person("Joel", "Kalich");
            Mailbox[,] expected = new Mailbox[100, 100];

            for (int xWalker = 0; xWalker < expected.GetLength(0); xWalker += 2)
            {
                for (int yWalker = xWalker % 2; yWalker < expected.GetLength(1); yWalker += 2)
                {
                    expected[xWalker, yWalker] = new Mailbox(new Sizes(), (xWalker, yWalker), testPerson);
                }
            }

            while (!bigAssed.FindValidLocation(testPerson).Equals((-1, -1)))
            {

                (int, int) temp = bigAssed.FindValidLocation(testPerson);
                bigAssed.mMailBoxesArray[temp.Item1, temp.Item2] = new Mailbox(new Sizes(), temp, testPerson);
            }

            Assert.AreEqual(expected.ToString(), bigAssed.mMailBoxesArray.ToString());
        }
    }
}
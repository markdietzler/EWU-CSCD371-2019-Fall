using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static Sorter.SortUtility;

namespace Sorter.Tests
{
    [TestClass]
    public class SortUtilityTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtilNullArrayNullDelagateThrowsException()
        {
            //Arrange
            SortUtility testUtil = new SortUtility();

            //Act
            testUtil.SelectionSortUtil(null!, null!);
            //Assert

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SortUtilNullDelagateThrowsException()
        {
            //Arrange
            int[] rawArray = new int[] { 7,2,0 };
            SortUtility testUtil = new SortUtility();

            //Act

            testUtil.SelectionSortUtil(rawArray, null!);

            //Assert
        }

        [TestMethod]
        public void SortUtilkAortAscendingOrderWithAnonymous()
        {
            //Arrange
            int[] rawArray = new int[] {6,0,1,5,2,4};
            int[] sorted = new int[] {0,1,2,4,5,6};
            SortUtility util = new SortUtility();

            //Act
            AnalyzeInts analyze = delegate (int thisOne, int thatOne)
            {
                return thisOne < thatOne;
            };

            rawArray = util.SelectionSortUtil(rawArray, analyze);

            //Assert
            CollectionAssert.AreEqual(rawArray, sorted);
        }

        [TestMethod]
        public void SortUtilSortDescendingLamda()
        {
            //Arrange
            int[] rawArray = new int[] { 9, 66, 32, 84, 101, 57, 42, 1 };
            int[] sorted = new int[] { 101, 84, 66, 57, 42, 32, 9, 1 };
            SortUtility util = new SortUtility();

            //Act

            rawArray = util.SelectionSortUtil(rawArray, ((int thisOne, int thatOne) => thisOne > thatOne));

            //Assert
            CollectionAssert.AreEqual(rawArray, sorted);
        }

        [TestMethod]
        public void SortUtilSortAscendingLabdaStatement()
        {
            //Arrange
            int[] rawArray = new int[] { 19, 1031, 721, 33, 998, 211, 88, 599, 151, 463 };
            int[] sortedAscending = new int[] { 19, 33, 88, 151, 211, 463, 599, 721, 998, 1031 };
            SortUtility util = new SortUtility();

            //Act
            rawArray = util.SelectionSortUtil(rawArray, (thisOne, thatOne) =>
            {
                return thisOne < thatOne;
            });

            //Assert
            CollectionAssert.AreEqual(rawArray, sortedAscending);
        }
    }
}

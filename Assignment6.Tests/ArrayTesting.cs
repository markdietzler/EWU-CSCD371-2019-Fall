using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment6.Tests
{
    [TestClass]
    public class ArrayTesting
    {
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Add_AtOutOfBoundsIndex_ThrowsException(int addMe)
        {
            var _TestArray = new Array<int>
            {
                1,2,3
            };

            _TestArray[4] = 4;
        }        

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Constructor_NegativeSize_ThrowsException()
        {
            var _TestArray = new Array<int>(-1);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Add_AddToFullArray_Throws_Exception(int addMe)
        {
            var _TestArray = new Array<int>(3)
            {
                1,2,3
            };

            _TestArray.Add(4);            
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Add_OneItem_Success(int addMe)
        {
            var _TestArray = new Array<int>
            {
                1,2,3
            };

            _TestArray.Add(4);

            Assert.AreEqual(_TestArray.Count, 4);            
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void ArrayIndex_EqualsValue_Success(int addMe)
        {
            var _TestArray = new Array<int>
            {
                1,2,3
            };

            Assert.AreEqual(_TestArray[2], 3);
        }

        [TestMethod]
        public void ClearArray_Success()
        {
            var _TestArray = new Array<int>
            {
                1,2,3
            };

            _TestArray.Clear();

            Assert.AreEqual(0, _TestArray.Count);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Contains_KnownGoodValue_Success(int item)
        {
            var _TestArray = new Array<int>
            {
                1,2,3
            };

            bool doesArrayContinThese = _TestArray.Contains(item);

            Assert.IsTrue(doesArrayContinThese);
        }

        [TestMethod]
        public void CopyTo_NewArray_Success()
        {
            var _TestArray = new Array<int>
            {
                1,2,3
            };

            var _TargetIntArray = new int[3];

            _TestArray.CopyTo(_TargetIntArray, 0);

            CollectionAssert.AreEqual(_TestArray.ToArray(), _TargetIntArray);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Remove_KnownPresentItem_SuccessViaContains(int removeMe)
        {
            var _TestArray = new Array<int>
            {
                1,2,3
            };

            _TestArray.Remove(removeMe);

            Assert.IsFalse(_TestArray.Contains(removeMe));
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Remove_KnownPresentItem_SuccessViaTrueBoolean(int addMe)
        {
            var _TestArray = new Array<int>
            {
                1,2,3
            };

            bool successfulDelete = _TestArray.Remove(3);

            Assert.IsTrue(successfulDelete);

        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        public void Remove_KnownNotPresentItem_SuccessViaFalseBoolean(int addMe)
        {
            var _TestArray = new Array<int>
            {
                1,2,3
            };

            bool unsuccessfulDelete = _TestArray.Remove(4);

            Assert.IsFalse(unsuccessfulDelete);
        }

    }
}

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment6.Tests
{
    [TestClass]
    public class ArrayTesting
    {
        [TestMethod]        
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void Array_Add_At_OutOfBounds_Index()
        {
            var _TestArray1 = new Array<int>();
            _TestArray1.Add(1);

            _TestArray1[4] = 4;
        }        

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Array_Of_Negative_Size_Throws_Exception()
        {
            var _TestArray3 = new Array<int>(-1);
        }

        [DataTestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Array_Add_To_Full_Array_Throws_Exception(int addMe)
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
        public void Array_Add_Success(int addMe)
        {
            var _TestArray = new Array<int>
            {
                1,2,3
            };

            _TestArray.Add(4);

            Assert.AreEqual(_TestArray.Count, 4);
            Assert.AreEqual(_TestArray[3], 4);
        }

        [TestMethod]
        public void Array_Clear_Array_Success()
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
        public void Array_Contains_Success(int item)
        {
            var _TestArray = new Array<int>
            {
                1,2,3
            };

            bool doesArrayContinThese = _TestArray.Contains(item);

            Assert.IsTrue(doesArrayContinThese);
        }

        [TestMethod]
        public void Array_CopyTo_Success()
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
        public void Array_Remove_Success(int removeMe)
        {
            var _TestArray = new Array<int>
            {
                1,2,3
            };

            _TestArray.Remove(removeMe);

            Assert.IsFalse(_TestArray.Contains(removeMe));
        }

    }
}

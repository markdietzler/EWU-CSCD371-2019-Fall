using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        private ICollection<T> _Collection;        

        public int Count => _Collection.Count();        

        public bool IsReadOnly => _Collection.IsReadOnly; 

        public Array()
        {
            _Collection = new List<T>();
        }

        public Array(int newArraySize)
        {
            //          if int is < 0           false, do this                                   true, do this
            _Collection = newArraySize < 0 ? new List<T>(newArraySize) : throw new ArgumentOutOfRangeException($"{nameof(newArraySize)} cannot be less than zero.");
        }

        public T this[int givenIndex]
        {
            get
            {
                ValidateIndexIsWithinArrayRange(givenIndex); //throws out of bounds exception
                return _Collection.AsEnumerable().ElementAt(givenIndex);
            }
            set
            {
                ValidateIndexIsWithinArrayRange(givenIndex); //throws out of bounds exception
                var temp = _Collection.ToList();
                temp[givenIndex] = value;
                _Collection = temp;
            }
        }        

        public void Add(T addMe)
        {          
                _Collection.Add(addMe);            
        }

        public void Clear()
        {
            _Collection.Clear();            
        }

        public bool Contains(T checkMe) => _Collection.Contains(checkMe);

        public void CopyTo(T[] array, int arrayIndex) => _Collection.CopyTo(array, arrayIndex);

        public IEnumerator<T> GetEnumerator() => _Collection.GetEnumerator();

        public bool Remove(T item) => _Collection.Remove(item);

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        private void ValidateIndexIsWithinArrayRange(int givenIndex)
        {
            if(givenIndex > _Collection.Count || givenIndex < 0)
            {
                throw new IndexOutOfRangeException($"{nameof(givenIndex)} is outside of the array index range!");
            }
        }
    }
}

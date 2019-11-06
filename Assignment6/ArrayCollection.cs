using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class ArrayCollection<T> : ICollection<T>
    {
        private T[] _Items;
        public int Capacity { get; set; }

        public int Count => ((ICollection<T>)_Items).Count;

        public bool IsReadOnly => ((ICollection<T>)_Items).IsReadOnly;

        public ArrayCollection(int width)
        {
            Capacity = width;
            _Items = new T[Capacity];
        }

        public void Add(T item)
        {
            ((ICollection<T>)_Items).Add(item);
        }

        public void Clear()
        {
            ((ICollection<T>)_Items).Clear();
        }

        public bool Contains(T item)
        {
            return ((ICollection<T>)_Items).Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ((ICollection<T>)_Items).CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return ((ICollection<T>)_Items).Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((ICollection<T>)_Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<T>)_Items).GetEnumerator();
        }
    }
}

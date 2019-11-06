using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class Array<T> : ICollection<T>
    {
        public T[] Items { get; set; }
        public int Capacity { get; set; }

        public int Count => ((ICollection<T>)Items).Count;

        public bool IsReadOnly => ((ICollection<T>)Items).IsReadOnly;

        public Array(int width)
        {
            Capacity = width;
            Items = new T[Capacity];
        }

        public void Add(T item)
        {
            ((ICollection<T>)Items).Add(item);
        }

        public void Clear()
        {
            ((ICollection<T>)Items).Clear();
        }

        public bool Contains(T item)
        {
            return ((ICollection<T>)Items).Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ((ICollection<T>)Items).CopyTo(array, arrayIndex);
        }

        public bool Remove(T item)
        {
            return ((ICollection<T>)Items).Remove(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return ((ICollection<T>)Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<T>)Items).GetEnumerator();
        }
    }
}

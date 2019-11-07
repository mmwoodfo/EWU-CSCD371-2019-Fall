using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class ArrayCollection<TCollection> : ICollection<TCollection>
    {
        private TCollection[] _Items;
        public int Capacity { get; set; }

        public int Count => ((ICollection<TCollection>)_Items).Count;

        public bool IsReadOnly => ((ICollection<TCollection>)_Items).IsReadOnly;

        public ArrayCollection(int width)
        {
            Capacity = width;
            _Items = new TCollection[Capacity];
        }

        public void Add(TCollection item)
        {
            ((ICollection<TCollection>)_Items).Add(item);
        }

        public void Clear()
        {
            ((ICollection<TCollection>)_Items).Clear();
        }

        public bool Contains(TCollection item)
        {
            return ((ICollection<TCollection>)_Items).Contains(item);
        }

        public void CopyTo(TCollection[] array, int arrayIndex)
        {
            ((ICollection<TCollection>)_Items).CopyTo(array, arrayIndex);
        }

        public bool Remove(TCollection item)
        {
            return ((ICollection<TCollection>)_Items).Remove(item);
        }

        public IEnumerator<TCollection> GetEnumerator()
        {
            return ((ICollection<TCollection>)_Items).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((ICollection<TCollection>)_Items).GetEnumerator();
        }
    }
}

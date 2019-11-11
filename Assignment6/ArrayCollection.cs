using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class ArrayCollection<TCollection> : ICollection<TCollection>
        where TCollection : ICollection
    {
        private ICollection<TCollection> _Items;

        public int Capacity { get; set; }

        public ArrayCollection(int capacity)
        {
            if(capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            Capacity = capacity;
            _Items = new TCollection[Capacity];
        }

        public ArrayCollection(ICollection<TCollection> collection)
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            if(collection.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(collection));
            }
            
            _Items = collection;
            Capacity = _Items.Count;
        }

        public int Count => ((ICollection<TCollection>)_Items).Count;

        public bool IsReadOnly => ((ICollection<TCollection>)_Items).IsReadOnly;

        public void Add(TCollection item)
        {
            if(item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

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

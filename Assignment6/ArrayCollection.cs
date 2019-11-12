using System;
using System.Collections;
using System.Collections.Generic;

namespace Assignment6
{
    public class ArrayCollection<TCollection> : ICollection<TCollection>
    {
        private ICollection<TCollection> _Items;

        public int Capacity { get; }

        public ArrayCollection(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }
            Capacity = capacity;
            _Items = new List<TCollection>(Capacity);
        }

        public ArrayCollection(ICollection<TCollection> collection)
        {
            if (collection is null)
            {
                throw new ArgumentNullException(nameof(collection));
            }
            if (collection.Count == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(collection));
            }

            _Items = new List<TCollection>(collection);
            Capacity = _Items.Count;
        }

        public int Count => _Items.Count;

        public bool IsReadOnly => _Items.IsReadOnly;

        public void Add(TCollection item)
        {
            if (item is null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            if (_Items.Count == Capacity)
            {
                throw new ArgumentOutOfRangeException(nameof(item));
            }

            _Items.Add(item);
        }

        public void Clear()
        {
            _Items.Clear();
        }

        public bool Contains(TCollection item)
        {
            return _Items.Contains(item);
        }

        public void CopyTo(TCollection[] array, int arrayIndex)
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array));

            if (arrayIndex > Capacity || arrayIndex < 0 || arrayIndex > array.Length)
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));

            _Items.CopyTo(array, arrayIndex);
        }

        public bool Remove(TCollection item)
        {
            return _Items.Remove(item);
        }

        public IEnumerator<TCollection> GetEnumerator()
        {
            foreach (TCollection item in _Items)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _Items.GetEnumerator();
        }

        /************************************************************************************/
        //----------------------- EXTRA CREDIT ---------------------------------------------//
        /************************************************************************************/
        public static explicit operator ArrayCollection<TCollection>(Array array)
        {
            if (array is null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            ArrayCollection<TCollection> items = new ArrayCollection<TCollection>(array.Length);
            foreach (var obj in array)
            {
                items.Add((TCollection)obj);
            }

            return items;
        }

        public static explicit operator Array(ArrayCollection<TCollection> items)
        {
            if (items is null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            Object[] array = new Object[items.Capacity];

            int i = 0;
            foreach (var item in items)
            {
                array[i++] = item!;
            }

            return array;
        }
    }
}

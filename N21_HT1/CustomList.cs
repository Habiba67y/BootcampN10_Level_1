using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace N21_HT1
{
    public class CustomList<T>
    {
        private T[] _items = new T[2];
        private long _lastIndex = 0;
        public void Add(T item)
        {
            EnsureCapacity();
            _items[_lastIndex++] = item;
        }

        public void AddRange(IEnumerable<T> items)
        {
            //EnsureCapacity((uint)items.Count());
            EnsureCapacity();

            foreach (var item in items)
                Add(item);
        }

        private void EnsureCapacity(uint additionalCapacity = 1)
        {

            if (_lastIndex + additionalCapacity < _items.Length - 1) return;

            var newCapacity = GetNextSize(additionalCapacity);
            var newArray = new T[newCapacity];
            Array.Copy(_items, newArray, _items.Length);
            _items = newArray;
        }

        private int GetNextSize(in uint newItemsSize)
        {
            var newCapacity = _items.Length;
            do
            {
                newCapacity *= 2;
            } while (newCapacity < newItemsSize);

            return newCapacity;
        }
        public bool Contains(T item)
        {
            foreach (var i in _items)
            {
                if (EqualityComparer<T>.Default.Equals(item, i))
                {
                    return true;
                }
            }
            return false;
        }
        public void CopyTo(T[] array)
        {
            Array.Copy(_items, array, _lastIndex);
        }
        public long Length()
        {
            return _lastIndex;
        }
        public int IndexOf(T item)
        {
            var index = 0;
            foreach(var i in _items)
            {
                if (EqualityComparer<T>.Default.Equals(item, i))
                {
                    return index;
                }
                index++;
            }
            return -1;
        }
        public void Insert(int index, T item)
        {
            try
            {
                if (index > Length()-1)
                {
                    throw new IndexOutOfRangeException("Xato index");
                }
                _lastIndex += 1;
                EnsureCapacity();
                var item1 = new T[Length() - index];
                for (int i = 0; i < Length(); i++)
                {
                    if (i == index)
                    {
                        item1[0] = _items[i];
                        _items[i] = item;
                    }
                    if (i > index)
                    {
                        item1[i - index] = _items[i];
                    }
                }
                for (int i = index + 1; i < Length() + 1; i++)
                {
                    _items[i] = item1[i - index - 1];
                }

            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void InsertRange(int index, IEnumerable<T> items)
        {
            //EnsureCapacity((uint)items.Count());
            EnsureCapacity();
            var index1 = 0;
            foreach (var item in items)
            {
                Insert(index, item);
                index++;
            }
        }
        public bool Remove(T item)
        {
            var m = false;
            var index = 0;
            var items = new T[_items.Length];
            var index1 = 0;
            var index2 = 0;
            foreach (var i in _items)
            {
                if (EqualityComparer<T>.Default.Equals(i, item))
                {
                    index2 = IndexOf(item);
                    _items[IndexOf(item)]= default(T);
                    _lastIndex -= 1;
                    m= true;
                }
                if (index > index2)
                {
                    items[index1] = i;
                    index1++;
                }
                index++;
            }
            for(int i=0; i<Length(); i++)
            {
                _items[index2] = items[i];
                index2++;
            }
            return m;
        }
        public bool RemoveAt(int index)
        {
            var m = false;
            var items = new T[_items.Length];
            var index1 = 0;
            for (var i = 0; i< _items.Length; i++)
            {
                if (i==index)
                {
                    _items[index] = default(T);
                    _lastIndex -= 1;
                    m = true;
                }
                if (i > index)
                {
                    items[index1] = _items[i];
                    index1++;
                }
            }
            for (int i = 0; i < Length(); i++)
            {
                _items[index] = items[i];
                index++;
            }
            return m;
        }
        public T[] ToArray()
        {
            var array = new T[Length()];
            for (var i = 0; i < Length(); i++)
            {
                array[i] = _items[i];
            }
            return array;
        }
    }
}

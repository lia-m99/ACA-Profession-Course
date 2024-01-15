using ConditionBasedCollection;
using System.Collections;

namespace CustomContainer
{
    public class ConditionBasedCollection<T> : ICollection<T> where T : notnull, IComparable, IFormattable, IConvertible
    {
        public event Action<T> ElementAdded = Helper<T>.HandleAddElement;
        public event Action<T> ElementRemoved = Helper<T>.HandleRemoveElement;

        private T[] _items;

        public int Count => _items.Length;

        public bool IsReadOnly => false;

        private readonly Func<T, bool> _condition;


        public T[] RowData()
        {
            return _items;
        }

        public ConditionBasedCollection(Func<T, bool> condition)
        {
            _items = new T[0];
            _condition = condition;
        }

        public void Add(T item)
        {
            if (_condition(item)) {
                Array.Resize(ref _items, _items.Length + 1);
                _items[_items.Length - 1] = item;
            }

            ElementAdded?.Invoke(item);
        }

        public void AddRange(IEnumerable<T> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            foreach (var item in items)
            {
                if (_condition(item))
                {
                    Add(item);
                }
            }
        }

        public void Clear()
        {
            _items = new T[0];
        }

        public bool Contains(T item)
        {
            if (_condition(item)) {
                foreach (T elem in _items)
                {
                    if (elem.Equals(item))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            if (arrayIndex < 0 || arrayIndex >= array.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayIndex));
            }

            if (_items.Length > array.Length - arrayIndex)
            {
                throw new ArgumentException("The destination array has insufficient space.");
            }

            Array.Copy(_items, 0, array, arrayIndex, _items.Length);
        }

        public bool Remove(T item)
        {
            int index = Array.IndexOf(_items, item);

            if (index != -1)
            {
                T[] newArray = new T[_items.Length - 1];

                Array.Copy(_items, 0, newArray, 0, index);

                Array.Copy(_items, index + 1, newArray, index, _items.Length - index - 1);

                _items = newArray;

                ElementRemoved?.Invoke(item);
                return true;
            }
            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new ConditionBasedEnumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

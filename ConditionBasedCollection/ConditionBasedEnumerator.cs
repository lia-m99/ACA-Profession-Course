using CustomContainer;
using System.Collections;

namespace ConditionBasedCollection
{
    public class ConditionBasedEnumerator<T> : IEnumerator<T> where T : notnull, IComparable, IFormattable, IConvertible
    {
        private ConditionBasedCollection<T> _collection;

        private int _currentIndex;

        public ConditionBasedEnumerator(ConditionBasedCollection<T> collection)
        {
            _collection = collection;
            _currentIndex = -1;
        }

        public T Current => _collection.RowData()[_currentIndex];

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            _currentIndex++;
            return _currentIndex < _collection.Count;
        }

        public void Reset()
        {
            _currentIndex = -1;
        }
    }
}

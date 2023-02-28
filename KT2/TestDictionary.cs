using System;
using System.Collections;
using System.Collections.Generic;

namespace KT2
{
    public class TestDictionary<T1, T2> : IEnumerable<TestKeyValuePairs<T1, T2>>, IEnumerator<TestKeyValuePairs<T1, T2>>
    {
        private readonly List<TestKeyValuePairs<T1, T2>> _testing = new List<TestKeyValuePairs<T1, T2>>();
        private int _position;
        private bool _disposedValue;

        public TestKeyValuePairs<T1, T2> Current
        {
            get
            {
                try
                {
                    return _testing[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException("Use method Reset");
                }
            }
        }

        object IEnumerator.Current => Current;
        
        public void Add(T1 t1, T2 t2)
        {
            _testing.Add(new TestKeyValuePairs<T1, T2>(t1, t2));
        }

        public void RemoveKey(T1 t1)
        {
            if (Check(t1, out int index) != -1)
            {
                _testing.RemoveAt(index);
            }
        }
        
        public void RemoveValue(T2 t2)
        {
            if (Check(t2, out int index) != -1)
            {
                _testing.RemoveAt(index);
            }
        }

        public TestKeyValuePairs<T1, T2> FindKey(T1 t1)
        {
            if (Check(t1, out int index) != -1)
            {
                return _testing[index];
            }

            throw new ElementNotFoundException();
        }

        public TestKeyValuePairs<T1, T2> FindValue(T2 t2)
        {
            if (Check(t2, out int index) != -1)
            {
                return _testing[index];
            }

            throw new ElementNotFoundException();
        }

        public IEnumerator<TestKeyValuePairs<T1, T2>> GetEnumerator()
        {
            return new TestDictionary<T1, T2>();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue)
            {
                return;
            }
        
            if (disposing)
            {
                // dispose managed state (managed objects).
            }

            _disposedValue = true;
        }

        ~TestDictionary()
        {
            Dispose(disposing: false);
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _testing.Count;
        }

        public void Reset()
        {
            _position = -1;
        }

        private int Check(T1 t1, out int index)
        {
            for (int i = 0; i < _testing.Count; i++)
            {
                if (Equals(_testing[i].Key, t1))
                {
                    return index = i;
                }
            }

            return index = -1;
        }
        
        private int Check(T2 t2, out int index)
        {
            for (int i = 0; i < _testing.Count; i++)
            {
                if (Equals(_testing[i].Value, t2))
                {
                    return index = i;
                }
            }

            return index = -1;
        }
    }
}
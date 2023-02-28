namespace KT2
{
    public class TestKeyValuePairs<T1, T2>
    {
        public TestKeyValuePairs(T1 key, T2 value)
        {
            Key = key;
            Value = value;
        }
        
        public T1 Key { get; }
        public T2 Value { get; }
    }
}
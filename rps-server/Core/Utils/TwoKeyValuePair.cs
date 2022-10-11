namespace rps_server.Core.Utils;

public class TwoKeyValuePair<TKey1, TKey2, TValue>
{
    public TKey1 Key1 { get; }
    public TKey2 Key2 { get; }
    public TValue Value { get; }

    public TwoKeyValuePair(TKey1 key1, TKey2 key2, TValue value)
    {
        Key1 = key1;
        Key2 = key2;
        Value = value;
    }
}
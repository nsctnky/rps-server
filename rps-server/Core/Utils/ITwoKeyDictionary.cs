namespace rps_server.Core.Utils;

public interface ITwoKeyDictionary<TKey1, TKey2, TValue> : IDisposable, IEnumerable<TwoKeyValuePair<TKey1, TKey2, TValue>>
{
    bool TryAdd(TKey1 key1, TKey2 key2, TValue value);
    void RemoveByKey1(TKey1 key2);
    void RemoveByKey2(TKey2 key2);
    void RemoveAt(int index);
    bool TryGetByKey1(TKey1 key1, out TValue? value);
    bool TryGetByKey2(TKey2 key2, out TValue? value);
    int Count { get; }
    TwoKeyValuePair<TKey1, TKey2, TValue> this[int index] { get; }
}
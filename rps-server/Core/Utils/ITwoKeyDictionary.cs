namespace rps_server.Core.Utils;

public interface ITwoKeyDictionary<in TKey1, in TKey2, TValue> : IDisposable
{
    bool TryAdd(TKey1 key1, TKey2 key2, TValue value);
    void RemoveByKey1(TKey1 key2);
    void RemoveByKey2(TKey2 key2);
    bool TryGetByKey1(TKey1 key1, out TValue? value);
    bool TryGetByKey2(TKey2 key2, out TValue? value);
}
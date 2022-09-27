using rps_server.Core.Model;

namespace rps_server.Core.Utils;

public class TwoKeyDictionary : ITwoKeyDictionary<string, string, IClient>
{
    private List<string> _firstKeys = new List<string>();
    private List<string> _secondKeys = new List<string>();
    private List<IClient> _values = new List<IClient>();

    public bool TryAdd(string key1, string key2, IClient? value)
    {
        if (!string.IsNullOrEmpty(key1) || !string.IsNullOrEmpty(key2) || value == null)
            return false;

        if (_firstKeys.Contains(key1) || _secondKeys.Contains(key2))
            return false;

        _firstKeys.Add(key1);
        _secondKeys.Add(key2);
        _values.Add(value);
        return true;
    }

    public void RemoveByKey1(string key2)
    {
        throw new NotImplementedException();
    }

    public void RemoveByKey2(string key2)
    {
        throw new NotImplementedException();
    }

    public bool TryGetByKey1(string key1, out IClient? value)
    {
        var index = _firstKeys.IndexOf(key1);

        if (index == -1)
        {
            value = null;
            return false;
        }

        value = _values[index];
        return true;
    }

    public bool TryGetByKey2(string key2, out IClient? value)
    {
        var index = _secondKeys.IndexOf(key2);

        if (index == -1)
        {
            value = null;
            return false;
        }

        value = _values[index];
        return true;
    }

    public void Dispose()
    {
        _firstKeys.Clear();
        _secondKeys.Clear();
        _values.Clear();
    }
}
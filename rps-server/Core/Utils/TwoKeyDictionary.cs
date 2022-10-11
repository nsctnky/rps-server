using System.Collections;
using rps_server.Core.Model;

namespace rps_server.Core.Utils;

public class TwoKeyDictionary : ITwoKeyDictionary<string, string, IClient>
{
    private List<string> _firstKeys = new List<string>();
    private List<string> _secondKeys = new List<string>();
    private List<IClient> _values = new List<IClient>();

    public TwoKeyValuePair<string, string, IClient> this[int index]
    {
        get
        {
            return new TwoKeyValuePair<string, string, IClient>(_firstKeys[index], _secondKeys[index], _values[index]);
        }
    }
    
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

    public void RemoveAt(int index)
    {
        _firstKeys.RemoveAt(index);
        _secondKeys.RemoveAt(index);
        _values.RemoveAt(index);
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

    public int Count
    {
        get { return _firstKeys.Count; }
    }

    public void Dispose()
    {
        _firstKeys.Clear();
        _secondKeys.Clear();
        _values.Clear();
    }

    public IEnumerator<TwoKeyValuePair<string, string, IClient>> GetEnumerator()
    {
        var list = new List<TwoKeyValuePair<string, string, IClient>>();
        for (int i = 0; i < _firstKeys.Count; i++)
            list.Add(new TwoKeyValuePair<string, string, IClient>(_firstKeys[i], _secondKeys[i], _values[i]));

        return list.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class DefaultDictionary<TKey, TValue> : IDictionary<TKey, TValue>
{
    public DefaultDictionary(TValue defaultValue)
    {
        _defaultValue = defaultValue;
    }

    private readonly TValue _defaultValue;

    private Dictionary<TKey, TValue> _data = new Dictionary<TKey, TValue>();
    public TValue this[TKey key]
    {
        get
        {
            if (_data.ContainsKey(key))
            {
                return _data[key];
            }
            else
            {
                _data.Add(key, _defaultValue);
                return _data[key];
            }
        }
        set
        {
            if (_data.ContainsKey(key))
            {
                _data[key] = value;
            }
            else
            {
                _data.Add(key, value);
            }
        }
    }
    public ICollection<TKey> Keys => _data.Keys;
    public ICollection<TValue> Values => _data.Values;
    public int Count => _data.Count;
    public bool IsReadOnly => false;
    public void Add(TKey key, TValue value) => _data.Add(key, value);
    public void Add(KeyValuePair<TKey, TValue> item) => Add(item.Key, item.Value);
    public void Clear() => _data.Clear();
    public bool Contains(KeyValuePair<TKey, TValue> item) => _data.Contains(item);
    public bool ContainsKey(TKey key) => _data.ContainsKey(key);
    public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => _data.ToArray().CopyTo(array, arrayIndex);
    public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _data.GetEnumerator();
    public bool Remove(TKey key) => _data.Remove(key);
    public bool Remove(KeyValuePair<TKey, TValue> item) => Remove(item);
    public bool TryGetValue(TKey key, out TValue value)
    {
        if (_data.ContainsKey(key))
        {
            value = _data[key];
            return true;
        }
        else
        {
            value = default;
            return false;
        }
    }
    IEnumerator IEnumerable.GetEnumerator() => _data.GetEnumerator();
}
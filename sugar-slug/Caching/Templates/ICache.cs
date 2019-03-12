using System;
using System.Collections.Generic;

namespace SugarSlug.Caching.Templates {
    public interface ICache<Key, Value> where Value : ICacheable {
        ICache<Key, Value> Add(Key key, Value value);
        ICache<Key, Value> AddRange(IDictionary<Key, Value> mappedValues);
        ICache<Key, Value> Remove(Key key);
        ICache<Key, Value> RemoveRange(ICollection<Key> keys);
        ICache<Key, Value> Clear();
        Value Get(Key key);
        ICollection<Value> GetRange(ICollection<Key> keys);
        Boolean ContainsKey(Key key);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DQModEditor.DataModel.Collections
{
    public class ObservableDictionary<TKey, TValue> : IDictionary<TKey, TValue>, INotifyCollectionChanged
    {
        internal ObservableDictionary() : this(new Dictionary<TKey, TValue>()) { }

        internal ObservableDictionary(IDictionary<TKey, TValue> dictionary)
        {
            _dictionary = dictionary;
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public ICollection<TKey> Keys => _dictionary.Keys;

        public ICollection<TValue> Values => _dictionary.Values;

        public int Count => _dictionary.Count;

        public bool IsReadOnly => _dictionary.IsReadOnly;

        public TValue this[TKey key]
        {
            get
            {
                return _dictionary[key];
            }

            set
            {
                if (!_dictionary.ContainsKey(key)) Add(key, value);
                KeyValuePair<TKey, TValue> old = new KeyValuePair<TKey, TValue>(key, this[key]);
                _dictionary[key] = value;
                CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Replace,
                    new KeyValuePair<TKey, TValue>(key, value), old));
            }
        }

        public bool ContainsKey(TKey key) => _dictionary.ContainsKey(key);

        public void Add(KeyValuePair<TKey, TValue> item) => Add(item.Key, item.Value);

        public void Add(TKey key, TValue value)
        {
            _dictionary.Add(key, value);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, 
                new KeyValuePair<TKey, TValue>(key, this[key])));
        }

        public bool Remove(KeyValuePair<TKey, TValue> item) => Remove(item.Key);

        public bool Remove(TKey key)
        {
            if (!_dictionary.ContainsKey(key)) return false;
            KeyValuePair<TKey, TValue> old = new KeyValuePair<TKey, TValue>(key, this[key]);
            _dictionary.Remove(key);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, old));
            return true;
        }

        public bool TryGetValue(TKey key, out TValue value) => _dictionary.TryGetValue(key, out value);

        public void Clear()
        {
            if (Count == 0) return;
            _dictionary.Clear();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public bool Contains(KeyValuePair<TKey, TValue> item) => _dictionary.Contains(item);

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) => _dictionary.CopyTo(array, arrayIndex);

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() => _dictionary.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _dictionary.GetEnumerator();

        private readonly IDictionary<TKey, TValue> _dictionary;
    }
}

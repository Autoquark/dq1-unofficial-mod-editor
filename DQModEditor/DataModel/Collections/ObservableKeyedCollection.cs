using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DQModEditor.DataModel.Collections
{
    /// <summary>
    /// Represents a collection of items that are retrievable by a key which is derived from the item, and which provides 
    /// notifications when items are added or removed.
    /// </summary>
    /// <remarks>This collection is dictionary-based. Client code can override the default IDictionary implementation by passing in
    /// an empty IDictionary instance. Direct manipulation of this instance may cause the ObservableKeyedCollection to behave
    /// incorrectly.</remarks>
    /// <typeparam name="TKey">The type of the key</typeparam>
    /// <typeparam name="TItem">The type of the items in the collection</typeparam>
    public class ObservableKeyedCollection<TKey, TItem> : ICollection<TItem>, IReadOnlyDictionary<TKey, TItem>, 
        INotifyCollectionChanged, INotifyCollectionItemChanged<ObservableKeyedCollection<TKey, TItem>, TItem> 
        where TItem : INotifyPropertyChanged
    {
        /// <summary>
        /// Convenience method. Creates a new ObservableKeyedCollection based on a sorted IDictionary implementation.
        /// </summary>
        /// <param name="keyExtractor"></param>
        /// <returns></returns>
        internal static ObservableKeyedCollection<TKey, TItem> CreateSorted(Func<TItem, TKey> keyExtractor)
        {
            return new ObservableKeyedCollection<TKey, TItem>(keyExtractor, new SortedDictionary<TKey, TItem>());
        }

        internal ObservableKeyedCollection(Func<TItem, TKey> keyExtractor) : this(keyExtractor, new Dictionary<TKey, TItem>()) { }

        internal ObservableKeyedCollection(Func<TItem, TKey> keyExtractor, IDictionary<TKey, TItem> dictionary)
        {
            if (dictionary.Count != 0) throw new ArgumentException("The given dictionary must be empty");
            _dictionary = dictionary;
            KeyExtractor = keyExtractor;
        }

        public Func<TItem, TKey> KeyExtractor { get; }
        public event NotifyCollectionChangedEventHandler CollectionChanged;
        public event CollectionItemChangedHandler<ObservableKeyedCollection<TKey, TItem>, TItem> CollectionItemChanged;

        public int Count => _dictionary.Count;

        public bool IsReadOnly => _dictionary.IsReadOnly;

        public IEnumerable<TKey> Keys => _dictionary.Keys;

        public IEnumerable<TItem> Values => _dictionary.Values;

        public TItem this[TKey key] => _dictionary[key];

        public void Add(TItem item)
        {
            TKey key = KeyExtractor(item);
            if (_dictionary.ContainsKey(key)) return;
            _dictionary.Add(key, item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
            item.PropertyChanged += Item_PropertyChanged;
        }

        public void Clear()
        {
            if (_dictionary.Count == 0) return;
            foreach (TItem item in this) item.PropertyChanged -= Item_PropertyChanged;
            _dictionary.Clear();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public bool Contains(TItem item) => _dictionary.ContainsKey(KeyExtractor(item));

        public void CopyTo(TItem[] array, int arrayIndex) => _dictionary.Values.CopyTo(array, arrayIndex);

        public bool Remove(TItem item)
        {
            TKey key = KeyExtractor(item);
            if (!_dictionary.ContainsKey(key)) return false;
            item.PropertyChanged -= Item_PropertyChanged;
            _dictionary.Remove(key);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));
            return true;
        }

        public IEnumerator<TItem> GetEnumerator() => _dictionary.Values.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _dictionary.Values.GetEnumerator();

        public bool ContainsKey(TKey key) => _dictionary.ContainsKey(key);

        public bool TryGetValue(TKey key, out TItem value) => _dictionary.TryGetValue(key, out value);

        IEnumerator<KeyValuePair<TKey, TItem>> IEnumerable<KeyValuePair<TKey, TItem>>.GetEnumerator() => _dictionary.GetEnumerator();

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            CollectionItemChanged?.Invoke(this, (TItem)sender, e);
        }

        private IDictionary<TKey, TItem> _dictionary;
    }
}

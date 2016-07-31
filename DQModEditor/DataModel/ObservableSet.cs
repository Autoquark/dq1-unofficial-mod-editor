using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DQModEditor.DataModel
{
    public class ObservableSet<T> : ISet<T>, INotifyCollectionChanged
    {
        public ObservableSet(ISet<T> set)
        {
            _set = set;
        }

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public int Count => _set.Count;

        public bool IsReadOnly => _set.IsReadOnly;

        void ICollection<T>.Add(T item) => Add(item);

        public bool Add(T item)
        {
            if (_set.Contains(item)) return false;
            _set.Add(item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));
            return true;
        }

        public void UnionWith(IEnumerable<T> other)
        {
            ISet<T> added = new HashSet<T>(other);
            added.ExceptWith(this);
            _set.UnionWith(other);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, added.ToList()));
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            ISet<T> removed = new HashSet<T>(this);
            removed.ExceptWith(other);
            _set.IntersectWith(other);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove,
                removed.ToList()));
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            ISet<T> removed = new HashSet<T>(this);
            removed.IntersectWith(other);
            _set.ExceptWith(other);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove,
                removed.ToList()));
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            ISet<T> removed = new HashSet<T>(this);
            removed.IntersectWith(other);
            ISet<T> added = new HashSet<T>(other);
            added.ExceptWith(this);
            _set.SymmetricExceptWith(other);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove,
                removed.ToList()));
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, added.ToList()));
        }

        public bool IsSubsetOf(IEnumerable<T> other) => _set.IsSubsetOf(other);

        public bool IsSupersetOf(IEnumerable<T> other) => _set.IsSupersetOf(other);

        public bool IsProperSupersetOf(IEnumerable<T> other) => _set.IsProperSupersetOf(other);

        public bool IsProperSubsetOf(IEnumerable<T> other) => _set.IsProperSubsetOf(other);

        public bool Overlaps(IEnumerable<T> other) => _set.Overlaps(other);

        public bool SetEquals(IEnumerable<T> other) => _set.SetEquals(other);

        public void Clear()
        {
            if (_set.Count == 0) return;
            _set.Clear();
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }

        public bool Contains(T item) => _set.Contains(item);

        public void CopyTo(T[] array, int arrayIndex) => _set.CopyTo(array, arrayIndex);

        public bool Remove(T item)
        {
            if (!_set.Contains(item)) return false;
            _set.Remove(item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, item));
            return true;
        }

        public IEnumerator<T> GetEnumerator() => _set.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => _set.GetEnumerator();

        private readonly ISet<T> _set;
    }
}

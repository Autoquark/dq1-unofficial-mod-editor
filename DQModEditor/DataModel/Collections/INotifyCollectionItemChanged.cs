using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DQModEditor.DataModel.Collections
{
    public delegate void CollectionItemChangedHandler<TCollection, TItem>(TCollection sender, TItem item, PropertyChangedEventArgs args) 
        where TItem : INotifyPropertyChanged;

    public interface INotifyCollectionItemChanged<TCollection, TItem> where TItem : INotifyPropertyChanged
    {
        event CollectionItemChangedHandler<TCollection, TItem> CollectionItemChanged;
    }
}

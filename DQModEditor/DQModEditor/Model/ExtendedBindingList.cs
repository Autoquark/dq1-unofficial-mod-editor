using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DQModEditor.Model
{
    /// <summary>
    /// An extension of BindingList&lt;T&gt; which provides notification when an item is about to be removed, allowing another collection to be kept in sync.
    /// </summary>
    /// <remarks>
    /// Credit: https://stackoverflow.com/questions/23339233/get-deleted-item-in-itemchanging-event-of-bindinglist
    /// </remarks>
    /// <typeparam name="T"></typeparam>
    internal class ExtendedBindingList<T> : BindingList<T>
    {
        public ExtendedBindingList() : base() { }
        public ExtendedBindingList(IList<T> list) : base(list) { }

        protected override void RemoveItem(int itemIndex)
        {
            //itemIndex = index of item which is going to be removed
            //get item from binding list at itemIndex position
            T deletedItem = Items[itemIndex];

            //raise event containing item which is going to be removed
            BeforeRemove?.Invoke(deletedItem);

            //remove item from list
            base.RemoveItem(itemIndex);
        }

        public delegate void BeforeRemoveEventHandler(T deletedItem);
        public event BeforeRemoveEventHandler BeforeRemove;
    }
}

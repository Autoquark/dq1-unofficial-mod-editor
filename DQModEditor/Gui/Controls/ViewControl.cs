using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DQModEditor.Gui.Controls
{
    /// <summary>
    /// Base class for user controls that display an object of a given type T.
    /// </summary>
    /// <remarks>
    /// Should be abstract, but having a user control type inherit directly from an abstract class breaks the forms designer.
    /// </remarks>
    internal class ViewControl<T> : UserControl where T : class
    {
        protected ViewControl()
        {
            Enabled = false;
            ControlAdded += (s, e) =>
            {
                if (e.Control is NumericUpDown) Utility.PreventEmptyText((NumericUpDown)e.Control);
            };
        }

        /// <summary>
        /// Gets or sets the object currently displayed by the ViewControl.
        /// </summary>
        /// <remarks>Setting DisplayedItem to null disables the control (and setting a non-null value reenables it).</remarks>
        public T DisplayedItem
        {
            get { return _DisplayedItem; }
            set
            {
                if (Equals(_DisplayedItem, value)) return;
                T previous = _DisplayedItem;
                _DisplayedItem = value;

                Enabled = !(_DisplayedItem == null);

                DisplayedItemChanged?.Invoke(this, previous);
            }
        }
        private T _DisplayedItem;

        public DisplayContext Context
        {
            get { return _Context; }
            set
            {
                if (_Context == value) return;
                DisplayContext previous = _Context;
                _Context = value;
                ContextChanged?.Invoke(this, previous);
            }
        }
        private DisplayContext _Context;

        /// <summary>
        /// Occurs the value of DisplayedItem changes.
        /// </summary>
        /// <param name="source">The ViewControl from which the event originates</param>
        /// <param name="previous">The previous value of DisplayedItem</param>
        public delegate void DisplayedItemChangedHandler(ViewControl<T> source, T previous);
        public event DisplayedItemChangedHandler DisplayedItemChanged;

        public delegate void ContextChangedHandler(ViewControl<T> source, DisplayContext previous);
        public event ContextChangedHandler ContextChanged;
    }
}

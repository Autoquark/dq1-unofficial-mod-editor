using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DQModEditor.Gui.Controls
{
    /// <summary>
    /// Base class for user controls that display and object of a given type T.
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

        public T DisplayedItem
        {
            get { return _DisplayedItem; }
            set
            {
                if (Equals(_DisplayedItem, value)) return;
                _DisplayedItem = value;

                Enabled = !(_DisplayedItem == null);

                DisplayedItemChanged?.Invoke(this);
            }
        }
        private T _DisplayedItem;

        public delegate void DisplayedItemChangedHandler(ViewControl<T> source);
        public event DisplayedItemChangedHandler DisplayedItemChanged;
    }
}

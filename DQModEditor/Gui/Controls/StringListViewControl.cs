using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DQModEditor.Gui.Controls
{
    internal partial class StringListViewControl : ViewControl<IReadOnlyDictionary<string, string>>
    {
        public StringListViewControl()
        {
            InitializeComponent();

            DisplayedItemChanged += (s, e) => UpdateData();
            
            listBox.ValueMember = nameof(KeyValuePair<string, string>.Key);

            addButton.Click += (s, e) =>
            {
                AddCommand?.Invoke(addTextBox.Text);
                addTextBox.Clear();
            };
            addTextBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) addButton.PerformClick();
            };
            deleteButton.Click += (s, e) =>
            {
                if (listBox.SelectedItem != null) DeleteCommand?.Invoke((string)listBox.SelectedValue);
            };
            clearButton.Click += (s, e) => ClearCommand?.Invoke();
        }

        public delegate void DeleteClickedHandler(string selected);
        public event DeleteClickedHandler DeleteCommand;

        public delegate void ClearClickedHandler();
        public event ClearClickedHandler ClearCommand;

        public delegate void AddClickedHandler(string value);
        public event AddClickedHandler AddCommand;

        /// <summary>
        /// Updates the displayed items from the DisplayedItem.
        /// </summary>
        public void UpdateData()
        {
            (listBox.DataSource as BindingSource)?.Dispose();

            if (DisplayedItem != null && DisplayedItem.Count > 0)
            {
                listBox.DataSource = new BindingSource(DisplayedItem, null);
                // Because setting the DataSource when the dictionary is empty seems to reset DisplayMember to "", we set 
                // DisplayMember on every change.
                listBox.DisplayMember = nameof(KeyValuePair<string, string>.Key);
            } else listBox.DataSource = null;
        }
    }
}

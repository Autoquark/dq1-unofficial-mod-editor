using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DQModEditor.DataModel;
using DQModEditor.DataModel.Collections;

namespace DQModEditor.Gui.Controls
{
    internal partial class StringListViewControl : ViewControl<ObservableSet<string>>
    {
        public StringListViewControl()
        {
            InitializeComponent();

            DisplayedItemChanged += (s, previous) =>
            {
                if (previous != null) previous.CollectionChanged -= (s2, e) => UpdateData();

                UpdateData();
                if(DisplayedItem != null) DisplayedItem.CollectionChanged += (s2, e) => UpdateData();
            };

            addButton.Click += (s, e) =>
            {
                if (addTextBox.Text.Length == 0) return;
                DisplayedItem.Add(addTextBox.Text);
                addTextBox.Clear();
            };
            addTextBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) addButton.PerformClick();
            };
            deleteButton.Click += (s, e) =>
            {
                if (listBox.SelectedItem != null) DisplayedItem.Remove((string)listBox.SelectedItem);
            };
            clearButton.Click += (s, e) => DisplayedItem.Clear();
        }

        /// <summary>
        /// Updates the displayed items from the DisplayedItem.
        /// </summary>
        private void UpdateData()
        {
            (listBox.DataSource as BindingSource)?.Dispose();

            // Because when the collection is empty, the list box seems to call ToString() on the collection instance and display that as an item.
            if (DisplayedItem != null && DisplayedItem.Count != 0) listBox.DataSource = new BindingSource(DisplayedItem, null);
            else listBox.DataSource = null;
        }
    }
}

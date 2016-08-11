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

namespace DQModEditor.Gui.Controls.Enemies.Graphics
{
    internal partial class EffectOffsetsListViewControl : ViewControl<ObservableDictionary<string, Point>>
    {
        public EffectOffsetsListViewControl()
        {
            InitializeComponent();

            listBox.Format += (s, e) =>
            {
                if (e.Value == null) return;
                KeyValuePair<string, Point> item = (KeyValuePair<string, Point>)e.Value;
                e.Value = $"{item.Key}: ({item.Value.X}, {item.Value.Y})";
            };
            listBox.SelectedValueChanged += (s, e) =>
            {
                if (listBox.SelectedValue == null)
                {
                    pointViewControl.Enabled = false;
                    return;
                }
                pointViewControl.Enabled = true;
                pointViewControl.Value = ((KeyValuePair<string, Point>)listBox.SelectedValue).Value;
            };
            pointViewControl.Validated += (s, e) =>
            {
                if (listBox.SelectedItem == null) return;
                KeyValuePair<string, Point> selected = (KeyValuePair<string, Point>)listBox.SelectedItem;
                DisplayedItem[selected.Key] = pointViewControl.Value;
            };
            addButton.Click += (s, e) =>
            {
                if (addTextBox.Text.Length == 0) return;
                DisplayedItem.Add(addTextBox.Text, new Point());
                addTextBox.Clear();
            };
            addTextBox.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter) addButton.PerformClick();
            };
            deleteButton.Click += (s, e) =>
            {
                if (listBox.SelectedItem != null) DisplayedItem.Remove((KeyValuePair<string, Point>)listBox.SelectedItem);
            };
            clearButton.Click += (s, e) => DisplayedItem.Clear();

            DisplayedItemChanged += EffectOffsetsListViewControl_DisplayedItemChanged;
        }

        private void EffectOffsetsListViewControl_DisplayedItemChanged(ViewControl<ObservableDictionary<string, Point>> source, 
            ObservableDictionary<string, Point> previous)
        {
            if (previous != null) previous.CollectionChanged -= (s, e) => UpdateData();

            if (DisplayedItem != null)
            {
                UpdateData();
                DisplayedItem.CollectionChanged += (s, e) => UpdateData();
            }
        }

        private void UpdateData()
        {
            (listBox.DataSource as BindingSource)?.Dispose();

            // Because when the collection is empty, the list box seems to call ToString() on the collection instance and display that as an item.
            if (DisplayedItem != null && DisplayedItem.Count != 0)
            {
                listBox.DataSource = new BindingSource(DisplayedItem, null);
            }
            else listBox.DataSource = null;
        }
    }
}

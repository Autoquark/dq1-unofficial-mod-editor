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

namespace DQModEditor.Gui.Controls.Enemies.Spawns
{
    internal partial class SpawnViewControl : ViewControl<SpawnInfo>
    {
        public SpawnViewControl()
        {
            InitializeComponent();

            Binding binding = new Binding(nameof(spawnIdTextBox.AutoCompleteCustomSource), this, nameof(Context), true);
            binding.DataSourceUpdateMode = DataSourceUpdateMode.Never;
            binding.Format += (s, e) => e.Value = Context?.EnemyIdAutoCompleteCollection;
            spawnIdTextBox.DataBindings.Add(binding);

            DisplayedItemChanged += ChangeDisplayedItem;
        }

        private void ChangeDisplayedItem(ViewControl<SpawnInfo> source, SpawnInfo previous)
        {
            if (DisplayedItem != null)
            {
                locationViewControl.SetBinding(nameof(locationViewControl.Value), DisplayedItem, nameof(DisplayedItem.Location));
                spawnIdTextBox.SetBinding(nameof(spawnIdTextBox.Text), DisplayedItem, nameof(DisplayedItem.SpawnId));
                effectIdTextBox.SetBinding(nameof(effectIdTextBox.Text), DisplayedItem, nameof(DisplayedItem.EffectId));
            }
        }
    }
}

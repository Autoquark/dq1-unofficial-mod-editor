using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DQModEditor.Model;

namespace DQModEditor.Gui.Controls.Enemies.Spawns
{
    internal partial class EnemySpawnViewControl : ViewControl<SpawnInfo>
    {
        public EnemySpawnViewControl()
        {
            InitializeComponent();

            DisplayedItemSetNonNull += ChangeDisplayedItem;
        }

        private void ChangeDisplayedItem(ViewControl<SpawnInfo> source)
        {
            spawnLocationViewControl.DataBindings.Clear();
            spawnLocationViewControl.DataBindings.Add(nameof(spawnLocationViewControl.Value), DisplayedItem, nameof(DisplayedItem.Location));
            spawnIdTextBox.DataBindings.Clear();
            spawnIdTextBox.DataBindings.Add(nameof(spawnIdTextBox.Text), DisplayedItem, nameof(DisplayedItem.SpawnId));
            effectIdTextBox.DataBindings.Clear();
            effectIdTextBox.DataBindings.Add(nameof(effectIdTextBox.Text), DisplayedItem, nameof(DisplayedItem.EffectId));
        }
    }
}

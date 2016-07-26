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
    internal partial class SpawnListViewControl : ViewControl<IList<SpawnInfo>>
    {
        public SpawnListViewControl()
        {
            InitializeComponent();

            spawnsListBox.Format += (sender, args) =>
            {
                SpawnInfo item = (SpawnInfo)args.Value;
                if (item == null) return;
                args.Value = item.SpawnId;
                if (item.SpawnId == "") args.Value = "<no id>";
                args.Value += " " + item.Location;
            };

            spawnsListBox.SelectedValueChanged += (s, e) =>
            {
                //If the user modifiers a property of the selected spawn (e.g. x coordinate) and then moves focus onto another
                //control within the EnemySpawnViewControl, the change to the EnemySpawnViewControl's displayed item causes the
                //control they switched to to lose focus. This appears to fix that, though it feels somewhat hacky.
                Control active = spawnViewControl.ActiveControl;
                spawnViewControl.DisplayedItem = (SpawnInfo)spawnsListBox.SelectedItem;
                active?.Select();
            };

            deleteButton.Click += (s, e) => { DisplayedItem.Remove(spawnViewControl.DisplayedItem); };
            clearButton.Click += (s, e) => { DisplayedItem.Clear(); };
            addButton.Click += AddButton_Click;
            cloneButton.Click += CloneButton_Click;

            DisplayedItemChanged += (s, p) => {
                if (DisplayedItem == null) return;
                spawnsListBox.DataSource = DisplayedItem;
                //Because ListBox.SelectedValueChanged does not seem to fire when we change to displaying an empty list
                spawnViewControl.DisplayedItem = (SpawnInfo)spawnsListBox.SelectedItem;
            };
        }

        private void CloneButton_Click(object sender, EventArgs e)
        {
            SpawnInfo cloned = new SpawnInfo(spawnViewControl.DisplayedItem);
            DisplayedItem.Insert(spawnsListBox.SelectedIndex, cloned);
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            SpawnInfo spawn = new SpawnInfo();
            DisplayedItem.Add(spawn);
            spawnsListBox.SelectedIndex = -1;
            spawnsListBox.SelectedIndex = spawnsListBox.Items.Count - 1;
        }
    }
}

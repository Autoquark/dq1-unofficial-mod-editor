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

namespace DQModEditor.Gui.Enemies
{
    /// <summary>
    /// Control that displays an enemy definition from a mod.
    /// </summary>
    internal partial class EnemyViewControl : ViewControl<Enemy>
    {
        public EnemyViewControl()
        {
            InitializeComponent();

            DisplayedItemSetNonNull += ChangeDisplayedItem;
        }

        private void ChangeDisplayedItem(ViewControl<Enemy> source)
        {
            // Text & Description
            string textPropertyName = nameof(displayNameTextBox.Text);
            internalNameTextBox.DataBindings.Clear();
            internalNameTextBox.DataBindings.Add(textPropertyName, DisplayedItem, nameof(DisplayedItem.InternalName));
            displayNameTextBox.DataBindings.Clear();
            displayNameTextBox.DataBindings.Add(textPropertyName, DisplayedItem, nameof(DisplayedItem.DisplayName));
            flavorNameTextBox.DataBindings.Clear();
            flavorNameTextBox.DataBindings.Add(textPropertyName, DisplayedItem, nameof(DisplayedItem.FlavorName));
            flavorDescriptionTextBox.DataBindings.Clear();
            flavorDescriptionTextBox.DataBindings.Add(textPropertyName, DisplayedItem, nameof(DisplayedItem.FlavorDescription));
            // Stats
            baseStatsViewControl.DisplayedItem = DisplayedItem.BaseStats;
            perLevelStatsViewControl.DisplayedItem = DisplayedItem.LevelUpIncrement;
            //Spawns
            enemySpawnListViewControl.DisplayedItem = DisplayedItem.Spawns;
        }
    }
}

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

namespace DQModEditor.Gui.Controls.Enemies
{
    /// <summary>
    /// Control that displays an enemy definition from a mod.
    /// </summary>
    internal partial class EnemyViewControl : ViewControl<Enemy>
    {
        public EnemyViewControl()
        {
            InitializeComponent();

            DisplayedItemChanged += ChangeDisplayedItem;

            typesListView.DeleteCommand += (s) => DisplayedItem.RemoveType(s);
            typesListView.ClearCommand += () => DisplayedItem.ClearTypes();
            typesListView.AddCommand += (s) => DisplayedItem.AddType(s);
            immunitiesListView.DeleteCommand += (s) => DisplayedItem.RemoveImmunity(s);
            immunitiesListView.ClearCommand += () => DisplayedItem.ClearImmunities();
            immunitiesListView.AddCommand += (s) => DisplayedItem.AddImmunity(s);
        }

        private void ChangeDisplayedItem(ViewControl<Enemy> source, Enemy previous)
        {
            if (previous != null)
            {
                Utility.ClearBindings(this);
                previous.TypesCollectionChanged -= typesListView.UpdateData;
                previous.ImmunitiesCollectionChanged -= immunitiesListView.UpdateData;
            }

            if (DisplayedItem != null)
            {
                // Text & Description
                string textPropertyName = nameof(displayNameTextBox.Text);
                internalNameTextBox.DataBindings.Add(textPropertyName, DisplayedItem, nameof(DisplayedItem.InternalName));
                displayNameTextBox.DataBindings.Add(textPropertyName, DisplayedItem, nameof(DisplayedItem.DisplayName));
                flavorNameTextBox.DataBindings.Add(textPropertyName, DisplayedItem, nameof(DisplayedItem.FlavorName));
                flavorDescriptionTextBox.DataBindings.Add(textPropertyName, DisplayedItem, nameof(DisplayedItem.FlavorDescription));
                // Appearance
                selectionBoxOffsetViewControl.DataBindings.Add(nameof(selectionBoxOffsetViewControl.Value), DisplayedItem,
                    nameof(DisplayedItem.SelectBoxOffset));
                graphicsIdTextBox.DataBindings.Add(textPropertyName, DisplayedItem, nameof(DisplayedItem.GraphicId));
                skinTextBox.DataBindings.Add(textPropertyName, DisplayedItem, nameof(DisplayedItem.GraphicSkinId));
                deathSoundTextBox.DataBindings.Add(textPropertyName, DisplayedItem, nameof(DisplayedItem.DeathSound));
                // Stats
                baseStatsViewControl.DisplayedItem = DisplayedItem.BaseStats;
                perLevelStatsViewControl.DisplayedItem = DisplayedItem.LevelUpIncrement;
                // Spawns
                enemySpawnListViewControl.DisplayedItem = DisplayedItem.Spawns;
                // Types
                typesListView.DisplayedItem = DisplayedItem.Types;
                DisplayedItem.TypesCollectionChanged += typesListView.UpdateData;
                // Immunities
                immunitiesListView.DisplayedItem = DisplayedItem.Immunities;
                DisplayedItem.ImmunitiesCollectionChanged += immunitiesListView.UpdateData;
            }
        }
    }
}

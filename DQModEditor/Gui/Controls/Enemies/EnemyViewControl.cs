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
using DQModEditor.DataModel.Enemies;

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

            typesListView.DeleteCommand += (s) => DisplayedItem.RemoveType(s);
            typesListView.ClearCommand += () => DisplayedItem.ClearTypes();
            typesListView.AddCommand += (s) => DisplayedItem.AddType(s);
            immunitiesListView.DeleteCommand += (s) => DisplayedItem.RemoveImmunity(s);
            immunitiesListView.ClearCommand += () => DisplayedItem.ClearImmunities();
            immunitiesListView.AddCommand += (s) => DisplayedItem.AddImmunity(s);

            viewCorrespondingButton.Click += ViewCorrespondingButton_Click;

            DisplayedItemChanged += ChangeDisplayedItem;
            ContextChanged += EnemyViewControl_ContextChanged;

            Utility.BindDisplayContext(this, spawnListViewControl);
        }

        private void EnemyViewControl_ContextChanged(ViewControl<Enemy> source, DisplayContext previous)
        {
            if (previous != null) Context.CurrentMod.EnemyCollectionChanged -= CurrentMod_EnemyCollectionChanged;

            if (Context == null) viewCorrespondingButton.Enabled = false;
            else
            {
                Context.CurrentMod.EnemyCollectionChanged += CurrentMod_EnemyCollectionChanged;
                UpdateViewCorrespondingEnabled();
            }
        }

        private void CurrentMod_EnemyCollectionChanged(Enemy enemy)
        {
            UpdateViewCorrespondingEnabled();
        }

        private void ViewCorrespondingButton_Click(object sender, EventArgs e)
        {
            DisplayedItem = Context.CurrentMod.GetCorrespondingEnemy(DisplayedItem);
        }

        private void ChangeDisplayedItem(ViewControl<Enemy> source, Enemy previous)
        {
            if (previous != null)
            {
                Utility.ClearBindings(this);
                previous.TypesCollectionChanged -= typesListView.UpdateData;
                previous.ImmunitiesCollectionChanged -= immunitiesListView.UpdateData;
                previous.PropertyChanged -= (s, e) => UpdateViewCorrespondingEnabled();
            }

            if (DisplayedItem != null)
            {
                string textPropertyName = nameof(displayNameTextBox.Text);
                // Identity
                internalNameTextBox.DataBindings.Add(textPropertyName, DisplayedItem, nameof(DisplayedItem.Id));
                // change the update mode, or the change does not take effect until the checkbox loses focus after clicking it
                newGamePlusCheckBox.DataBindings.Add(nameof(newGamePlusCheckBox.Checked), DisplayedItem, 
                    nameof(DisplayedItem.IsNewGamePlus), false, DataSourceUpdateMode.OnPropertyChanged);
                // Text & Description
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
                spawnListViewControl.DisplayedItem = DisplayedItem.Spawns;
                // Resistances
                resistanceListViewControl.DisplayedItem = DisplayedItem.Resistances;
                // Types
                typesListView.DisplayedItem = DisplayedItem.Types;
                DisplayedItem.TypesCollectionChanged += typesListView.UpdateData;
                // Immunities
                immunitiesListView.DisplayedItem = DisplayedItem.Immunities;
                DisplayedItem.ImmunitiesCollectionChanged += immunitiesListView.UpdateData;

                // View Corresponding
                UpdateViewCorrespondingEnabled();
                DisplayedItem.PropertyChanged += (s, e) => UpdateViewCorrespondingEnabled();
            }
        }

        private void UpdateViewCorrespondingEnabled()
        {
            if(Context == null)
            {
                viewCorrespondingButton.Enabled = false;
                return;
            }
            if(Context.CurrentMod.GetCorrespondingEnemy(DisplayedItem) == null)
            {
                viewCorrespondingButton.Enabled = false;
                return;
            }
            viewCorrespondingButton.Enabled = true;
        }
    }
}

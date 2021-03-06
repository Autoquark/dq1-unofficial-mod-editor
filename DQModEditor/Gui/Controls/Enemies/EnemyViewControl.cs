﻿using System;
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
using System.Collections.Specialized;

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

            viewCorrespondingButton.Click += ViewCorrespondingButton_Click;
            changeIdButton.Click += (s, e) =>
            {
                ChangeEnemyIdForm f = new ChangeEnemyIdForm(Context, DisplayedItem);
                f.SelectedValue = DisplayedItem.Id;
                f.ShowDialog();
                if (f.DialogResult == DialogResult.Cancel) return;

                Enemy renamed = Context.CurrentLoader.StableClone(DisplayedItem, f.SelectedValue);
                Context.CurrentMod.EnemiesById.Remove(DisplayedItem);
                Context.CurrentMod.EnemiesById.Add(renamed);
                DisplayedItem = renamed;
            };

            DisplayedItemChanged += ChangeDisplayedItem;
            ContextChanged += EnemyViewControl_ContextChanged;

            Utility.BindDisplayContext(this, spawnListViewControl);
            Utility.BindDisplayContext(this, enemyColorListViewControl);
        }

        private void EnemyViewControl_ContextChanged(ViewControl<Enemy> source, DisplayContext previous)
        {
            if (previous != null) Context.CurrentMod.EnemiesById.CollectionChanged -= CurrentMod_EnemyCollectionChanged;

            if (Context != null) Context.CurrentMod.EnemiesById.CollectionChanged += CurrentMod_EnemyCollectionChanged;

            UpdateContextDependent();
        }

        private void CurrentMod_EnemyCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            UpdateContextDependent();
        }

        private void ViewCorrespondingButton_Click(object sender, EventArgs e)
        {
            DisplayedItem = Context.CurrentMod.GetCorrespondingEnemy(DisplayedItem);
        }

        private void ChangeDisplayedItem(ViewControl<Enemy> source, Enemy previous)
        {
            if (previous != null) previous.PropertyChanged -= (s, e) => UpdateContextDependent();

            if (DisplayedItem != null)
            {
                string textPropertyName = nameof(displayNameTextBox.Text);
                // Identity
                internalNameTextBox.SetBinding(textPropertyName, DisplayedItem, nameof(DisplayedItem.Id));
                //change the update mode, or the change does not take effect until the checkbox loses focus after clicking it
                newGamePlusCheckBox.SetBinding(new Binding(nameof(newGamePlusCheckBox.Checked), DisplayedItem,
                    nameof(DisplayedItem.IsNewGamePlus), false, DataSourceUpdateMode.OnPropertyChanged));
                // Text & Description
                displayNameTextBox.SetBinding(textPropertyName, DisplayedItem, nameof(DisplayedItem.DisplayName));
                flavorNameTextBox.SetBinding(textPropertyName, DisplayedItem, nameof(DisplayedItem.FlavorName));
                flavorDescriptionTextBox.SetBinding(textPropertyName, DisplayedItem, nameof(DisplayedItem.FlavorDescription));
                // Appearance
                selectionBoxOffsetViewControl.SetBinding(nameof(selectionBoxOffsetViewControl.Value), DisplayedItem, 
                    nameof(DisplayedItem.SelectBoxOffset));
                graphicsIdTextBox.SetBinding(textPropertyName, DisplayedItem, nameof(DisplayedItem.GraphicId));
                skinTextBox.SetBinding(textPropertyName, DisplayedItem, nameof(DisplayedItem.GraphicSkinId));
                deathSoundTextBox.SetBinding(textPropertyName, DisplayedItem, nameof(DisplayedItem.DeathSound));
                effectOffsetsListViewControl.SetBinding(nameof(effectOffsetsListViewControl.DisplayedItem), DisplayedItem,
                    nameof(DisplayedItem.EffectOffsets));
                enemyColorListViewControl.DisplayedItem = DisplayedItem;
                // Stats
                baseStatsViewControl.DisplayedItem = DisplayedItem.BaseStats;
                perLevelStatsViewControl.DisplayedItem = DisplayedItem.LevelUpIncrement;
                // Spawns
                spawnListViewControl.DisplayedItem = DisplayedItem.Spawns;
                // Resistances
                resistanceListViewControl.DisplayedItem = DisplayedItem.Resistances;
                // Types
                typesListView.DisplayedItem = DisplayedItem.Types;
                // Immunities
                immunitiesListView.DisplayedItem = DisplayedItem.Immunities;

                // Context Dependent
                UpdateContextDependent();
                DisplayedItem.PropertyChanged += (s, e) => UpdateContextDependent();
            }
        }

        private void UpdateContextDependent()
        {
            viewCorrespondingButton.Enabled = true;
            changeIdButton.Enabled = true;

            if (DisplayedItem == null || Context == null)
            {
                viewCorrespondingButton.Enabled = false;
                changeIdButton.Enabled = false;
                return;
            }

            if(Context.CurrentMod.GetCorrespondingEnemy(DisplayedItem) == null)
            {
                viewCorrespondingButton.Enabled = false;
                return;
            }
        }
    }
}

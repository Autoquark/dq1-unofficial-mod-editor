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

namespace DQModEditor.Gui.Controls.Enemies
{
    /// <summary>
    /// Control that displays the enemies defined by a mod.
    /// </summary>
    internal partial class EnemyListViewControl : ViewControl<Mod>
    {
        public EnemyListViewControl()
        {
            InitializeComponent();

            enemiesListBox.DisplayMember = nameof(KeyValuePair<string, Enemy>.Key);
            enemiesListBox.ValueMember = nameof(KeyValuePair<string, Enemy>.Value);
            enemiesListBox.SelectedValueChanged += (o, e) => { enemyViewControl.DisplayedItem = (Enemy)enemiesListBox.SelectedValue; };

            DisplayedItemChanged += ChangeDisplayedItem;
        }

        private void ChangeDisplayedItem(ViewControl<Mod> source, Mod previous)
        {
            if(previous != null) DisplayedItem.EnemyCollectionChanged -= DisplayedItem_EnemyAdded;

            if (DisplayedItem != null)
            {
                enemiesListBox.DataSource = new BindingSource(DisplayedItem.EnemiesByInternalName, null);
                DisplayedItem.EnemyCollectionChanged += DisplayedItem_EnemyAdded;
            }
        }

        private void DisplayedItem_EnemyAdded(Enemy enemy)
        {
            ((BindingSource)enemiesListBox.DataSource).DataSource = null;
            ((BindingSource)enemiesListBox.DataSource).DataSource = DisplayedItem.EnemiesByInternalName;
        }
    }
}

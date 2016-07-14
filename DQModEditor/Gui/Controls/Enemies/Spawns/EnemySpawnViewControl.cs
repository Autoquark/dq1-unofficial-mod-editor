﻿using System;
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

            DisplayedItemChanged += ChangeDisplayedItem;
        }

        private void ChangeDisplayedItem(ViewControl<SpawnInfo> source, SpawnInfo previous)
        {
            if (previous != null) Utility.ClearBindings(this);

            if (DisplayedItem != null)
            {
                spawnLocationViewControl.DataBindings.Add(nameof(spawnLocationViewControl.Value), DisplayedItem, 
                    nameof(DisplayedItem.Location));
                spawnIdTextBox.DataBindings.Add(nameof(spawnIdTextBox.Text), DisplayedItem, nameof(DisplayedItem.SpawnId));
                effectIdTextBox.DataBindings.Add(nameof(effectIdTextBox.Text), DisplayedItem, nameof(DisplayedItem.EffectId));
            }
        }
    }
}

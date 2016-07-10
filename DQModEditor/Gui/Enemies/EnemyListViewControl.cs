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

namespace DQModEditor.Gui.Enemies
{
    /// <summary>
    /// Control that displays the enemies defined by a mod.
    /// </summary>
    internal partial class EnemyListViewControl : UserControl
    {
        public EnemyListViewControl(Mod mod)
        {
            InitializeComponent();

            enemiesListBox.Format += (sender, args) => { args.Value = ((Enemy)args.Value).InternalName; };
            enemiesListBox.SelectedValueChanged += (o, e) => { enemyViewControl.DisplayedItem = (Enemy)enemiesListBox.SelectedItem; };
            enemiesListBox.DataSource = mod.Enemies;
        }
    }
}

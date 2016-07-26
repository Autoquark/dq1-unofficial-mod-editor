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

namespace DQModEditor.Gui.Controls.Enemies
{
    internal partial class StatSetViewControl : ViewControl<StatSet>
    {
        public StatSetViewControl()
        {
            InitializeComponent();

            DisplayedItemChanged += ChangeDisplayedItem;
        }

        private void ChangeDisplayedItem(ViewControl<StatSet> source, StatSet previous)
        {
            if (previous != null) Utility.ClearBindings(this);

            if (DisplayedItem != null)
            {
                string valuePropertyName = nameof(hpSpinner.Value);
                hpSpinner.DataBindings.Add(valuePropertyName, DisplayedItem, nameof(DisplayedItem.Hp));
                psiSpinner.DataBindings.Add(valuePropertyName, DisplayedItem, nameof(DisplayedItem.Psi));
                scrapSpinner.DataBindings.Add(valuePropertyName, DisplayedItem, nameof(DisplayedItem.Scrap));
                speedSpinner.DataBindings.Add(valuePropertyName, DisplayedItem, nameof(DisplayedItem.Speed));
                strengthSpinner.DataBindings.Add(valuePropertyName, DisplayedItem, nameof(DisplayedItem.Strength));
                armorSpinner.DataBindings.Add(valuePropertyName, DisplayedItem, nameof(DisplayedItem.Armor));
                xpSpinner.DataBindings.Add(valuePropertyName, DisplayedItem, nameof(DisplayedItem.Xp));
            }
        }
    }
}

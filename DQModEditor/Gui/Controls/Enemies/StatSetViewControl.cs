using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DQModEditor.Model.Enemy;
using DQModEditor.Model;

namespace DQModEditor.Gui.Controls.Enemies
{
    internal partial class StatSetViewControl : ViewControl<StatSet>
    {
        public StatSetViewControl()
        {
            InitializeComponent();

            DisplayedItemChanged += ChangeDisplayedItem;
        }

        private void ChangeDisplayedItem(ViewControl<StatSet> source)
        {
            if (DisplayedItem == null) return;
            string valuePropertyName = nameof(hpSpinner.Value);
            hpSpinner.DataBindings.Clear();
            hpSpinner.DataBindings.Add(valuePropertyName, DisplayedItem, nameof(DisplayedItem.Hp));
            psiSpinner.DataBindings.Clear();
            psiSpinner.DataBindings.Add(valuePropertyName, DisplayedItem, nameof(DisplayedItem.Psi));
            scrapSpinner.DataBindings.Clear();
            scrapSpinner.DataBindings.Add(valuePropertyName, DisplayedItem, nameof(DisplayedItem.Scrap));
            speedSpinner.DataBindings.Clear();
            speedSpinner.DataBindings.Add(valuePropertyName, DisplayedItem, nameof(DisplayedItem.Speed));
            strengthSpinner.DataBindings.Clear();
            strengthSpinner.DataBindings.Add(valuePropertyName, DisplayedItem, nameof(DisplayedItem.Strength));
            armorSpinner.DataBindings.Clear();
            armorSpinner.DataBindings.Add(valuePropertyName, DisplayedItem, nameof(DisplayedItem.Armor));
            xpSpinner.DataBindings.Clear();
            xpSpinner.DataBindings.Add(valuePropertyName, DisplayedItem, nameof(DisplayedItem.Xp));
        }
    }
}

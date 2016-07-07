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

namespace DQModEditor.Gui
{
    public partial class StatSetViewControl : UserControl
    {
        public StatSetViewControl(StatSet statSet)
        {
            InitializeComponent();

            string valuePropertyName = nameof(hpSpinner.Value);
            hpSpinner.DataBindings.Add(valuePropertyName, statSet, nameof(statSet.Hp));
            psiSpinner.DataBindings.Add(valuePropertyName, statSet, nameof(statSet.Psi));
            scrapSpinner.DataBindings.Add(valuePropertyName, statSet, nameof(statSet.Scrap));
            speedSpinner.DataBindings.Add(valuePropertyName, statSet, nameof(statSet.Speed));
            strengthSpinner.DataBindings.Add(valuePropertyName, statSet, nameof(statSet.Strength));
            armorSpinner.DataBindings.Add(valuePropertyName, statSet, nameof(statSet.Armor));
            xpSpinner.DataBindings.Add(valuePropertyName, statSet, nameof(statSet.Xp));
        }
    }
}

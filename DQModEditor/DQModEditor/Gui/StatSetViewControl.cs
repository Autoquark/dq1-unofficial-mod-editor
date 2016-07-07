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
            Utility.EnableCommitImmediately(hpSpinner);
            psiSpinner.DataBindings.Add(valuePropertyName, statSet, nameof(statSet.Psi));
            Utility.EnableCommitImmediately(psiSpinner);
            scrapSpinner.DataBindings.Add(valuePropertyName, statSet, nameof(statSet.Scrap));
            Utility.EnableCommitImmediately(scrapSpinner);
            speedSpinner.DataBindings.Add(valuePropertyName, statSet, nameof(statSet.Speed));
            Utility.EnableCommitImmediately(speedSpinner);
            strengthSpinner.DataBindings.Add(valuePropertyName, statSet, nameof(statSet.Strength));
            Utility.EnableCommitImmediately(strengthSpinner);
            armorSpinner.DataBindings.Add(valuePropertyName, statSet, nameof(statSet.Armor));
            Utility.EnableCommitImmediately(armorSpinner);
            xpSpinner.DataBindings.Add(valuePropertyName, statSet, nameof(statSet.Xp));
            Utility.EnableCommitImmediately(xpSpinner);
        }
    }
}

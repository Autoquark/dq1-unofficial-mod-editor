using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DQModEditor.DataModel.Enemies;

namespace DQModEditor.Gui.Controls.Enemies.Resistances
{
    internal partial class ResistanceListViewControl : ViewControl<IList<Resistance>>
    {
        public ResistanceListViewControl()
        {
            InitializeComponent();

            resistancesListBox.Format += (sender, args) =>
            {
                Resistance item = (Resistance)args.Value;
                if (item == null) return;
                string flavor = item.Flavor;
                if (item.Flavor == "") flavor = "<unspecified>";
                string value = (item.Amount * 100).ToString("F0");
                if (item.ResistanceKind == Resistance.Kind.DamageMultiplier)
                {
                    args.Value = $"{value}% damage from {flavor}";
                }
                else
                {
                    args.Value = $"{value}% evade {flavor}";
                }
            };

            resistancesListBox.SelectedValueChanged += (s, e) =>
            {
                //See SpawnListViewControl
                Control active = resistanceViewControl.ActiveControl;
                resistanceViewControl.DisplayedItem = (Resistance)resistancesListBox.SelectedItem;
                active?.Select();
            };

            deleteButton.Click += (s, e) => { DisplayedItem.Remove(resistanceViewControl.DisplayedItem); };
            clearButton.Click += (s, e) => { DisplayedItem.Clear(); };
            addButton.Click += AddButton_Click;

            DisplayedItemChanged += (s, p) => {
                if (DisplayedItem == null) return;
                resistancesListBox.DataSource = DisplayedItem;
                //Because ListBox.SelectedValueChanged does not seem to fire when we change to displaying an empty list
                resistanceViewControl.DisplayedItem = (Resistance)resistancesListBox.SelectedItem;
            };
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            Resistance resistance = new Resistance();
            DisplayedItem.Add(resistance);
            resistancesListBox.SelectedIndex = -1;
            resistancesListBox.SelectedIndex = resistancesListBox.Items.Count - 1;
        }
    }
}

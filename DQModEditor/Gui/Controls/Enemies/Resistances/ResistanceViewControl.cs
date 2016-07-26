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
    internal partial class ResistanceViewControl : ViewControl<Resistance>
    {
        public ResistanceViewControl()
        {
            InitializeComponent();

            _enumViewControl.SetLabel(Resistance.Kind.DamageMultiplier, "Damage Multiplier");
            _enumViewControl.SetLabel(Resistance.Kind.Evade, "Evasion Chance");
            Point p = new Point(effectLabel.Right + 8, effectLabel.Top - 3);
            _enumViewControl.Location = p;
            Controls.Add(_enumViewControl);

            DisplayedItemChanged += ChangeDisplayedItem;
        }

        private void ChangeDisplayedItem(ViewControl<Resistance> source, Resistance previous)
        {
            if(previous != null) Utility.ClearBindings(this);

            if(DisplayedItem != null)
            {
                _enumViewControl.DataBindings.Add(nameof(_enumViewControl.SelectedValue), DisplayedItem, nameof(DisplayedItem.ResistanceKind));
                flavorTextBox.DataBindings.Add(nameof(flavorTextBox.Text), DisplayedItem, nameof(DisplayedItem.Flavor));

                Binding binding = new Binding(nameof(amountSpinner.Value), DisplayedItem, nameof(DisplayedItem.Amount));
                binding.Format += (s, e) => { e.Value = (decimal)e.Value * 100; };
                binding.Parse += (s, e) => { e.Value = amountSpinner.Value / 100; };
                amountSpinner.DataBindings.Add(binding);
            }
        }

        private RadioButtonEnumViewControl<Resistance.Kind> _enumViewControl = new RadioButtonEnumViewControl<Resistance.Kind>();
    }
}

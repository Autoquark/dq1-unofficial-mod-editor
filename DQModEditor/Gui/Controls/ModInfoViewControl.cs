using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DQModEditor.DataModel;

namespace DQModEditor.Gui.Controls
{
    internal partial class ModInfoViewControl : ViewControl<Mod>
    {
        public ModInfoViewControl()
        {
            InitializeComponent();

            DisplayedItemChanged += ChangeDisplayedItem;
        }

        private void ChangeDisplayedItem(ViewControl<Mod> source, Mod previous)
        {
            if(previous != null) Utility.ClearBindings(this);

            if (DisplayedItem != null)
            {
                string textPropertyName = nameof(TextBox.Text);
                modIdTextBox.DataBindings.Add(textPropertyName, DisplayedItem, nameof(DisplayedItem.Id));
                gameNameTextBox.DataBindings.Add(textPropertyName, DisplayedItem, nameof(DisplayedItem.GameName));
                versionTextBox.DataBindings.Add(textPropertyName, DisplayedItem, nameof(DisplayedItem.GameVersion));
                modTitleTextBox.DataBindings.Add(textPropertyName, DisplayedItem, nameof(DisplayedItem.Title));
                descriptionTextBox.DataBindings.Add(textPropertyName, DisplayedItem, nameof(DisplayedItem.Description));
            }
        }
    }
}

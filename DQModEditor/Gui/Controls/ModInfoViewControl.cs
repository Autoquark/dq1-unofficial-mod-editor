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
            if (DisplayedItem != null)
            {
                string textPropertyName = nameof(TextBox.Text);
                modIdTextBox.SetBinding(textPropertyName, DisplayedItem, nameof(DisplayedItem.Id));
                gameNameTextBox.SetBinding(textPropertyName, DisplayedItem, nameof(DisplayedItem.GameName));
                versionTextBox.SetBinding(textPropertyName, DisplayedItem, nameof(DisplayedItem.GameVersion));
                modTitleTextBox.SetBinding(textPropertyName, DisplayedItem, nameof(DisplayedItem.Title));
                descriptionTextBox.SetBinding(textPropertyName, DisplayedItem, nameof(DisplayedItem.Description));
            }
        }
    }
}

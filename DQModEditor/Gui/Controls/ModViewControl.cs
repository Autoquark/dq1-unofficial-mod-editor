using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DQModEditor.Model;
using DQModEditor.Loader;
using DQModEditor.Gui.Controls.Enemies;

namespace DQModEditor.Gui.Controls
{
    /// <summary>
    /// Control that displays a mod.
    /// </summary>
    internal partial class ModViewControl : ViewControl<ModLoadInformation>
    {
        public ModViewControl()
        {
            InitializeComponent();

            saveButton.Click += SaveButton_Click;
            saveButton.DisplayStyle = ToolStripItemDisplayStyle.Text;

            toolStrip.CausesValidation = true;

            DisplayedItemSetNonNull += ChangeDisplayedItem;
        }

        private void ChangeDisplayedItem(ViewControl<ModLoadInformation> source)
        {
            enemyListViewControl.DisplayedItem = DisplayedItem.Mod;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Workaround: If the user is editing a value (e.g. a NumericUpDown) and clicks the save button, the control they were using does not
            //lose focus and does not commit the value to the model. I think this is because ToolStripButtons do not acquire focus. Grabbing the 
            //focus manually causes events to fire on other controls which we can hook in order to manually force the data binding to update the model object.
            toolStrip.Focus();

            ModDirectoryParser parser = new ModDirectoryParser(DisplayedItem.DirectoryPath);
            parser.Save(DisplayedItem.Mod);
        }
    }
}

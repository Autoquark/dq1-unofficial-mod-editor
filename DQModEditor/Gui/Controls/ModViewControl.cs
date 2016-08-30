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
using DQModEditor.Loader;
using DQModEditor.Gui.Controls.Enemies;

namespace DQModEditor.Gui.Controls
{
    /// <summary>
    /// Control that displays a mod.
    /// </summary>
    internal partial class ModViewControl : ViewControl<ModLoader>
    {
        public ModViewControl()
        {
            InitializeComponent();

            saveButton.Click += SaveButton_Click;
            openButton.Click += (s, e) =>
            {
                ModLoader info = Utility.ShowLoadModDialog();
                if (info == null) return;
                DisplayedItem = info;
            };
            closeButton.Click += (s, e) => DisplayedItem = null;

            toolStrip.CausesValidation = true;

            DisplayedItemChanged += (s, p) =>
            {
                if (DisplayedItem == null) return;
                enemyListViewControl.DisplayedItem = DisplayedItem.LoadedMod;
                modInfoViewControl.DisplayedItem = DisplayedItem.LoadedMod;
                Context = new DisplayContext(DisplayedItem);
            };

            Utility.BindDisplayContext(this, modInfoViewControl);
            Utility.BindDisplayContext(this, enemyListViewControl);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Workaround: If the user is editing a value (e.g. a NumericUpDown) and clicks the save button, the control they were using does not
            //lose focus and does not commit the value to the model. I think this is because ToolStripButtons do not acquire focus. Grabbing the 
            //focus manually causes events to fire on other controls which we can hook in order to manually force the data binding to update the model object.
            toolStrip.Focus();

            DisplayedItem.StableSave();
        }
    }
}

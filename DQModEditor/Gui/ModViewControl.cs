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
using DQModEditor.Gui.Enemies;

namespace DQModEditor.Gui
{
    /// <summary>
    /// Control that displays a mod.
    /// </summary>
    internal partial class ModViewControl : UserControl
    {
        public ModViewControl(Mod mod, string modDirectory)
        {
            InitializeComponent();
            _mod = mod;
            _modDirectory = modDirectory;

            EnemyListViewControl enemiesControl = new EnemyListViewControl(mod);
            enemiesControl.Location = new Point(0, 8);
            enemiesTabPage.Controls.Add(enemiesControl);

            saveButton.Click += SaveButton_Click;
            saveButton.DisplayStyle = ToolStripItemDisplayStyle.Text;

            toolStrip.CausesValidation = true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Workaround: If the user is editing a value (e.g. a NumericUpDown) and clicks the save button, the control they were using does not
            //lose focus and does not commit the value to the model. I think this is because ToolStripButtons do not acquire focus. Grabbing the 
            //focus manually causes events to fire on other controls which we can hook in order to manually force the data binding to update the model object.
            toolStrip.Focus();

            ModDirectoryParser parser = new ModDirectoryParser(_modDirectory);
            parser.Save(_mod);
        }

        private readonly Mod _mod;
        private readonly string _modDirectory;
    }
}

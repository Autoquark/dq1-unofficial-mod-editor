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

namespace DQModEditor.Gui
{
    /// <summary>
    /// Control that displays a mod.
    /// </summary>
    public partial class ModViewControl : UserControl
    {
        public ModViewControl(Mod mod, string modDirectory)
        {
            InitializeComponent();
            _mod = mod;
            _modDirectory = modDirectory;

            EnemiesViewControl enemiesControl = new EnemiesViewControl(mod);
            enemiesControl.Location = new Point(0, 8);
            enemiesTabPage.Controls.Add(enemiesControl);

            saveButton.Click += SaveButton_Click;
            saveButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            //Workaround: If the user is editing a value (e.g. a NumericUpDown) and clicks the save button, the control they were using does not
            //lose focus and does not commit the value to the model, so we save the old value and not the one they just entered. Grabbing the focus
            //forces the previously focused control to validate and commit and changed value.
            toolStrip.Focus();

            ModDirectoryParser parser = new ModDirectoryParser(_modDirectory);
            parser.Save(_mod);
        }

        private readonly Mod _mod;
        private readonly string _modDirectory;
    }
}

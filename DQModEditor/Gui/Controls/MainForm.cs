using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DQModEditor.DataModel;
using DQModEditor.Loader;

namespace DQModEditor.Gui.Controls
{
    /// <summary>
    /// The main program window.
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            openModControl = new OpenModControl();
            Controls.Add(openModControl);
            openModControl.Location = new System.Drawing.Point((Width - openModControl.Width) / 2, (Height - openModControl.Height) / 2);
            openModControl.ModLoaded += OpenModControl_ModLoaded;

            Text = Utility.ProgramNameShort + " (" + Utility.VersionString + ") ";
            modViewControl.DisplayedItemChanged += ModViewControl_DisplayedItemChanged;
        }

        private void ModViewControl_DisplayedItemChanged(ViewControl<ModLoader> source, ModLoader previous)
        {
            Text = Utility.ProgramNameShort + " (" + Utility.VersionString + ") " + (modViewControl.DisplayedItem?.ModDirectoryPath ?? "");
            if (modViewControl.DisplayedItem == null)
            {
                openModControl.Visible = true;
                modViewControl.Visible = false;
            }
        }

        private void OpenModControl_ModLoaded(ModLoader loader)
        {
            openModControl.Visible = false;
            modViewControl.Visible = true;
            modViewControl.DisplayedItem = loader;
        }

        private readonly OpenModControl openModControl;
    }
}

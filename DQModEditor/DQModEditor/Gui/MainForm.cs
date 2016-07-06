using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DQModEditor.Model;

namespace DQModEditor.Gui
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
            openModControl.Location = new Point((Width - openModControl.Width) / 2, (Height - openModControl.Height) / 2);
            openModControl.ModLoaded += OpenModControl_ModLoaded;
        }

        private void OpenModControl_ModLoaded(Mod mod)
        {
            openModControl.Visible = false;
            modViewControl?.Dispose();
            modViewControl = new ModViewControl(mod);
            Controls.Add(modViewControl);
        }

        private readonly OpenModControl openModControl;
        private ModViewControl modViewControl = null;
    }
}

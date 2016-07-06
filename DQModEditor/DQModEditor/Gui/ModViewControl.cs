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

namespace DQModEditor.Gui
{
    /// <summary>
    /// Control that displays a mod.
    /// </summary>
    public partial class ModViewControl : UserControl
    {
        public ModViewControl(Mod mod)
        {
            InitializeComponent();

            EnemiesViewControl enemiesControl = new EnemiesViewControl(mod);
            enemiesControl.Location = new Point(0, 8);
            enemiesTabPage.Controls.Add(enemiesControl);
        }
    }
}

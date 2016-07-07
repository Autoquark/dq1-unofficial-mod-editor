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
    /// Control that displays the enemies defined by a mod.
    /// </summary>
    public partial class EnemiesViewControl : UserControl
    {
        public EnemiesViewControl(Mod mod)
        {
            InitializeComponent();

            enemiesListBox.DataSource = mod.Enemies;
            enemiesListBox.Format += (sender, args) => { args.Value = ((Enemy)args.Value).InternalName; };
            enemiesListBox.SelectedIndexChanged += EnemiesListBox_SelectedIndexChanged;
        }

        private void EnemiesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (enemyViewControl != null && enemiesListBox.SelectedItem == enemyViewControl.DisplayedEnemy) return;
            enemyViewControl?.Dispose();
            enemyViewControl = new EnemyViewControl((Enemy)enemiesListBox.SelectedItem);
            Controls.Add(enemyViewControl);
            enemyViewControl.Location = new Point(enemiesListBox.Right + 8, 0);
        }

        private EnemyViewControl enemyViewControl = null;
    }
}

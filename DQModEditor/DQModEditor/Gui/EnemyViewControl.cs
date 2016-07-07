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
    /// Control that displays an enemy definition from a mod.
    /// </summary>
    public partial class EnemyViewControl : UserControl
    {
        public EnemyViewControl(Enemy enemy)
        {
            InitializeComponent();

            DisplayedEnemy = enemy;

            // Text & Description
            string textPropertyName = nameof(displayNameTextBox.Text);
            internalNameTextBox.DataBindings.Add(textPropertyName, enemy, nameof(enemy.InternalName));
            displayNameTextBox.DataBindings.Add(textPropertyName, enemy, nameof(enemy.DisplayName));
            flavorNameTextBox.DataBindings.Add(textPropertyName, enemy, nameof(enemy.FlavorName));
            flavorDescriptionTextBox.DataBindings.Add(textPropertyName, enemy, nameof(enemy.FlavorDescription));
            // Stats
            StatSetViewControl statControl = new StatSetViewControl(enemy.BaseStats);
            statsGroupBox.Controls.Add(statControl);
            statControl.Location = new Point(56, 45);
            statControl = new StatSetViewControl(enemy.LevelUpIncrement);
            statsGroupBox.Controls.Add(statControl);
            statControl.Location = new Point(144, 45);
        }

        public Enemy DisplayedEnemy { get; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DQModEditor.DataModel.Enemies;

namespace DQModEditor.Gui.Controls.Enemies
{
    partial class ChangeEnemyIdForm : Form
    {
        public ChangeEnemyIdForm(DisplayContext context, Enemy enemy)
        {
            if (context == null) throw new ArgumentNullException($"Parameter {nameof(context)} may not be null");

            InitializeComponent();

            _context = context;
            _enemy = enemy;

            SelectedValue = enemy.Id;

            iconPictureBox.Image = SystemIcons.Information.ToBitmap();
            newIdTextBox.TextChanged += (s, e) => UpdateState();
            okButton.DialogResult = DialogResult.OK;
            okButton.Click += (s, e) => Close();

            UpdateState();
        }

        public string SelectedValue
        {
            get { return newIdTextBox.Text; }
            set
            {
                if (newIdTextBox.Text == value) return;
                if (value == null) value = "";
                newIdTextBox.Text = value;
            }
        }

        private void UpdateState()
        {
            okButton.Enabled = true;

            if(_context.CurrentMod.EnemiesById.ContainsKey(SelectedValue) && SelectedValue != _enemy.Id)
            {
                messageTextBox.Text = "An enemy with the given id already exists";
                okButton.Enabled = false;
                return;
            }

            if (SelectedValue.EndsWith(Enemy.NewGamePlusIdSuffix))
            {
                messageTextBox.Text = $"Because the id ends with {Enemy.NewGamePlusIdSuffix}, this enemy will be treated as a New Game Plus enemy.";
            }
            else
            {
                messageTextBox.Text = "";
            }
        }

        private readonly DisplayContext _context;
        private readonly Enemy _enemy;
    }
}

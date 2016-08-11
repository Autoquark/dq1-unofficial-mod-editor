using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DQModEditor.DataModel.Graphics;
using DQModEditor.DataModel.Enemies;

namespace DQModEditor.Gui.Controls.Enemies.Graphics
{
    public partial class EnemyLayerColorViewControl : UserControl
    {
        public EnemyLayerColorViewControl()
        {
            InitializeComponent();

            colorSelectButton.Click += (s, e) =>
            {
                if (colorDialog.ShowDialog() != DialogResult.OK) return;
                SelectedColor = colorDialog.Color;
            };
            colorSelectButton.BackColorChanged += (s, e) => {
                var x = colorSelectButton;
                var y = this;
            };
            SetColorUndefined();
        }

        public delegate void SelectedColorChangedHander();
        public event SelectedColorChangedHander SelectedColorChanged;

        public string LayerLabel
        {
            get { return layerNameLabel.Text; }
            set
            {
                if (layerNameLabel.Text == value) return;
                layerNameLabel.Text = value;
            }
        }

        public Color SelectedColor
        {
            get { return colorSelectButton.BackColor; }
            set
            {
                if (colorSelectButton.BackColor == value) return;
                colorSelectButton.BackColor = value;
                colorSelectButton.Text = "";
                SelectedColorChanged?.Invoke();
            }
        }

        public bool SelectedColorUndefined
        {
            get { return colorSelectButton.UseVisualStyleBackColor; }
        }

        public void SetColorUndefined()
        {
            colorSelectButton.BackColor = Color.Empty;
            colorSelectButton.UseVisualStyleBackColor = true;
            colorSelectButton.Text = "X";
        }
    }
}

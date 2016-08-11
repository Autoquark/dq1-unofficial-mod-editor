using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DQModEditor.Gui.Controls
{
    public partial class PointViewControl : UserControl
    {
        public PointViewControl()
        {
            InitializeComponent();

            xPosSpinner.Validated += (s, e) => _validX = (int)xPosSpinner.Value;
            yPosSpinner.Validated += (s, e) => _validY = (int)yPosSpinner.Value;
        }

        public Point Value
        {
            get { return new Point(_validX, _validY); }
            set
            {
                xPosSpinner.Value = _validX = value.X;
                yPosSpinner.Value = _validY = value.Y;
            }
        }
        private int _validX;
        private int _validY;
    }
}

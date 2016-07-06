using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DQModEditor.Gui
{
    static internal class Utility
    {
        internal static void EnableRenderControlArea(ContainerControl control)
        {
            control.Paint += RenderControlArea;
        }

        private static void RenderControlArea(object sender, PaintEventArgs e)
        {
            ContainerControl control = (ContainerControl)sender;
            e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(0, 0, control.Width - 1, control.Height - 1));

        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DQModEditor.Gui
{
    /// <summary>
    /// Static class providing utility methods relating to WinForms.
    /// </summary>
    static internal class Utility
    {
        /// <summary>
        /// Causes a NumericUpDown to write the new value to all data bindings immediately upon being modified via the buttons or mousewheel.
        /// Does not affect manually typing into the text box.
        /// </summary>
        /// <param name="control"></param>
        internal static void EnableCommitImmediately(NumericUpDown control)
        {
            control.ValueChanged -= CommitImmediately;
            control.ValueChanged += CommitImmediately;
        }

        /// <summary>
        /// Causes a control to draw a black rectangle around the edge of its area. For debugging/UI design.
        /// </summary>
        /// <param name="control"></param>
        internal static void EnableRenderControlArea(ContainerControl control)
        {
            control.Paint -= RenderControlArea;
            control.Paint += RenderControlArea;
        }

        private static void RenderControlArea(object sender, PaintEventArgs e)
        {
            ContainerControl control = (ContainerControl)sender;
            e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(0, 0, control.Width - 1, control.Height - 1));

        }

        private static void CommitImmediately(object sender, EventArgs e)
        {
            foreach (Binding b in ((NumericUpDown)sender).DataBindings) b.WriteValue();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DQModEditor.Loader;
using DQModEditor.Model;

namespace DQModEditor.Gui
{
    /// <summary>
    /// Static class providing utility methods relating to WinForms.
    /// </summary>
    static internal class Utility
    {
        internal static string ProgramName { get; } = "Defender's Quest Unofficial Mod Editor";
        internal static string VersionString { get; } = "v0.2";

        internal static ModLoadInformation ShowLoadModDialog()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "LevelUpLabs", "DefendersQuest", "mods");
            dialog.Description = "Select mod folder";
            if (dialog.ShowDialog() != DialogResult.OK) return null;

            ModDirectoryParser parser = new ModDirectoryParser(dialog.SelectedPath);
            return new ModLoadInformation(parser.Load(), dialog.SelectedPath);
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

        internal static void PreventEmptyText(NumericUpDown control)
        {
            control.Validated += (s, e) =>
            {
                if (control.Text == "") control.Text = control.Value.ToString();
            };
        }

        private static void RenderControlArea(object sender, PaintEventArgs e)
        {
            ContainerControl control = (ContainerControl)sender;
            e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(0, 0, control.Width - 1, control.Height - 1));
        }
    }
}

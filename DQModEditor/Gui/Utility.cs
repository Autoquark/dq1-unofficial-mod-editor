using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DQModEditor.Loader;
using DQModEditor.DataModel;
using DQModEditor.Gui.Controls;

namespace DQModEditor.Gui
{
    /// <summary>
    /// Static class providing utility methods relating to WinForms.
    /// </summary>
    static internal class Utility
    {
        static Utility()
        {
            Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            VersionString = $"v{version.Major}.{version.Minor}";
        }

        internal static string ProgramName { get; } = "Defender's Quest Unofficial Mod Editor";
        internal static string ProgramNameShort { get; } = "DQME";
        internal static string VersionString { get; }

        /// <summary>
        /// Creates a data binding on second that binds the control's display context to that of the first control.
        /// </summary>
        internal static void BindDisplayContext<T1, T2>(ViewControl<T1> first, ViewControl<T2> second) where T1 : class 
            where T2 : class
        {
            // Without formattingEnabled = true, this errors. Not sure why
            second.DataBindings.Add(nameof(second.Context), first, nameof(first.Context), true, DataSourceUpdateMode.Never);
        }

        /// <summary>
        /// Binds the given property of the control to the given member of the given datasource, first removing any existing binding
        /// to that property of the control.
        /// </summary>
        internal static void SetBinding(this Control control, string property, object dataSource, string dataMember)
        {
            SetBinding(control, new Binding(property, dataSource, dataMember));
        }

        internal static void SetBinding(this Control control, Binding binding)
        {
            ControlBindingsCollection c = control.DataBindings;
            Binding existing = c.Cast<Binding>().Where(x => x.PropertyName == binding.PropertyName).SingleOrDefault();
            if(existing != null) c.Remove(existing);
            c.Add(binding);
        }

        internal static ModLoader ShowLoadModDialog()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "LevelUpLabs", "DefendersQuest", "mods");
            dialog.Description = "Select mod folder";
            if (dialog.ShowDialog() != DialogResult.OK) return null;

            return new ModLoader(dialog.SelectedPath);
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

        /// <summary>
        /// Prevents a NumericUpDown from being left blank
        /// </summary>
        /// <param name="control"></param>
        internal static void PreventEmptyText(NumericUpDown control)
        {
            control.Validated += (s, e) =>
            {
                if (control.Text == "") control.Text = control.Value.ToString();
            };
        }

        /// <summary>
        /// When subscribed to a control's paint event, renders a black box around the area of a control.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void RenderControlArea(object sender, PaintEventArgs e)
        {
            ContainerControl control = (ContainerControl)sender;
            e.Graphics.DrawRectangle(new Pen(Color.Black), new Rectangle(0, 0, control.Width - 1, control.Height - 1));
        }
    }
}

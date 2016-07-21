using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DQModEditor.DataModel;
using System.IO;
using DQModEditor.Loader;

namespace DQModEditor.Gui.Controls
{
    /// <summary>
    /// Control that allows the user to load a mod directory.
    /// </summary>
    internal partial class OpenModControl : UserControl
    {
        internal event Action<ModLoadInformation> ModLoaded;

        internal OpenModControl()
        {
            InitializeComponent();

            loadModButton.Click += (s, e) =>
            {
                ModLoadInformation info = Utility.ShowLoadModDialog();
                if (info == null) return;
                ModLoaded?.Invoke(info);
            };
        }
    }
}

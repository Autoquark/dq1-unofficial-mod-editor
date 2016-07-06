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
using System.IO;

namespace DQModEditor.Gui
{
    /// <summary>
    /// Control that allows the user to load a mod directory.
    /// </summary>
    public partial class OpenModControl : UserControl
    {
        internal event Action<Mod> ModLoaded;

        internal OpenModControl()
        {
            InitializeComponent();

            loadModButton.Click += LoadModButton_Click;
        }

        private void LoadModButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            //dialog.RootFolder = Environment.SpecialFolder.Desktop;
            dialog.SelectedPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "LevelUpLabs", "DefendersQuest", "mods");
            if (dialog.ShowDialog() != DialogResult.OK) return;
            Mod mod = Mod.LoadDirectory(dialog.SelectedPath);
            ModLoaded?.Invoke(mod);
        }
    }
}

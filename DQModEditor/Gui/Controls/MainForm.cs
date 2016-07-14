﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DQModEditor.Model;

namespace DQModEditor.Gui.Controls
{
    /// <summary>
    /// The main program window.
    /// </summary>
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            openModControl = new OpenModControl();
            Controls.Add(openModControl);
            openModControl.Location = new Point((Width - openModControl.Width) / 2, (Height - openModControl.Height) / 2);
            openModControl.ModLoaded += OpenModControl_ModLoaded;

            Text = Utility.ProgramName + " (" + Utility.VersionString + ") ";
            modViewControl.DisplayedItemChanged += ModViewControl_DisplayedItemChanged;
        }

        private void ModViewControl_DisplayedItemChanged(ViewControl<ModLoadInformation> source, ModLoadInformation previous)
        {
            Text = Utility.ProgramName + " (" + Utility.VersionString + ") " + (modViewControl.DisplayedItem?.DirectoryPath ?? "");
            if (modViewControl.DisplayedItem == null)
            {
                openModControl.Visible = true;
                modViewControl.Visible = false;
            }
        }

        private void OpenModControl_ModLoaded(ModLoadInformation info)
        {
            openModControl.Visible = false;
            modViewControl.Visible = true;
            modViewControl.DisplayedItem = info;
        }

        private readonly OpenModControl openModControl;
    }
}

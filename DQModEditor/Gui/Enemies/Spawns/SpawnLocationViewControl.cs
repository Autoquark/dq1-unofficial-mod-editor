﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DQModEditor.Model;
using static DQModEditor.Model.SpawnInfo;

namespace DQModEditor.Gui.Enemies.Spawns
{
    internal partial class SpawnLocationViewControl : UserControl
    {
        public SpawnLocationViewControl()
        {
            InitializeComponent();

            xPosSpinner.Validated += (s, e) => _validX = xPosSpinner.Value;
            yPosSpinner.Validated += (s, e) => _validY = yPosSpinner.Value;
        }

        public SpawnLocation Value
        {
            get { return new SpawnLocation(_validX, _validY); }
            set
            {
                xPosSpinner.Value = value.X;
                yPosSpinner.Value = value.Y;
            }
        }
        private decimal _validX;
        private decimal _validY;
    }
}
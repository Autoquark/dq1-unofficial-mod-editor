using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DQModEditor.DataModel;
using DQModEditor.DataModel.Enemies;

namespace DQModEditor.Gui
{
    /// <summary>
    /// Contains additional information required by controls
    /// </summary>
    internal class DisplayContext
    {
        public DisplayContext(Mod mod)
        {
            CurrentMod = mod;
        }

        public Mod CurrentMod { get; }
    }
}

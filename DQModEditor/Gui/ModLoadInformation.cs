using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DQModEditor.Model;

namespace DQModEditor.Gui
{
    internal class ModLoadInformation
    {
        public ModLoadInformation(Mod mod, string path)
        {
            Mod = mod;
            DirectoryPath = path;
        }

        public Mod Mod { get; }
        public string DirectoryPath { get; }
    }
}

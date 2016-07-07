using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using DQModEditor.Model;

namespace DQModEditor.Loader
{
    /// <summary>
    /// Saves/loads Mods to/from a directory.
    /// </summary>
    public class ModDirectoryParser : DirectoryParserBase
    {
        public ModDirectoryParser(string modPath) : base(modPath)
        {
            if (!Directory.Exists(modPath)) throw new ModLoadException("The given path does not exist or is not a directory");

            _enemyParser = new EnemyDirectoryParser(modPath);
        }

        /// <summary>
        /// Parses the contents of the mod directory into a Mod object
        /// </summary>
        /// <returns></returns>
        public Mod Load()
        {
            Mod mod = new Mod();

            // Load enemies
            _enemyParser.LoadEnemyInfo(mod);

            return mod;
        }

        /// <summary>
        /// Saves the Mod object to the mod directory. Any additional data in the directory is preserved.
        /// </summary>
        /// <param name="mod"></param>
        public void Save(Mod mod)
        {
            // Save enemies
            _enemyParser.SaveEnemyInfo(mod);
        }

        private readonly EnemyDirectoryParser _enemyParser;
    }
}

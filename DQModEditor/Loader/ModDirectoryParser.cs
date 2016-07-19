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
            _infoFilePath = Path.Combine(ModDirectoryPath, "settings.xml");
        }

        /// <summary>
        /// Parses the contents of the mod directory into a Mod object
        /// </summary>
        /// <returns></returns>
        public Mod Load()
        {
            // Load mod info
            XElement infoRoot = XElement.Load(_infoFilePath);

            string modId = infoRoot.Descendant(_modIdElementName).AttributeValue(_modIdAttributeName);
            string gameName = infoRoot.Descendant(_gameElementName).AttributeValue(_gameNameAttributeName);
            Mod mod = new Mod(modId, gameName);

            mod.Title = infoRoot.Descendant(_modTitleElementName).AttributeValue(_modTitleAttributeName);
            mod.Description = infoRoot.Descendant(_modDescriptionElementName).AttributeValue(_modDescriptionAttributeName);
            mod.GameVersion = infoRoot.Descendant(_gameElementName).AttributeValue(_gameVersionAttributeName);

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
            // Save mod info
            XElement infoRoot = XElement.Load(_infoFilePath);
            infoRoot.Descendant(_modIdElementName).SetAttributeValue(_modIdAttributeName, mod.Id);
            infoRoot.Descendant(_modTitleElementName).SetAttributeValue(_modTitleAttributeName, mod.Title);
            infoRoot.Descendant(_modDescriptionElementName).SetAttributeValue(_modDescriptionAttributeName, mod.Description);
            infoRoot.Descendant(_gameElementName).SetAttributeValue(_gameNameAttributeName, mod.GameName);
            infoRoot.Descendant(_gameElementName).SetAttributeValue(_gameVersionAttributeName, mod.GameVersion);
            infoRoot.Save(_infoFilePath);

            // Save enemies
            _enemyParser.SaveEnemyInfo(mod);
        }

        private readonly string _modIdElementName = "mod";
        private readonly string _modIdAttributeName = "id";
        private readonly string _modTitleElementName = "title";
        private readonly string _modTitleAttributeName = "value";
        private readonly string _modDescriptionElementName = "description";
        private readonly string _modDescriptionAttributeName = "value";
        private readonly string _gameElementName = "game";
        private readonly string _gameNameAttributeName = "name";
        private readonly string _gameVersionAttributeName = "version";

        private readonly EnemyDirectoryParser _enemyParser;
        private readonly string _infoFilePath;
    }
}

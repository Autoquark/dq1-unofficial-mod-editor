using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using DQModEditor.DataModel;
using DQModEditor.DataModel.Enemies;
using DQModEditor.DataModel.Graphics;

namespace DQModEditor.Loader
{
    /// <summary>
    /// Manages saving and loading a mod to/from a directory on disk.
    /// </summary>
    public class ModLoader : DirectoryParserBase
    {
        /// <summary>
        /// Initializes a new ModLoader that manages the given mod folder.
        /// </summary>
        /// <param name="modPath"></param>
        public ModLoader(string modPath) : base(modPath)
        {
            if (!Directory.Exists(modPath)) throw new ModLoadException("The given path does not exist or is not a directory");

            _enemyLoader = new EnemyDataLoader(modPath);
            _enemyGraphicsLoader = new EnemyGraphicsDataLoader(modPath);
            _infoFilePath = Path.Combine(ModDirectoryPath, "settings.xml");

            XElement infoRoot = XElement.Load(_infoFilePath);
            string modId = infoRoot.Descendant(_modIdElementName).AttributeValue(_modIdAttributeName);
            string gameName = infoRoot.Descendant(_gameElementName).AttributeValue(_gameNameAttributeName);
            LoadedMod = new Mod(modId, gameName);

            Load();
        }

        /// <summary>
        /// Gets the currently loaded mod data.
        /// </summary>
        public Mod LoadedMod { get; }

        /// <summary>
        /// Edits the Mod object from the contents of the mod directory, discarding any changes made to the object in memory.
        /// </summary>
        /// <returns></returns>
        public void Load()
        {
            // Load mod info
            XElement infoRoot = XElement.Load(_infoFilePath);
            LoadedMod.Title = infoRoot.Descendant(_modTitleElementName).AttributeValue(_modTitleAttributeName);
            LoadedMod.Description = infoRoot.Descendant(_modDescriptionElementName).AttributeValue(_modDescriptionAttributeName);
            LoadedMod.GameVersion = infoRoot.Descendant(_gameElementName).AttributeValue(_gameVersionAttributeName);

            // Load enemies
            _enemyLoader.LoadEnemyInfo(LoadedMod);
            // Load enemy graphics
            _enemyGraphicsLoader.LoadEnemyGraphicsInfo(LoadedMod);
        }

        /// <summary>
        /// Saves changes made to the Mod object to the mod directory. 
        /// </summary>
        /// <remarks>
        /// Changes are merged into existing files so that any additional files in the mod directory or additional XML content in XML
        /// files is preserved.
        /// </remarks>
        /// <param name="_mod"></param>
        public void StableSave()
        {
            // Save mod info
            XElement infoRoot = XElement.Load(_infoFilePath);
            infoRoot.Descendant(_modIdElementName).SetAttributeValue(_modIdAttributeName, LoadedMod.Id);
            infoRoot.Descendant(_modTitleElementName).SetAttributeValue(_modTitleAttributeName, LoadedMod.Title);
            infoRoot.Descendant(_modDescriptionElementName).SetAttributeValue(_modDescriptionAttributeName, LoadedMod.Description);
            infoRoot.Descendant(_gameElementName).SetAttributeValue(_gameNameAttributeName, LoadedMod.GameName);
            infoRoot.Descendant(_gameElementName).SetAttributeValue(_gameVersionAttributeName, LoadedMod.GameVersion);
            infoRoot.Save(_infoFilePath);

            // Save enemies
            _enemyLoader.StableSave(LoadedMod);
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

        private readonly EnemyDataLoader _enemyLoader;
        private readonly EnemyGraphicsDataLoader _enemyGraphicsLoader;
        private readonly string _infoFilePath;
    }
}

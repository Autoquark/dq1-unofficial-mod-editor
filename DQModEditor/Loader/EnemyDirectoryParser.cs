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
using DataModel;
using DQModEditor.Model;
using static DQModEditor.Model.Enemy;

namespace DQModEditor.Loader
{
    /// <summary>
    /// Saves/loads information relating to enemy types to/from a mod directory
    /// </summary>
    internal class EnemyDirectoryParser : DirectoryParserBase
    {
        public EnemyDirectoryParser(string modPath) : base(modPath)
        {
            _enemyXmlPath = Path.Combine(ModDirectoryPath, "xml", "enemy.xml");
        }

        public void LoadEnemyInfo(Mod mod)
        {
            string path = Path.Combine(ModDirectoryPath, _enemyXmlPath);
            if (!File.Exists(path)) return;
            XElement enemyRoot = XElement.Load(path);
            foreach (XElement e in GetEnemyDefinitions(enemyRoot)) mod.AddEnemy(CreateEnemyFromXml(e));
        }

        public void SaveEnemyInfo(Mod mod)
        {
            XElement enemyRoot = XElement.Load(Path.Combine(ModDirectoryPath, _enemyXmlPath));
            //Remove enemy definitions from the XML that are not present in the Mod
            foreach (XElement enemyXml in GetEnemyDefinitions(enemyRoot).ToList())
            {
                if (mod.GetEnemyByIdOrNull(enemyXml.AttributeValue("name")) == null) enemyXml.Remove();
            }
            //Edit/add enemy definitions to the XML that are present in the mod
            foreach (Enemy enemy in mod.EnemiesByInternalName.Values)
            {
                EditXmlFromEnemy(enemy, GetEnemyDefinition(enemyRoot, enemy.InternalName));
            }

            enemyRoot.Save(_enemyXmlPath);
        }

        private IEnumerable<XElement> GetEnemyDefinitions(XElement enemyRoot)
        {
            foreach (XElement enemyXml in enemyRoot.Descendants("enemy"))
            {
                yield return enemyXml;
            }
        }

        private XElement GetEnemyDefinition(XElement enemyRoot, string id)
        {
            return enemyRoot.Descendants("enemy").Where(x => x.AttributeValue("name") == id).Single();
        }

        private Enemy CreateEnemyFromXml(XElement enemyRoot)
        {
            // Name & Description
            Enemy enemy = new Enemy(enemyRoot.AttributeValue(_internalNameAttributeName));
            enemy.DisplayName = enemyRoot.AttributeValue(_displayNameAttributeName);
            XElement flavorElement = enemyRoot.Descendants(_flavorElementName).Single();
            enemy.FlavorName = flavorElement.AttributeValue(_flavorNameAttributeName);
            enemy.FlavorDescription = flavorElement.AttributeValue(_flavorDescriptionAttributeName);

            // Sound & Graphics
            enemy.DeathSound = enemyRoot.Descendants("sounds").SingleOrDefault()?.AttributeValue("death");
            XElement graphicsElement = enemyRoot.Descendants("graphic").Single();
            enemy.GraphicId = graphicsElement.AttributeValue("id");
            enemy.GraphicSkinId = graphicsElement.AttributeValueOrNull("skin");

            // Stats
            enemy.BaseStats.SetFrom(CreateStatSetFromXml(enemyRoot.Descendants(_statsElementName).Single()));
            enemy.LevelUpIncrement.SetFrom(CreateStatSetFromXml(enemyRoot.Descendants(_levelupElementName).Single()));

            // Immunities
            XElement immunitiesRoot = enemyRoot.Descendants(_immunityListElementName).SingleOrDefault();
            if(immunitiesRoot != null)
            {
                foreach (XElement immunityElement in immunitiesRoot.Descendants(_immunityElementName))
                {
                    enemy.AddImmunity(immunityElement.AttributeValue(_immunityAttributeName));
                }
            }

            // Select Box Offset
            XElement offsetElement = enemyRoot.Descendants(_selectBoxOffsetElementName).SingleOrDefault();
            if (offsetElement != null) enemy.SelectBoxOffset = new Point(int.Parse(offsetElement.AttributeValue("x")),
                 int.Parse(offsetElement.AttributeValue("y")));
            // Types
            foreach (XElement e in enemyRoot.Descendants(_typeElementName)) enemy.AddType(e.AttributeValue(_typeAttributeName));
            // Spawns
            foreach (XElement spawnElement in enemyRoot.Descendants(_spawnsElementName))
            {
                string spawnId = spawnElement.AttributeValue(_spawnIdAttributeName);
                string effectId = spawnElement.AttributeValueOrNull(_spawnEffectIdAttributeName);

                foreach (XElement locationElement in spawnElement.Descendants(_spawnLocationElementName))
                {
                    decimal x = decimal.Parse(locationElement.AttributeValue("x"));
                    decimal y = decimal.Parse(locationElement.AttributeValue("y"));
                    enemy.Spawns.Add(new SpawnInfo { SpawnId = spawnId, Location = new SpawnInfo.SpawnLocation(x, y) });
                    enemy.Spawns.Last().EffectId = effectId;
                }
            }
            return enemy;
        }

        private StatSet CreateStatSetFromXml(XElement statsRoot)
        {
            StatSet statSet = new StatSet();
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            statSet.Armor = decimal.Parse(statsRoot.AttributeValue(_armorAttributeName), cultureInfo);
            statSet.Hp = int.Parse(statsRoot.AttributeValue(_hpAttributeName), cultureInfo);
            statSet.Scrap = decimal.Parse(statsRoot.AttributeValue(_scrapAttributeName), cultureInfo);
            statSet.Speed = decimal.Parse(statsRoot.AttributeValue(_speedAttributeName), cultureInfo);
            statSet.Strength = decimal.Parse(statsRoot.AttributeValue(_strengthAttributeName), cultureInfo);
            statSet.Psi = decimal.Parse(statsRoot.AttributeValue(_psiAttributeName), cultureInfo);
            statSet.Xp = decimal.Parse(statsRoot.AttributeValue(_xpAttributeName), cultureInfo);
            return statSet;
        }

        /// <summary>
        /// Modifies the given xml tree, whose root should be an "enemy" element whose "name" attribute matches the id of the given enemy,
        /// so that the XML data matches the data in the given Enemy. Any additional unrecognised XML information will be preserved.
        /// </summary>
        /// <param name="enemy"></param>
        /// <param name="xmlRoot"></param>
        private void EditXmlFromEnemy(Enemy enemy, XElement enemyRoot)
        {
            if (enemyRoot.AttributeValue("name") != enemy.InternalName) throw new ModLoadException();

            // Name & Description
            enemyRoot.SetAttributeValue(_displayNameAttributeName, enemy.DisplayName);
            XElement flavorElement = enemyRoot.Descendants(_flavorElementName).Single();
            flavorElement.SetAttributeValue(_flavorNameAttributeName, enemy.FlavorName);
            flavorElement.SetAttributeValue(_flavorDescriptionAttributeName, enemy.FlavorDescription);
            // Stats
            EditXmlFromStatSet(enemy.BaseStats, enemyRoot.Descendants(_statsElementName).Single());
            EditXmlFromStatSet(enemy.LevelUpIncrement, enemyRoot.Descendants(_levelupElementName).Single());
            // Types
            foreach (XElement typeElement in enemyRoot.Descendants(_typeElementName).ToList()) typeElement.Remove();
            foreach (string type in enemy.Types.Keys)
            {
                XElement typeElement = new XElement(XName.Get(_typeElementName));
                typeElement.SetAttributeValue(_typeAttributeName, type);
                enemyRoot.Add(typeElement);
            }
            // Immunities
            XElement immunityListElement = enemyRoot.Descendants(_immunityListElementName).SingleOrDefault();
            if (immunityListElement == null)
            {
                immunityListElement = new XElement(XName.Get(_immunityListElementName));
                enemyRoot.Add(immunityListElement);
            }
            foreach (XElement immunityElement in immunityListElement.Descendants(_immunityElementName).ToList()) immunityElement.Remove();
            foreach(string immunity in enemy.Immunities.Keys)
            {
                XElement immunityElement = new XElement(XName.Get(_immunityElementName));
                immunityElement.SetAttributeValue(_immunityAttributeName, immunity);
                immunityListElement.Add(immunityElement);
            }
            // Spawns
            EditSpawnsFromSpawnInfoList(enemy.Spawns, enemyRoot);
        }

        private void EditSpawnsFromSpawnInfoList(IList<SpawnInfo> infoList, XElement enemyRoot)
        {
            //Remove existing spawns and rewrite. This won't preserve any information in the existing spawn definitions that we
            //don't understand, but there's no clear way to define having edited a spawn vs removed it and added another, so this
            //is the best we can do.
            foreach (XElement spawnElement in enemyRoot.Descendants(_spawnsElementName).ToList()) spawnElement.Remove();

            //Group spawns with the same id and effect, as we can use a single spawn element for them.
            foreach(IGrouping<Tuple<string, string>, SpawnInfo> spawnGroup in infoList.GroupBy(x => Tuple.Create(x.SpawnId, x.EffectId)))
            {
                XElement spawnElement = new XElement(XName.Get(_spawnsElementName));
                spawnElement.SetAttributeValue(_spawnIdAttributeName, spawnGroup.Key.Item1);
                spawnElement.SetAttributeValue(_spawnEffectIdAttributeName, spawnGroup.Key.Item2);
                foreach (SpawnInfo info in spawnGroup)
                {
                    XElement locationElement = new XElement(XName.Get(_spawnLocationElementName));
                    locationElement.SetAttributeValue("x", info.Location.X);
                    locationElement.SetAttributeValue("y", info.Location.Y);
                    spawnElement.Add(locationElement);
                }
                enemyRoot.Add(spawnElement);
            }
        }

        private void EditXmlFromStatSet(StatSet statSet, XElement statSetRoot)
        {
            statSetRoot.SetAttributeValue(_armorAttributeName, statSet.Armor);
            statSetRoot.SetAttributeValue(_hpAttributeName, statSet.Hp);
            statSetRoot.SetAttributeValue(_scrapAttributeName, statSet.Scrap);
            statSetRoot.SetAttributeValue(_speedAttributeName, statSet.Speed);
            statSetRoot.SetAttributeValue(_strengthAttributeName, statSet.Strength);
            statSetRoot.SetAttributeValue(_psiAttributeName, statSet.Psi);
            statSetRoot.SetAttributeValue(_xpAttributeName, statSet.Xp);
        }

        private readonly string _enemyXmlPath;
        // Name & Description
        private readonly static string _internalNameAttributeName = "name";
        private readonly static string _displayNameAttributeName = "nick";
        private readonly static string _flavorElementName = "flavor";
        private readonly static string _flavorNameAttributeName = "name";
        private readonly static string _flavorDescriptionAttributeName = "text";
        // Stats
        private readonly static string _statsElementName = "stats";
        private readonly static string _levelupElementName = "levelup";

        private readonly static string _armorAttributeName = "armor";
        private readonly static string _hpAttributeName = "hp";
        private readonly static string _scrapAttributeName = "gold";
        private readonly static string _speedAttributeName = "speed";
        private readonly static string _strengthAttributeName = "str";
        private readonly static string _psiAttributeName = "psi";
        private readonly static string _xpAttributeName = "xp";
        // Select Box Offset
        private readonly static string _selectBoxOffsetElementName = "select_box_offset";
        // Immunities
        private readonly static string _immunityListElementName = "immunities";
        private readonly static string _immunityElementName = "immune";
        private readonly static string _immunityAttributeName = "value";
        // Type
        private readonly static string _typeElementName = "type";
        private readonly static string _typeAttributeName = "value";
        // Spawns
        private readonly static string _spawnsElementName = "spawn";
        private readonly static string _spawnIdAttributeName = "id";
        private readonly static string _spawnEffectIdAttributeName = "effect";
        private readonly static string _spawnLocationElementName = "loc";
    }
}

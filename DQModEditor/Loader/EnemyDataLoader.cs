using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DQModEditor.DataModel;
using DQModEditor.DataModel.Enemies;

namespace DQModEditor.Loader
{
    /// <summary>
    /// Saves/loads information relating to enemy types to/from a mod directory
    /// </summary>
    internal class EnemyDataLoader : DirectoryParserBase
    {
        public EnemyDataLoader(string modPath) : base(modPath)
        {
            _enemyXmlPath = Path.Combine(ModDirectoryPath, "xml", "enemy.xml");
            _enemyPlusXmlPath = Path.Combine(ModDirectoryPath, "xml", "enemy_plus.xml");
        }

        public void LoadEnemyInfo(Mod mod)
        {
            // Load normal enemies
            if (File.Exists(_enemyXmlPath))
            {
                foreach (XElement e in GetEnemyDefinitions(XElement.Load(_enemyXmlPath)))
                {
                    Enemy enemy = CreateEnemyFromXml(e);
                    if (enemy.IsNewGamePlus) throw new ModLoadException($"Enemy {enemy.Id} has an id with the "
                        + $"{Enemy.NewGamePlusIdSuffix} suffix but is declared in enemy.xml. New Game plus enemies should use the "
                        + $"{Enemy.NewGamePlusIdSuffix} suffix and be declared in enemy_plus.xml. Normal enemies should not use the"
                        + $"suffix and be declard in enemy.xml");
                    mod.EnemiesById.Add(enemy);
                }
            }

            // Load NG+ enemies
            if (File.Exists(_enemyPlusXmlPath))
            {
                foreach (XElement e in GetEnemyDefinitions(XElement.Load(_enemyPlusXmlPath)))
                {
                    Enemy enemy = CreateEnemyFromXml(e);
                    if (!enemy.IsNewGamePlus) throw new ModLoadException($"Enemy {enemy.Id} has an id without the "
                        + $"{Enemy.NewGamePlusIdSuffix} suffix but is declared in enemy_plus.xml. New Game plus enemies should use the "
                        + $"{Enemy.NewGamePlusIdSuffix} suffix and be declared in enemy_plus.xml. Normal enemies should not use the"
                        + $"suffix and be declard in enemy.xml");
                    mod.EnemiesById.Add(enemy);
                }
            }
        }

        public void StableSave(Mod mod, StableSaveTracker tracker)
        {
            XElement normalRoot = XElement.Load(_enemyXmlPath);
            XElement plusRoot = XElement.Load(_enemyPlusXmlPath);

            foreach (KeyValuePair<string, string> pair in tracker.ClonedEnemies)
            {
                XElement templateXml;
                if (Enemy.IdIsNewGamePlus(pair.Value)) templateXml = GetEnemyDefinition(plusRoot, pair.Value);
                else templateXml = new XElement(GetEnemyDefinition(normalRoot, pair.Value));

                templateXml.SetAttributeValue(_idAttributeName, pair.Key);
                if (Enemy.IdIsNewGamePlus(pair.Key)) AddEnemyDefinition(plusRoot, templateXml);
                else AddEnemyDefinition(normalRoot, templateXml);
            }

            // Save normal
            EditXmlFromEnemies(mod.EnemiesById.Values.Where(x => !x.IsNewGamePlus).ToDictionary(x => x.Id), normalRoot);
            normalRoot.Save(_enemyXmlPath);

            // Save NG+ enemies
            EditXmlFromEnemies(mod.EnemiesById.Values.Where(x => x.IsNewGamePlus).ToDictionary(x => x.Id), plusRoot);
            plusRoot.Save(_enemyPlusXmlPath);
        }

        private void EditXmlFromEnemies(IReadOnlyDictionary<string, Enemy> enemies, XElement root)
        {
            //Remove enemy definitions from the XML that are not present in the Mod
            foreach (XElement enemyXml in GetEnemyDefinitions(root).ToList())
            {
                if (!enemies.ContainsKey(enemyXml.AttributeValue(_idAttributeName))) enemyXml.Remove();
            }
            //Edit/add enemy definitions to the XML that are present in the mod
            foreach (Enemy enemy in enemies.Values)
            {
                EditXmlFromEnemy(enemy, GetEnemyDefinition(root, enemy.Id));
            }
        }

        private IEnumerable<XElement> GetEnemyDefinitions(XElement enemyRoot)
        {
            foreach (XElement enemyXml in enemyRoot.Descendants("enemy"))
            {
                yield return enemyXml;
            }
        }

        private XElement GetEnemyDefinition(XElement enemyRoot, string id) 
            => GetEnemyDefinitions(enemyRoot).Where(x => x.AttributeValue(_idAttributeName) == id).Single();

        private Enemy CreateEnemyFromXml(XElement root)
        {
            // Name & Description
            Enemy enemy = new Enemy(root.AttributeValue(_idAttributeName));
            enemy.DisplayName = root.AttributeValue(_displayNameAttributeName);
            XElement flavorElement = root.Descendant(_flavorElementName);
            enemy.FlavorName = flavorElement.AttributeValue(_flavorNameAttributeName);
            enemy.FlavorDescription = flavorElement.AttributeValue(_flavorDescriptionAttributeName);

            // Sound & Graphics
            enemy.DeathSound = root.Descendant(_soundsElementName)?.AttributeValue(_deathSoundAttributeName);
            XElement graphicsElement = root.Descendant(_graphicElementName);
            enemy.GraphicId = graphicsElement.AttributeValue(_graphicIdAttributeName);
            enemy.GraphicSkinId = graphicsElement.AttributeValueOrNull(_graphicSkinAttributeName);
            XElement offsetElement = root.Descendant(_selectBoxOffsetElementName);
            if (offsetElement != null) enemy.SelectBoxOffset = CreatePointFromXml(offsetElement);
            XElement effectOffsetsElement = root.Descendant(_effectOffsetListElementName);
            if(effectOffsetsElement != null)
            {
                foreach(XElement e in effectOffsetsElement.Descendants(_effectOffsetElementName))
                    enemy.EffectOffsets.Add(e.AttributeValue(_effectOffsetsIdAttributeName), CreatePointFromXml(e));
            }
            foreach(string colorString in root.Descendants(_colorElementName).Select(x => x.AttributeValue(_colorAttributeName)))
            {
                Color c = ParseColor(colorString);
                if (c == Color.Empty) throw new ModLoadException($"Invalid color string in definition of enemy {enemy.Id}");
                enemy.Colors.Add(c);
            }

            // Stats
            enemy.BaseStats.SetFrom(CreateStatSetFromXml(root.Descendant(_statsElementName)));
            enemy.LevelUpIncrement.SetFrom(CreateStatSetFromXml(root.Descendant(_levelupElementName)));

            // Immunities
            XElement immunitiesRoot = root.Descendant(_immunityListElementName);
            if(immunitiesRoot != null)
            {
                foreach (XElement immunityElement in immunitiesRoot.Descendants(_immunityElementName))
                {
                    enemy.Immunities.Add(immunityElement.AttributeValue(_immunityAttributeName));
                }
            }
            
            // Resistances
            foreach(XElement resistanceElement in root.Descendants(_resistanceElementName))
            {
                Resistance resistance = new Resistance();
                resistance.Flavor = resistanceElement.AttributeValue(_resistanceFlavorAttributeName);
                resistance.Amount = decimal.Parse(resistanceElement.AttributeValue(_resistanceAmountAttributeName));
                string kind = resistanceElement.AttributeValue(_resistanceKindAttributeName);
                // Dictionary is only two items, reverse lookup efficiency is not an issue.
                resistance.ResistanceKind = _resistanceKindToString.Where(x => x.Value == kind).Single().Key;
                enemy.Resistances.Add(resistance);
            }

            // Types
            foreach (XElement e in root.Descendants(_typeElementName)) enemy.Types.Add(e.AttributeValue(_typeAttributeName));
            // Spawns
            foreach (XElement spawnElement in root.Descendants(_spawnsElementName))
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

        private Point CreatePointFromXml(XElement root) => 
            new Point(int.Parse(root.AttributeValue("x")), int.Parse(root.AttributeValue("y")));

        private StatSet CreateStatSetFromXml(XElement root)
        {
            StatSet statSet = new StatSet();
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            statSet.Armor = decimal.Parse(root.AttributeValue(_armorAttributeName), cultureInfo);
            statSet.Hp = int.Parse(root.AttributeValue(_hpAttributeName), cultureInfo);
            statSet.Scrap = decimal.Parse(root.AttributeValue(_scrapAttributeName), cultureInfo);
            statSet.Speed = decimal.Parse(root.AttributeValue(_speedAttributeName), cultureInfo);
            statSet.Strength = decimal.Parse(root.AttributeValue(_strengthAttributeName), cultureInfo);
            statSet.Psi = decimal.Parse(root.AttributeValue(_psiAttributeName), cultureInfo);
            statSet.Xp = decimal.Parse(root.AttributeValue(_xpAttributeName), cultureInfo);
            return statSet;
        }

        private void AddEnemyDefinition(XElement enemyRoot, XElement enemy) => enemyRoot.Descendant(_contentElementName).Add(enemy);

        /// <summary>
        /// Modifies the given xml tree, whose root should be an "enemy" element whose "name" attribute matches the id of the given enemy,
        /// so that the XML data matches the data in the given Enemy. Any additional unrecognised XML information will be preserved.
        /// </summary>
        /// <param name="enemy"></param>
        /// <param name="xmlRoot"></param>
        private void EditXmlFromEnemy(Enemy enemy, XElement root)
        {
            if (root.AttributeValue(_idAttributeName) != enemy.Id) throw new ModLoadException();

            // Name & Description
            root.SetAttributeValue(_displayNameAttributeName, enemy.DisplayName);
            XElement flavorElement = root.Descendant(_flavorElementName);
            flavorElement.SetAttributeValue(_flavorNameAttributeName, enemy.FlavorName);
            flavorElement.SetAttributeValue(_flavorDescriptionAttributeName, enemy.FlavorDescription);

            // Sound & Graphics
            EditXmlFromPoint(enemy.SelectBoxOffset, root.EnsureDescendant(_selectBoxOffsetElementName));
            root.EnsureDescendant(_soundsElementName).SetAttributeValue(_deathSoundAttributeName, enemy.DeathSound);
            root.EnsureDescendant(_graphicElementName).SetAttributeValue(_graphicIdAttributeName, enemy.GraphicId);
            root.Descendant(_graphicElementName).SetAttributeValue(_graphicSkinAttributeName, enemy.GraphicSkinId);

            XElement offsetListElement = root.EnsureDescendant(_effectOffsetListElementName);
            foreach (XElement e in offsetListElement.Descendants(_effectOffsetElementName).ToList()) e.Remove();
            foreach (KeyValuePair<string, Point> offset in enemy.EffectOffsets)
            {
                XElement offsetElement = new XElement(XName.Get(_effectOffsetElementName));
                offsetElement.SetAttributeValue(_effectOffsetsIdAttributeName, offset.Key);
                EditXmlFromPoint(offset.Value, offsetElement);
                offsetListElement.Add(offsetElement);
            }
            foreach (XElement e in root.Descendants(_colorElementName).ToList()) e.Remove();
            foreach(Color color in enemy.Colors)
            {
                XElement colorElement = new XElement(XName.Get(_colorElementName));
                colorElement.SetAttributeValue(_colorAttributeName, FormatColor(color));
                root.Add(colorElement);
            }

            // Stats
            EditXmlFromStatSet(enemy.BaseStats, root.Descendant(_statsElementName));
            EditXmlFromStatSet(enemy.LevelUpIncrement, root.Descendant(_levelupElementName));
            // Types
            foreach (XElement typeElement in root.Descendants(_typeElementName).ToList()) typeElement.Remove();
            foreach (string type in enemy.Types)
            {
                XElement typeElement = new XElement(XName.Get(_typeElementName));
                typeElement.SetAttributeValue(_typeAttributeName, type);
                root.Add(typeElement);
            }
            // Immunities
            XElement immunityListElement = root.EnsureDescendant(_immunityListElementName);
            foreach (XElement e in immunityListElement.Descendants(_immunityElementName).ToList()) e.Remove();
            foreach(string immunity in enemy.Immunities)
            {
                XElement immunityElement = new XElement(XName.Get(_immunityElementName));
                immunityElement.SetAttributeValue(_immunityAttributeName, immunity);
                immunityListElement.Add(immunityElement);
            }
            // Resistances
            foreach (XElement e in root.Descendants(_resistanceElementName).ToList()) e.Remove();
            foreach(Resistance resistance in enemy.Resistances)
            {
                XElement resistanceElement = new XElement(XName.Get(_resistanceElementName));
                resistanceElement.SetAttributeValue(_resistanceFlavorAttributeName, resistance.Flavor);
                resistanceElement.SetAttributeValue(_resistanceKindAttributeName, _resistanceKindToString[resistance.ResistanceKind]);
                resistanceElement.SetAttributeValue(_resistanceAmountAttributeName, resistance.Amount);
                root.Add(resistanceElement);
            }
            // Spawns
            EditSpawnsFromSpawnInfoList(enemy.Spawns, root);
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

        private void EditXmlFromPoint(Point point, XElement root)
        {
            root.SetAttributeValue("x", point.X);
            root.SetAttributeValue("y", point.Y);
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

        private Color ParseColor(string text)
        {
            try
            {
                return Color.FromArgb(255, Color.FromArgb(Convert.ToInt32(text, 16)));
            }
            catch(FormatException) { return Color.Empty; }
        }

        private string FormatColor(Color color)
        {
            return $"0x{color.R.ToString("X2")}{color.G.ToString("X2")}{color.B.ToString("X2")}";
        }

        private readonly string _enemyXmlPath;
        private readonly string _enemyPlusXmlPath;

        private readonly static string _contentElementName = "enemy_data";
        private readonly static string _enemyElementName = "enemy";
        // Name & Description
        private readonly static string _idAttributeName = "name";
        private readonly static string _displayNameAttributeName = "nick";
        private readonly static string _flavorElementName = "flavor";
        private readonly static string _flavorNameAttributeName = "name";
        private readonly static string _flavorDescriptionAttributeName = "text";
        // Sound & Graphics
        private readonly static string _selectBoxOffsetElementName = "select_box_offset";
        private readonly static string _graphicElementName = "graphic";
        private readonly static string _graphicIdAttributeName = "id";
        private readonly static string _graphicSkinAttributeName = "skin";
        private readonly static string _soundsElementName = "sounds";
        private readonly static string _deathSoundAttributeName = "death";
        private readonly static string _effectOffsetListElementName = "effect_offset";
        private readonly static string _effectOffsetElementName = "effect";
        private readonly static string _effectOffsetsIdAttributeName = "id";
        private readonly static string _colorElementName = "color";
        private readonly static string _colorAttributeName = "value";
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
        // Immunities
        private readonly static string _immunityListElementName = "immunities";
        private readonly static string _immunityElementName = "immune";
        private readonly static string _immunityAttributeName = "value";
        // Resistances
        private readonly static string _resistanceElementName = "strong";
        private readonly static string _resistanceFlavorAttributeName = "value";
        private readonly static string _resistanceKindAttributeName = "effect";
        private readonly static string _resistanceAmountAttributeName = "amount";
        private readonly static IReadOnlyDictionary<Resistance.Kind, string> _resistanceKindToString
            = new Dictionary<Resistance.Kind, string> { { Resistance.Kind.DamageMultiplier, "dmg_mult" },
                { Resistance.Kind.Evade, "evade" } };
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

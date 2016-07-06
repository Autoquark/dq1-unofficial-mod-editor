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

namespace DQModEditor.Model
{
    /// <summary>
    /// Represents an enemy type definition.
    /// </summary>
    public class Enemy
    {
        internal static IList<Enemy> LoadEnemies(string modPath)
        {
            XmlReader reader = XmlReader.Create(Path.Combine(modPath, "xml", "enemy.xml"));
            while (reader.NodeType != XmlNodeType.Element) reader.Read();
            XElement enemiesRoot = XElement.Load(reader).Descendants("enemy_data").Single();

            List<Enemy> enemies = new List<Enemy>();
            foreach(XElement enemyXml in enemiesRoot.Descendants("enemy"))
            {
                // Name & Description
                Enemy enemy = new Enemy(enemyXml.AttributeValue("name"));
                enemy.DisplayName = enemyXml.AttributeValue("nick");
                XElement flavorElement = enemyXml.Descendants("flavor").Single();
                enemy.FlavorName = flavorElement.AttributeValue("name");
                enemy.FlavorDescription = flavorElement.AttributeValue("text");

                // Sound & Graphics
                enemy.DeathSound = enemyXml.Descendants("sounds").SingleOrDefault()?.AttributeValue("death");
                XElement graphicsElement = enemyXml.Descendants("graphic").Single();
                enemy.GraphicId = graphicsElement.AttributeValue("id");
                enemy.GraphicSkinId = graphicsElement.AttributeValueOrNull("skin");

                // Stats
                XElement statsElement = enemyXml.Descendants("stats").Single();
                CultureInfo cultureInfo = CultureInfo.InvariantCulture;
                enemy.BaseArmor = decimal.Parse(statsElement.AttributeValue("armor"), cultureInfo);
                enemy.BaseStrength = decimal.Parse(statsElement.AttributeValue("str"), cultureInfo);
                enemy.BaseHp = int.Parse(statsElement.AttributeValue("hp"), cultureInfo);
                enemy.BaseScrap = decimal.Parse(statsElement.AttributeValue("gold"), cultureInfo);
                enemy.BaseSpeed = decimal.Parse(statsElement.AttributeValue("speed"), cultureInfo);
                enemy.BaseXp = decimal.Parse(statsElement.AttributeValue("xp"), cultureInfo);

                statsElement = enemyXml.Descendants("levelup").Single();
                enemy.ArmourPerLevel = decimal.Parse(statsElement.AttributeValue("armor"), cultureInfo);
                enemy.StrengthPerLevel = decimal.Parse(statsElement.AttributeValue("str"), cultureInfo);
                enemy.HpPerLevel = int.Parse(statsElement.AttributeValue("hp"), cultureInfo);
                enemy.ScrapPerLevel = decimal.Parse(statsElement.AttributeValue("gold"), cultureInfo);
                enemy.SpeedPerLevel = decimal.Parse(statsElement.AttributeValue("speed"), cultureInfo);
                enemy.XpPerLevel = decimal.Parse(statsElement.AttributeValue("xp"), cultureInfo);

                // Misc
                XElement offsetElement = enemyXml.Descendants("select_box_offset").SingleOrDefault();
                if (offsetElement != null) enemy.SelectBoxOffset = new Point(int.Parse(offsetElement.AttributeValue("x")),
                     int.Parse(offsetElement.AttributeValue("y")));
                foreach (XElement e in enemyXml.Descendants("type")) enemy.Types.Add(e.AttributeValue("value"));
                foreach (XElement spawnElement in enemyXml.Descendants("spawn"))
                {
                    string spawnId = spawnElement.AttributeValue("id");
                    string effectId = spawnElement.AttributeValueOrNull("effect");

                    foreach (XElement locationElement in spawnElement.Descendants("loc"))
                    {
                        decimal x = decimal.Parse(locationElement.AttributeValue("x"));
                        decimal y = decimal.Parse(locationElement.AttributeValue("y"));
                        enemy.Spawns.Add(new SpawnInfo(spawnId, new SpawnInfo.SpawnLocation(x, y)));
                        enemy.Spawns.Last().EffectId = effectId;
                    }
                }

                enemies.Add(enemy);
            }

            return enemies;
        }

        private Enemy(string internalName)
        {
            InternalName = internalName;
        }

        //Name & Description
        public string InternalName { get; }
        public string DisplayName { get; set; }
        public string FlavorName { get; set; }
        public string FlavorDescription { get; set; }

        // Sound & Graphics
        public string DeathSound { get; set; }
        public string GraphicId { get; set; }
        public string GraphicSkinId { get; set; }

        //Stats
        public int BaseHp { get; set; }
        public int HpPerLevel { get; set; }
        public decimal BaseArmor { get; set; }
        public decimal ArmourPerLevel { get; set; }
        public decimal BaseSpeed { get; set; }
        public decimal SpeedPerLevel { get; set; }
        public decimal BaseStrength { get; set; }
        public decimal StrengthPerLevel { get; set; }
        public decimal BasePsi { get; set; }
        public decimal PsiPerLevel { get; set; }
        public decimal BaseScrap { get; set; }
        public decimal ScrapPerLevel { get; set; }
        public decimal BaseXp { get; set; }
        public decimal XpPerLevel { get; set; }

        // Misc
        public IList<string> Types { get; } = new List<string>();
        public Point SelectBoxOffset { get; set; }
        /// <summary>
        /// Contains 
        /// </summary>
        public IList<SpawnInfo> Spawns { get; } = new List<SpawnInfo>();
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DQModEditor.DataModel;
using DQModEditor.DataModel.Graphics;

namespace DQModEditor.Loader
{
    class EnemyGraphicsDataLoader : DirectoryParserBase
    {
        public EnemyGraphicsDataLoader(string modPath) : base(modPath)
        {
            _enemyGraphicsXmlDirectoryPath = Path.Combine(ModDirectoryPath, "xml", "entities", "enemies");
        }

        public void LoadEnemyGraphicsInfo(Mod mod)
        {
            foreach(string xmlPath in Directory.EnumerateFiles(_enemyGraphicsXmlDirectoryPath)
                .Where(x => Path.GetExtension(x) == ".xml"))
            {
                mod.EnemyGraphicsById.Add(CreateGraphicSetFromXml(XElement.Load(xmlPath), Path.GetFileNameWithoutExtension(xmlPath)));
            }
        }

        private GraphicSet CreateGraphicSetFromXml(XElement root, string fileName)
        {
            //The game currently uses the file name, not the id given in the xml. In addition, the id in the xml is given with one of
            // two different attributes. See https://waffle.io/larsiusprime/tdrpg-bugs/cards/579f91cd99a184f40108be86
            //XElement graphicsElement = root.Descendant(_graphicSetElementName);
            //GraphicSet graphics = new GraphicSet(graphicsElement.AttributeValueOrNull(_graphicSetIdAttributeName) 
            //    ?? graphicsElement.AttributeValue(_graphicSetIdAttributeName2));
            GraphicSet graphics = new GraphicSet(fileName);
            foreach (XElement skinElement in root.Descendants(_skinElementName))
            {
                Skin skin = new Skin(skinElement.AttributeValue(_skinIdAttributeName));
                skin.Width = int.Parse(skinElement.AttributeValue(_skinWidthAttributeName));
                skin.Height = int.Parse(skinElement.AttributeValue(_skinHeightAttributeName));
                foreach(XElement layerElement in skinElement.Descendants(_layerElementName)
                    .OrderBy(x => x.AttributeValue(_layerOrderAttributeName)))
                {
                    skin.Layers.Add(new SkinLayer(layerElement.AttributeValue(_layerNameAttributeName)));
                }
                graphics.SkinsById.Add(skin);
            }
            return graphics;
        }

        private readonly string _enemyGraphicsXmlDirectoryPath;
        // Graphic Set
        private readonly static string _graphicSetElementName = "graphic";
        private readonly static string _graphicSetIdAttributeName = "name";
        private readonly static string _graphicSetIdAttributeName2 = "id";
        // Skin
        private readonly static string _skinElementName = "skin";
        private readonly static string _skinIdAttributeName = "name";
        private readonly static string _skinWidthAttributeName = "width";
        private readonly static string _skinHeightAttributeName = "height";
        // Layer
        private readonly static string _layerElementName = "layer";
        private readonly static string _layerOrderAttributeName = "sort";
        private readonly static string _layerNameAttributeName = "name";
    }
}

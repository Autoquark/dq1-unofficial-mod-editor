using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DQModEditor.Model
{
    /// <summary>
    /// Static class providing extension methods to simplify parsing XML during mod loading.
    /// </summary>
    internal static class XmlExtensions
    {
        internal static string AttributeValue(this XElement element, string name)
        {
            return element.Attribute(XName.Get(name)).Value;
        }

        internal static string AttributeValueOrNull(this XElement element, string name)
        {
            return element.Attribute(XName.Get(name))?.Value;
        }

        internal static IEnumerable<XElement> Descendents(this XElement element, string name)
        {
            return element.Descendants(XName.Get(name));
        }
    }
}

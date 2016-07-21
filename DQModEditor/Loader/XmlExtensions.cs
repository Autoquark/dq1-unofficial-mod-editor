using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DQModEditor.Loader
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

        internal static void SetAttributeValue(this XElement element, string name, object value)
        {
            element.SetAttributeValue(XName.Get(name), value);
        }

        internal static IEnumerable<XElement> Descendants(this XElement element, string name)
        {
            return element.Descendants(XName.Get(name));
        }

        internal static XElement Descendant(this XElement element, string name)
        {
            return element.Descendants(name).SingleOrDefault();
        }

        internal static XElement EnsureDescendant(this XElement element, string name)
        {
            XElement e = element.Descendant(name);
            if (e == null)
            {
                e = new XElement(XName.Get(name));
                element.Add(e);
            }
            return e;
        }
    }
}

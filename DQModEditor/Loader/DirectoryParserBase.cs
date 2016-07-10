using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DQModEditor.Loader
{
    /// <summary>
    /// Base class for classes that parse/save information to/from a mod directory.
    /// </summary>
    public abstract class DirectoryParserBase
    {
        protected DirectoryParserBase(string modDirectoryPath)
        {
            ModDirectoryPath = modDirectoryPath;
        }

        protected string ModDirectoryPath { get; }
    }
}

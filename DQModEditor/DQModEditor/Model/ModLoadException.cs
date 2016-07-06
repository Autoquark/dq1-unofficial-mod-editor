using System;
using System.Runtime.Serialization;

namespace DQModEditor.Model
{
    /// <summary>
    /// Exception thrown when a problem occurs while loading a mod folder.
    /// </summary>
    [Serializable]
    internal class ModLoadException : Exception
    {
        public ModLoadException()
        {
        }

        public ModLoadException(string message) : base(message)
        {
        }

        public ModLoadException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ModLoadException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
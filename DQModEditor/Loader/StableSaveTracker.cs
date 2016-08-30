using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DQModEditor.DataModel;

namespace DQModEditor.Loader
{
    internal class StableSaveTracker
    {
        internal StableSaveTracker() { }

        internal void SetCloneSource(string clonedId, string templateId)
        {
            string s;
            // If the template was already cloned, mark clonedId as cloned from the original clone source.
            if (_clonedEnemies.TryGetValue(templateId, out s)) templateId = s;
            _clonedEnemies.Add(clonedId, templateId);
        }

        /// <summary>
        /// Maps cloned enemy ids to the id of the enemy they were cloned from, so that the XML can also be cloned.
        /// </summary>
        public IReadOnlyDictionary<string, string> ClonedEnemies => new ReadOnlyDictionary<string, string>(_clonedEnemies);

        private IDictionary<string, string> _clonedEnemies = new Dictionary<string, string>();
    }
}

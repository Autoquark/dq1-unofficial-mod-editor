using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DQModEditor.DataModel;
using DQModEditor.DataModel.Enemies;

namespace DQModEditor.Gui
{
    /// <summary>
    /// Contains additional information required by controls
    /// </summary>
    internal class DisplayContext
    {
        public DisplayContext(Mod mod)
        {
            CurrentMod = mod;

            EnemyIdAutoCompleteCollection = new AutoCompleteStringCollection();
            EnemyIdAutoCompleteCollection.AddRange(mod.EnemiesByInternalName.Keys.ToArray());
            mod.EnemyCollectionChanged += e =>
            {
                if (mod.EnemiesByInternalName.ContainsKey(e.Id)) EnemyIdAutoCompleteCollection.Add(e.Id);
                else EnemyIdAutoCompleteCollection.Remove(e.Id);
            };
        }

        /// <summary>
        /// Gets the Mod whose data this control is displaying.
        /// </summary>
        public Mod CurrentMod { get; }

        /// <summary>
        /// Gets an AutoCompleteStringCollection containing the ids of all enemies for the current mod.
        /// </summary>
        public AutoCompleteStringCollection EnemyIdAutoCompleteCollection { get; }
    }
}

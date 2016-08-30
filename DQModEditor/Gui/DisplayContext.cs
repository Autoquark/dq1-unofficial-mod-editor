using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DQModEditor.DataModel;
using DQModEditor.DataModel.Enemies;
using DQModEditor.Loader;

namespace DQModEditor.Gui
{
    /// <summary>
    /// Contains additional information required by controls
    /// </summary>
    internal class DisplayContext
    {
        public DisplayContext(ModLoader loader)
        {
            CurrentLoader = loader;

            EnemyIdAutoCompleteCollection = new AutoCompleteStringCollection();
            EnemyIdAutoCompleteCollection.AddRange(CurrentMod.EnemiesById.Keys.ToArray());
            CurrentMod.EnemiesById.CollectionChanged += (s, e) =>
            {
                if (e.Action == NotifyCollectionChangedAction.Reset) EnemyIdAutoCompleteCollection.Clear();
                if(e.OldItems != null) foreach (object o in e.OldItems) EnemyIdAutoCompleteCollection.Remove(((Enemy)o).Id);
                if(e.NewItems != null) foreach (object o in e.NewItems) EnemyIdAutoCompleteCollection.Add(((Enemy)o).Id);
            };
        }

        /// <summary>
        /// Gets the Mod whose data this control is displaying.
        /// </summary>
        public Mod CurrentMod => CurrentLoader.LoadedMod;

        public ModLoader CurrentLoader { get; }

        /// <summary>
        /// Gets an AutoCompleteStringCollection containing the ids of all enemies for the current mod.
        /// </summary>
        public AutoCompleteStringCollection EnemyIdAutoCompleteCollection { get; }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace DQModEditor.Model
{
    /// <summary>
    /// Represents a DQ1 mod.
    /// </summary>
    public class Mod
    {
        /// <summary>
        /// Creates an empty Mod.
        /// </summary>
        public Mod() { }

        public delegate void EnemyAddedHandler(Enemy enemy);
        public event EnemyAddedHandler EnemyAdded;

        public Enemy GetEnemyByIdOrNull(string id)
        {
            Enemy e;
            _enemiesByInternalName.TryGetValue(id, out e);
            return e;
        }

        public void AddEnemy(Enemy enemy)
        {
            _enemiesByInternalName.Add(enemy.InternalName, enemy);
            EnemyAdded?.Invoke(enemy);
        }

        private void Enemies_BeforeRemove(Enemy deletedItem)
        {
            _enemiesByInternalName.Remove(deletedItem.InternalName);
        }

        public IReadOnlyDictionary<string, Enemy> EnemiesByInternalName
        {
            get { return new ReadOnlyDictionary<string, Enemy>(_enemiesByInternalName);}
        }

        private SortedDictionary<string, Enemy> _enemiesByInternalName = new SortedDictionary<string, Enemy>();
    }
}

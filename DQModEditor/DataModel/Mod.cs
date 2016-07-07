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
        public Mod()
        {
            ExtendedBindingList<Enemy> enemies = new ExtendedBindingList<Enemy>();
            Enemies = enemies;
            Enemies.ListChanged += Enemies_ListChanged;
            enemies.BeforeRemove += Enemies_BeforeRemove;
        }

        private void Enemies_BeforeRemove(Enemy deletedItem)
        {
            _enemiesByInternalName.Remove(deletedItem.InternalName);
        }

        private void Enemies_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded) _enemiesByInternalName.Add(Enemies[e.NewIndex].InternalName, Enemies[e.NewIndex]);
            else if (e.ListChangedType == ListChangedType.Reset) _enemiesByInternalName.Clear();
        }

        public BindingList<Enemy> Enemies { get; }
        private Dictionary<string, Enemy> _enemiesByInternalName = new Dictionary<string, Enemy>();

        public Enemy GetEnemyByIdOrNull(string id)
        {
            Enemy e;
            _enemiesByInternalName.TryGetValue(id, out e);
            return e;
        }
    }
}

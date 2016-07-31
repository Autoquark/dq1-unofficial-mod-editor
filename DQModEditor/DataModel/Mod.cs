using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using DQModEditor.DataModel.Enemies;

namespace DQModEditor.DataModel
{
    /// <summary>
    /// Represents a DQ1 mod.
    /// </summary>
    public class Mod : INotifyPropertyChanged
    {
        /// <summary>
        /// Creates an empty Mod.
        /// </summary>
        public Mod(string id, string gameName)
        {
            Id = id;
            GameName = gameName;
        }

        public string Id { get; }
        public string GameName { get; }
        public string GameVersion {
            get { return _GameVersion; }
            set
            {
                if (_GameVersion == value) return;
                if (value == null) value = "";
                _GameVersion = value;
                NotifyPropertyChanged();
            }
        }
        private string _GameVersion = "";
        public string Title
        {
            get { return _Title; }
            set
            {
                if (_Title == value) return;
                if (value == null) value = "";
                _Title = value;
                NotifyPropertyChanged();
            }
        }
        private string _Title = "";
        public string Description
        {
            get { return _Description; }
            set
            {
                if (_Description == value) return;
                if (value == null) value = "";
                _Description = value;
                NotifyPropertyChanged();
            }
        }
        private string _Description = "";

        public delegate void EnemyAddedHandler(Enemy enemy);
        public event EnemyAddedHandler EnemyCollectionChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public void AddEnemy(Enemy enemy)
        {
            _enemiesByInternalName.Add(enemy.Id, enemy);
            EnemyCollectionChanged?.Invoke(enemy);
        }

        public Enemy GetCorrespondingEnemy(Enemy enemy)
        {
            string s = enemy.GetCorrespondingOtherModeId();
            if (s == null) return null;
            Enemy e;
            EnemiesByInternalName.TryGetValue(s, out e);
            return e;
        }

        public IReadOnlyDictionary<string, Enemy> EnemiesByInternalName 
            => new ReadOnlyDictionary<string, Enemy>(_enemiesByInternalName);
        private SortedDictionary<string, Enemy> _enemiesByInternalName = new SortedDictionary<string, Enemy>();

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

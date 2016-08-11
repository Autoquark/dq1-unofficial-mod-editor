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
using DQModEditor.DataModel.Collections;
using DQModEditor.DataModel.Enemies;
using DQModEditor.DataModel.Graphics;

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

        public event PropertyChangedEventHandler PropertyChanged;

        public Enemy GetCorrespondingEnemy(Enemy enemy)
        {
            if (!EnemiesById.Contains(enemy)) return null;
            Enemy e;
            EnemiesById.TryGetValue(enemy.NewGamePlusCorrespondingId, out e);
            return e;
        }

        public ObservableKeyedCollection<string, Enemy> EnemiesById { get; } 
            = ObservableKeyedCollection<string, Enemy>.CreateSorted(x => x.Id);

        public ObservableKeyedCollection<string, GraphicSet> EnemyGraphicsById { get; }
            = ObservableKeyedCollection<string, GraphicSet>.CreateSorted(x => x.Id);

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

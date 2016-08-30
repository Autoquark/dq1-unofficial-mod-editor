using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using DQModEditor.DataModel.Collections;

namespace DQModEditor.DataModel.Enemies
{
    /// <summary>
    /// Represents the definition for one enemy. The original and NG+ versions of an enemy are represented by separate Enemy objects.
    /// </summary>
    /// <remarks>Sealed because the copy mechanism would need to be adapted to handle subclasses correctly</remarks>
    public sealed class Enemy : INotifyPropertyChanged
    {
        public static string NewGamePlusIdSuffix => "_plus";

        public static bool IdIsNewGamePlus(string id) => id.EndsWith(NewGamePlusIdSuffix);

        public Enemy(string id) : this(null, id) { }

        private Enemy(Enemy source, string id)
        {
            Id = id;
            IsNewGamePlus = IdIsNewGamePlus(id);
            NewGamePlusCorrespondingId = IsNewGamePlus ? (Id.Substring(0, Id.Length - NewGamePlusIdSuffix.Length))
                : (Id + NewGamePlusIdSuffix);

            if(source != null)
            {
                // Name & Description
                DisplayName = source.DisplayName;
                FlavorName = source.FlavorName;
                FlavorDescription = source.FlavorDescription;

                // Sound
                DeathSound = source.DeathSound;

                // Graphics
                GraphicId = source.GraphicId;
                GraphicSkinId = source.GraphicSkinId;
                SelectBoxOffset = source.SelectBoxOffset;
                foreach (var o in source.EffectOffsets) EffectOffsets.Add(o);
                foreach (var o in source.Colors) Colors.Add(o);

                // Stats
                BaseStats.SetFrom(source.BaseStats);
                LevelUpIncrement.SetFrom(source.LevelUpIncrement);

                // Misc
                foreach (var o in source.Types) Types.Add(o);
                foreach (var o in source.Immunities) Immunities.Add(o);
                foreach (var o in source.Spawns) Spawns.Add(new SpawnInfo(o));
                foreach (var o in source.Resistances) Resistances.Add(new Resistance(o));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //Name & Description
        public string Id { get; }
        public string DisplayName
        {
            get { return _DisplayName; }
            set
            {
                if (_DisplayName == value) return;
                if (value == null) value = "";
                _DisplayName = value;
                NotifyPropertyChanged();
            }
        }
        private string _DisplayName = "";
        public string FlavorName {
            get { return _FlavorName; }
            set
            {
                if (_FlavorName == value) return;
                if (value == null) value = "";
                _FlavorName = value;
                NotifyPropertyChanged();
            }
        }
        private string _FlavorName = "";
        public string FlavorDescription
        {
            get { return _FlavorDescription; }
            set
            {
                if (_FlavorDescription == value) return;
                if (value == null) value = "";
                _FlavorDescription = value;
                NotifyPropertyChanged();
            }
        }
        private string _FlavorDescription = "";

        // Sound
        public string DeathSound
        {
            get { return _DeathSound; }
            set
            {
                if (_DeathSound == value) return;
                if (value == null) value = "";
                _DeathSound = value;
                NotifyPropertyChanged();
            }
        }
        private string _DeathSound = "";
        // Graphics
        public string GraphicId {
            get { return _GraphicId; }
            set
            {
                if (_GraphicId == value) return;
                if (value == null) value = "";
                _GraphicId = value;
                NotifyPropertyChanged();
            }
        }
        private string _GraphicId = "";
        public string GraphicSkinId {
            get { return _GraphicSkinId; }
            set
            {
                if (_GraphicSkinId == value) return;
                if (value == null) value = "";
                _GraphicSkinId = value;
                NotifyPropertyChanged();
            }
        }
        private string _GraphicSkinId = "";
        public Point SelectBoxOffset
        {
            get { return _SelectBoxOffset; }
            set
            {
                if (_SelectBoxOffset == value) return;
                _SelectBoxOffset = value;
                NotifyPropertyChanged();
            }
        }
        private Point _SelectBoxOffset;
        public ObservableDictionary<string, Point> EffectOffsets { get; } = new ObservableDictionary<string, Point>();
        public BindingList<Color> Colors { get; } = new BindingList<Color>();

        //Stats
        public StatSet BaseStats { get; } = new StatSet();
        public StatSet LevelUpIncrement { get; } = new StatSet();

        // Misc
        /// <summary>
        /// Gets a value indicating whether this is an NG+ or normal enemy.
        /// </summary>
        public bool IsNewGamePlus { get; }
        public string NewGamePlusCorrespondingId { get; }

        /// <summary>
        /// Gets the collection of types that this enemy is a member of.
        /// </summary>
        public ObservableSet<string> Types { get; } = new ObservableSet<string>(new SortedSet<string>());
        /// <summary>
        /// Gets the collection of flavors that this enemy is immune to.
        /// </summary>
        public ObservableSet<string> Immunities { get; } = new ObservableSet<string>(new SortedSet<string>());

        /// <summary>
        /// Gets the collection of objects describing the enemies spawned by this enemy upon death.
        /// </summary>
        public BindingList<SpawnInfo> Spawns { get; } = new BindingList<SpawnInfo>();
        /// <summary>
        /// Gets the collection of this enemy's resistances.
        /// </summary>
        public BindingList<Resistance> Resistances { get; } = new BindingList<Resistance>();

        public Enemy Copy(string id)
        {
            return new Enemy(this, id);
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
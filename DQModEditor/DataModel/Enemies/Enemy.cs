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

namespace DQModEditor.DataModel.Enemies
{
    /// <summary>
    /// Represents the definition for one enemy. The original and NG+ versions of an enemy are represented by separate Enemy objects.
    /// </summary>
    public class Enemy : INotifyPropertyChanged
    {
        public static string NewGamePlusIdSuffix => "_plus";

        public Enemy(string internalName)
        {
            Id = internalName;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event Action EffectOffsetsCollectionChanged;

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
        public ObservableDictionary<string, Point> EffectOffsets { get; } = new ObservableDictionary<string, Point>(new Dictionary<string, Point>());

        //Stats
        public StatSet BaseStats { get; } = new StatSet();
        public StatSet LevelUpIncrement { get; } = new StatSet();

        // Misc
        /// <summary>
        /// Gets or sets a value indicating whether this is an NG+ or normal enemy.
        /// </summary>
        public bool IsNewGamePlus {
            get { return _IsNewGamePlus; }
            set
            {
                if (_IsNewGamePlus == value) return;
                _IsNewGamePlus = value;
                NotifyPropertyChanged();
            }
        }
        private bool _IsNewGamePlus = false;

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

        public string GetCorrespondingOtherModeId()
        {
            if (IsNewGamePlus && !Id.EndsWith(NewGamePlusIdSuffix)) return null;
            if (IsNewGamePlus) return Id.Substring(0, Id.Length - NewGamePlusIdSuffix.Length).ToString();
            return Id + NewGamePlusIdSuffix;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

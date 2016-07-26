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
    /// Represents the definition for one variation of an enemy type: original, or New Game Plus.
    /// </summary>
    public class EnemyVariant : INotifyPropertyChanged
    {
        public EnemyVariant(string internalName)
        {
            InternalName = internalName;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public event Action TypesCollectionChanged;
        public event Action ImmunitiesCollectionChanged;

        //Name & Description
        public string InternalName { get; }
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

        // Sound & Graphics
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

        //Stats
        public StatSet BaseStats { get; } = new StatSet();
        public StatSet LevelUpIncrement { get; } = new StatSet();

        // Misc
        /// <summary>
        /// Gets a read-only sorted collection containing this enemy's types.
        /// </summary>
        public IReadOnlyDictionary<string, string> Types => new ReadOnlyDictionary<string, string>(_Types);
        private SortedDictionary<string, string> _Types = new SortedDictionary<string, string>();
        /// <summary>
        /// Gets a read-only sorted collection containing the ids of the flavors that this enemy is immune to.
        /// </summary>
        public IReadOnlyDictionary<string, string> Immunities => new ReadOnlyDictionary<string, string>(_Immunities);
        private SortedDictionary<string, string> _Immunities = new SortedDictionary<string, string>();

        public Point SelectBoxOffset {
            get { return _SelectBoxOffset; }
            set
            {
                if (_SelectBoxOffset == value) return;
                _SelectBoxOffset = value;
                NotifyPropertyChanged();
            }
        }
        private Point _SelectBoxOffset;

        /// <summary>
        /// The enemies spawned by enemies of this type upon death.
        /// </summary>
        public BindingList<SpawnInfo> Spawns { get; } = new BindingList<SpawnInfo>();
        /// <summary>
        /// This enemy's resistances.
        /// </summary>
        public BindingList<Resistance> Resistances { get; } = new BindingList<Resistance>();

        public void AddType(string type)
        {
            if (!_Types.ContainsKey(type)) _Types.Add(type, type);
            TypesCollectionChanged?.Invoke();
        }

        public void RemoveType(string type)
        {
            _Types.Remove(type);
            TypesCollectionChanged?.Invoke();
        }

        public void ClearTypes()
        {
            _Types.Clear();
            TypesCollectionChanged?.Invoke();
        }

        public void AddImmunity(string immunity)
        {
            if (!_Immunities.ContainsKey(immunity)) _Immunities.Add(immunity, immunity);
            ImmunitiesCollectionChanged?.Invoke();
        }

        public void RemoveImmunity(string immunity)
        {
            _Immunities.Remove(immunity);
            ImmunitiesCollectionChanged?.Invoke();
        }

        public void ClearImmunities()
        {
            _Immunities.Clear();
            ImmunitiesCollectionChanged?.Invoke();
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

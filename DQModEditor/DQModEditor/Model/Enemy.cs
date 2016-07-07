using System;
using System.Collections.Generic;
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

namespace DQModEditor.Model
{
    /// <summary>
    /// Represents an enemy type definition.
    /// </summary>
    public class Enemy : INotifyPropertyChanged
    {
        public Enemy(string internalName)
        {
            InternalName = internalName;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        //Name & Description
        public string InternalName { get; }
        public string DisplayName
        {
            get { return _DisplayName; }
            set
            {
                if (_DisplayName == value) return;
                _DisplayName = value;
                NotifyPropertyChanged();
            }
        }
        private string _DisplayName;
        public string FlavorName {
            get { return _FlavorName; }
            set
            {
                if (_FlavorName == value) return;
                _FlavorName = value;
                NotifyPropertyChanged();
            }
        }
        private string _FlavorName;
        public string FlavorDescription
        {
            get { return _FlavorDescription; }
            set
            {
                if (_FlavorDescription == value) return;
                _FlavorDescription = value;
                NotifyPropertyChanged();
            }
        }
        private string _FlavorDescription;

        // Sound & Graphics
        public string DeathSound
        {
            get { return _DeathSound; }
            set
            {
                if (_DeathSound == value) return;
                _DeathSound = value;
                NotifyPropertyChanged();
            }
        }
        private string _DeathSound;
        public string GraphicId {
            get { return _GraphicId; }
            set
            {
                if (_GraphicId == value) return;
                _GraphicId = value;
                NotifyPropertyChanged();
            }
        }
        private string _GraphicId;
        public string GraphicSkinId {
            get { return _GraphicSkinId; }
            set
            {
                if (_GraphicSkinId == value) return;
                _GraphicSkinId = value;
                NotifyPropertyChanged();
            }
        }
        private string _GraphicSkinId;

        //Stats
        public StatSet BaseStats { get; } = new StatSet();
        public StatSet LevelUpIncrement { get; } = new StatSet();

        // Misc
        public BindingList<string> Types { get; } = new BindingList<string>();
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

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public class StatSet : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            public void SetFrom(StatSet statSet)
            {
                Armor = statSet.Armor;
                Hp = statSet.Hp;
                Scrap = statSet.Scrap;
                Speed = statSet.Speed;
                Strength = statSet.Strength;
                Psi = statSet.Psi;
                Xp = statSet.Xp;
            }

            public int Hp
            {
                get { return _Hp; }
                set
                {
                    if (_Hp == value) return;
                    _Hp = value;
                    NotifyPropertyChanged();
                }
            }
            private int _Hp;
            public decimal Armor
            {
                get { return _Armor; }
                set
                {
                    if (_Armor == value) return;
                    _Armor = value;
                    NotifyPropertyChanged();
                }
            }
            private decimal _Armor;
            public decimal Speed
            {
                get { return _Speed; }
                set
                {
                    if (_Speed == value) return;
                    _Speed = value;
                    NotifyPropertyChanged();
                }
            }
            private decimal _Speed;
            public decimal Strength
            {
                get { return _Strength; }
                set
                {
                    if (_Strength == value) return;
                    _Strength = value;
                    NotifyPropertyChanged();
                }
            }
            private decimal _Strength;
            public decimal Psi
            {
                get { return _Psi; }
                set
                {
                    if (_Psi == value) return;
                    _Psi = value;
                    NotifyPropertyChanged();
                }
            }
            private decimal _Psi;
            public decimal Scrap
            {
                get { return _Scrap; }
                set
                {
                    if (_Scrap == value) return;
                    _Scrap = value;
                    NotifyPropertyChanged();
                }
            }
            private decimal _Scrap;
            public decimal Xp
            {
                get { return _Xp; }
                set
                {
                    if (_Xp == value) return;
                    _Xp = value;
                    NotifyPropertyChanged();
                }
            }
            private decimal _Xp;

            private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

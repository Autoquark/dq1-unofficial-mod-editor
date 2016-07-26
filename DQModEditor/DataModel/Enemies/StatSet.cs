using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DQModEditor.DataModel.Enemies
{
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

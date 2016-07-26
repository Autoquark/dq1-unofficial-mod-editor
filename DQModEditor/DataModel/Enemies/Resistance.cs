using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DQModEditor.DataModel.Enemies
{
    /// <summary>
    /// Represents an enemy's resistance (multiplier to incoming damage or chance to evade) to a flavor.
    /// </summary>
    public class Resistance : INotifyPropertyChanged
    {
        public enum Kind
        {
            DamageMultiplier,
            Evade,
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Flavor
        {
            get { return _Flavor; }
            set
            {
                if (_Flavor == value) return;
                _Flavor = value;
                NotifyPropertyChanged();
            }
        }
        private string _Flavor;

        public Kind ResistanceKind
        {
            get { return _ResistanceKind; }
            set
            {
                if (_ResistanceKind == value) return;
                _ResistanceKind = value;
                NotifyPropertyChanged();
            }
        }
        private Kind _ResistanceKind;

        public decimal Amount
        {
            get { return _Amount; }
            set
            {
                if (_Amount == value) return;
                _Amount = value;
                NotifyPropertyChanged();
            }
        }
        private decimal _Amount;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

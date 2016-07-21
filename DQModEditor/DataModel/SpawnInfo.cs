using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DQModEditor.DataModel
{
    /// <summary>
    /// Represents information about how an enemy spawns another enemy on death.
    /// </summary>
    public class SpawnInfo : INotifyPropertyChanged
    {
        public SpawnInfo() { }

        public SpawnInfo(SpawnInfo template)
        {
            _SpawnId = template.SpawnId;
            _EffectId = template.EffectId;
            _Location = template.Location;
        }

        public string SpawnId
        {
            get { return _SpawnId; }
            set
            {
                if (_SpawnId == value) return;
                if(value == null) value = "";
                _SpawnId = value;
                NotifyPropertyChanged();
            }
        }
        private string _SpawnId = "";
        public string EffectId
        {
            get { return _EffectId; }
            set
            {
                if (_EffectId == value) return;
                if (value == null) value = "";
                _EffectId = value;
                NotifyPropertyChanged();
            }
        }
        private string _EffectId = "";
        public SpawnLocation Location {
            get { return _Location; }
            set
            {
                if (_Location == value) return;
                _Location = value;
                NotifyPropertyChanged();
            }
        }
        private SpawnLocation _Location;
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public struct SpawnLocation
        {
            public SpawnLocation(decimal x, decimal y)
            {
                X = x;
                Y = y;
            }

            public decimal X { get; }
            public decimal Y { get; }

            public static bool operator==(SpawnLocation a, SpawnLocation b)
            {
                return a.X == b.X && a.Y == b.Y;
            }

            public static bool operator !=(SpawnLocation a, SpawnLocation b)
            {
                return !(a == b);
            }

            public override string ToString()
            {
                return $"({X}, {Y})";
            }

            public override bool Equals(object o)
            {
                if (!(o is SpawnLocation)) return false;
                return this == (SpawnLocation)o;
            }

            public override int GetHashCode()
            {
                return X.GetHashCode() ^ Y.GetHashCode();
            }
        }
    }
}

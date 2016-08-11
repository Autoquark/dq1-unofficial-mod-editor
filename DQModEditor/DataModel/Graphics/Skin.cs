using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DQModEditor.DataModel.Graphics
{
    public class Skin : INotifyPropertyChanged
    {
        public static string HdSuffix { get; } = "_hd";

        /// <summary>
        /// Determines whether the given Skin Id would represent an HD skin.
        /// </summary>
        public static bool IsIdHd(string skinId) => skinId.EndsWith(HdSuffix);

        /// <summary>
        /// Determines what the Id for the non-HD equivalent of the given HD skin id would be, or vice-versa.
        /// </summary>
        /// <param name="skinId"></param>
        /// <returns></returns>
        public static string GetHdCorrespondingId(string skinId) =>
            IsIdHd(skinId) ? skinId.Substring(0, skinId.Length - HdSuffix.Length) : skinId + HdSuffix;

        public enum ColorMode
        {
            Pixels,
            Layers,
            LayersStacked,
        }

        public Skin(string id)
        {
            Id = id;
            IsHd = Id.EndsWith(HdSuffix);
            HdCorrespondingId = GetHdCorrespondingId(Id);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Id { get; }

        public int Width {
            get { return _Width; }
            set
            {
                if (_Width == value) return;
                _Width = value;
                NotifyPropertyChanged();
            }
        }
        private int _Width;

        public int Height {
            get { return _Height; }
            set
            {
                if (_Height == value) return;
                _Height = value;
                NotifyPropertyChanged();
            }
        }
        private int _Height;

        public ColorMode Mode
        {
            get { return _Mode; }
            set
            {
                if (_Mode == value) return;
                _Mode = value;
                NotifyPropertyChanged();
            }
        }
        private ColorMode _Mode;

        public bool IsHd { get; }
        public string HdCorrespondingId { get; }

        /// <summary>
        /// Gets the collection of layers for this skin, in the order in which they are drawn ingame.
        /// </summary>
        public BindingList<SkinLayer> Layers { get; } = new BindingList<SkinLayer>();

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

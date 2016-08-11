using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DQModEditor.DataModel.Collections;

namespace DQModEditor.DataModel.Graphics
{
    public class GraphicSet : INotifyPropertyChanged
    {
        public GraphicSet(string id)
        {
            Id = id;
        }

        public string Id { get; }

        public ObservableKeyedCollection<string, Skin> SkinsById { get; }
            = ObservableKeyedCollection<string, Skin>.CreateSorted(x => x.Id);

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

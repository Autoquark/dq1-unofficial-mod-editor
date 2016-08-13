using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DQModEditor.DataModel.Enemies;
using DQModEditor.DataModel.Graphics;

namespace DQModEditor.Gui.Controls.Enemies.Graphics
{
    internal partial class EnemyColorListViewControl : ViewControl<Enemy>
    {
        private static readonly string undefinedLayerName = "<none>";

        public EnemyColorListViewControl()
        {
            InitializeComponent();

            DisplayedItemChanged += EnemyColorListViewControl_DisplayedItemChanged;
            ContextChanged += (s, e) => UpdateLayerLabels();

            SizeChanged += (s, e) =>
            {
                listPanel.Height = Height - listPanel.Top - addButton.Height;
                addButton.Top = listPanel.Bottom;
                removeButton.Top = listPanel.Bottom;
            };

            addButton.Click += (s, e) => DisplayedItem.Colors.Add(Color.Black);
            removeButton.Click += (s, e) => DisplayedItem.Colors.RemoveAt(DisplayedItem.Colors.Count - 1);
        }

        private void EnemyColorListViewControl_DisplayedItemChanged(ViewControl<Enemy> source, Enemy previous)
        {
            if (previous != null)
            {
                previous.Colors.ListChanged -= Colors_ListChanged;
                previous.PropertyChanged -= DisplayedItem_PropertyChanged;
            }

            if(DisplayedItem != null)
            {
                DisplayedItem.Colors.ListChanged += Colors_ListChanged;
                DisplayedItem.PropertyChanged += DisplayedItem_PropertyChanged;
                UpdateLayerLabels();
                UpdateSelectedColors();
            }
        }

        private void Colors_ListChanged(object sender, ListChangedEventArgs e) => UpdateSelectedColors();
        private void Layers_ListChanged(object sender, ListChangedEventArgs e) => UpdateLayerLabels();

        private void DisplayedItem_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != nameof(DisplayedItem.GraphicId) && e.PropertyName != nameof(DisplayedItem.GraphicSkinId)) return;
            UpdateLayerLabels();
        }

        private void UpdateSelectedColors()
        {
            while (_colorControls.Count < DisplayedItem.Colors.Count) AddColorControl();
            for (int i = 0; i < _colorControls.Count; i++)
            {
                if (i < DisplayedItem.Colors.Count) _colorControls[i].SelectedColor = DisplayedItem.Colors[i];
                else _colorControls[i].SetColorUndefined();
            }

            TrimColorControls();
        }

        private void UpdateLayerLabels()
        {
            IList<string> layerNames = new List<string>();
            // Get layer names if possible
            if (Context != null)
            {
                if (_currentSkin != null) _currentSkin.Layers.ListChanged -= Layers_ListChanged;
                GraphicSet set;
                if (Context.CurrentMod.EnemyGraphicsById.TryGetValue(DisplayedItem.GraphicId, out set) &&
                    set.SkinsById.TryGetValue(Skin.GetHdCorrespondingId(DisplayedItem.GraphicSkinId), out _currentSkin))
                {
                    _currentSkin.Layers.ListChanged += Layers_ListChanged;
                    layerNames = _currentSkin.Layers.Select(x => x.Name).ToList();
                }
            }

            // Update labels
            while (_colorControls.Count < layerNames.Count) AddColorControl();
            for (int i = 0; i < _colorControls.Count; i++)
            {
                if (i < layerNames.Count) _colorControls[i].LayerLabel = layerNames[i];
                else _colorControls[i].LayerLabel = undefinedLayerName;
            }

            TrimColorControls();
        }

        private EnemyLayerColorViewControl AddColorControl()
        {
            EnemyLayerColorViewControl control = new EnemyLayerColorViewControl();
            Point p = new Point(0, 32 * _colorControls.Count);
            p.Offset(listPanel.AutoScrollPosition);
            control.Location = p;
            control.LayerLabel = undefinedLayerName;

            int i_capture = _colorControls.Count;
            control.SelectedColorChanged += () =>
            {
                Color c = control.SelectedColor;
                while (i_capture >= DisplayedItem.Colors.Count) DisplayedItem.Colors.Add(Color.Black);
                DisplayedItem.Colors[i_capture] = c;
            };

            listPanel.Controls.Add(control);
            _colorControls.Add(control);
            return control;
        }

        private void TrimColorControls()
        {
            int count = Math.Max(_currentSkin?.Layers.Count ?? 0, DisplayedItem?.Colors.Count ?? 0);
            while(_colorControls.Count > count)
            {
                _colorControls.Last().Dispose();
                listPanel.Controls.Remove(_colorControls.Last());
                _colorControls.RemoveAt(_colorControls.Count - 1);
            }
        }

        private IList<EnemyLayerColorViewControl> _colorControls = new List<EnemyLayerColorViewControl>();
        private Skin _currentSkin = null;
    }
}

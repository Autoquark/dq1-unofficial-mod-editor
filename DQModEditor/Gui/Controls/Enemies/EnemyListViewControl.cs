using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DQModEditor.DataModel;
using DQModEditor.DataModel.Enemies;
using System.Collections.Specialized;

namespace DQModEditor.Gui.Controls.Enemies
{
    /// <summary>
    /// Control that displays the enemies defined by a mod.
    /// </summary>
    internal partial class EnemyListViewControl : ViewControl<Mod>
    {
        public EnemyListViewControl()
        {
            InitializeComponent();

            enemiesListBox.DisplayMember = nameof(Enemy.Id);
            enemiesListBox.SelectedIndexChanged += (o, e) => enemyViewControl.DisplayedItem = (Enemy)enemiesListBox.SelectedItem;

            enemyViewControl.DisplayedItemChanged += (s, e) =>
            {
                if (enemyViewControl.DisplayedItem == null) enemiesListBox.ClearSelected();
                else enemiesListBox.SelectedItem = enemyViewControl.DisplayedItem;
            };

            DisplayedItemChanged += ChangeDisplayedItem;

            Utility.BindDisplayContext(this, enemyViewControl);
        }

        private void ChangeDisplayedItem(ViewControl<Mod> source, Mod previous)
        {
            if(previous != null) DisplayedItem.EnemiesById.CollectionChanged -= DisplayedItem_CollectionChanged;

            if (DisplayedItem != null)
            {
                enemiesListBox.DataSource = new BindingSource(DisplayedItem.EnemiesById, null);
                DisplayedItem.EnemiesById.CollectionChanged += DisplayedItem_CollectionChanged;
            }
        }

        private void DisplayedItem_CollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            ((BindingSource)enemiesListBox.DataSource).DataSource = null;
            ((BindingSource)enemiesListBox.DataSource).DataSource = DisplayedItem.EnemiesById;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DQModEditor.DataModel;
using DQModEditor.DataModel.Enemies;

namespace DQModEditor.Loader
{
    /// <summary>
    /// Tracks changes made to a Mod after loading in order to support stable saving.
    /// </summary>
    internal class StableSaveTracker : IDisposable
    {
        /// <summary>
        /// Initializes a new StableSaveTracker that tracks changes to the given Mod.
        /// </summary>
        /// <param name="mod"></param>
        internal StableSaveTracker(Mod mod)
        {
            mod.EnemyCollectionChanged += Mod_EnemyCollectionChanged;
            _mod = mod;

            foreach (Enemy enemy in mod.EnemiesByInternalName.Values) enemy.PropertyChanged += Enemy_PropertyChanged;
        }

        private void Mod_EnemyCollectionChanged(Enemy enemy)
        {
            if (_mod.EnemiesByInternalName.ContainsKey(enemy.Id)) enemy.PropertyChanged += Enemy_PropertyChanged;
            else enemy.PropertyChanged -= Enemy_PropertyChanged;
        }

        private void Enemy_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            Enemy enemy = (Enemy)sender;
            if(e.PropertyName == nameof(Enemy.IsNewGamePlus))
            {
                // Toggle membership of set
                if (!_enemiesIsNewGamePlusChanged.Add(enemy)) _enemiesIsNewGamePlusChanged.Remove(enemy);
            }
        }

        /// <summary>
        /// Records enemies where IsNewGamePlus has been toggled. On save, the XML for the enemy must be moved from the plus file to 
        /// the normal file or vice versa.
        /// </summary>
        public IEnumerable<Enemy> EnemiesIsNewGamePlusChanged => _enemiesIsNewGamePlusChanged;
        private readonly ISet<Enemy> _enemiesIsNewGamePlusChanged = new HashSet<Enemy>();
        private readonly Mod _mod;

        #region IDisposable Support
        private bool _isDisposed = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (_isDisposed) return;

            if (disposing)
            {
                _mod.EnemyCollectionChanged -= Mod_EnemyCollectionChanged;
                foreach (Enemy e in _mod.EnemiesByInternalName.Values) e.PropertyChanged -= Enemy_PropertyChanged;
            }
            _isDisposed = true;
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}

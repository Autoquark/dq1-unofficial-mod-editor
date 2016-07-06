using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DQModEditor.Model;

namespace DQModEditor.Gui
{
    /// <summary>
    /// Control that displays an enemy definition from a mod.
    /// </summary>
    public partial class EnemyViewControl : UserControl
    {
        public EnemyViewControl(Enemy enemy)
        {
            InitializeComponent();

            // Text & Description
            internalNameLabel.DataBindings.Add(nameof(internalNameLabel.Text), enemy, nameof(enemy.InternalName));
            string textPropertyName = nameof(displayNameTextBox.Text);
            displayNameTextBox.DataBindings.Add(textPropertyName, enemy, nameof(enemy.DisplayName));
            flavorNameTextBox.DataBindings.Add(textPropertyName, enemy, nameof(enemy.FlavorName));
            flavorDescriptionTextBox.DataBindings.Add(textPropertyName, enemy, nameof(enemy.FlavorDescription));
            // Stats
            string valuePropertyName = nameof(baseHpSpinner.Value);
            baseHpSpinner.DataBindings.Add(valuePropertyName, enemy, nameof(enemy.BaseHp));
            basePsiSpinner.DataBindings.Add(valuePropertyName, enemy, nameof(enemy.BasePsi));
            baseScrapSpinner.DataBindings.Add(valuePropertyName, enemy, nameof(enemy.BaseScrap));
            baseSpeedSpinner.DataBindings.Add(valuePropertyName, enemy, nameof(enemy.BaseSpeed));
            baseStrengthSpinner.DataBindings.Add(valuePropertyName, enemy, nameof(enemy.BaseStrength));
            baseArmorSpinner.DataBindings.Add(valuePropertyName, enemy, nameof(enemy.BaseArmor));
            baseXpSpinner.DataBindings.Add(valuePropertyName, enemy, nameof(enemy.BaseXp));

            perLevelHpSpinner.DataBindings.Add(valuePropertyName, enemy, nameof(enemy.HpPerLevel));
            perLevelPsiSpinner.DataBindings.Add(valuePropertyName, enemy, nameof(enemy.PsiPerLevel));
            perLevelScrapSpinner.DataBindings.Add(valuePropertyName, enemy, nameof(enemy.ScrapPerLevel));
            perLevelSpeedSpinner.DataBindings.Add(valuePropertyName, enemy, nameof(enemy.SpeedPerLevel));
            perLevelStrengthSpinner.DataBindings.Add(valuePropertyName, enemy, nameof(enemy.StrengthPerLevel));
            perLevelArmorSpinner.DataBindings.Add(valuePropertyName, enemy, nameof(enemy.ArmourPerLevel));
            perLevelXpSpinner.DataBindings.Add(valuePropertyName, enemy, nameof(enemy.XpPerLevel));
        }
    }
}

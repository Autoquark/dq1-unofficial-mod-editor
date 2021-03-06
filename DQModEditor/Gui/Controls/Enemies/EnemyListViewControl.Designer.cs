﻿namespace DQModEditor.Gui.Controls.Enemies
{
    partial class EnemyListViewControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.enemiesListBox = new System.Windows.Forms.ListBox();
            this.enemyViewControl = new DQModEditor.Gui.Controls.Enemies.EnemyViewControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select an enemy to edit:";
            // 
            // enemiesListBox
            // 
            this.enemiesListBox.FormattingEnabled = true;
            this.enemiesListBox.Location = new System.Drawing.Point(0, 24);
            this.enemiesListBox.Name = "enemiesListBox";
            this.enemiesListBox.Size = new System.Drawing.Size(128, 446);
            this.enemiesListBox.TabIndex = 2;
            // 
            // enemyViewControl
            // 
            this.enemyViewControl.Context = null;
            this.enemyViewControl.DisplayedItem = null;
            this.enemyViewControl.Enabled = false;
            this.enemyViewControl.Location = new System.Drawing.Point(136, 0);
            this.enemyViewControl.Name = "enemyViewControl";
            this.enemyViewControl.Size = new System.Drawing.Size(624, 488);
            this.enemyViewControl.TabIndex = 4;
            // 
            // EnemyListViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.enemyViewControl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enemiesListBox);
            this.Name = "EnemyListViewControl";
            this.Size = new System.Drawing.Size(768, 494);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox enemiesListBox;
        private EnemyViewControl enemyViewControl;
    }
}

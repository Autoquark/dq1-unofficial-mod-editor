﻿namespace DQModEditor.Gui.Controls.Enemies.Spawns
{
    partial class SpawnViewControl
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.spawnIdTextBox = new System.Windows.Forms.TextBox();
            this.effectIdTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.locationViewControl = new DQModEditor.Gui.Controls.Enemies.Spawns.SpawnLocationViewControl();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Spawn Location Offset:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Spawn Id";
            // 
            // spawnIdTextBox
            // 
            this.spawnIdTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.spawnIdTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.spawnIdTextBox.Location = new System.Drawing.Point(8, 64);
            this.spawnIdTextBox.Name = "spawnIdTextBox";
            this.spawnIdTextBox.Size = new System.Drawing.Size(144, 20);
            this.spawnIdTextBox.TabIndex = 6;
            this.spawnIdTextBox.Text = "(spawn id)";
            // 
            // effectIdTextBox
            // 
            this.effectIdTextBox.Location = new System.Drawing.Point(8, 120);
            this.effectIdTextBox.Name = "effectIdTextBox";
            this.effectIdTextBox.Size = new System.Drawing.Size(144, 20);
            this.effectIdTextBox.TabIndex = 8;
            this.effectIdTextBox.Text = "(effect id)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Effect Id:";
            // 
            // spawnLocationViewControl
            // 
            this.locationViewControl.Location = new System.Drawing.Point(8, 16);
            this.locationViewControl.Name = "spawnLocationViewControl";
            this.locationViewControl.Size = new System.Drawing.Size(152, 24);
            this.locationViewControl.TabIndex = 9;
            // 
            // SpawnViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.locationViewControl);
            this.Controls.Add(this.effectIdTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.spawnIdTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Name = "SpawnViewControl";
            this.Size = new System.Drawing.Size(152, 144);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox spawnIdTextBox;
        private System.Windows.Forms.TextBox effectIdTextBox;
        private System.Windows.Forms.Label label5;
        private SpawnLocationViewControl locationViewControl;
    }
}

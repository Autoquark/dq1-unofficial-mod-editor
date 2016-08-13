namespace DQModEditor.Gui.Controls.Enemies.Graphics
{
    partial class EnemyColorListViewControl
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
            this.nameColumnLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listPanel = new System.Windows.Forms.Panel();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nameColumnLabel
            // 
            this.nameColumnLabel.AutoSize = true;
            this.nameColumnLabel.Location = new System.Drawing.Point(0, 0);
            this.nameColumnLabel.Name = "nameColumnLabel";
            this.nameColumnLabel.Size = new System.Drawing.Size(64, 13);
            this.nameColumnLabel.TabIndex = 0;
            this.nameColumnLabel.Text = "Layer Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(88, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Color";
            // 
            // listPanel
            // 
            this.listPanel.AutoScroll = true;
            this.listPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listPanel.Location = new System.Drawing.Point(0, 16);
            this.listPanel.Name = "listPanel";
            this.listPanel.Size = new System.Drawing.Size(144, 120);
            this.listPanel.TabIndex = 3;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(0, 136);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(72, 23);
            this.addButton.TabIndex = 4;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(72, 136);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(72, 23);
            this.removeButton.TabIndex = 5;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            // 
            // EnemyColorListViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.listPanel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.nameColumnLabel);
            this.Name = "EnemyColorListViewControl";
            this.Size = new System.Drawing.Size(144, 160);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameColumnLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel listPanel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
    }
}

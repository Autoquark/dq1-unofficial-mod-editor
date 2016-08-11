namespace DQModEditor.Gui.Controls.Enemies.Graphics
{
    partial class EnemyLayerColorViewControl
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
            this.colorSelectButton = new System.Windows.Forms.Button();
            this.layerNameLabel = new System.Windows.Forms.Label();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // colorSelectButton
            // 
            this.colorSelectButton.Location = new System.Drawing.Point(88, 0);
            this.colorSelectButton.Name = "colorSelectButton";
            this.colorSelectButton.Size = new System.Drawing.Size(24, 23);
            this.colorSelectButton.TabIndex = 5;
            this.colorSelectButton.UseVisualStyleBackColor = true;
            // 
            // layerNameLabel
            // 
            this.layerNameLabel.AutoSize = true;
            this.layerNameLabel.Location = new System.Drawing.Point(0, 5);
            this.layerNameLabel.Name = "layerNameLabel";
            this.layerNameLabel.Size = new System.Drawing.Size(65, 13);
            this.layerNameLabel.TabIndex = 4;
            this.layerNameLabel.Text = "detail_hilight";
            // 
            // EnemyLayerColorViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.colorSelectButton);
            this.Controls.Add(this.layerNameLabel);
            this.Name = "EnemyLayerColorViewControl";
            this.Size = new System.Drawing.Size(112, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button colorSelectButton;
        private System.Windows.Forms.Label layerNameLabel;
        private System.Windows.Forms.ColorDialog colorDialog;
    }
}

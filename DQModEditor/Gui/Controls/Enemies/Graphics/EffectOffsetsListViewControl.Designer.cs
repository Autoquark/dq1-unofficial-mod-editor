namespace DQModEditor.Gui.Controls.Enemies.Graphics
{
    internal partial class EffectOffsetsListViewControl
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
            this.listBox = new System.Windows.Forms.ListBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.pointViewControl = new DQModEditor.Gui.Controls.PointViewControl();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(0, 0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(112, 95);
            this.listBox.TabIndex = 0;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(0, 120);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(56, 23);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // addTextBox
            // 
            this.addTextBox.Location = new System.Drawing.Point(0, 96);
            this.addTextBox.Name = "addTextBox";
            this.addTextBox.Size = new System.Drawing.Size(88, 20);
            this.addTextBox.TabIndex = 4;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(88, 96);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(24, 20);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(56, 120);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(56, 23);
            this.clearButton.TabIndex = 5;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // pointViewControl
            // 
            this.pointViewControl.Location = new System.Drawing.Point(120, 8);
            this.pointViewControl.Name = "pointViewControl";
            this.pointViewControl.Size = new System.Drawing.Size(128, 24);
            this.pointViewControl.TabIndex = 6;
            // 
            // EffectOffsetsListViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pointViewControl);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.addTextBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.listBox);
            this.Name = "EffectOffsetsListViewControl";
            this.Size = new System.Drawing.Size(248, 144);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.TextBox addTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button clearButton;
        private PointViewControl pointViewControl;
    }
}

namespace DQModEditor.Gui.Controls
{
    partial class StringListViewControl
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
            this.addButton = new System.Windows.Forms.Button();
            this.addTextBox = new System.Windows.Forms.TextBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(0, 0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(96, 95);
            this.listBox.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(72, 96);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(24, 20);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "+";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // addTextBox
            // 
            this.addTextBox.Location = new System.Drawing.Point(0, 96);
            this.addTextBox.Name = "addTextBox";
            this.addTextBox.Size = new System.Drawing.Size(72, 20);
            this.addTextBox.TabIndex = 2;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(0, 120);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(48, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(48, 120);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(48, 23);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // StringListViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addTextBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.listBox);
            this.Name = "StringListViewControl";
            this.Size = new System.Drawing.Size(96, 144);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox addTextBox;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button clearButton;
    }
}

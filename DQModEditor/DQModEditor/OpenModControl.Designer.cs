namespace DQModEditor.Gui
{
    partial class OpenModControl
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
            this.loadModButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // loadModButton
            // 
            this.loadModButton.Location = new System.Drawing.Point(0, 0);
            this.loadModButton.Name = "loadModButton";
            this.loadModButton.Size = new System.Drawing.Size(240, 23);
            this.loadModButton.TabIndex = 1;
            this.loadModButton.Text = "Load Mod";
            this.loadModButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(0, 32);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(240, 112);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "To begin editing a mod, click \"Load Mod\" and select the root folder of a DQ1 mod." +
    "\r\n\r\nWarning! This software is alpha and is provided without warranty. Please bac" +
    "k up the mod folder before loading.";
            // 
            // OpenModControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.loadModButton);
            this.Controls.Add(this.textBox1);
            this.Name = "OpenModControl";
            this.Size = new System.Drawing.Size(240, 150);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button loadModButton;
        private System.Windows.Forms.TextBox textBox1;
    }
}

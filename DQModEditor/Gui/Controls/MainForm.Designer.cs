namespace DQModEditor.Gui.Controls
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.modViewControl = new DQModEditor.Gui.Controls.ModViewControl();
            this.SuspendLayout();
            // 
            // modViewControl
            // 
            this.modViewControl.DisplayedItem = null;
            this.modViewControl.Enabled = false;
            this.modViewControl.Location = new System.Drawing.Point(0, 0);
            this.modViewControl.Name = "modViewControl";
            this.modViewControl.Size = new System.Drawing.Size(784, 564);
            this.modViewControl.TabIndex = 0;
            this.modViewControl.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.modViewControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Defender\'s Quest Unofficial Mod Editor";
            this.ResumeLayout(false);

        }

        #endregion

        private ModViewControl modViewControl;
    }
}


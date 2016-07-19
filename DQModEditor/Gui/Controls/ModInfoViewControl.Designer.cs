namespace DQModEditor.Gui.Controls
{
    partial class ModInfoViewControl
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
            this.descriptionTextBox = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.modTitleTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.versionTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gameNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.modIdTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(72, 93);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(312, 379);
            this.descriptionTextBox.TabIndex = 19;
            this.descriptionTextBox.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Description";
            // 
            // modNameTextBox
            // 
            this.modTitleTextBox.Location = new System.Drawing.Point(72, 61);
            this.modTitleTextBox.Name = "modNameTextBox";
            this.modTitleTextBox.Size = new System.Drawing.Size(128, 20);
            this.modTitleTextBox.TabIndex = 17;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(0, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Mod Name";
            // 
            // versionTextBox
            // 
            this.versionTextBox.Location = new System.Drawing.Point(256, 29);
            this.versionTextBox.Name = "versionTextBox";
            this.versionTextBox.Size = new System.Drawing.Size(128, 20);
            this.versionTextBox.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Version";
            // 
            // gameNameTextBox
            // 
            this.gameNameTextBox.Location = new System.Drawing.Point(72, 29);
            this.gameNameTextBox.Name = "gameNameTextBox";
            this.gameNameTextBox.ReadOnly = true;
            this.gameNameTextBox.Size = new System.Drawing.Size(128, 20);
            this.gameNameTextBox.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Game Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Mod Id";
            // 
            // modIdTextBox
            // 
            this.modIdTextBox.Location = new System.Drawing.Point(72, 0);
            this.modIdTextBox.Name = "modIdTextBox";
            this.modIdTextBox.ReadOnly = true;
            this.modIdTextBox.Size = new System.Drawing.Size(128, 20);
            this.modIdTextBox.TabIndex = 10;
            // 
            // ModInfoViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.descriptionTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.modTitleTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.versionTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.gameNameTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modIdTextBox);
            this.Name = "ModInfoViewControl";
            this.Size = new System.Drawing.Size(624, 488);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox descriptionTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox modTitleTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox versionTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox gameNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox modIdTextBox;
    }
}

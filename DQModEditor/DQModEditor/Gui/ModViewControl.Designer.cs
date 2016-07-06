namespace DQModEditor.Gui
{
    partial class ModViewControl
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.enemiesTabPage = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.enemiesTabPage);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 560);
            this.tabControl1.TabIndex = 0;
            // 
            // enemiesTabPage
            // 
            this.enemiesTabPage.Location = new System.Drawing.Point(4, 22);
            this.enemiesTabPage.Name = "enemiesTabPage";
            this.enemiesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.enemiesTabPage.Size = new System.Drawing.Size(776, 534);
            this.enemiesTabPage.TabIndex = 1;
            this.enemiesTabPage.Text = "Enemies";
            this.enemiesTabPage.UseVisualStyleBackColor = true;
            // 
            // ModViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "ModViewControl";
            this.Size = new System.Drawing.Size(784, 568);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage enemiesTabPage;
    }
}

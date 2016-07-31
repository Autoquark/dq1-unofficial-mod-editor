namespace DQModEditor.Gui.Controls
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModViewControl));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.infoTabPage = new System.Windows.Forms.TabPage();
            this.enemiesTabPage = new System.Windows.Forms.TabPage();
            this.saveButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.closeButton = new System.Windows.Forms.ToolStripButton();
            this.modInfoViewControl = new DQModEditor.Gui.Controls.ModInfoViewControl();
            this.enemyListViewControl = new DQModEditor.Gui.Controls.Enemies.EnemyListViewControl();
            this.tabControl1.SuspendLayout();
            this.infoTabPage.SuspendLayout();
            this.enemiesTabPage.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.infoTabPage);
            this.tabControl1.Controls.Add(this.enemiesTabPage);
            this.tabControl1.Location = new System.Drawing.Point(0, 32);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(784, 528);
            this.tabControl1.TabIndex = 0;
            // 
            // infoTabPage
            // 
            this.infoTabPage.Controls.Add(this.modInfoViewControl);
            this.infoTabPage.Location = new System.Drawing.Point(4, 22);
            this.infoTabPage.Name = "infoTabPage";
            this.infoTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.infoTabPage.Size = new System.Drawing.Size(776, 502);
            this.infoTabPage.TabIndex = 2;
            this.infoTabPage.Text = "Info";
            this.infoTabPage.UseVisualStyleBackColor = true;
            // 
            // enemiesTabPage
            // 
            this.enemiesTabPage.Controls.Add(this.enemyListViewControl);
            this.enemiesTabPage.Location = new System.Drawing.Point(4, 22);
            this.enemiesTabPage.Name = "enemiesTabPage";
            this.enemiesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.enemiesTabPage.Size = new System.Drawing.Size(776, 502);
            this.enemiesTabPage.TabIndex = 1;
            this.enemiesTabPage.Text = "Enemies";
            this.enemiesTabPage.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(35, 22);
            this.saveButton.Text = "Save";
            this.saveButton.ToolTipText = "Merge changes back into the mod directory";
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveButton,
            this.openButton,
            this.closeButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(784, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // openButton
            // 
            this.openButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(40, 22);
            this.openButton.Text = "Open";
            this.openButton.ToolTipText = "Load a different mod, discarding any changes to the current one";
            // 
            // closeButton
            // 
            this.closeButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.closeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(40, 22);
            this.closeButton.Text = "Close";
            this.closeButton.ToolTipText = "Close the current mod";
            // 
            // modInfoViewControl
            // 
            this.modInfoViewControl.Context = null;
            this.modInfoViewControl.DisplayedItem = null;
            this.modInfoViewControl.Enabled = false;
            this.modInfoViewControl.Location = new System.Drawing.Point(8, 8);
            this.modInfoViewControl.Name = "modInfoViewControl";
            this.modInfoViewControl.Size = new System.Drawing.Size(624, 496);
            this.modInfoViewControl.TabIndex = 0;
            // 
            // enemyListViewControl
            // 
            this.enemyListViewControl.Context = null;
            this.enemyListViewControl.DisplayedItem = null;
            this.enemyListViewControl.Enabled = false;
            this.enemyListViewControl.Location = new System.Drawing.Point(8, 8);
            this.enemyListViewControl.Name = "enemyListViewControl";
            this.enemyListViewControl.Size = new System.Drawing.Size(768, 488);
            this.enemyListViewControl.TabIndex = 0;
            // 
            // ModViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.tabControl1);
            this.Name = "ModViewControl";
            this.Size = new System.Drawing.Size(784, 564);
            this.tabControl1.ResumeLayout(false);
            this.infoTabPage.ResumeLayout(false);
            this.enemiesTabPage.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage enemiesTabPage;
        private System.Windows.Forms.ToolStripButton saveButton;
        private System.Windows.Forms.ToolStrip toolStrip;
        private Enemies.EnemyListViewControl enemyListViewControl;
        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.ToolStripButton closeButton;
        private System.Windows.Forms.TabPage infoTabPage;
        private ModInfoViewControl modInfoViewControl;
    }
}

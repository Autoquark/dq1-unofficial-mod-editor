namespace DQModEditor.Gui.Enemies.Spawns
{
    partial class EnemySpawnListViewControl
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
            this.spawnsListBox = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.enemySpawnViewControl = new DQModEditor.Gui.Enemies.Spawns.EnemySpawnViewControl();
            this.cloneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // spawnsListBox
            // 
            this.spawnsListBox.FormattingEnabled = true;
            this.spawnsListBox.Location = new System.Drawing.Point(0, 0);
            this.spawnsListBox.Name = "spawnsListBox";
            this.spawnsListBox.Size = new System.Drawing.Size(112, 108);
            this.spawnsListBox.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(0, 112);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(56, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(0, 136);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(56, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(56, 136);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(56, 23);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // enemySpawnViewControl
            // 
            this.enemySpawnViewControl.Location = new System.Drawing.Point(112, 0);
            this.enemySpawnViewControl.Name = "enemySpawnViewControl";
            this.enemySpawnViewControl.Size = new System.Drawing.Size(160, 152);
            this.enemySpawnViewControl.TabIndex = 5;
            // 
            // cloneButton
            // 
            this.cloneButton.Location = new System.Drawing.Point(56, 112);
            this.cloneButton.Name = "cloneButton";
            this.cloneButton.Size = new System.Drawing.Size(56, 23);
            this.cloneButton.TabIndex = 6;
            this.cloneButton.Text = "Clone";
            this.cloneButton.UseVisualStyleBackColor = true;
            // 
            // EnemySpawnListViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cloneButton);
            this.Controls.Add(this.enemySpawnViewControl);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.spawnsListBox);
            this.Name = "EnemySpawnListViewControl";
            this.Size = new System.Drawing.Size(264, 160);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox spawnsListBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button clearButton;
        private EnemySpawnViewControl enemySpawnViewControl;
        private System.Windows.Forms.Button cloneButton;
    }
}

namespace DQModEditor.Gui.Controls.Enemies.Spawns
{
    partial class SpawnListViewControl
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
            this.cloneButton = new System.Windows.Forms.Button();
            this.spawnViewControl = new DQModEditor.Gui.Controls.Enemies.Spawns.SpawnViewControl();
            this.SuspendLayout();
            // 
            // spawnsListBox
            // 
            this.spawnsListBox.FormattingEnabled = true;
            this.spawnsListBox.Location = new System.Drawing.Point(0, 0);
            this.spawnsListBox.Name = "spawnsListBox";
            this.spawnsListBox.Size = new System.Drawing.Size(112, 95);
            this.spawnsListBox.TabIndex = 0;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(0, 96);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(56, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(0, 120);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(56, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(56, 120);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(56, 23);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // cloneButton
            // 
            this.cloneButton.Location = new System.Drawing.Point(56, 96);
            this.cloneButton.Name = "cloneButton";
            this.cloneButton.Size = new System.Drawing.Size(56, 23);
            this.cloneButton.TabIndex = 6;
            this.cloneButton.Text = "Clone";
            this.cloneButton.UseVisualStyleBackColor = true;
            // 
            // enemySpawnViewControl
            // 
            this.spawnViewControl.DisplayedItem = null;
            this.spawnViewControl.Enabled = false;
            this.spawnViewControl.Location = new System.Drawing.Point(120, 0);
            this.spawnViewControl.Name = "enemySpawnViewControl";
            this.spawnViewControl.Size = new System.Drawing.Size(152, 144);
            this.spawnViewControl.TabIndex = 5;
            // 
            // EnemySpawnListViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cloneButton);
            this.Controls.Add(this.spawnViewControl);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.spawnsListBox);
            this.Name = "EnemySpawnListViewControl";
            this.Size = new System.Drawing.Size(272, 144);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox spawnsListBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button clearButton;
        private SpawnViewControl spawnViewControl;
        private System.Windows.Forms.Button cloneButton;
    }
}

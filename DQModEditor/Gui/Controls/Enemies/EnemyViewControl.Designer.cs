namespace DQModEditor.Gui.Controls.Enemies
{
    partial class EnemyViewControl
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
            this.displayNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.statsGroupBox = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.internalNameTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.flavorDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.flavorNameTextBox = new System.Windows.Forms.TextBox();
            this.spawnsGroupBox = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.immunitiesListView = new DQModEditor.Gui.Controls.StringListViewControl();
            this.typesListView = new DQModEditor.Gui.Controls.StringListViewControl();
            this.enemySpawnListViewControl = new DQModEditor.Gui.Controls.Enemies.Spawns.EnemySpawnListViewControl();
            this.perLevelStatsViewControl = new DQModEditor.Gui.Controls.Enemies.StatSetViewControl();
            this.baseStatsViewControl = new DQModEditor.Gui.Controls.Enemies.StatSetViewControl();
            this.statsGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.spawnsGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // displayNameTextBox
            // 
            this.displayNameTextBox.Location = new System.Drawing.Point(400, 21);
            this.displayNameTextBox.Name = "displayNameTextBox";
            this.displayNameTextBox.Size = new System.Drawing.Size(208, 20);
            this.displayNameTextBox.TabIndex = 1;
            this.displayNameTextBox.Text = "(display name)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(320, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Display Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "HP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Armor";
            // 
            // statsGroupBox
            // 
            this.statsGroupBox.Controls.Add(this.perLevelStatsViewControl);
            this.statsGroupBox.Controls.Add(this.baseStatsViewControl);
            this.statsGroupBox.Controls.Add(this.label10);
            this.statsGroupBox.Controls.Add(this.label9);
            this.statsGroupBox.Controls.Add(this.label8);
            this.statsGroupBox.Controls.Add(this.label7);
            this.statsGroupBox.Controls.Add(this.label4);
            this.statsGroupBox.Controls.Add(this.label6);
            this.statsGroupBox.Controls.Add(this.label5);
            this.statsGroupBox.Controls.Add(this.label3);
            this.statsGroupBox.Controls.Add(this.label2);
            this.statsGroupBox.Location = new System.Drawing.Point(0, 88);
            this.statsGroupBox.Name = "statsGroupBox";
            this.statsGroupBox.Size = new System.Drawing.Size(232, 216);
            this.statsGroupBox.TabIndex = 7;
            this.statsGroupBox.TabStop = false;
            this.statsGroupBox.Text = "Stats";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 184);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Strength";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "XP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(152, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Per Level";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(80, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Base";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Speed";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Psi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Scrap";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.internalNameTextBox);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.flavorDescriptionTextBox);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.flavorNameTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.displayNameTextBox);
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(616, 88);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Name && Description";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 24);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(76, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Internal Name:";
            // 
            // internalNameTextBox
            // 
            this.internalNameTextBox.Location = new System.Drawing.Point(88, 21);
            this.internalNameTextBox.Name = "internalNameTextBox";
            this.internalNameTextBox.ReadOnly = true;
            this.internalNameTextBox.Size = new System.Drawing.Size(208, 20);
            this.internalNameTextBox.TabIndex = 7;
            this.internalNameTextBox.Text = "(display name)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(304, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Flavor Description";
            // 
            // flavorDescriptionTextBox
            // 
            this.flavorDescriptionTextBox.Location = new System.Drawing.Point(400, 53);
            this.flavorDescriptionTextBox.Name = "flavorDescriptionTextBox";
            this.flavorDescriptionTextBox.Size = new System.Drawing.Size(208, 20);
            this.flavorDescriptionTextBox.TabIndex = 5;
            this.flavorDescriptionTextBox.Text = "(display name)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 4;
            this.label11.Text = "Flavor Name";
            // 
            // flavorNameTextBox
            // 
            this.flavorNameTextBox.Location = new System.Drawing.Point(88, 53);
            this.flavorNameTextBox.Name = "flavorNameTextBox";
            this.flavorNameTextBox.Size = new System.Drawing.Size(208, 20);
            this.flavorNameTextBox.TabIndex = 3;
            this.flavorNameTextBox.Text = "(display name)";
            // 
            // spawnsGroupBox
            // 
            this.spawnsGroupBox.Controls.Add(this.enemySpawnListViewControl);
            this.spawnsGroupBox.Location = new System.Drawing.Point(240, 88);
            this.spawnsGroupBox.Name = "spawnsGroupBox";
            this.spawnsGroupBox.Size = new System.Drawing.Size(280, 216);
            this.spawnsGroupBox.TabIndex = 9;
            this.spawnsGroupBox.TabStop = false;
            this.spawnsGroupBox.Text = "Spawns";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.typesListView);
            this.groupBox1.Location = new System.Drawing.Point(0, 304);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(128, 176);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Types";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.immunitiesListView);
            this.groupBox3.Location = new System.Drawing.Point(136, 304);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(128, 176);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Immunities";
            // 
            // immunitiesListView
            // 
            this.immunitiesListView.DisplayedItem = null;
            this.immunitiesListView.Enabled = false;
            this.immunitiesListView.Location = new System.Drawing.Point(16, 24);
            this.immunitiesListView.Name = "immunitiesListView";
            this.immunitiesListView.Size = new System.Drawing.Size(96, 144);
            this.immunitiesListView.TabIndex = 11;
            // 
            // typesListView
            // 
            this.typesListView.DisplayedItem = null;
            this.typesListView.Enabled = false;
            this.typesListView.Location = new System.Drawing.Point(16, 24);
            this.typesListView.Name = "typesListView";
            this.typesListView.Size = new System.Drawing.Size(96, 144);
            this.typesListView.TabIndex = 11;
            // 
            // enemySpawnListViewControl
            // 
            this.enemySpawnListViewControl.DisplayedItem = null;
            this.enemySpawnListViewControl.Enabled = false;
            this.enemySpawnListViewControl.Location = new System.Drawing.Point(8, 24);
            this.enemySpawnListViewControl.Name = "enemySpawnListViewControl";
            this.enemySpawnListViewControl.Size = new System.Drawing.Size(264, 160);
            this.enemySpawnListViewControl.TabIndex = 0;
            // 
            // perLevelStatsViewControl
            // 
            this.perLevelStatsViewControl.DisplayedItem = null;
            this.perLevelStatsViewControl.Enabled = false;
            this.perLevelStatsViewControl.Location = new System.Drawing.Point(144, 37);
            this.perLevelStatsViewControl.Name = "perLevelStatsViewControl";
            this.perLevelStatsViewControl.Size = new System.Drawing.Size(80, 168);
            this.perLevelStatsViewControl.TabIndex = 27;
            // 
            // baseStatsViewControl
            // 
            this.baseStatsViewControl.DisplayedItem = null;
            this.baseStatsViewControl.Enabled = false;
            this.baseStatsViewControl.Location = new System.Drawing.Point(56, 37);
            this.baseStatsViewControl.Name = "baseStatsViewControl";
            this.baseStatsViewControl.Size = new System.Drawing.Size(80, 168);
            this.baseStatsViewControl.TabIndex = 26;
            // 
            // EnemyViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.spawnsGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.statsGroupBox);
            this.Name = "EnemyViewControl";
            this.Size = new System.Drawing.Size(624, 488);
            this.statsGroupBox.ResumeLayout(false);
            this.statsGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.spawnsGroupBox.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox displayNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox statsGroupBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox flavorDescriptionTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox flavorNameTextBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox internalNameTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox spawnsGroupBox;
        private Spawns.EnemySpawnListViewControl enemySpawnListViewControl;
        private StatSetViewControl perLevelStatsViewControl;
        private StatSetViewControl baseStatsViewControl;
        private System.Windows.Forms.GroupBox groupBox1;
        private StringListViewControl typesListView;
        private System.Windows.Forms.GroupBox groupBox3;
        private StringListViewControl immunitiesListView;
    }
}

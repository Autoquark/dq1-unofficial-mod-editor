namespace DQModEditor.Gui
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
            this.internalNameLabel = new System.Windows.Forms.Label();
            this.displayNameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.baseHpSpinner = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.baseArmorSpinner = new System.Windows.Forms.NumericUpDown();
            this.baseSpeedSpinner = new System.Windows.Forms.NumericUpDown();
            this.baseScrapSpinner = new System.Windows.Forms.NumericUpDown();
            this.basePsiSpinner = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.perLevelPsiSpinner = new System.Windows.Forms.NumericUpDown();
            this.perLevelScrapSpinner = new System.Windows.Forms.NumericUpDown();
            this.perLevelSpeedSpinner = new System.Windows.Forms.NumericUpDown();
            this.perLevelArmorSpinner = new System.Windows.Forms.NumericUpDown();
            this.perLevelHpSpinner = new System.Windows.Forms.NumericUpDown();
            this.perLevelXpSpinner = new System.Windows.Forms.NumericUpDown();
            this.baseXpSpinner = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.perLevelStrengthSpinner = new System.Windows.Forms.NumericUpDown();
            this.baseStrengthSpinner = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.flavorNameTextBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.flavorDescriptionTextBox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseHpSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseArmorSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseSpeedSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseScrapSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.basePsiSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perLevelPsiSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perLevelScrapSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perLevelSpeedSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perLevelArmorSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perLevelHpSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perLevelXpSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseXpSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.perLevelStrengthSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseStrengthSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // internalNameLabel
            // 
            this.internalNameLabel.AutoSize = true;
            this.internalNameLabel.Location = new System.Drawing.Point(64, 8);
            this.internalNameLabel.Name = "internalNameLabel";
            this.internalNameLabel.Size = new System.Drawing.Size(79, 13);
            this.internalNameLabel.TabIndex = 0;
            this.internalNameLabel.Text = "(Internal Name)";
            // 
            // displayNameTextBox
            // 
            this.displayNameTextBox.Location = new System.Drawing.Point(88, 21);
            this.displayNameTextBox.Name = "displayNameTextBox";
            this.displayNameTextBox.ReadOnly = true;
            this.displayNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.displayNameTextBox.TabIndex = 1;
            this.displayNameTextBox.Text = "(display name)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Display Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "HP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Armor";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.perLevelStrengthSpinner);
            this.groupBox1.Controls.Add(this.perLevelXpSpinner);
            this.groupBox1.Controls.Add(this.baseStrengthSpinner);
            this.groupBox1.Controls.Add(this.baseXpSpinner);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.perLevelPsiSpinner);
            this.groupBox1.Controls.Add(this.perLevelScrapSpinner);
            this.groupBox1.Controls.Add(this.perLevelSpeedSpinner);
            this.groupBox1.Controls.Add(this.perLevelArmorSpinner);
            this.groupBox1.Controls.Add(this.perLevelHpSpinner);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.basePsiSpinner);
            this.groupBox1.Controls.Add(this.baseScrapSpinner);
            this.groupBox1.Controls.Add(this.baseSpeedSpinner);
            this.groupBox1.Controls.Add(this.baseArmorSpinner);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.baseHpSpinner);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(8, 128);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 216);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Stats";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.flavorDescriptionTextBox);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.flavorNameTextBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.displayNameTextBox);
            this.groupBox2.Location = new System.Drawing.Point(8, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(608, 88);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Name && Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Speed";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Scrap";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Psi";
            // 
            // baseHpSpinner
            // 
            this.baseHpSpinner.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.baseHpSpinner.Location = new System.Drawing.Point(56, 45);
            this.baseHpSpinner.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.baseHpSpinner.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.baseHpSpinner.Name = "baseHpSpinner";
            this.baseHpSpinner.ReadOnly = true;
            this.baseHpSpinner.Size = new System.Drawing.Size(80, 20);
            this.baseHpSpinner.TabIndex = 13;
            this.baseHpSpinner.Value = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(80, 24);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Base";
            // 
            // baseArmorSpinner
            // 
            this.baseArmorSpinner.DecimalPlaces = 1;
            this.baseArmorSpinner.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.baseArmorSpinner.Location = new System.Drawing.Point(56, 69);
            this.baseArmorSpinner.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.baseArmorSpinner.Name = "baseArmorSpinner";
            this.baseArmorSpinner.ReadOnly = true;
            this.baseArmorSpinner.Size = new System.Drawing.Size(80, 20);
            this.baseArmorSpinner.TabIndex = 15;
            // 
            // baseSpeedSpinner
            // 
            this.baseSpeedSpinner.DecimalPlaces = 1;
            this.baseSpeedSpinner.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.baseSpeedSpinner.Location = new System.Drawing.Point(56, 93);
            this.baseSpeedSpinner.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.baseSpeedSpinner.Name = "baseSpeedSpinner";
            this.baseSpeedSpinner.ReadOnly = true;
            this.baseSpeedSpinner.Size = new System.Drawing.Size(80, 20);
            this.baseSpeedSpinner.TabIndex = 16;
            // 
            // baseScrapSpinner
            // 
            this.baseScrapSpinner.DecimalPlaces = 1;
            this.baseScrapSpinner.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.baseScrapSpinner.Location = new System.Drawing.Point(56, 117);
            this.baseScrapSpinner.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.baseScrapSpinner.Name = "baseScrapSpinner";
            this.baseScrapSpinner.ReadOnly = true;
            this.baseScrapSpinner.Size = new System.Drawing.Size(80, 20);
            this.baseScrapSpinner.TabIndex = 17;
            // 
            // basePsiSpinner
            // 
            this.basePsiSpinner.DecimalPlaces = 1;
            this.basePsiSpinner.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.basePsiSpinner.Location = new System.Drawing.Point(56, 141);
            this.basePsiSpinner.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.basePsiSpinner.Name = "basePsiSpinner";
            this.basePsiSpinner.ReadOnly = true;
            this.basePsiSpinner.Size = new System.Drawing.Size(80, 20);
            this.basePsiSpinner.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(152, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "Per Level";
            // 
            // perLevelPsiSpinner
            // 
            this.perLevelPsiSpinner.DecimalPlaces = 1;
            this.perLevelPsiSpinner.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.perLevelPsiSpinner.Location = new System.Drawing.Point(144, 141);
            this.perLevelPsiSpinner.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.perLevelPsiSpinner.Name = "perLevelPsiSpinner";
            this.perLevelPsiSpinner.ReadOnly = true;
            this.perLevelPsiSpinner.Size = new System.Drawing.Size(80, 20);
            this.perLevelPsiSpinner.TabIndex = 24;
            // 
            // perLevelScrapSpinner
            // 
            this.perLevelScrapSpinner.DecimalPlaces = 1;
            this.perLevelScrapSpinner.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.perLevelScrapSpinner.Location = new System.Drawing.Point(144, 117);
            this.perLevelScrapSpinner.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.perLevelScrapSpinner.Name = "perLevelScrapSpinner";
            this.perLevelScrapSpinner.ReadOnly = true;
            this.perLevelScrapSpinner.Size = new System.Drawing.Size(80, 20);
            this.perLevelScrapSpinner.TabIndex = 23;
            // 
            // perLevelSpeedSpinner
            // 
            this.perLevelSpeedSpinner.DecimalPlaces = 1;
            this.perLevelSpeedSpinner.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.perLevelSpeedSpinner.Location = new System.Drawing.Point(144, 93);
            this.perLevelSpeedSpinner.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.perLevelSpeedSpinner.Name = "perLevelSpeedSpinner";
            this.perLevelSpeedSpinner.ReadOnly = true;
            this.perLevelSpeedSpinner.Size = new System.Drawing.Size(80, 20);
            this.perLevelSpeedSpinner.TabIndex = 22;
            // 
            // perLevelArmorSpinner
            // 
            this.perLevelArmorSpinner.DecimalPlaces = 1;
            this.perLevelArmorSpinner.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.perLevelArmorSpinner.Location = new System.Drawing.Point(144, 69);
            this.perLevelArmorSpinner.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.perLevelArmorSpinner.Name = "perLevelArmorSpinner";
            this.perLevelArmorSpinner.ReadOnly = true;
            this.perLevelArmorSpinner.Size = new System.Drawing.Size(80, 20);
            this.perLevelArmorSpinner.TabIndex = 21;
            // 
            // perLevelHpSpinner
            // 
            this.perLevelHpSpinner.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.perLevelHpSpinner.Location = new System.Drawing.Point(144, 45);
            this.perLevelHpSpinner.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.perLevelHpSpinner.Name = "perLevelHpSpinner";
            this.perLevelHpSpinner.ReadOnly = true;
            this.perLevelHpSpinner.Size = new System.Drawing.Size(80, 20);
            this.perLevelHpSpinner.TabIndex = 20;
            this.perLevelHpSpinner.Value = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            // 
            // perLevelXpSpinner
            // 
            this.perLevelXpSpinner.DecimalPlaces = 1;
            this.perLevelXpSpinner.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.perLevelXpSpinner.Location = new System.Drawing.Point(144, 165);
            this.perLevelXpSpinner.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.perLevelXpSpinner.Name = "perLevelXpSpinner";
            this.perLevelXpSpinner.ReadOnly = true;
            this.perLevelXpSpinner.Size = new System.Drawing.Size(80, 20);
            this.perLevelXpSpinner.TabIndex = 27;
            // 
            // baseXpSpinner
            // 
            this.baseXpSpinner.DecimalPlaces = 1;
            this.baseXpSpinner.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.baseXpSpinner.Location = new System.Drawing.Point(56, 165);
            this.baseXpSpinner.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.baseXpSpinner.Name = "baseXpSpinner";
            this.baseXpSpinner.ReadOnly = true;
            this.baseXpSpinner.Size = new System.Drawing.Size(80, 20);
            this.baseXpSpinner.TabIndex = 26;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 168);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "XP";
            // 
            // perLevelStrengthSpinner
            // 
            this.perLevelStrengthSpinner.DecimalPlaces = 1;
            this.perLevelStrengthSpinner.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.perLevelStrengthSpinner.Location = new System.Drawing.Point(144, 189);
            this.perLevelStrengthSpinner.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.perLevelStrengthSpinner.Name = "perLevelStrengthSpinner";
            this.perLevelStrengthSpinner.ReadOnly = true;
            this.perLevelStrengthSpinner.Size = new System.Drawing.Size(80, 20);
            this.perLevelStrengthSpinner.TabIndex = 27;
            // 
            // baseStrengthSpinner
            // 
            this.baseStrengthSpinner.DecimalPlaces = 1;
            this.baseStrengthSpinner.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.baseStrengthSpinner.Location = new System.Drawing.Point(56, 189);
            this.baseStrengthSpinner.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.baseStrengthSpinner.Name = "baseStrengthSpinner";
            this.baseStrengthSpinner.ReadOnly = true;
            this.baseStrengthSpinner.Size = new System.Drawing.Size(80, 20);
            this.baseStrengthSpinner.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 192);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Strength";
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
            this.flavorNameTextBox.ReadOnly = true;
            this.flavorNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.flavorNameTextBox.TabIndex = 3;
            this.flavorNameTextBox.Text = "(display name)";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(296, 56);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Flavor Description";
            // 
            // flavorDescriptionTextBox
            // 
            this.flavorDescriptionTextBox.Location = new System.Drawing.Point(392, 53);
            this.flavorDescriptionTextBox.Name = "flavorDescriptionTextBox";
            this.flavorDescriptionTextBox.ReadOnly = true;
            this.flavorDescriptionTextBox.Size = new System.Drawing.Size(208, 20);
            this.flavorDescriptionTextBox.TabIndex = 5;
            this.flavorDescriptionTextBox.Text = "(display name)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(16, 8);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 9;
            this.label13.Text = "Enemy:";
            // 
            // EnemyViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label13);
            this.Controls.Add(this.internalNameLabel);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "EnemyViewControl";
            this.Size = new System.Drawing.Size(624, 534);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.baseHpSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseArmorSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseSpeedSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseScrapSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.basePsiSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perLevelPsiSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perLevelScrapSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perLevelSpeedSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perLevelArmorSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perLevelHpSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perLevelXpSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseXpSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.perLevelStrengthSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseStrengthSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label internalNameLabel;
        private System.Windows.Forms.TextBox displayNameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown perLevelXpSpinner;
        private System.Windows.Forms.NumericUpDown baseXpSpinner;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown perLevelPsiSpinner;
        private System.Windows.Forms.NumericUpDown perLevelScrapSpinner;
        private System.Windows.Forms.NumericUpDown perLevelSpeedSpinner;
        private System.Windows.Forms.NumericUpDown perLevelArmorSpinner;
        private System.Windows.Forms.NumericUpDown perLevelHpSpinner;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown basePsiSpinner;
        private System.Windows.Forms.NumericUpDown baseScrapSpinner;
        private System.Windows.Forms.NumericUpDown baseSpeedSpinner;
        private System.Windows.Forms.NumericUpDown baseArmorSpinner;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown baseHpSpinner;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown perLevelStrengthSpinner;
        private System.Windows.Forms.NumericUpDown baseStrengthSpinner;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox flavorDescriptionTextBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox flavorNameTextBox;
        private System.Windows.Forms.Label label13;
    }
}

namespace DQModEditor.Gui
{
    partial class StatSetViewControl
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
            this.strengthSpinner = new System.Windows.Forms.NumericUpDown();
            this.xpSpinner = new System.Windows.Forms.NumericUpDown();
            this.psiSpinner = new System.Windows.Forms.NumericUpDown();
            this.scrapSpinner = new System.Windows.Forms.NumericUpDown();
            this.speedSpinner = new System.Windows.Forms.NumericUpDown();
            this.armorSpinner = new System.Windows.Forms.NumericUpDown();
            this.hpSpinner = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.strengthSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.psiSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrapSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.armorSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hpSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // strengthSpinner
            // 
            this.strengthSpinner.DecimalPlaces = 1;
            this.strengthSpinner.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.strengthSpinner.Location = new System.Drawing.Point(0, 144);
            this.strengthSpinner.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.strengthSpinner.Name = "strengthSpinner";
            this.strengthSpinner.Size = new System.Drawing.Size(80, 20);
            this.strengthSpinner.TabIndex = 32;
            // 
            // xpSpinner
            // 
            this.xpSpinner.DecimalPlaces = 1;
            this.xpSpinner.Location = new System.Drawing.Point(0, 120);
            this.xpSpinner.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.xpSpinner.Name = "xpSpinner";
            this.xpSpinner.Size = new System.Drawing.Size(80, 20);
            this.xpSpinner.TabIndex = 33;
            // 
            // psiSpinner
            // 
            this.psiSpinner.DecimalPlaces = 1;
            this.psiSpinner.Location = new System.Drawing.Point(0, 96);
            this.psiSpinner.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.psiSpinner.Name = "psiSpinner";
            this.psiSpinner.Size = new System.Drawing.Size(80, 20);
            this.psiSpinner.TabIndex = 31;
            // 
            // scrapSpinner
            // 
            this.scrapSpinner.DecimalPlaces = 1;
            this.scrapSpinner.Location = new System.Drawing.Point(0, 72);
            this.scrapSpinner.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.scrapSpinner.Name = "scrapSpinner";
            this.scrapSpinner.Size = new System.Drawing.Size(80, 20);
            this.scrapSpinner.TabIndex = 30;
            // 
            // speedSpinner
            // 
            this.speedSpinner.DecimalPlaces = 1;
            this.speedSpinner.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.speedSpinner.Location = new System.Drawing.Point(0, 48);
            this.speedSpinner.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.speedSpinner.Name = "speedSpinner";
            this.speedSpinner.Size = new System.Drawing.Size(80, 20);
            this.speedSpinner.TabIndex = 29;
            // 
            // armorSpinner
            // 
            this.armorSpinner.DecimalPlaces = 1;
            this.armorSpinner.Location = new System.Drawing.Point(0, 24);
            this.armorSpinner.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.armorSpinner.Name = "armorSpinner";
            this.armorSpinner.Size = new System.Drawing.Size(80, 20);
            this.armorSpinner.TabIndex = 28;
            // 
            // hpSpinner
            // 
            this.hpSpinner.Location = new System.Drawing.Point(0, 0);
            this.hpSpinner.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.hpSpinner.Name = "hpSpinner";
            this.hpSpinner.Size = new System.Drawing.Size(80, 20);
            this.hpSpinner.TabIndex = 27;
            this.hpSpinner.Value = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            // 
            // StatSetViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.strengthSpinner);
            this.Controls.Add(this.xpSpinner);
            this.Controls.Add(this.psiSpinner);
            this.Controls.Add(this.scrapSpinner);
            this.Controls.Add(this.speedSpinner);
            this.Controls.Add(this.armorSpinner);
            this.Controls.Add(this.hpSpinner);
            this.Name = "StatSetViewControl";
            this.Size = new System.Drawing.Size(80, 168);
            ((System.ComponentModel.ISupportInitialize)(this.strengthSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.psiSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrapSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.armorSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hpSpinner)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown strengthSpinner;
        private System.Windows.Forms.NumericUpDown xpSpinner;
        private System.Windows.Forms.NumericUpDown psiSpinner;
        private System.Windows.Forms.NumericUpDown scrapSpinner;
        private System.Windows.Forms.NumericUpDown speedSpinner;
        private System.Windows.Forms.NumericUpDown armorSpinner;
        private System.Windows.Forms.NumericUpDown hpSpinner;
    }
}

namespace DQModEditor.Gui.Controls.Enemies.Resistances
{
    partial class ResistanceViewControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.flavorTextBox = new System.Windows.Forms.TextBox();
            this.effectLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.amountSpinner = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.amountSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flavor:";
            // 
            // flavorTextBox
            // 
            this.flavorTextBox.Location = new System.Drawing.Point(48, 0);
            this.flavorTextBox.Name = "flavorTextBox";
            this.flavorTextBox.Size = new System.Drawing.Size(88, 20);
            this.flavorTextBox.TabIndex = 1;
            this.flavorTextBox.Text = "physical-ranged";
            // 
            // effectLabel
            // 
            this.effectLabel.AutoSize = true;
            this.effectLabel.Location = new System.Drawing.Point(0, 40);
            this.effectLabel.Name = "effectLabel";
            this.effectLabel.Size = new System.Drawing.Size(38, 13);
            this.effectLabel.TabIndex = 2;
            this.effectLabel.Text = "Effect:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(0, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Amount:";
            // 
            // amountSpinner
            // 
            this.amountSpinner.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.amountSpinner.Location = new System.Drawing.Point(48, 101);
            this.amountSpinner.Name = "amountSpinner";
            this.amountSpinner.Size = new System.Drawing.Size(56, 20);
            this.amountSpinner.TabIndex = 6;
            // 
            // ResistanceViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.amountSpinner);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.effectLabel);
            this.Controls.Add(this.flavorTextBox);
            this.Controls.Add(this.label1);
            this.Name = "ResistanceViewControl";
            this.Size = new System.Drawing.Size(136, 128);
            ((System.ComponentModel.ISupportInitialize)(this.amountSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox flavorTextBox;
        private System.Windows.Forms.Label effectLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown amountSpinner;
    }
}

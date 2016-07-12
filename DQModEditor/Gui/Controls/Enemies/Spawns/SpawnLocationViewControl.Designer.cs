namespace DQModEditor.Gui.Controls.Enemies.Spawns
{
    partial class SpawnLocationViewControl
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
            this.yPosSpinner = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.xPosSpinner = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.yPosSpinner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xPosSpinner)).BeginInit();
            this.SuspendLayout();
            // 
            // yPosSpinner
            // 
            this.yPosSpinner.DecimalPlaces = 3;
            this.yPosSpinner.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.yPosSpinner.Location = new System.Drawing.Point(88, 0);
            this.yPosSpinner.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.yPosSpinner.Name = "yPosSpinner";
            this.yPosSpinner.Size = new System.Drawing.Size(56, 20);
            this.yPosSpinner.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Y:";
            // 
            // xPosSpinner
            // 
            this.xPosSpinner.DecimalPlaces = 3;
            this.xPosSpinner.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.xPosSpinner.Location = new System.Drawing.Point(16, 0);
            this.xPosSpinner.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.xPosSpinner.Name = "xPosSpinner";
            this.xPosSpinner.Size = new System.Drawing.Size(56, 20);
            this.xPosSpinner.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "X:";
            // 
            // SpawnLocationViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.yPosSpinner);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.xPosSpinner);
            this.Controls.Add(this.label1);
            this.Name = "SpawnLocationViewControl";
            this.Size = new System.Drawing.Size(152, 24);
            ((System.ComponentModel.ISupportInitialize)(this.yPosSpinner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xPosSpinner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown yPosSpinner;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown xPosSpinner;
        private System.Windows.Forms.Label label1;
    }
}

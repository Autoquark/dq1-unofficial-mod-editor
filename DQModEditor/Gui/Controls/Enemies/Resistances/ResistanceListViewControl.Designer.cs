namespace DQModEditor.Gui.Controls.Enemies.Resistances
{
    partial class ResistanceListViewControl
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
            this.resistancesListBox = new System.Windows.Forms.ListBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.resistanceViewControl = new DQModEditor.Gui.Controls.Enemies.Resistances.ResistanceViewControl();
            this.SuspendLayout();
            // 
            // resistancesListBox
            // 
            this.resistancesListBox.FormattingEnabled = true;
            this.resistancesListBox.Location = new System.Drawing.Point(0, 0);
            this.resistancesListBox.Name = "resistancesListBox";
            this.resistancesListBox.Size = new System.Drawing.Size(152, 108);
            this.resistancesListBox.TabIndex = 1;
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(104, 112);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(48, 23);
            this.clearButton.TabIndex = 6;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(48, 112);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(56, 23);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(0, 112);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(48, 23);
            this.addButton.TabIndex = 7;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            // 
            // resistanceViewControl
            // 
            this.resistanceViewControl.DisplayedItem = null;
            this.resistanceViewControl.Enabled = false;
            this.resistanceViewControl.Location = new System.Drawing.Point(160, 8);
            this.resistanceViewControl.Name = "resistanceViewControl";
            this.resistanceViewControl.Size = new System.Drawing.Size(144, 128);
            this.resistanceViewControl.TabIndex = 9;
            // 
            // ResistanceListViewControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.resistanceViewControl);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.resistancesListBox);
            this.Name = "ResistanceListViewControl";
            this.Size = new System.Drawing.Size(304, 144);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox resistancesListBox;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addButton;
        private ResistanceViewControl resistanceViewControl;
    }
}

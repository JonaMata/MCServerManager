namespace serverChooser
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.serverListBox = new System.Windows.Forms.ListBox();
            this.selectedServerLabel = new System.Windows.Forms.Label();
            this.addServerButton = new System.Windows.Forms.Button();
            this.addServerTextBox = new wmgCMS.WaterMarkTextBox();
            this.SuspendLayout();
            // 
            // serverListBox
            // 
            this.serverListBox.FormattingEnabled = true;
            this.serverListBox.Location = new System.Drawing.Point(13, 13);
            this.serverListBox.Name = "serverListBox";
            this.serverListBox.Size = new System.Drawing.Size(155, 199);
            this.serverListBox.TabIndex = 2;
            this.serverListBox.SelectedIndexChanged += new System.EventHandler(this.serverListBox_SelectedValueChanged);
            // 
            // selectedServerLabel
            // 
            this.selectedServerLabel.AutoSize = true;
            this.selectedServerLabel.Location = new System.Drawing.Point(175, 13);
            this.selectedServerLabel.Name = "selectedServerLabel";
            this.selectedServerLabel.Size = new System.Drawing.Size(0, 13);
            this.selectedServerLabel.TabIndex = 4;
            // 
            // addServerButton
            // 
            this.addServerButton.Location = new System.Drawing.Point(197, 226);
            this.addServerButton.Name = "addServerButton";
            this.addServerButton.Size = new System.Drawing.Size(75, 23);
            this.addServerButton.TabIndex = 5;
            this.addServerButton.Text = "Add Server";
            this.addServerButton.UseVisualStyleBackColor = true;
            this.addServerButton.Click += new System.EventHandler(this.addServerButton_Click);
            // 
            // addServerTextBox
            // 
            this.addServerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.addServerTextBox.Location = new System.Drawing.Point(13, 229);
            this.addServerTextBox.Name = "addServerTextBox";
            this.addServerTextBox.Size = new System.Drawing.Size(155, 20);
            this.addServerTextBox.TabIndex = 6;
            this.addServerTextBox.WaterMarkColor = System.Drawing.Color.Gray;
            this.addServerTextBox.WaterMarkText = "Type server name here...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.addServerTextBox);
            this.Controls.Add(this.addServerButton);
            this.Controls.Add(this.selectedServerLabel);
            this.Controls.Add(this.serverListBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox serverListBox;
        private System.Windows.Forms.Label selectedServerLabel;
        private System.Windows.Forms.Button addServerButton;
        private wmgCMS.WaterMarkTextBox addServerTextBox;
    }
}


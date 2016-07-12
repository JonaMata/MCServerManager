namespace MCServerManager
{
    partial class server
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
            this.serverBox = new System.Windows.Forms.RichTextBox();
            this.inputTextBox = new wmgCMS.WaterMarkTextBox();
            this.SuspendLayout();
            // 
            // serverBox
            // 
            this.serverBox.Location = new System.Drawing.Point(0, 0);
            this.serverBox.Name = "serverBox";
            this.serverBox.ReadOnly = true;
            this.serverBox.Size = new System.Drawing.Size(280, 240);
            this.serverBox.TabIndex = 0;
            this.serverBox.Text = "";
            // 
            // inputTextBox
            // 
            this.inputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.inputTextBox.Location = new System.Drawing.Point(0, 240);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(280, 20);
            this.inputTextBox.TabIndex = 1;
            this.inputTextBox.WaterMarkColor = System.Drawing.Color.Gray;
            this.inputTextBox.WaterMarkText = "Command...";
            this.inputTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.sendInput);
            // 
            // server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.serverBox);
            this.Name = "server";
            this.Text = "Server Runner";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClosedEventHandler);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox serverBox;
        private wmgCMS.WaterMarkTextBox inputTextBox;
    }
}
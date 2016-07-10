namespace serverChooser
{
    partial class buildtools
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
            this.buildtoolsOutput = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buildtoolsOutput
            // 
            this.buildtoolsOutput.Location = new System.Drawing.Point(0, 0);
            this.buildtoolsOutput.Name = "buildtoolsOutput";
            this.buildtoolsOutput.ReadOnly = true;
            this.buildtoolsOutput.Size = new System.Drawing.Size(280, 260);
            this.buildtoolsOutput.TabIndex = 0;
            this.buildtoolsOutput.Text = "";
            // 
            // buildtools
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.buildtoolsOutput);
            this.Name = "buildtools";
            this.Text = "buildtools";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClosedEventHandler);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox buildtoolsOutput;
    }
}
namespace MCServerManager
{
    partial class MCServerManager
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
            this.startServerButton = new System.Windows.Forms.Button();
            this.updateServerButton = new System.Windows.Forms.Button();
            this.deleteServerButton = new System.Windows.Forms.Button();
            this.editPropertiesButton = new System.Windows.Forms.Button();
            this.tabManager = new System.Windows.Forms.TabControl();
            this.serverManagerTab = new System.Windows.Forms.TabPage();
            this.addServerTextBox = new wmgCMS.WaterMarkTextBox();
            this.serverPortTextBox = new wmgCMS.WaterMarkTextBox();
            this.optionsTab = new System.Windows.Forms.TabPage();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.serverDirectoryButton = new System.Windows.Forms.Button();
            this.serverDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tabManager.SuspendLayout();
            this.serverManagerTab.SuspendLayout();
            this.optionsTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // serverListBox
            // 
            this.serverListBox.FormattingEnabled = true;
            this.serverListBox.Location = new System.Drawing.Point(6, 6);
            this.serverListBox.Name = "serverListBox";
            this.serverListBox.Size = new System.Drawing.Size(155, 186);
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
            this.addServerButton.Location = new System.Drawing.Point(167, 205);
            this.addServerButton.Name = "addServerButton";
            this.addServerButton.Size = new System.Drawing.Size(94, 23);
            this.addServerButton.TabIndex = 5;
            this.addServerButton.Text = "Add Server";
            this.addServerButton.UseVisualStyleBackColor = true;
            this.addServerButton.Click += new System.EventHandler(this.addServerButton_Click);
            // 
            // startServerButton
            // 
            this.startServerButton.Location = new System.Drawing.Point(167, 6);
            this.startServerButton.Name = "startServerButton";
            this.startServerButton.Size = new System.Drawing.Size(94, 23);
            this.startServerButton.TabIndex = 7;
            this.startServerButton.Text = "Start Server";
            this.startServerButton.UseVisualStyleBackColor = true;
            this.startServerButton.Click += new System.EventHandler(this.startServerButton_Click);
            // 
            // updateServerButton
            // 
            this.updateServerButton.Location = new System.Drawing.Point(167, 61);
            this.updateServerButton.Name = "updateServerButton";
            this.updateServerButton.Size = new System.Drawing.Size(94, 23);
            this.updateServerButton.TabIndex = 8;
            this.updateServerButton.Text = "Update Server";
            this.updateServerButton.UseVisualStyleBackColor = true;
            this.updateServerButton.Click += new System.EventHandler(this.updateServerButton_Click);
            // 
            // deleteServerButton
            // 
            this.deleteServerButton.Location = new System.Drawing.Point(167, 169);
            this.deleteServerButton.Name = "deleteServerButton";
            this.deleteServerButton.Size = new System.Drawing.Size(94, 23);
            this.deleteServerButton.TabIndex = 11;
            this.deleteServerButton.Text = "Delete Server";
            this.deleteServerButton.UseVisualStyleBackColor = true;
            this.deleteServerButton.Click += new System.EventHandler(this.deleteServerButton_Click);
            // 
            // editPropertiesButton
            // 
            this.editPropertiesButton.Location = new System.Drawing.Point(167, 90);
            this.editPropertiesButton.Name = "editPropertiesButton";
            this.editPropertiesButton.Size = new System.Drawing.Size(94, 23);
            this.editPropertiesButton.TabIndex = 12;
            this.editPropertiesButton.Text = "Edit Properties";
            this.editPropertiesButton.UseVisualStyleBackColor = true;
            this.editPropertiesButton.Click += new System.EventHandler(this.editPropertiesButton_Click);
            // 
            // tabManager
            // 
            this.tabManager.Controls.Add(this.serverManagerTab);
            this.tabManager.Controls.Add(this.optionsTab);
            this.tabManager.Location = new System.Drawing.Point(0, 0);
            this.tabManager.Name = "tabManager";
            this.tabManager.SelectedIndex = 0;
            this.tabManager.Size = new System.Drawing.Size(280, 260);
            this.tabManager.TabIndex = 13;
            this.tabManager.SelectedIndexChanged += new System.EventHandler(this.tabChanged);
            // 
            // serverManagerTab
            // 
            this.serverManagerTab.Controls.Add(this.button1);
            this.serverManagerTab.Controls.Add(this.serverListBox);
            this.serverManagerTab.Controls.Add(this.addServerButton);
            this.serverManagerTab.Controls.Add(this.deleteServerButton);
            this.serverManagerTab.Controls.Add(this.editPropertiesButton);
            this.serverManagerTab.Controls.Add(this.addServerTextBox);
            this.serverManagerTab.Controls.Add(this.startServerButton);
            this.serverManagerTab.Controls.Add(this.serverPortTextBox);
            this.serverManagerTab.Controls.Add(this.updateServerButton);
            this.serverManagerTab.Location = new System.Drawing.Point(4, 22);
            this.serverManagerTab.Name = "serverManagerTab";
            this.serverManagerTab.Padding = new System.Windows.Forms.Padding(3);
            this.serverManagerTab.Size = new System.Drawing.Size(272, 234);
            this.serverManagerTab.TabIndex = 0;
            this.serverManagerTab.Text = "Server Manager";
            this.serverManagerTab.UseVisualStyleBackColor = true;
            // 
            // addServerTextBox
            // 
            this.addServerTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.addServerTextBox.Location = new System.Drawing.Point(6, 208);
            this.addServerTextBox.Name = "addServerTextBox";
            this.addServerTextBox.Size = new System.Drawing.Size(155, 20);
            this.addServerTextBox.TabIndex = 6;
            this.addServerTextBox.WaterMarkColor = System.Drawing.Color.Gray;
            this.addServerTextBox.WaterMarkText = "Type server name here...";
            // 
            // serverPortTextBox
            // 
            this.serverPortTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.serverPortTextBox.Location = new System.Drawing.Point(167, 35);
            this.serverPortTextBox.Name = "serverPortTextBox";
            this.serverPortTextBox.Size = new System.Drawing.Size(94, 20);
            this.serverPortTextBox.TabIndex = 9;
            this.serverPortTextBox.WaterMarkColor = System.Drawing.Color.Gray;
            this.serverPortTextBox.WaterMarkText = "Server Port";
            // 
            // optionsTab
            // 
            this.optionsTab.Controls.Add(this.saveButton);
            this.optionsTab.Controls.Add(this.cancelButton);
            this.optionsTab.Controls.Add(this.serverDirectoryButton);
            this.optionsTab.Controls.Add(this.serverDirectoryTextBox);
            this.optionsTab.Controls.Add(this.label1);
            this.optionsTab.Location = new System.Drawing.Point(4, 22);
            this.optionsTab.Name = "optionsTab";
            this.optionsTab.Padding = new System.Windows.Forms.Padding(3);
            this.optionsTab.Size = new System.Drawing.Size(272, 234);
            this.optionsTab.TabIndex = 1;
            this.optionsTab.Text = "Options";
            this.optionsTab.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(110, 203);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(191, 204);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // serverDirectoryButton
            // 
            this.serverDirectoryButton.Location = new System.Drawing.Point(205, 6);
            this.serverDirectoryButton.Name = "serverDirectoryButton";
            this.serverDirectoryButton.Size = new System.Drawing.Size(61, 23);
            this.serverDirectoryButton.TabIndex = 2;
            this.serverDirectoryButton.Text = "Choose";
            this.serverDirectoryButton.UseVisualStyleBackColor = true;
            this.serverDirectoryButton.Click += new System.EventHandler(this.serverDirectoryButton_Click);
            // 
            // serverDirectoryTextBox
            // 
            this.serverDirectoryTextBox.Location = new System.Drawing.Point(99, 7);
            this.serverDirectoryTextBox.Name = "serverDirectoryTextBox";
            this.serverDirectoryTextBox.Size = new System.Drawing.Size(100, 20);
            this.serverDirectoryTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Directory:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(167, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Open Folder";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MCServerManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.tabManager);
            this.Controls.Add(this.selectedServerLabel);
            this.Name = "MCServerManager";
            this.Text = "MC Server Manager";
            this.tabManager.ResumeLayout(false);
            this.serverManagerTab.ResumeLayout(false);
            this.serverManagerTab.PerformLayout();
            this.optionsTab.ResumeLayout(false);
            this.optionsTab.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox serverListBox;
        private System.Windows.Forms.Label selectedServerLabel;
        private System.Windows.Forms.Button addServerButton;
        private wmgCMS.WaterMarkTextBox addServerTextBox;
        private System.Windows.Forms.Button startServerButton;
        private System.Windows.Forms.Button updateServerButton;
        private wmgCMS.WaterMarkTextBox serverPortTextBox;
        private System.Windows.Forms.Button deleteServerButton;
        private System.Windows.Forms.Button editPropertiesButton;
        private System.Windows.Forms.TabControl tabManager;
        private System.Windows.Forms.TabPage serverManagerTab;
        private System.Windows.Forms.TabPage optionsTab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel serverDirectoryLinkLabel;
        private System.Windows.Forms.Button serverDirectoryButton;
        private System.Windows.Forms.TextBox serverDirectoryTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button button1;
    }
}


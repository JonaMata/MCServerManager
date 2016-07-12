using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Diagnostics;
using Ookii.Dialogs;
using static MCServerManager.filepaths;

namespace MCServerManager
{
    public partial class MCServerManager : Form
    {
        Dictionary<String, String> serverList = new Dictionary<String, String>();
        int number = 1;
        String name;
        public static buildtools bt;
        public static server sv;

        public MCServerManager()
        {
            InitializeComponent();

            //Server Manager Tab

            if (Properties.Settings.Default.upgradeRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.upgradeRequired = false;
                Properties.Settings.Default.Save();
            }

            //readSettings();
            if (Properties.Settings.Default.firstRun == true)
            {
                firstRun();
            }
            else
            {
                AcceptButton = addServerButton;
                addServerTextBox.Cursor = Cursors.IBeam;
                serverInfo.port = "25565";
                refreshServers();
            }





            
            

            


        }
        

        private void firstRun()
        {
            DialogResult chooseFolder = MessageBox.Show("This is the first time you run this application.\nPlease choose a server directory.", "Change server directory");

            firstRunServerDirChooser();
        }

        private void firstRunServerDirChooser()
        {
            try
            {
                string newServerDir;
                VistaFolderBrowserDialog folderBrowser = new VistaFolderBrowserDialog();
                folderBrowser.SelectedPath = Properties.Settings.Default.serverDir;
                folderBrowser.ShowNewFolderButton = true;
                if (folderBrowser.ShowDialog() == DialogResult.OK)
                {
                    newServerDir = folderBrowser.SelectedPath;
                    if (Directory.Exists(newServerDir))
                    {
                        if (isDirectoryEmpty(newServerDir) == true)
                        {
                            Properties.Settings.Default.serverDir = newServerDir;
                            firstRunSuccess();
                        }
                        else
                        {
                            MessageBox.Show("This directory isn't empty, please select an empty directory.", "Directory not empty!");
                            firstRunServerDirChooser();
                        }

                    }
                    else
                    {
                        if (MessageBox.Show("Folder doesn't exist.\nDo you want to create the new folder?", "Folder doesn't exist", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Directory.CreateDirectory(newServerDir);
                            if (Directory.Exists(newServerDir))
                            {
                                if (isDirectoryEmpty(newServerDir) == true)
                                {
                                    Properties.Settings.Default.serverDir = newServerDir;
                                    firstRunSuccess();
                                }
                                else
                                {
                                    MessageBox.Show("This directory isn't empty, please select an empty directory.", "Directory not empty!");
                                    firstRunServerDirChooser();
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Error selecting the server directory, please try again.", "Error!");
                            firstRunServerDirChooser();
                        }
                    }
                }
                else
                {
                    if (MessageBox.Show("Error selecting the server directory\nDo you want to try again?", "Error!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        firstRunServerDirChooser();
                    }
                    else
                    {
                        this.Close();
                    }
                }
            }
             catch (Exception)
            {
                MessageBox.Show("You don't have the correct permissions to access this directory, please choose another directory.", "Error!");
                firstRunServerDirChooser();
            }
            
        }

        private void firstRunSuccess()
        {
            Properties.Settings.Default.firstRun = false;
            Properties.Settings.Default.Save();
            this.Text = "Server Chooser";
            AcceptButton = addServerButton;
            addServerTextBox.Cursor = Cursors.IBeam;
            serverInfo.port = "25565";
            refreshServers();
        }


        private void refreshServers()
        {
            //clear listbox and dictionary
            serverListBox.DataSource = null;
            serverList.Clear();


            try
            {
                number = 1;
                string[] servers = Directory.GetDirectories(Properties.Settings.Default.serverDir);
                foreach (string server in servers)
                {
                    string serverPath = string.Format(@"{0}", server);
                    //create name
                    name = String.Format(number.ToString());
                    //check name
                    if (serverList.ContainsKey(name))
                    {
                        serverList[name] = Path.GetFileName(server);
                    }
                    else
                    {
                        serverList.Add(name, Path.GetFileName(server));
                    }
                    number += 1;
                }



                

                //Show all dictionary items
                /*
                foreach (KeyValuePair<String, String> kvp in serverList)
                {
                    Console.WriteLine(String.Format("Key: {0} - Value: {1}", kvp.Key, kvp.Value));
                }
                */

                //choose one of the servers and select it's name
                //Console.WriteLine();
                //Console.Write("Choose one of the servers above: ");
                //string server = Console.ReadLine();
                //Console.WriteLine();
                //Console.WriteLine("You chose the {0}.", serverList[server]);
                //Console.ReadLine();
                if (serverList.ContainsKey("1"))
                {
                    serverListBox.DataSource = new BindingSource(serverList, null);
                    serverListBox.DisplayMember = "Value";
                    serverListBox.ValueMember = "Value";
                    selectedServerLabel.Text = serverListBox.SelectedValue.ToString();
                }
                else
                    selectedServerLabel.Text = null;
                

            }



            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        private void serverListBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (serverListBox.SelectedIndex != -1)
            {
                string selectedServer = serverListBox.SelectedValue.ToString();
                //string orbit = ListBox1.SelectedValue.ToString();
                selectedServerLabel.Text = selectedServer;
            }
        }

        private void selectServer_Click(object sender, EventArgs e)
        {
            string selectedServer = serverListBox.SelectedItem.ToString();
            selectedServerLabel.Text = selectedServer;
        }

        private void addServerButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Check if directory exists, if not create one
                string newServer = addServerTextBox.Text;
                string newServerDir = string.Format(@"{0}\{1}", Properties.Settings.Default.serverDir, newServer);
                if (!Directory.Exists(newServerDir))
                {
                    Directory.CreateDirectory(newServerDir);
                }
                else
                {
                    MessageBox.Show("This server already exists!", "Error!");
                }


            }


            finally
            {
                refreshServers();
                serverListBox.SelectedValue = addServerTextBox.Text;
                addServerTextBox.Text = null;
            }
        }

        private void startServerButton_Click(object sender, EventArgs e)
        {
            string selectedServer = selectedServerLabel.Text;
            dir.server = string.Format(@"{0}\{1}\", Properties.Settings.Default.serverDir, selectedServer);
            path.spigot = string.Format(@"{0}\{1}\spigot.jar", Properties.Settings.Default.serverDir, selectedServer);
            path.java = string.Format(@"{0}\java\bin\java.exe", Environment.CurrentDirectory);
            path.eula = string.Format(@"{0}\{1}\eula.txt", Properties.Settings.Default.serverDir, selectedServer);
            if (File.Exists(path.spigot))
            {
                if (File.ReadLines(path.eula).Any(line => line.Contains("eula=false")))
                {
                    DialogResult eulaAccept = MessageBox.Show("Do want to agree to the eula? \n https://account.mojang.com/documents/minecraft_eula", "EULA ERROR!", MessageBoxButtons.YesNo);
                    if (eulaAccept == DialogResult.Yes)
                        File.WriteAllText(path.eula, File.ReadAllText(path.eula).Replace("eula=false", "eula=true"));
                }
                serverInfo.port = serverPortTextBox.Text;
                serverPortTextBox.Text = null;
                sv = new server();
                sv.Show();
            }
            else
            {
                MessageBox.Show("spigot file doesn't exist, please update this server before running.", "No spigot file!");
            }
        }

        private void updateServerButton_Click(object sender, EventArgs e)
        {
            string selectedServer = selectedServerLabel.Text;
            dir.server = string.Format(@"{0}\{1}\", Properties.Settings.Default.serverDir, selectedServer);
            path.buildtools = string.Format(@"{0}\{1}\BuildTools.jar", Properties.Settings.Default.serverDir, selectedServer);
            path.java = string.Format("{0}/java/bin/java.exe", Environment.CurrentDirectory.ToString().Replace("\\", "/"));

            bt = new buildtools();
            bt.Show();
        }
        

        private void deleteServerButton_Click(object sender, EventArgs e)
        {
            if (selectedServerLabel.Text != null)
            {
                string deleteServer = selectedServerLabel.Text;
                DialogResult deleteCheck = MessageBox.Show(string.Format("Are you sure you want to delete {0}?", deleteServer), "Delete!", MessageBoxButtons.YesNo);
                if (deleteCheck == DialogResult.Yes)
                {
                    DirectoryInfo deleteDir = new DirectoryInfo(string.Format(@"{0}\{1}\", Properties.Settings.Default.serverDir, deleteServer));
                    if (deleteDir.Exists)
                    {
                        foreach (FileInfo file in deleteDir.GetFiles())
                        {
                            file.Delete();
                        }
                        foreach (DirectoryInfo dir in deleteDir.GetDirectories())
                        {
                            dir.Delete(true);
                        }
                        Directory.Delete(string.Format(@"{0}\{1}\", Properties.Settings.Default.serverDir, deleteServer), true);
                    }
                    
                }
            }
        }

        private void editPropertiesButton_Click(object sender, EventArgs e)
        {
            string selectedServer = selectedServerLabel.Text;
            path.properties = string.Format(@"{0}\{1}\server.properties", Properties.Settings.Default.serverDir, selectedServer);
            if (File.Exists(path.properties))
            {
                Process.Start("notepad.exe", path.properties);
            }
            else
            {
                MessageBox.Show("server.properties doesn't exist, please update your server first.", "ERROR!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedServer = selectedServerLabel.Text;
            dir.server = string.Format(@"{0}\{1}\", Properties.Settings.Default.serverDir, selectedServer);
            Process.Start(dir.server);
        }










        //Options Tab

        private void tabChanged(object sender, EventArgs e)
        {
            if (tabManager.SelectedTab == serverManagerTab)
            {
                refreshServers();
            }
            else if (tabManager.SelectedTab == optionsTab)
            {
                refreshOptions();
            }
        }

        private void refreshOptions()
        {
            serverDirectoryTextBox.Text = Properties.Settings.Default.serverDir;
        }

        private void serverDirectoryButton_Click(object sender, EventArgs e)
        {
            VistaFolderBrowserDialog folderBrowser = new VistaFolderBrowserDialog();
            folderBrowser.SelectedPath = Properties.Settings.Default.serverDir;
            folderBrowser.ShowNewFolderButton = true;
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                if (Directory.Exists(folderBrowser.SelectedPath))
                {
                    serverDirectoryTextBox.Text = folderBrowser.SelectedPath;
                }
                else
                {
                    MessageBox.Show("Failed to select the new server folder.", "Failed!");
                }

            }
        }

        public bool isDirectoryEmpty(string path)
        {
            return !Directory.EnumerateFileSystemEntries(path).Any();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string newServerDir = string.Format(@"{0}", serverDirectoryTextBox.Text);
            if (Directory.Exists(serverDirectoryTextBox.Text))
            {
                if (isDirectoryEmpty(newServerDir) == true)
                {
                    Directory.Move(Properties.Settings.Default.serverDir, newServerDir);
                    Properties.Settings.Default.serverDir = newServerDir;
                    Properties.Settings.Default.Save();
                    refreshOptions();
                }
                else
                {
                    MessageBox.Show("This directory isn't empty, please select an empty directory.", "Directory not empty!");
                    refreshOptions();
                }
                
            }
            else
            {
                if (MessageBox.Show("Folder doesn't exist.\nDo you want to create the new folder?", "Folder doesn't exist", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Directory.CreateDirectory(newServerDir);
                    if (Directory.Exists(newServerDir))
                    {
                        if (isDirectoryEmpty(newServerDir) == true)
                        {
                            Directory.Move(Properties.Settings.Default.serverDir, newServerDir);
                            Properties.Settings.Default.serverDir = newServerDir;
                            Properties.Settings.Default.Save();
                            refreshOptions();
                        }
                        else
                        {
                            MessageBox.Show("This directory isn't empty, please select an empty directory.", "Directory not empty!");
                            refreshOptions();
                        }
                    }
                }
                else
                {
                    refreshOptions();
                }
            }
        }



        private void cancelButton_Click(object sender, EventArgs e)
        {
            refreshOptions();
        }

        
    }
}

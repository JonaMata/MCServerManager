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
using static serverChooser.filepaths;

namespace serverChooser
{
    public partial class Form1 : Form
    {
        Dictionary<String, String> serverList = new Dictionary<String, String>();
        String line;
        int number = 1;
        String name;
        public static buildtools bt;
        public static server sv;

        public Form1()
        {
            InitializeComponent();
            this.Text = "Server Chooser";
            AcceptButton = addServerButton;
            addServerTextBox.Cursor = Cursors.IBeam;

            refreshServers();

            



        }

        private void refreshServers()
        {
            //clear listbox and dictionary
            serverListBox.DataSource = null;
            serverList.Clear();


            try
            {
                StreamReader sr = new StreamReader("serverList.txt");
                sr.ReadLine();
                line = sr.ReadLine();
                number = 1;

                if (line != null)
                {
                    while (line != null)
                    {
                        //Check if directory exists, if not create one
                        if (Directory.Exists(string.Format(@"{0}\server\{1}", Environment.CurrentDirectory, line))) { }
                        else
                        {
                            Directory.CreateDirectory(string.Format(@"{0}\servers\{1}", Environment.CurrentDirectory, line));
                        }


                        //create name
                        name = String.Format(number.ToString());
                        //check name
                        if (serverList.ContainsKey(name))
                        {
                            serverList[name] = number.ToString();
                        }
                        else
                        {
                            serverList.Add(name, line);
                        }


                        line = sr.ReadLine();
                        number += 1;





                    }
                }
                
                sr.Close();



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
                if (Directory.Exists(string.Format(@"{0}\servers\{1}", Environment.CurrentDirectory, addServerTextBox.Text)))
                {
                    MessageBox.Show("This server already exists!", "Error!");
                }
                else
                {
                    StreamWriter sw = File.AppendText("serverList.txt");
                    sw.WriteLine();
                    sw.Write(addServerTextBox.Text);
                    sw.Close();

                    //create name
                    name = String.Format(number.ToString());
                    //check name
                    if (serverList.ContainsKey(name))
                    {
                        serverList[name] = number.ToString();
                    }
                    else
                    {
                        serverList.Add(name, addServerTextBox.Text);
                    }


                    number += 1;
                    Directory.CreateDirectory(string.Format(@"{0}\servers\{1}", Environment.CurrentDirectory, addServerTextBox.Text));
                }
                


            }


            finally
            {
                serverListBox.DataSource = new BindingSource(serverList, null);
                serverListBox.DisplayMember = "Value";
                serverListBox.ValueMember = "Value";
                selectedServerLabel.Text = addServerTextBox.Text;
                serverListBox.SelectedValue = addServerTextBox.Text;
                addServerTextBox.Text = null;
            }
        }

        private void startServerButton_Click(object sender, EventArgs e)
        {
            path.spigot = string.Format(@"{0}\servers\{1}\spigot.jar", Environment.CurrentDirectory, selectedServerLabel.Text);
            path.java = string.Format(@"{0}\java\bin\java.exe", Environment.CurrentDirectory);
            if (File.Exists(path.spigot))
            {
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
            dir.server = string.Format(@"{0}\servers\{1}\", Environment.CurrentDirectory, selectedServerLabel.Text);
            path.buildtools = string.Format("{0}/servers/{1}/BuildTools.jar", Environment.CurrentDirectory ,selectedServerLabel.Text);

            bt = new buildtools();
            bt.Show();
        }
        
        private void downloadProgress(object sender, DownloadProgressChangedEventArgs e)
        {
            updateServerProgressBar.Value = e.ProgressPercentage;
        }

        private void deleteServerButton_Click(object sender, EventArgs e)
        {
            if (selectedServerLabel.Text != null)
            {
                string deleteServer = selectedServerLabel.Text;
                DialogResult deleteCheck = MessageBox.Show(string.Format("Are you sure you want to delete {0}?", deleteServer), "Delete!", MessageBoxButtons.YesNo);
                if (deleteCheck == DialogResult.Yes)
                {
                    DirectoryInfo deleteDir = new DirectoryInfo(string.Format(@"{0}\servers\{1}\", Environment.CurrentDirectory, deleteServer));

                    foreach (FileInfo file in deleteDir.GetFiles())
                    {
                        file.Delete();
                    }
                    foreach (DirectoryInfo dir in deleteDir.GetDirectories())
                    {
                        dir.Delete(true);
                    }
                    Directory.Delete(string.Format(@"{0}\servers\{1}\", Environment.CurrentDirectory, deleteServer), true);
                    File.WriteAllLines("serverList.txt", File.ReadLines("serverList.txt").Where(l => l != deleteServer).ToList());
                    refreshServers();
                }
            }
        }
    }
}

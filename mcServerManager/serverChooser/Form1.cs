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

namespace serverChooser
{
    public partial class Form1 : Form
    {
        Dictionary<String, String> serverList = new Dictionary<String, String>();
        public Form1()
        {
            InitializeComponent();

            
            String line;
            var number = 1;
            String name;
            try
            {
                StreamReader sr = new StreamReader("serverList.txt");
                line = sr.ReadLine();
                number = 1;
                

                while (line != null)
                {

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
                serverListBox.DataSource = new BindingSource(serverList, null);
                serverListBox.DisplayMember = "Value";
                serverListBox.ValueMember = "Value";

            }



            finally
            {
                selectedServerLabel.Text = null;
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
                StreamWriter sw = File.AppendText("serverList.txt");
                sw.WriteLine();
                sw.Write(addServerTextBox.Text);
                sw.Close();
            }
            finally
            {
                
                selectedServerLabel.Text = addServerTextBox.Text;
            }
        }
    }
}

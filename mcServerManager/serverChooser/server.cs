using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using static serverChooser.filepaths;
using System.Threading;
using System.IO;

namespace serverChooser
{
    using System.Runtime.InteropServices;

    public partial class server : Form
    {

        private delegate void AppendRawTextDelegat(string text);
        private readonly AppendRawTextDelegat _appendRawDelegate;

        private readonly serverRunner runner;

        Thread thread;

        

        public server()
        {
            InitializeComponent();
            runner = new serverRunner(this);
            _appendRawDelegate = AppendRawText;
            startServer();


        }

        private void startServer()
        {
            thread = new Thread(delegate () {
                runner.runServer();
            });
            thread.Start();
        }

        public void AppendRawText(string text)
        {
            if (InvokeRequired)
            {
                Invoke(_appendRawDelegate, text);
            }
            else
            {
                serverBox.AppendText(text + "\n");
                serverBox.ScrollToCaret();
            }
        }

        public void updateError()
        {
            MessageBox.Show("There was en error while starting the server", "Error!");
        }

        public void FormClosedEventHandler(object sender, FormClosedEventArgs e)
        {
            thread.Abort();
        }

        private void sendInput(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                runner.sendInput(inputTextBox.Text);
                inputTextBox.Text = null;
            }
        }




    }
}

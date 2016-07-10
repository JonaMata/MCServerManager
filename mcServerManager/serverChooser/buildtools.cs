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

namespace serverChooser
{
    using System.Runtime.InteropServices;

    public partial class buildtools : Form
    {

        private delegate void AppendRawTextDelegat(string text);
        private readonly AppendRawTextDelegat _appendRawDelegate;

        private readonly buildtoolsRunner runner;

        Thread thread;

        public buildtools()
        {
            InitializeComponent();
            runner = new buildtoolsRunner(this);
            _appendRawDelegate = AppendRawText;
            startBuildtools();
            
            
        }

        private void startBuildtools()
        {
            thread = new Thread(delegate () {
                runner.runBuildtools();
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
                buildtoolsOutput.AppendText(text + "\n");
                buildtoolsOutput.ScrollToCaret();
            }
        }

        public void updateError()
        {
            MessageBox.Show("There was en error while updating the server", "Error!");
        }

        public void FormClosedEventHandler(object sender, FormClosedEventArgs e)
        {
            thread.Abort();
        }
    }
}

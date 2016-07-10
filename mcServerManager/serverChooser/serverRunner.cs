using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Net;
using static serverChooser.filepaths;

namespace serverChooser
{
    class serverRunner
    {
        private readonly server sv;

        private readonly HashSet<IDisposable> _disposables = new HashSet<IDisposable>();

        public Process buildProcess;

        StreamWriter inputWriter;

        public serverRunner(server form)
        {
            sv = form;
        }

        bool succes = true;

        public void runServer()
        {
            using (buildProcess = new Process())
            {
                _disposables.Add(buildProcess);
                try
                {
                    buildProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    buildProcess.StartInfo.CreateNoWindow = true;
                    buildProcess.StartInfo.FileName = path.java;
                    buildProcess.StartInfo.UseShellExecute = false;
                    buildProcess.StartInfo.RedirectStandardOutput = true;
                    buildProcess.StartInfo.RedirectStandardError = true;
                    buildProcess.StartInfo.RedirectStandardInput = true;
                    buildProcess.StartInfo.WorkingDirectory = dir.server;
                    buildProcess.StartInfo.Arguments =
                        string.Format(" -jar \"{0}\"", path.spigot);
                    buildProcess.OutputDataReceived += (sender, args) => sv.AppendRawText(args.Data);
                    buildProcess.ErrorDataReceived += (sender, args) => sv.AppendRawText(args.Data);
                    buildProcess.Start();
                    inputWriter = buildProcess.StandardInput;
                    buildProcess.BeginOutputReadLine();
                    buildProcess.BeginErrorReadLine();
                    buildProcess.WaitForExit();
                    if (buildProcess.ExitCode != 0)
                        throw new Exception();
                }
                catch (Exception e)
                {
                    sv.AppendRawText(e.ToString());
                    sv.updateError();
                    succes = false;
                }
                finally
                {
                    if (succes)
                    {
                        sv.AppendRawText("Server stopped succesfully!");
                        _disposables.Remove(buildProcess);
                    }

                }
            }

        }

        public void sendInput(string input)
        {
            inputWriter.WriteLine(input);
        }
    }
}

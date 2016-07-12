using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Net;
using static MCServerManager.filepaths;

namespace MCServerManager
{
    class serverRunner
    {
        private readonly server sv;

        private readonly HashSet<IDisposable> _disposables = new HashSet<IDisposable>();

        public Process serverProcess;

        StreamWriter inputWriter;

        public serverRunner(server form)
        {
            sv = form;
        }

        bool succes = true;

        public void runServer()
        {
            using (serverProcess = new Process())
            {
                _disposables.Add(serverProcess);
                try
                {
                    serverProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    serverProcess.StartInfo.CreateNoWindow = true;
                    serverProcess.StartInfo.FileName = path.java;
                    serverProcess.StartInfo.UseShellExecute = false;
                    serverProcess.StartInfo.RedirectStandardOutput = true;
                    serverProcess.StartInfo.RedirectStandardError = true;
                    serverProcess.StartInfo.RedirectStandardInput = true;
                    serverProcess.StartInfo.WorkingDirectory = dir.server;
                    serverProcess.StartInfo.Arguments =
                        string.Format(" -jar \"{0}\" -p " + serverInfo.port, path.spigot);
                    serverProcess.OutputDataReceived += (sender, args) => sv.AppendRawText(args.Data);
                    serverProcess.ErrorDataReceived += (sender, args) => sv.AppendRawText(args.Data);
                    serverProcess.Start();
                    inputWriter = serverProcess.StandardInput;
                    serverProcess.BeginOutputReadLine();
                    serverProcess.BeginErrorReadLine();
                    serverProcess.WaitForExit();
                    if (serverProcess.ExitCode != 0)
                        throw new Exception(serverProcess.ExitCode.ToString());
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
                        _disposables.Remove(serverProcess);
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

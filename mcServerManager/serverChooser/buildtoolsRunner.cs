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
    class buildtoolsRunner
    {
        private readonly buildtools bt;

        private readonly HashSet<IDisposable> _disposables = new HashSet<IDisposable>();

        WebClient downloader = new WebClient();

        public buildtoolsRunner(buildtools form)
        {
            bt = form;
        }

        bool succes = true;

        public void runBuildtools()
        {
            downloader.DownloadFile("https://hub.spigotmc.org/jenkins/job/BuildTools/lastSuccessfulBuild/artifact/target/BuildTools.jar", path.buildtools);
            if (File.Exists(path.buildtools))
            {
                using (Process buildProcess = new Process())
                {
                    _disposables.Add(buildProcess);
                    try
                    {
                        buildProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        buildProcess.StartInfo.CreateNoWindow = true;
                        buildProcess.StartInfo.FileName = "./git//bin/bash.exe";
                        buildProcess.StartInfo.UseShellExecute = false;
                        buildProcess.StartInfo.RedirectStandardOutput = true;
                        buildProcess.StartInfo.RedirectStandardError = true;
                        buildProcess.StartInfo.WorkingDirectory = dir.server;
                        buildProcess.StartInfo.Arguments =
                            "--login -c \"git config --global --replace-all core.autocrlf true & ../../java/bin/java.exe -jar BuildTools.jar\"";
                        buildProcess.OutputDataReceived += (sender, args) => bt.AppendRawText(args.Data);
                        buildProcess.ErrorDataReceived += (sender, args) => bt.AppendRawText(args.Data);
                        buildProcess.Start();
                        buildProcess.BeginOutputReadLine();
                        buildProcess.BeginErrorReadLine();
                        buildProcess.WaitForExit();
                        if (buildProcess.ExitCode != 0)
                            throw new Exception();
                    }
                    catch (Exception e)
                    {
                        bt.AppendRawText(e.ToString());
                        bt.updateError();
                        succes = false;
                    }
                    finally
                    {
                        if (succes)
                        {
                            string[] currentSpigotFile = Directory.GetFiles(dir.server, "spigot*");
                            foreach (string file in currentSpigotFile)
                            {
                                File.Delete(path.spigot);
                                File.Move(file, path.spigot);
                            }
                            bt.AppendRawText("Server update finished suucesfully!");
                            _disposables.Remove(buildProcess);
                        }

                    }
                }

            
            }
        }
        
        
    }
}

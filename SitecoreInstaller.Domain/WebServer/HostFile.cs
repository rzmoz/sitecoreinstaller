using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.WebServer
{
    using System.Security;

    using SitecoreInstaller.Framework.Diagnostics;
    using SitecoreInstaller.Framework.Sys;

    public class HostFile
    {
        private static readonly FileInfo _hostFile = new FileInfo(@"C:\Windows\System32\drivers\etc\hosts");

        public bool HasWritePermissions()
        {
            try
            {
                using (var writer = _hostFile.OpenWrite())
                {
                    writer.Close();
                    return true;
                }
            }
            catch (UnauthorizedAccessException)
            {
                return false;
            }
            catch (SecurityException)
            {
                return false;
            }
        }

        public void AddHostName(string hostName)
        {
            if (string.IsNullOrEmpty(hostName))
            {
                Log.ToApp.Error("Host name is null or empty - please provide a hostname");
                return;
            }

            if (!_hostFile.Exists)
            {
                Log.ToApp.Error("Host file not found at {0}:", _hostFile.FullName);
                return;
            }

            var hostFileIisSiteName = hostName.ToLowerInvariant();
            var addNewline = false;

            Log.ToApp.Info("Adding hostname '{0}'", hostFileIisSiteName);

            //check if host name already exist
            Stream reader = null;
            try
            {
                reader = _hostFile.OpenRead();
                using (var fileReader = new StreamReader(reader))
                {
                    try
                    {
                        while (fileReader.Peek() >= 0)
                        {
                            var line = fileReader.ReadLine();
                            if (line == null)
                                continue;
                            if (LineIsHostFileName(hostFileIisSiteName, line) == false)
                                continue;
                            Log.ToApp.Warning("Iis site name already exist in host file. File not updated");
                            fileReader.Close();
                            return;
                        }
                    }
                    finally
                    {
                        fileReader.Close();
                    }
                }

                reader = _hostFile.OpenRead();
                using (var fileReader = new StreamReader(reader))
                {
                    try
                    {
                        var content = fileReader.ReadToEnd();
                        addNewline = !content.EndsWith(Environment.NewLine);
                            
                    }
                    finally
                    {
                        fileReader.Close();
                    }
                }
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }

            //we add newline, if file doesn't end with newline to make sure new entry is on it's own line
            if(addNewline)
                WriteLineToHostfile("");

            var hostFileEntry = string.Format(_HostFileEntryFormat, hostFileIisSiteName);
            WriteLineToHostfile(hostFileEntry);
        }

        private void WriteLineToHostfile(string line)
        {
            using (var fileWriter = _hostFile.AppendText())
            {
                
                fileWriter.WriteLine(line);
                fileWriter.Close();
                Log.ToApp.Debug("'{0}' written to host file", line);
            }
        }

        public bool LineIsHostFileName(string hostFileIisSiteName, string line)
        {
            if (line == null)
                return true;
            line = line.Trim();
            if (line.Length == 0)
                return false;
            if (line.StartsWith(_LocalHostIpAddress) == false)
                return false;

            if (line.Length <= _LocalHostIpAddress.Length)
                return false;
            //assumes line format is IP-address, space and host name
            line = line.Remove(0, _LocalHostIpAddress.Length);
            line = line.Trim();
            return line.Equals(hostFileIisSiteName.Trim());
        }

        public void RemoveHostName(string hostName)
        {
            var hostFileIisSiteName = hostName.ToLowerInvariant();
            var tempFile = Path.GetTempFileName();

            using (var sr = new StreamReader(_hostFile.FullName))
            {
                using (var sw = new StreamWriter(tempFile))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (LineIsHostFileName(hostFileIisSiteName, line) == false)//if line is not the host name that needs to be removed
                            sw.WriteLine(line);
                        else
                        {
                            Log.ToApp.Info("Entry deleted from host file: {0}", line);
                        }
                    }
                }
            }
            File.Delete(_hostFile.FullName);
            File.Copy(tempFile, _hostFile.FullName);
            File.Delete(tempFile);
        }

        private const string _HostFileEntryFormat = _LocalHostIpAddress + " {0}";
        private const string _LocalHostIpAddress = "127.0.0.1";
    }
}

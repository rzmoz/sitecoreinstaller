using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.WebServer
{
    using System.Security;

    using SitecoreInstaller.Framework.Diagnostics;

    public class HostFileService : IHostFileService
    {
        private static readonly FileInfo _hostFile = new FileInfo(@"C:\Windows\System32\drivers\etc\hosts");
        
        public bool HasWritePermissions()
        {
            try
            {
                using (var writer = _hostFile.OpenWrite())
                {
                    writer.Close();
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
            return true;
        }

        public void AddHostName(string hostName)
        {
            if (string.IsNullOrEmpty(hostName))
            {
                Log.As.Error("Host name is null or empty - please provide a hostname");
                return;
            }

            if (!_hostFile.Exists)
            {
                Log.As.Error("Host file not found at {0}:", _hostFile.FullName);
                return;
            }

            var hostFileIisSiteName = hostName.ToLowerInvariant();

            Log.As.Info("Adding hostname '{0}'", hostFileIisSiteName);

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
                            Log.As.Warning("Iis site name already exist in host file. File not updated");
                            fileReader.Close();
                            return;
                        }
                    }
                    finally
                    {
                        fileReader.Close();
                    }
                }
                using (var fileWriter = _hostFile.AppendText())
                {
                    var hostFileEntry = string.Format(_HostFileEntryFormat, hostFileIisSiteName);
                    fileWriter.WriteLine(hostFileEntry);
                    fileWriter.Close();
                    Log.As.Debug("Iis site name written to host file: {0}", hostFileEntry);
                }
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        internal bool LineIsHostFileName(string hostFileIisSiteName, string line)
        {
            if (line == null)
                return true;
            if (line.Length <= 10)
                return true;
            //assumes line format is IP-address, space and host name
            line = line.Remove(0, 10);
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
                            Log.As.Info("Entry deleted from host file: {0}", line);
                        }
                    }
                }
            }
            File.Delete(_hostFile.FullName);
            File.Copy(tempFile, _hostFile.FullName);
            File.Delete(tempFile);
        }

        private const string _HostFileEntryFormat = @"127.0.0.1 {0}";
    }
}

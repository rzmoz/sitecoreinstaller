using System;
using System.IO;
using System.Linq;
using System.Security;
using DotNet.Basics.IO;
using DotNet.Basics.NLog;
using DotNet.Basics.Tasks;

namespace SitecoreInstaller.WebServer
{
    public class HostFile : IPreflightCheck
    {

        private static readonly FilePath _hostFile = Environment.GetEnvironmentVariable("SystemRoot").ToFile(@"System32\drivers\etc\hosts");

        private const string _localHostIpAddress = "127.0.0.1";
        private const string _hostFileEntryFormat = _localHostIpAddress + " {0}";

        public bool Exists => _hostFile.Exists();

        public bool HasWritePermissions()
        {
            try
            {
                using (var writer = File.OpenWrite(_hostFile.FullName))
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

        public void AddHostName(string hostname)
        {
            if (Assert().Issues.Any())
            {
                this.NLog().Fatal($"Host file ready for update. Your website will not be available in your local IIS");
                return;
            }

            bool addNewline;

            //check if host name already exist
            Stream reader = null;
            try
            {
                reader = File.OpenRead(_hostFile.FullName);
                using (var fileReader = new StreamReader(reader))
                {
                    try
                    {
                        while (fileReader.Peek() >= 0)
                        {
                            var line = fileReader.ReadLine();
                            if (line == null)
                                continue;
                            if (LineIsHostFileName(hostname, line) == false)
                                continue;
                            this.NLog().Warn($"Iis site name already exists in host file: {hostname}. File not updated");
                            fileReader.Close();
                            return;
                        }
                    }
                    finally
                    {
                        fileReader.Close();
                    }
                }

                reader = File.OpenRead(_hostFile.FullName);
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
                reader?.Close();
            }

            //we add newline, if file doesn't end with newline to make sure new entry is on it's own line
            if (addNewline)
                WriteLineToHostfile(string.Empty);

            var hostFileEntry = string.Format(_hostFileEntryFormat, hostname);
            WriteLineToHostfile(hostFileEntry);

            this.NLog().Trace($"Entry added to hostfile: {hostFileEntry}");
        }

        public void RemoveHostName(string hostname)
        {

            var tempFile = Path.GetTempFileName();

            string deletedEntry = null;

            using (var sr = new StreamReader(_hostFile.FullName))
            {
                using (var sw = new StreamWriter(tempFile))
                {
                    string line;

                    while ((line = sr.ReadLine()) != null)
                    {
                        if (LineIsHostFileName(hostname, line) == false)//if line is not the host name that needs to be removed
                            sw.WriteLine(line);
                        else
                        {
                            deletedEntry = line;
                            this.NLog().Debug($"Entry for deletion detected : {line}");
                        }
                    }
                }
            }
            File.Delete(_hostFile.FullName);
            File.Copy(tempFile, _hostFile.FullName);
            File.Delete(tempFile);

            if (deletedEntry == null)
                this.NLog().Error($"Hostname {hostname} not found in host file!");
            else
                this.NLog().Trace($"Hostname {deletedEntry} removed from hostfile");
        }

        private void WriteLineToHostfile(string line)
        {
            using (var fileWriter = File.AppendText(_hostFile.FullName))
            {
                fileWriter.WriteLine(line);
                fileWriter.Close();
                this.NLog().Debug($"'{line}' written to host file");
            }
        }

        private bool LineIsHostFileName(string hostFileIisSiteName, string line)
        {
            if (line == null)
                return true;
            line = line.Trim();
            if (line.Length == 0)
                return false;
            if (line.StartsWith(_localHostIpAddress) == false)
                return false;

            if (line.Length <= _localHostIpAddress.Length)
                return false;
            //assumes line format is IP-address, space and host name
            line = line.Remove(0, _localHostIpAddress.Length);
            line = line.Trim();
            return line.Equals(hostFileIisSiteName.Trim());
        }

        public TaskResult Assert()
        {
            return new TaskResult(issues =>
            {
                if (Exists)
                    this.NLog().Trace($"Hostfile found at: {_hostFile.FullName}");
                else
                    issues.Add($"Host file not found at: {_hostFile.FullName}");

                if (HasWritePermissions() == false)
                    issues.Add($"SitecoreInstaller does not have write permissions to host file at {_hostFile.FullName}. Run with elevated privileges (Run as administrator) to allow updates to your host file");
            });
        }
    }
}

using System;
using System.IO;
using System.Security;
using DotNet.Basics.IO;
using NLog;
using SitecoreInstaller.PreflightChecks;

namespace SitecoreInstaller.WebServer
{
    public class HostFile : IPreflightCheck
    {
        private static readonly FilePath _hostFile = Environment.GetEnvironmentVariable("SystemRoot").ToFile(@"System32\drivers\etc\hosts");

        private const string _localHostIpAddress = "127.0.0.1";
        private const string _hostFileEntryFormat = _localHostIpAddress + " {0}";

        private readonly ILogger _logger;

        public HostFile()
        {
            _logger = LogManager.GetLogger(nameof(HostFile));
        }

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

        public void AddHostName(string hostName)
        {
            if (Assert().IsReady == false)
            {
                _logger.Fatal($"Host file ready for update. Your website will not be available in your local IIS");
                return;
            }

            var hostFileIisSiteName = hostName.ToLowerInvariant();
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
                            if (LineIsHostFileName(hostFileIisSiteName, line) == false)
                                continue;
                            _logger.Warn($"Iis site name already exists in host file: {hostName}. File not updated");
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

            var hostFileEntry = string.Format(_hostFileEntryFormat, hostFileIisSiteName);
            WriteLineToHostfile(hostFileEntry);
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
                            _logger.Debug($"Entry deleted from host file: {line}");
                        }
                    }
                }
            }
            File.Delete(_hostFile.FullName);
            File.Copy(tempFile, _hostFile.FullName);
            File.Delete(tempFile);
        }

        private void WriteLineToHostfile(string line)
        {
            using (var fileWriter = File.AppendText(_hostFile.FullName))
            {
                fileWriter.WriteLine(line);
                fileWriter.Close();
                _logger.Debug($"'{line}' written to host file");
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

        public PreflightCheckResult Assert()
        {
            return new PreflightCheckResult(issues =>
            {
                if (Exists == false)
                    issues.Add($"Host file not found at: {_hostFile.FullName}");
                if (HasWritePermissions() == false)
                    issues.Add($"SitecoreInstaller does not have write permissions to host file at {_hostFile.FullName}. Run with elevated privileges (Run as administrator) to allow updates to your host file");
            });
        }
    }
}

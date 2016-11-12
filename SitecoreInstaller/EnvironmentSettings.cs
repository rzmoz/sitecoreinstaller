using System;
using DotNet.Basics.IO;
using DotNet.Basics.NLog;
using Newtonsoft.Json;
using SitecoreInstaller.PreflightChecks;

namespace SitecoreInstaller
{
    public class EnvironmentSettings : IPreflightCheck
    {
        private readonly FilePath _settingsFileLocation =
            typeof(EnvironmentSettings).Assembly.Location.ToFile().Directory.ToFile("settings.json");

        public EnvironmentSettings()
        {
            BasicSettings = new BasicSettings();
            AdvancedSettings = new AdvancedSettings();
        }

        public BasicSettings BasicSettings { get; set; }
        public AdvancedSettings AdvancedSettings { get; set; }

        public PreflightCheckResult Assert()
        {
            return new PreflightCheckResult(issues =>
            {

                if (_settingsFileLocation.Exists())
                {
                    this.NLog<EnvironmentSettings>().Debug($"Settings found at: {_settingsFileLocation.FullName}");
                    var content = _settingsFileLocation.ReadAllText();
                    var loadedFile = JsonConvert.DeserializeObject<EnvironmentSettings>(content);
                    BasicSettings = loadedFile.BasicSettings;
                    AdvancedSettings = loadedFile.AdvancedSettings;
                    this.NLog<EnvironmentSettings>().Debug($"Settings loaded: {JsonConvert.SerializeObject(this)}");
                    this.NLog<EnvironmentSettings>().Trace($"Settings loaded from: {_settingsFileLocation.FullName}");
                }
                else
                {
                    this.NLog<EnvironmentSettings>().Debug($"Settings file not found at: {_settingsFileLocation.FullName}. Creating...");
                    try
                    {
                        JsonConvert.SerializeObject(this).WriteAllText(_settingsFileLocation);
                        this.NLog<EnvironmentSettings>().Trace($"Settings file saved to : {_settingsFileLocation.FullName}");
                    }
                    catch (Exception e)
                    {
                        issues.Add($"Failed to save settings file at: {_settingsFileLocation}");
                    }
                }
            });
        }
    }
}

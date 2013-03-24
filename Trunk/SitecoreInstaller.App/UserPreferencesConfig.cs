using SitecoreInstaller.Framework.Configuration;

namespace SitecoreInstaller.App
{
  using System.Xml.Serialization;

  public class UserPreferencesConfig : IConfig
  {
    public string ProjectsFolder { get; set; }

    public string LocalBuildLibrary { get; set; }

    [XmlIgnore]
    public string ArchiveFolder
    {
      get { return LocalBuildLibrary + @"\sitecore"; }
    }

    public string IisSitePostfix { get; set; }

    public string SqlInstanceName { get; set; }

    public string SqlLogin { get; set; }

    public string SqlPassword { get; set; }

    public bool PromptForUserSettings { get; set; }

    public int LicenseExpirationPeriodInDays { get; set; }
  }
}

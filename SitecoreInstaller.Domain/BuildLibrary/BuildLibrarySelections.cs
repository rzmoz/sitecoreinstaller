namespace SitecoreInstaller.Domain.BuildLibrary
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using SitecoreInstaller.Framework.Sys;

  public class BuildLibrarySelections
  {
    public BuildLibrarySelections()
    {
      SelectedSitecore = new SourceEntry(string.Empty, string.Empty);
      SelectedLicense = new SourceEntry(string.Empty, string.Empty);
      SelectedModules = Enumerable.Empty<SourceEntry>();
    }

    public SourceEntry SelectedSitecore { get; set; }
    public SourceEntry SelectedLicense { get; set; }
    public IEnumerable<SourceEntry> SelectedModules { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.App
{
    public class UserSelections
    {
        public UserSelections()
        {
            SelectedSitecore = new SourceEntry(string.Empty,string.Empty);
            SelectedLicense = new SourceEntry(string.Empty, string.Empty);
            SelectedModules = Enumerable.Empty<SourceEntry>();
        }

        public SourceEntry SelectedSitecore{ get; set; }
        public SourceEntry SelectedLicense { get; set; }
        public IEnumerable<SourceEntry> SelectedModules { get; set; }
    }
}

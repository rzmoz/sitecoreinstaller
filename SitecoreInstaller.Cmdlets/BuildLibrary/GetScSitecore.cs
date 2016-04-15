using System.Management.Automation;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.Cmdlets.BuildLibrary
{
    [Cmdlet(VerbsCommon.Get, "ScSitecore")]
    public class GetScSitecore : BuildLibraryCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true)]
        [Alias("V")]
        [ValidateNotNullOrEmpty]
        public string[] Version { get; set; }

        [Parameter(Position = 2, Mandatory = false)]
        [Alias("P", "PSPath", "BuildLibraryRootPath")]
        public string Path { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetFromBuildLibrary(Version, BuildLibraryType.Sitecore, Path);
        }
    }
}

using System.Management.Automation;
using SitecoreInstaller.BuildLibrary;

namespace SitecoreInstaller.Cmdlets.BuildLibrary
{
    [Cmdlet(VerbsCommon.Get, "SISitecore")]
    public class GetSiSitecore : BuildLibraryCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string[] Version { get; set; }

        [Parameter(Position = 2, Mandatory = false)]
        [Alias("PSPath", "BuildLibraryRootPath")]
        public string Path { get; set; }

        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            GetFromBuildLibrary(Version, BuildLibraryType.Sitecore, Path);
        }
    }
}

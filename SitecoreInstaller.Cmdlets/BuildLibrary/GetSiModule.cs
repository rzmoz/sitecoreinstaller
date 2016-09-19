using System.Management.Automation;
using SitecoreInstaller.BuildLibrary;

namespace SitecoreInstaller.Cmdlets.BuildLibrary
{
    [Cmdlet(VerbsCommon.Get, "SIModule")]
    public class GetSiModule : BuildLibraryCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true)]
        [ValidateNotNullOrEmpty]
        public string[] Module { get; set; }

        [Parameter(Position = 2, Mandatory = false)]
        [Alias("PSPath", "BuildLibraryRootPath")]
        public string Path { get; set; }

        protected override void ProcessRecord()
        {
            GetFromBuildLibrary(Module, BuildLibraryType.Module, Path);
        }
    }
}

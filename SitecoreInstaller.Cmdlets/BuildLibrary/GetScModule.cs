using System.Management.Automation;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.Cmdlets.BuildLibrary
{
    [Cmdlet(VerbsCommon.Get, "ScModule")]
    public class GetScModule : BuildLibraryCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true)]
        [Alias("M")]
        [ValidateNotNullOrEmpty]
        public string[] Module { get; set; }

        [Parameter(Position = 2, Mandatory = false)]
        [Alias("P", "PSPath", "BuildLibraryRootPath")]
        public string Path { get; set; }

        protected override void ProcessRecord()
        {
            GetFromBuildLibrary(Module, BuildLibraryType.Module, Path);
        }
    }
}

using System.Management.Automation;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.Cmdlets.BuildLibrary
{
    [Cmdlet(VerbsCommon.Get, "SiLicense")]
    public class GetSiLicense : BuildLibraryCmdlet
    {
        [Parameter(Position = 0, Mandatory = true, ValueFromPipeline = true)]
        [Alias("L")]
        [ValidateNotNullOrEmpty]
        public string[] License { get; set; }

        [Parameter(Position = 2, Mandatory = false)]
        [Alias("P", "PSPath", "BuildLibraryRootPath")]
        public string Path { get; set; }

        protected override void ProcessRecord()
        {
            GetFromBuildLibrary(License, BuildLibraryType.LicenseFile, Path);
        }
    }
}

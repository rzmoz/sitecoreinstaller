using System.Management.Automation;
using DotNet.Basics.Diagnostics;
using DotNet.Basics.Pipelines;
using SitecoreInstaller.App.Install;

namespace SitecoreInstaller.Cmdlets
{
    [Cmdlet(VerbsCommon.New, "SIDeployment")]
    public class NewSiDeployment : SiCmdlet
    {
        [Alias("ProjectName")]
        [Parameter(Position = 0, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 1, Mandatory = true)]
        [Alias("V")]
        [ValidateNotNullOrEmpty]
        public string Version { get; set; }

        [Parameter(Position = 2, Mandatory = true)]
        [Alias("L")]
        [ValidateNotNullOrEmpty]
        public string License { get; set; }

        [Parameter(Position = 3)]
        [Alias("M")]
        public string[] Module { get; set; }

        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void ProcessRecord()
        {
            var args = InstallArgs.Create(Name, Version, License, Module);

            var runResult = PipelineRunner.RunAsync<InstallPipeline, InstallArgs>(args).Result;

            if (runResult.Success)
                WriteInformation("Sitecore installation finished without errors", new string[0]);
            else
                WriteWarning("Sitecore installation finished with errors. Check log for details");
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }
    }
}

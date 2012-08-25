using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SitecoreInstaller.App;
using SitecoreInstaller.Domain.BuildLibrary;
using SitecoreInstaller.Domain.WebServer;

namespace SitecoreInstallerConsole.Runners
{
    using SitecoreInstaller.Domain.Pipelines;

    public class InstallRunner : ConsolePipelineRunner
    {
        public InstallRunner(string[] args)
            : base(args)
        {
        }

        public override void Run()
        {
            if (Args[0] != ArgSwitches.Install)
                throw new ArgumentException(string.Format("Wrong arguments provided. Was {0}", Args[0]));

            if (Args.Length < 2)
                throw new ArgumentException(string.Format("Wrong # of arguments. Expected at least 2. Was {0}", Args.Length));

            var projectName = Args[1];
            var sitecore = Args.Length >= 3 ? Args[2] : ArgSwitches.Latest;
            var license = Args.Length >= 4 ? Args[3] : ArgSwitches.Latest;

            var selectedModules = new List<SourceEntry>();

            for (var i = 4; i < Args.Length; i++)
                selectedModules.Add(new SourceEntry(Args[i], string.Empty));

            Install(license, selectedModules, projectName, sitecore);
        }

        private void Install(string license, IEnumerable<SourceEntry> selectedModules, string projectName, string sitecore)
        {
            Services.AppSettings.ProjectName.Value = projectName;
            Services.AppSettings.AppPool = new AppPoolSettings() { Name = Services.AppSettings.IisSiteName };
            Services.AppSettings.UserSelections.SelectedSitecore = new SourceEntry(sitecore, string.Empty);
            Services.AppSettings.UserSelections.SelectedLicense = new SourceEntry(license, string.Empty);
            if (sitecore == ArgSwitches.Latest)
                Services.AppSettings.UserSelections.SelectedSitecore = Services.BuildLibrary.List(SourceType.Sitecore).Last();
            else
                Services.AppSettings.UserSelections.SelectedSitecore = new SourceEntry(sitecore, string.Empty);
            if (license == ArgSwitches.Latest)
                Services.AppSettings.UserSelections.SelectedLicense = Services.BuildLibrary.List(SourceType.License).Last();
            else
                Services.AppSettings.UserSelections.SelectedLicense = new SourceEntry(license, string.Empty);
            Services.AppSettings.UserSelections.SelectedModules = selectedModules;

            var pipeline = Services.Pipelines.GetInstaller();
            pipeline.Pipeline.IsInUiMode = false;
            pipeline.ExecuateAllSteps(this, new EventArgs());
        }
    }
}

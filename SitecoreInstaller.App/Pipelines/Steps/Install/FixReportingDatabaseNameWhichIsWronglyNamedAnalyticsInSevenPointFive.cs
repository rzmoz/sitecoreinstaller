using System.IO;
using System.Linq;
using System.Reflection;
using CSharp.Basics.IO;
using SitecoreInstaller.Domain;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class FixReportingDatabaseNameWhichIsWronglyNamedAnalyticsInSevenPointFive : Step<PipelineApplicationEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineApplicationEventArgs args)
        {
            //yuck :-/
            if (args.ProjectSettings.Sql.InstallType != DbInstallType.Auto)
                return;

            var sitecoreKernelPath = args.ProjectSettings.ProjectFolder.Website.Bin.CombineTo<FileInfo>("Sitecore.Kernel.dll");

            var sitecoreKernelAssembly = Assembly.Load(File.ReadAllBytes(sitecoreKernelPath.FullName));//to not lock the file

            var sitecoreVersion = sitecoreKernelAssembly.GetName().Version;

            //we don't care if the sitecore version is lower than 7.5
            if (sitecoreVersion.Major < 7)
                return;
            if (sitecoreVersion.Major < 5)
                return;

            var analyticsDataFile= args.ProjectSettings.ProjectFolder.Databases.CombineTo<FileInfo>("Sitecore.Analytics.mdf");
            var analyticsLogFile= args.ProjectSettings.ProjectFolder.Databases.CombineTo<FileInfo>("Sitecore.Analytics.ldf");

            if (analyticsDataFile.Exists())
                analyticsDataFile.MoveTo(args.ProjectSettings.ProjectFolder.Databases.CombineTo<FileInfo>("Sitecore.Reporting.mdf").FullName);

            if(analyticsLogFile.Exists())
                analyticsLogFile.MoveTo(args.ProjectSettings.ProjectFolder.Databases.CombineTo<FileInfo>("Sitecore.Reporting.ldf").FullName);
        }
    }
}

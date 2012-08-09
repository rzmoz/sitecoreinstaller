using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Sitecore;
using Sitecore.Data.Engines;
using Sitecore.Data.Proxies;
using Sitecore.Install;
using Sitecore.Install.Files;
using Sitecore.Install.Framework;
using Sitecore.Install.Items;
using Sitecore.Install.Metadata;
using Sitecore.Install.Utils;
using Sitecore.Install.Zip;
using Sitecore.SecurityModel;

namespace SitecoreInstaller.Runtime
{
    public class InstallPackageService : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var packageName = HttpContext.Current.Request.QueryString["Install"];

            if(packageName == null)
                return;

            packageName = HttpUtility.UrlDecode(packageName);

            var filename = Path.Combine(PackageFolder.FullName, packageName);
            InstallPackage(filename);
        }

        private static void InstallPackage(string filename)
        {
            Sitecore.Context.SetActiveSite("shell");
            using (new SecurityDisabler())
            {
                using (new ProxyDisabler())
                {
                    using (new SyncOperationContext())
                    {
                        IProcessingContext context = new SimpleProcessingContext(); // 
                        IItemInstallerEvents events =
                            new DefaultItemInstallerEvents(new BehaviourOptions(InstallMode.Overwrite, MergeMode.Undefined));
                        context.AddAspect(events);
                        IFileInstallerEvents events1 = new DefaultFileInstallerEvents(true);
                        context.AddAspect(events1);
                        var inst = new Installer();
                        inst.InstallPackage(MainUtil.MapPath(filename), context);
                        ISource<PackageEntry> source = new PackageReader(MainUtil.MapPath(filename));
                        var previewContext = Installer.CreatePreviewContext();
                        var view = new MetadataView(previewContext);
                        var sink = new MetadataSink(view);
                        sink.Initialize(previewContext);
                        source.Populate(sink);
                        inst.ExecutePostStep(view.PostStep, previewContext);
                    }
                }
            }
        }

        public DirectoryInfo PackageFolder
        {
            get
            {
                var packagePath = Sitecore.Configuration.Settings.PackagePath;

                //if package path is relative to web root
                if (packagePath.StartsWith("/"))
                {
                    packagePath = packagePath.TrimStart('/');//remove leading slash for full path resolving
                    packagePath = Path.Combine(HttpContext.Current.Server.MapPath("/"), packagePath);
                }

                return new DirectoryInfo(packagePath);
            }
        }
    }
}
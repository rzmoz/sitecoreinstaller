<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="CS" runat="server">

    protected void Page_Load(object sender, System.EventArgs e)
    {
        var packageName = System.Web.HttpContext.Current.Request.QueryString["Install"];

        if (packageName == null)
            return;

        packageName = System.Web.HttpUtility.UrlDecode(packageName);

        var filename = System.IO.Path.Combine(PackageFolder.FullName, packageName);
        InstallPackage(filename);
    }

    private static void InstallPackage(string filename)
    {
        Sitecore.Context.SetActiveSite("shell");
        using (new Sitecore.SecurityModel.SecurityDisabler())
        {
            using (new Sitecore.Data.Proxies.ProxyDisabler())
            {
                using (new Sitecore.Data.Engines.SyncOperationContext())
                {
                    Sitecore.Install.Framework.IProcessingContext context = new Sitecore.Install.Framework.SimpleProcessingContext(); // 
                    Sitecore.Install.Items.IItemInstallerEvents events =
                        new Sitecore.Install.Items.DefaultItemInstallerEvents(new Sitecore.Install.Utils.BehaviourOptions(Sitecore.Install.Utils.InstallMode.Overwrite, Sitecore.Install.Utils.MergeMode.Undefined));
                    context.AddAspect(events);
                    Sitecore.Install.Files.IFileInstallerEvents events1 = new Sitecore.Install.Files.DefaultFileInstallerEvents(true);
                    context.AddAspect(events1);
                    var inst = new Sitecore.Install.Installer();
                    inst.InstallPackage(Sitecore.MainUtil.MapPath(filename), context);
                    Sitecore.Install.Framework.ISource<Sitecore.Install.Framework.PackageEntry> source = new Sitecore.Install.Zip.PackageReader(Sitecore.MainUtil.MapPath(filename));
                    var previewContext = Sitecore.Install.Installer.CreatePreviewContext();
                    var view = new Sitecore.Install.Metadata.MetadataView(previewContext);
                    var sink = new Sitecore.Install.Metadata.MetadataSink(view);
                    sink.Initialize(previewContext);
                    source.Populate(sink);
                    inst.ExecutePostStep(view.PostStep, previewContext);
                }
            }
        }
    }

    public System.IO.DirectoryInfo PackageFolder
    {
        get
        {
            var packagePath = Sitecore.Configuration.Settings.PackagePath;

            //if package path is relative to web root
            if (packagePath.StartsWith("/"))
            {
                packagePath = packagePath.TrimStart('/');//remove leading slash for full path resolving
                packagePath = System.IO.Path.Combine(System.Web.HttpContext.Current.Server.MapPath("/"), packagePath);
            }

            return new System.IO.DirectoryInfo(packagePath);
        }
    }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>InstallPackage.aspx</title>
</head>
<body>
<h1></h1>InstallPackage
</body>
</html>

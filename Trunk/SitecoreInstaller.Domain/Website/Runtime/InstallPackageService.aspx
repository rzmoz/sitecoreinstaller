<%@ Page Language="C#" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="Sitecore.Data.Engines" %>
<%@ Import Namespace="Sitecore.Data.Proxies" %>
<%@ Import Namespace="Sitecore.Install" %>
<%@ Import Namespace="Sitecore.Install.Files" %>
<%@ Import Namespace="Sitecore.Install.Framework" %>
<%@ Import Namespace="Sitecore.Install.Items" %>
<%@ Import Namespace="Sitecore.Install.Utils" %>
<%@ Import Namespace="Sitecore.SecurityModel" %>
<%@ Import Namespace="Sitecore.Install.Metadata" %>
<%@ Import Namespace="Sitecore.Install.Zip" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  private const string _packageStatusPath = "/temp/SitecoreInstaller/PackageInstallStatus.txt";

  protected void Page_Load(object sender, EventArgs e)
  {
    var packageName = HttpContext.Current.Request.QueryString["PackageName"];
    var action = HttpContext.Current.Request.QueryString["Action"];

    if (packageName == null || action == null)
    {
      HttpContext.Current.Response.StatusCode = 400;
      HttpContext.Current.Response.StatusDescription = "action or package name was not set!";
      return;
    }

    packageName = HttpUtility.UrlDecode(packageName);
    var filename = Path.Combine(PackageFolder.FullName, packageName);


    Sitecore.Context.SetActiveSite("shell");
    using (new SecurityDisabler())
    {
      using (new ProxyDisabler())
      {
        using (new SyncOperationContext())
        {
          File.WriteAllText(PackageInstallStatusPath, "Processing " + filename);
          switch (action)
          {
            case "Install":
              Install(filename);
              break;
            case "PostInstall":
              PostInstall(filename);
              break;
            default:
              HttpContext.Current.Response.StatusCode = 400;
              HttpContext.Current.Response.StatusDescription = "Unknown action: " + action;
              break;
          }
          File.WriteAllText(PackageInstallStatusPath, "Done Processing " + filename);
        }
      }
    }
  }

  private static void Install(string package)
  {
    SimpleProcessingContext context = new SimpleProcessingContext();
    DefaultItemInstallerEvents events = new DefaultItemInstallerEvents(new BehaviourOptions(InstallMode.Overwrite, MergeMode.Undefined));
    context.AddAspect(events);
    DefaultFileInstallerEvents events1 = new DefaultFileInstallerEvents(true);
    context.AddAspect(events1);
    new Installer().InstallPackage(package, context);
    new Installer().InstallSecurity(package, context);
  }

  private static void PostInstall(string package)
  {
    IProcessingContext context2 = Installer.CreatePreviewContext();
    ISource<PackageEntry> source = new PackageReader(package);
    MetadataView view = new MetadataView(context2);
    MetadataSink sink = new MetadataSink(view);
    sink.Initialize(context2);
    source.Populate(sink);
    new Installer().ExecutePostStep(view.PostStep, context2);
  }


  public static string PackageInstallStatusPath
  {
    get { return HttpContext.Current.Server.MapPath(_packageStatusPath); }
  }

  public static System.IO.DirectoryInfo PackageFolder
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
</body>
</html>

<%@ Page Language="C#" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="Sitecore.Data.Engines" %>
<%@ Import Namespace="Sitecore.Data.Proxies" %>
<%@ Import Namespace="Sitecore.Diagnostics" %>
<%@ Import Namespace="Sitecore.Install" %>
<%@ Import Namespace="Sitecore.SecurityModel" %>
<%@ Import Namespace="Sitecore.Install.Metadata" %>
<%@ Import Namespace="Sitecore.Install.Zip" %>
<%@ Import Namespace="Sitecore.Update" %>
<%@ Import Namespace="Sitecore.Update.Installer.Exceptions" %>
<%@ Import Namespace="Sitecore.Update.Installer.Installer.Utils" %>
<%@ Import Namespace="Sitecore.Update.Installer.Utils" %>
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

    Log.Info("<SitecoreInstaller> Installing package: " + packageName, this);

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
    var log = log4net.LogManager.GetLogger("LogFileAppender");
    using (new ShutdownGuard())
    {
      var installationInfo = new PackageInstallationInfo
      {
        Action = UpgradeAction.Upgrade,
        Mode = Sitecore.Update.Utils.InstallMode.Install,
        Path = package
      };

      try
      {
        string text;
        UpdateHelper.Install(installationInfo, log, out text);
      }
      catch (PostStepInstallerException)
      {
      }
    }
  }

  private static void PostInstall(string package)
  {
    try
    {
      var context2 = Installer.CreatePreviewContext();
      var source = new PackageReader(package);
      var view = new MetadataView(context2);
      var sink = new MetadataSink(view);
      sink.Initialize(context2);
      source.Populate(sink);
      new Installer().ExecutePostStep(view.PostStep, context2);
    }
    catch (Sitecore.Jobs.AsyncUI.InvalidContextException)
    {
    }
  }


  public static string PackageInstallStatusPath
  {
    get { return HttpContext.Current.Server.MapPath(_packageStatusPath); }
  }

  public static DirectoryInfo PackageFolder
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

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>InstallPackage.aspx</title>
</head>
<body>
</body>
</html>

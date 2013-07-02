<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  private const string _packageStatusPath = "/temp/SitecoreInstaller/PackageInstallStatus.txt";

  protected void Page_Load(object sender, System.EventArgs e)
  {
    var packageName = System.Web.HttpContext.Current.Request.QueryString["Status"];

    if (packageName == null)
    {
      HttpContext.Current.Response.StatusCode = 404; //package not found
      HttpContext.Current.Response.StatusDescription = packageName + " not found";
    }

    var status = System.IO.File.ReadAllText(PackageInstallStatusPath);

    HttpContext.Current.Response.StatusDescription = status;

    if (status.StartsWith("Installing"))
    {
      HttpContext.Current.Response.StatusCode = 202; //still installing
    }

    if (status.StartsWith("Done"))
    {
      HttpContext.Current.Response.StatusCode = 200; //done processing
    }
  }

  public static string PackageInstallStatusPath
  {
    get { return HttpContext.Current.Server.MapPath(_packageStatusPath); }
  }

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>InstallPackage.aspx</title>
</head>
<body>
</body>
</html>

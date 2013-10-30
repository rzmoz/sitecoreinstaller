<%@ Page Language="C#" %>
<%@ Import Namespace="Sitecore.Data" %>
<%@ Import Namespace="Sitecore.Diagnostics" %>
<%@ Import Namespace="Sitecore.localhost" %>
<%@ Import Namespace="Sitecore.Tasks" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

  void Page_Load(object sender, System.EventArgs e)
  {
    //set context
    Sitecore.Context.SetActiveSite("shell");
    
    Log.Info("Publishing site from SitecoreInstaller publisher", this);

    using (new Sitecore.SecurityModel.SecurityDisabler())
    {
      var masterDb = Sitecore.Configuration.Factory.GetDatabase("master");
      var webDb = Sitecore.Configuration.Factory.GetDatabase("web");

      foreach (var language in masterDb.GetLanguages())
      {
        // The publishOptions determine the source and target database,
        // the publish mode and language, and the publish date
        Sitecore.Publishing.PublishOptions publishOptions =
          new Sitecore.Publishing.PublishOptions(masterDb,
                                                 webDb,
                                                 Sitecore.Publishing.PublishMode.Full,
                                                 language,
                                                 DateTime.Now);  // Create a publisher with the publishoptions
        Sitecore.Publishing.Publisher publisher = new Sitecore.Publishing.Publisher(publishOptions);

        publisher.Options.RootItem = masterDb.GetItem("/sitecore");

        publisher.Options.Deep = true;

        Log.Info("Publishing everything in:" + language, this);

        publisher.Publish();
      }
    }

  }

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>Publish site</title>
</head>
<body>
</body>
</html>

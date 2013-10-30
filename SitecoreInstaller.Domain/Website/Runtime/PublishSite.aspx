<%@ Page Language="C#" %>
<%@ Import Namespace="Sitecore.Data" %>
<%@ Import Namespace="Sitecore.localhost" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    void Page_Load(object sender, System.EventArgs e)
    {
      //set context
      Sitecore.Context.SetActiveSite("shell");

      using (new Sitecore.SecurityModel.SecurityDisabler())
      {
        // The publishOptions determine the source and target database,
        // the publish mode and language, and the publish date
        Sitecore.Publishing.PublishOptions publishOptions =
          new Sitecore.Publishing.PublishOptions(Database.GetDatabase("master"),
                                                 Database.GetDatabase("web"),
                                                 Sitecore.Publishing.PublishMode.Full,
                                                 item.Language,
                                                 DateTime.Now);  // Create a publisher with the publishoptions
        Sitecore.Publishing.Publisher publisher = new Sitecore.Publishing.Publisher(publishOptions);

        // Choose where to publish from
        publisher.Options.RootItem = Sitecore.Context.Item;

        // Publish children as well?
        publisher.Options.Deep = true;

        // Do the publish!
        publisher.Publish();  
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

<%@ Page Language="C#" %>
<%@ Import Namespace="Sitecore.Data.Serialization" %>
<%@ Import Namespace="System.IO" %>
<%@ Import Namespace="System.Threading.Tasks" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">
  
  protected void Page_Load(object sender, EventArgs e)
  {
    var serializationFolder = new DirectoryInfo(PathUtils.Root);

    Parallel.ForEach(serializationFolder.GetDirectories(), dir =>
      Manager.LoadTree(dir.FullName, new Sitecore.Data.Serialization.LoadOptions()));
  }
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title>DeserializeItems.aspx</title>
</head>
<body>
</body>
</html>

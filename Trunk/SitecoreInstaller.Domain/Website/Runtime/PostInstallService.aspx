﻿<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script language="CS" runat="server">

    void Page_Load(object sender, System.EventArgs e)
    {
        var admin = Sitecore.Security.Accounts.User.FromName(@"sitecore\admin", true);
        var profile = admin.Profile;
        profile["WallPaper"] = string.Empty;
        profile.Save();
    }

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PostInstallService.aspx</title>
</head>
<body>
    <h1>
        PostInstallService</h1>
</body>
</html>
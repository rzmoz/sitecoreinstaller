<%@ Page Language="C#" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<script runat="server">

    void Page_Load(object sender, System.EventArgs e)
    {
        Sitecore.Security.Authentication.AuthenticationManager.Login(@"sitecore\admin", "b");
        HttpContext.Current.Response.Redirect("/sitecore");
    }

</script>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Login</title>
</head>
<body>
    <h1>
        Something went wrong with the login since you can see this...
    </h1>
</body>
</html>

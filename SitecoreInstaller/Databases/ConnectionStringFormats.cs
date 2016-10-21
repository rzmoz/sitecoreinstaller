﻿namespace SitecoreInstaller.Databases
{
    internal class ConnectionStringFormats
    {
        public static readonly string ConnectionStringsFileFormat = @"<?xml version=""1.0"" encoding=""utf-8""?>
<connectionStrings>
    <!-- 
    Sitecore connection strings.
    All database connections for Sitecore are configured here.
  -->
    {0}
</connectionStrings>";

        public static string ConnectionStringXdtFormat = @"<?xml version=""1.0""?>
<!-- For more information on using web.config transformation visit http://go.microsoft.com/fwlink/?LinkId=125889 -->
<connectionStrings xmlns:xdt=""http://schemas.microsoft.com/XML-Document-Transform"">
{0}
</connectionStrings>";
    }
}

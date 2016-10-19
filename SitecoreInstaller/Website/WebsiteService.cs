using System;
using System.Security.AccessControl;
using DotNet.Basics.IO;
using DotNet.Basics.Sys;
using DotNet.Basics.Tasks.Repeating;
using NLog;
using SitecoreInstaller.PreflightChecks;

namespace SitecoreInstaller.Website
{
    public class WebsiteService : IPreflightCheck
    {
        public PreflightCheckResult Assert()
        {
            return new PreflightCheckResult();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using System.IO;

    using Microsoft.Web.Administration;

    using SitecoreInstaller.Framework.Diagnostics;
    using SitecoreInstaller.Framework.IO;

    public class GrantPermissionsToNetworkService : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            Log.As.Debug("Giving Network Service user FullControl to project folder: {0}", Services.ProjectSettings.Folders.ProjectFolder.FullName);
            Services.ProjectSettings.Folders.ProjectFolder.GrantReadAndWritePermissions(ProcessModelIdentityType.NetworkService.ToString());
            new DirectoryInfo(@"c:\windows\temp").GrantReadAndWritePermissions(ProcessModelIdentityType.NetworkService.ToString());
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    using System.IO;

    using Microsoft.Web.Administration;

    using SitecoreInstaller.Framework.IO;

  public class GrantPermissions : Step<PipelineEventArgs>
    {
        protected override void InnerInvoke(object sender, PipelineEventArgs  args)
        {
            args.ProjectSettings.ProjectFolder.GrantFullControl("everyone");
            new DirectoryInfo(@"c:\windows\temp").GrantFullControl(ProcessModelIdentityType.NetworkService.ToString());
        }
    }
}

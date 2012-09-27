﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Install
{
    public class SetDataFolder : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            Services.Website.SetDataFolder(Services.ProjectSettings.ProjectFolder.Data, Services.ProjectSettings.ProjectFolder.Website.AppConfig.Include.DataFolderConfigFile);
        }
    }
}

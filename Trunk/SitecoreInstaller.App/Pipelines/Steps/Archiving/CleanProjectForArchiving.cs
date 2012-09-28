﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.App.Pipelines.Steps.Archiving
{
    public class CleanProjectForArchiving : Step
    {
        protected override void InnerInvoke(object sender, EventArgs args)
        {
            Services.Projects.CleanProjectForArchiving(Services.ProjectSettings.ProjectFolder);
            Services.Website.DeleteRuntimeServices(Services.ProjectSettings.ProjectFolder.Website.Directory);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.UI.UserSettingsDialogs
{
    public enum UserSettingsStep
    {
        NotSet = 0,
        FirstRunWelcome,
        Sql,
        License,
        Sitecore,
        ProjectFolder,
        BuildLibraryFolder,
        UrlPostfix,
        FirstRunFinish
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstallerConsole.CmdArgs
{
  public static class SitecoreInstallerParameters
  {
    public static CmdLineParameter List { get { return new CmdLineParameter("list", "Lists available Sitecores, Licenses and modules"); } }
    public static CmdLineParameter Projects { get { return new CmdLineParameter("projects", "Lists existing projects"); } }
    public static CmdLineParameter Install { get { return new CmdLineParameter("install", "Install a new Sitecore project. Value is project name"); } }
    public static CmdLineParameter UnInstall { get { return new CmdLineParameter("uninstall", "Un-Install an existing Sitecore project. Value is project name"); } }
    public static CmdLineParameter Open { get { return new CmdLineParameter("open", "Open an existing Sitecore project in browser. Value is project name"); } }
    

    public static CmdLineParameter Latest
    {
      get
      {
        var param = new CmdLineParameter("latest", "latest");
        param.SetValue(param.Name);
        return param;
      }
    }
    public static CmdLineParameter Sitecore { get { return new CmdLineParameter("sitecore", "sitecore"); } }
    public static CmdLineParameter License { get { return new CmdLineParameter("license", "license"); } }
    public static CmdLineParameter Modules { get { return new CmdLineParameter("modules", "modules"); } }
  }
}

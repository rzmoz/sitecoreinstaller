﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
  public class CheckSqlConnection : Precondition<PipelineEventArgs>
  {
    public override bool InnerEvaluate(object sender, PipelineEventArgs args)
    {
      if (args.ProjectSettings.Sql.TestConnection())
        return true;
      ErrorMessage = "Sql settings are not properly set. Check under preferences";
      return false;
    }
  }
}

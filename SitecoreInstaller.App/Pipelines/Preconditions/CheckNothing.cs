﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.App.Pipelines.Preconditions
{
  public class CheckNothing : Precondition<PipelineEventArgs>
  {
    public override bool InnerEvaluate(object sender, PipelineEventArgs args)
    {
      return args.ProjectSettings != null;
    }
  }
}
﻿namespace SitecoreInstaller.App.Pipelines.Preconditions
{
    public class CheckNothing : Precondition<PipelineApplicationEventArgs>
    {
        protected override bool InnerEvaluate(object sender, PipelineApplicationEventArgs args)
        {
            return args.ProjectSettings != null;
        }
    }
}
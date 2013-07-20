﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
    using SitecoreInstaller.Framework.Sys;

    public interface IPipelineRunner
    {
        event EventHandler<PipelineInfoEventArgs> AllStepsExecuting;
        event EventHandler<PipelineInfoEventArgs> AllStepsExecuted;

        event EventHandler<PipelineStepInfoEventArgs> StepExecuting;
        event EventHandler<PipelineStepInfoEventArgs> StepExecuted;

        event EventHandler<GenericEventArgs<string>> PreconditionNotMet;

        string ExecuteAllText { get; }
        void ExecuateAllSteps(object sender, EventArgs e);
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Pipelines
{
    public class PipelineStepInfoEventArgs : EventArgs
    {
        public PipelineStepInfoEventArgs(int stepNumber, int totalStepNumber, string stepName)
        {
            if (stepNumber < 1 || totalStepNumber < 1)
                ProgressPercentage = 100;
            else
                ProgressPercentage = Convert.ToInt32(100.0 / ((double)totalStepNumber / (double)stepNumber));
            StepName = stepName ?? string.Empty;
        }

        public int ProgressPercentage { get; private set; }
        public string StepName { get; private set; }
    }
}
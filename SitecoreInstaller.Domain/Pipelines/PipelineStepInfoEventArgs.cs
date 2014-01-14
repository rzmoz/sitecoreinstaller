using System;

namespace SitecoreInstaller.Domain.Pipelines
{
    public class PipelineStepInfoEventArgs : EventArgs
    {
        public PipelineStepInfoEventArgs(int stepNumber, int totalStepCount, string stepName)
        {
            StepNumber = stepNumber;
            TotalStepCount = totalStepCount;

            StepName = stepName ?? string.Empty;
        }

        public int StepNumber { get; private set; }
        public int TotalStepCount { get; private set; }
        public string StepName { get; private set; }
    }
}

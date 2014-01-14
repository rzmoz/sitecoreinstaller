using System;

namespace SitecoreInstaller.Domain.Pipelines
{
    public class PipelineEventArgs : EventArgs
    {
        private string _abortReason;

        public PipelineEventArgs()
        {
            AbortPipeline = false;
            _abortReason = string.Empty;
        }

        public bool AbortPipeline { get; set; }

        public string AbortReason
        {
            get { return _abortReason; }
            set { _abortReason = value ?? string.Empty; }
        }
    }
}

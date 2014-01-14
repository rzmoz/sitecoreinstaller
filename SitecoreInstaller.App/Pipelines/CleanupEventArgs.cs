namespace SitecoreInstaller.App.Pipelines
{
    public class CleanupEventArgs : PipelineApplicationEventArgs
    {
        public CleanupEventArgs()
        {
            DeepClean = true;
        }

        public bool DeepClean { get; set; }
    }
}

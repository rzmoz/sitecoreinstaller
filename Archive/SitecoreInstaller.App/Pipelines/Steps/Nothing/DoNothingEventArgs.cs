namespace SitecoreInstaller.App.Pipelines.Steps.Nothing
{
    public class DoNothingEventArgs : PipelineApplicationEventArgs
    {
        public DoNothingEventArgs()
        {
            Wait = 1000;
        }

        public int Wait { get; set; }
        public bool UserAccepted { get; set; }
    }
}

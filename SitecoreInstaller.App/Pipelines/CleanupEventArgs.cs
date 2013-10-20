namespace SitecoreInstaller.App.Pipelines
{
  public class CleanupEventArgs : PipelineEventArgs
  {
    public CleanupEventArgs()
    {
      DeepClean = true;
    }

    public bool DeepClean { get; set; }
  }
}

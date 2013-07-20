namespace SitecoreInstaller.App.Pipelines
{
  public class CleanupEventArgs : PipelineEventArgs
  {
    public CleanupEventArgs()
    {
      this.DeepClean = true;
    }

    public bool DeepClean { get; set; }
  }
}

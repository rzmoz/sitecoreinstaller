namespace SitecoreInstaller.App.Pipelines.Steps.Nothing
{
  public class DoNothingEventArgs : PipelineEventArgs
  {
    public DoNothingEventArgs()
    {
      Wait = 1000;
    }

    public int Wait { get; set; }
  }
}

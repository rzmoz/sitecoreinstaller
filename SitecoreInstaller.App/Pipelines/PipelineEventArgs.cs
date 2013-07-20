namespace SitecoreInstaller.App.Pipelines
{
  using System;
  using SitecoreInstaller.Domain.Pipelines;

  public class PipelineEventArgs : EventArgs
    {
        public PipelineEventArgs()
        {
            this.Dialogs = Dialogs.On;
        }
        
        public ProjectSettings ProjectSettings { get; set; }
        public Dialogs Dialogs { get; set; }
    }
}

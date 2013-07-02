namespace SitecoreInstaller.App.Pipelines
{
  using System;
  using SitecoreInstaller.Domain.Pipelines;

  public class StepEventArgs : EventArgs
    {
        public StepEventArgs()
        {
            this.Dialogs = Dialogs.On;
        }
        
        public ProjectSettings ProjectSettings { get; set; }
        public Dialogs Dialogs { get; set; }
    }
}

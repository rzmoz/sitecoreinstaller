namespace SitecoreInstaller.Framework.Sys
{
  public class CommandPromptResult
  {
    private string standardOutput;
    private string standardError;

    public CommandPromptResult()
    {
      standardOutput = string.Empty;
      standardError = string.Empty;
    }

    public string StandardOutput
    {
      get
      {
        return this.standardOutput;
      }
      set
      {
        this.standardOutput = value ?? string.Empty;
      }
    }

    public string StandardError
    {
      get
      {
        return this.standardError;
      }
      set
      {
        this.standardError = value ?? string.Empty;
      }
    }
  }
}

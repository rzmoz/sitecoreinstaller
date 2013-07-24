﻿namespace SitecoreInstaller.Framework.CmdArgs
{
  public class CmdLineParameter
  {
    public CmdLineParameter(string name, string helpMessage)
    {
      this.Name = name;
      this.Value = string.Empty;
      this.Required = false;
      this.Help = helpMessage;
      this.AllowEmptyValue = true;
      this.Exists = false;
    }

    public void SetValue(string value)
    {
      this.Value = value;
      this.Exists = true;
    }

    public string Value { get; private set; }
    public string Help { get; set; }
    public bool Exists { get; private set; }
    public bool Required { get; set; }
    public bool AllowEmptyValue { get; set; }
    public string Name { get; private set; }
  }
}
namespace SitecoreInstaller.Framework.CmdArgs
{
    public class CmdLineParameter
    {
        public CmdLineParameter(string name, string helpMessage)
        {
            Name = name;
            Value = string.Empty;
            Required = false;
            Help = helpMessage;
            AllowEmptyValue = true;
            Exists = false;
        }

        public void SetValue(string value)
        {
            Value = value;
            Exists = true;
        }

        public string Value { get; private set; }
        public string Help { get; set; }
        public bool Exists { get; private set; }
        public bool Required { get; set; }
        public bool AllowEmptyValue { get; set; }
        public string Name { get; private set; }
    }
}

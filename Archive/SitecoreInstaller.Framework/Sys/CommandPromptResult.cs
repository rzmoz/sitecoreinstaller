namespace SitecoreInstaller.Framework.Sys
{
    public class CommandPromptResult
    {
        private string _standardOutput;
        private string _standardError;

        public CommandPromptResult()
        {
            _standardOutput = string.Empty;
            _standardError = string.Empty;
        }

        public bool HasErrors
        {
            get { return _standardError.Length > 0; }
        }

        public string StandardOutput
        {
            get { return _standardOutput; }
            set { _standardOutput = value ?? string.Empty; }
        }

        public string StandardError
        {
            get { return _standardError; }
            set { _standardError = value ?? string.Empty; }
        }
    }
}

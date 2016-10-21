namespace SitecoreInstaller.Databases
{
    public abstract class BaseConnectionString : IConnectionString
    {
        public string Value { get; set; }
        public virtual bool IsValid()
        {
            //we assume the con str is good if set
            return string.IsNullOrEmpty(Value) == false;
        }
        public override string ToString()
        {
            return Value;
        }
    }
}

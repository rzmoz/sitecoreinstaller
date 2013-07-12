namespace SitecoreInstaller.Framework.Sys.Converters
{
  public class StringConverter : Converter
  {
    public override T Convert<T>(object value)
    {
      return (T)(object)value.ToString();
    }
  }
}

using System;

namespace SitecoreInstaller.Framework.Sys.Converters
{
  public class IntConverter : Converter
  {
    public override T Convert<T>(object value)
    {
      return (T)(object)Int32.Parse(value.ToString());
    }
  }
}

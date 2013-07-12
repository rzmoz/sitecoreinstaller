using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Framework.Sys.Converters
{
  public class BoolConverter : Converter
  {
    public override T Convert<T>(object value)
    {
      return (T)(object)Boolean.Parse(value.ToString());
    }
  }
}

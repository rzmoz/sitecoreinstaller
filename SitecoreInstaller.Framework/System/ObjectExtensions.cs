using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.System
{
  using SitecoreInstaller.Framework.System.Converters;
  using global::System.Reflection;

  public static class ObjectExtensions
  {
    public static void SetPropertyValue<T>(this object obj, string propName, T val)
    {
      Type t = obj.GetType();
      t.InvokeMember(propName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty | BindingFlags.Instance, null, obj, new object[] { val });
    }

    public static T TrySet<T>(this T property, object inputValue, bool setIfEmptyString = false)
    {
      if (inputValue == null)
        return property;

      if (setIfEmptyString == false)
      {
        var input = inputValue.ToString();
        if (input.Length == 0)
          return property;
      }

      if (inputValue == null)
        throw new ArgumentNullException("inputValue");

      var converter = ConverterFactory.Create<T>();
      return converter.Convert<T>(inputValue);
    }
    
  }
}

using System;

namespace SitecoreInstaller.Framework.System.Converters
{
  public static class ConverterFactory
  {
    public static Converter Create<T>()
    {
      var targetType = typeof(T);

      switch (targetType.FullName)
      {
        case "System.String":
          return new StringConverter();
        case "System.Int32":
          return new IntConverter();
        case "System.Boolean":
          return new BoolConverter();
        default:
          throw new NotSupportedException("Type not supported. Was: " + targetType.FullName);
      }
    }
  }
}

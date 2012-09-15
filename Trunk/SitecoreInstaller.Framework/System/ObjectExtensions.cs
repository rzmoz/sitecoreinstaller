using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.System
{
    using global::System.Dynamic;

    public static class ObjectExtensions
    {
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

            var targetType = typeof(T);

            switch (targetType.FullName)
            {
                case "System.String":
                    return (T)(object)inputValue.ToString();
                case "System.Int32":
                    return (T)(object)Int32.Parse(inputValue.ToString());
                case "System.Boolean":
                    return (T)(object)Boolean.Parse(inputValue.ToString());
                default:
                    throw new NotSupportedException("Type not supported. Was: " + targetType.FullName);
            }
        }
    }
}

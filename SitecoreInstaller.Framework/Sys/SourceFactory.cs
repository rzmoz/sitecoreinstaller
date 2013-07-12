using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace SitecoreInstaller.Framework.Sys
{
    public class SourceFactory
    {
        private const string _TypeFormatRegex = @"^([a-zA-Z0-9\. ]+,[a-zA-Z0-9\. ]+)$";
        private static readonly Regex _typeFormatRegex = new Regex(_TypeFormatRegex, RegexOptions.Compiled);

        public T Create<T>(string type, string name)
        {
            //verify format of input
            if (!_typeFormatRegex.IsMatch(type))
                throw new ArgumentException(string.Format("type \"{0}\" is not in correct format - should be in this format: {1}", type, _TypeFormatRegex));

            //classInfo[0] is class identifier
            //classInfo[1] is assembly name
            var classInfo = type.Replace(" ", string.Empty).Split(',');

            //test if type is present in already loaded assemblies
            var a = Assembly.Load(new AssemblyName(classInfo[1]));
            var objectType = a.GetType(classInfo[0]);
            try
            {
                var o = Activator.CreateInstance(objectType, name);
                if (o is T)
                    return (T)o;

                throw new ArgumentException("Type '{0}' doesn't implement SitecoreInstaller.Domain.BuildLibrary.ISource", type);
            }
            catch (Exception e)
            {
                throw new ArgumentException(string.Format("Error creating type: {0}\r\n\r\nInnerException:\r\n{1}", type, e));
            }
        }
    }
}

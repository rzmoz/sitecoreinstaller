using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    public class LicenseFileException : Exception
    {
        public LicenseFileException()
        {
        }

        public LicenseFileException(string message) : base(message)
        {
        }
        public LicenseFileException(string messageFormat, params object[] parameters)
            : base(string.Format(messageFormat, parameters))
        {
        }

        public LicenseFileException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LicenseFileException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

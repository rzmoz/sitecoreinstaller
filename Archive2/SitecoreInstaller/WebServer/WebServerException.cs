using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SitecoreInstaller.WebServer
{
    public class WebServerException : Exception
    {
        public WebServerException()
        {
        }

        public WebServerException(string message) : base(message)
        {
        }

        public WebServerException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected WebServerException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

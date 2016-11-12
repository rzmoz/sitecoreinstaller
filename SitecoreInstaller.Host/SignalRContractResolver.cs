using System;
using System.Reflection;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json.Serialization;

namespace SitecoreInstaller.Host
{
    public class SignalRContractResolver : IContractResolver
    {
        private readonly Assembly _assembly;
        private readonly IContractResolver _camelCaseContractResolver;
        private readonly IContractResolver _defaultContractSerializer;

        public SignalRContractResolver()
        {
            _defaultContractSerializer = new DefaultContractResolver();
            _camelCaseContractResolver = new CamelCasePropertyNamesContractResolver();
            _assembly = typeof(Hub).Assembly;
        }

        public JsonContract ResolveContract(Type type)
        {
            return type.Assembly.Equals(_assembly) ? 
                _defaultContractSerializer.ResolveContract(type) : 
                _camelCaseContractResolver.ResolveContract(type);
        }

    }
}

using DotNet.Basics.Ioc;

namespace SitecoreInstaller.Runtime
{
    public class RuntimeBootstrapper
    {
        private readonly SimpleContainer _container;

        public RuntimeBootstrapper()
        {
            _container = new SimpleContainer();
            _container.Register(new SiRegistrations());
        }

        public void Register(params ISimpleRegistrations[] registrations)
        {
            _container.Register(registrations);
        }
    }
}

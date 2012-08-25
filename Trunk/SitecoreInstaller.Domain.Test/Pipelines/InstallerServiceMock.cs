namespace SitecoreInstaller.Domain.Test.Pipelines
{
    using System;
    using System.Collections.Generic;

    using SitecoreInstaller.Domain.Pipelines;
    using SitecoreInstaller.Framework.Diagnostics;

    internal class InstallerServiceMock : IPipeline
    {
        public void NotAInstallStep() { }

        public string Name
        {
            get { return GetType().Name; }
        }

        public IEnumerable<IStep> Steps
        {
            get { throw new NotImplementedException(); }
        }

        public IEnumerable<IPrecondition> Preconditions
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsInUiMode
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public void Init()
        {
        }
    }
}

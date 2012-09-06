namespace SitecoreInstaller.Domain.Test.Pipelines
{
    using System;
    using System.Collections.Generic;

    using NSubstitute;

    using SitecoreInstaller.Domain.Pipelines;
    using SitecoreInstaller.Framework.Diagnostics;

    internal class InstallerServiceMock : Pipeline
    {
        public InstallerServiceMock()
        {
            AddStep(Substitute.For<IStep>());
            AddStep(Substitute.For<IStep>());
            AddStep(Substitute.For<IStep>());
        }
    }
}

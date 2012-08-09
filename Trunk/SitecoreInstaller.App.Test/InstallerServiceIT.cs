using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SitecoreInstaller.App.Pipelines;
using SitecoreInstaller.Domain.Pipelines;


namespace SitecoreInstaller.App.Test
{
    using FluentAssertions;

    using NSubstitute;

    using SitecoreInstaller.Framework.Diagnostics;

    [TestFixture]
    public class InstallerServiceIT
    {
        private PipelineRunner<InstallPipeline> _installerService;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            var log = Substitute.For<ILog>();
            _installerService = new PipelineRunner<InstallPipeline>(new InstallPipeline(null),  log);
        }

        [Test]
        public void Ctor_InitInstallSteps_InstallStepsAreFound()
        {
            var installationSteps = _installerService.Processor.Steps;

            installationSteps.Should().HaveCount(16);
        }
    }
}

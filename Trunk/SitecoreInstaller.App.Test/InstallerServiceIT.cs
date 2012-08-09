using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using SitecoreInstaller.App.Pipelines;
using SitecoreInstaller.Domain.Pipelines;


namespace SitecoreInstaller.App.Test
{
    using SitecoreInstaller.Framework.Diagnostics;

    [TestFixture]
    public class InstallerServiceIT
    {
        private PipelineRunner<InstallPipeline> _installerService;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            _installerService = new PipelineRunner<InstallPipeline>(new InstallPipeline(null),  new Log());
        }

        [Test]
        public void Ctor_InitInstallSteps_InstallStepsAreFound()
        {
            var installationSteps = _installerService.Processor.Steps;

            Assert.AreEqual(16, installationSteps.Count());
        }
    }
}

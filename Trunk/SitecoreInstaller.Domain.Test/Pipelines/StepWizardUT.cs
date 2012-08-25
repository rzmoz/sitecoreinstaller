namespace SitecoreInstaller.Domain.Test.Pipelines
{
    using System.Linq;

    using NUnit.Framework;

    using SitecoreInstaller.Domain.Pipelines;
    using SitecoreInstaller.Framework.Diagnostics;

    [TestFixture]
    public class StepWizardUT
    {
        private PipelineRunner<InstallerServiceMock> _pipelineRunner;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            _pipelineRunner = new PipelineRunner<InstallerServiceMock>(new InstallerServiceMock());
        }

        
        [Test]
        public void Steps_GetInstallSteps_StepsAreFound()
        {
            var result = _pipelineRunner.Pipeline.Steps;

            Assert.AreEqual(3, result.Count());
        }
        [Test]
        public void Steps_StepsOrdering_StepsAreOrderedAscending()
        {
            /*
            var result = _pipelineRunner.Processor.Steps.ToList();

            Assert.AreEqual(1, result[0].Order);
            Assert.AreEqual(2, result[1].Order);
            Assert.AreEqual(3, result[2].Order);
             * */
        }
    }
}

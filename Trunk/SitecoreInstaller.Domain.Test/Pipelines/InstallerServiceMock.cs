namespace SitecoreInstaller.Domain.Test.Pipelines
{
    using System;

    using SitecoreInstaller.Domain.Pipelines;
    using SitecoreInstaller.Framework.Diagnostics;

    internal class InstallerServiceMock : IPipeline
    {
        //unordered on purpose
        [Step(2)]
        public void Step2(object sender, EventArgs args) { }
        [Step(3)]
        public void Step3(object sender, EventArgs args) { }
        [Step(1)]
        public void Step01WithMoreText(object sender, EventArgs args) { }


        //[Step(4)]
        //public void InvalidStepWithWrongParameters() { }

        public void NotAInstallStep() { }

        public void Init(ILog log)
        {

        }
    }
}

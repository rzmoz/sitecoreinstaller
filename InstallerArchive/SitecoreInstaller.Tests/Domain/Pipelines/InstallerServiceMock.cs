using System;
using System.Collections.Generic;
using SitecoreInstaller.App.Pipelines;
using SitecoreInstaller.Domain.Pipelines;
using SitecoreInstaller.Framework.Linguistics;

namespace SitecoreInstaller.Tests.Domain.Pipelines
{
    public class InstallerServiceMock : Pipeline<PipelineApplicationEventArgs>
    {
        public class EmptyStep : IStep
        {
            public EmptyStep()
            {
                Name = new Sentence(GetType().Name);
            }

            public Sentence Name { get; private set; }
            public event EventHandler<EventArgs> StepInvoking;
            public event EventHandler<EventArgs> StepInvoked;

            public int Order
            {
                get { throw new NotImplementedException(); }
                set { throw new NotImplementedException(); }
            }

            public IEnumerable<IPrecondition> Preconditions
            {
                get { throw new NotImplementedException(); }
            }

            public void Invoke(object sender, EventArgs e)
            {
                throw new NotImplementedException();
            }
        }

        public InstallerServiceMock()
        {
            AddStep<EmptyStep>();
            AddStep<EmptyStep>();
            AddStep<EmptyStep>();
        }
    }
}

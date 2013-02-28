namespace SitecoreInstaller.Domain.Test.Pipelines
{
    using System;
    using System.Collections.Generic;

    using SitecoreInstaller.Domain.Pipelines;
  
    public class InstallerServiceMock : Pipeline
    {
        public class EmptyStep : IStep
        {
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

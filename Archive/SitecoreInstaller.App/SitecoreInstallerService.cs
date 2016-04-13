using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SitecoreInstaller.Domain.Batch;
using SitecoreInstaller.Framework.Messaging;

namespace SitecoreInstaller.App
{
    public abstract class SitecoreInstallerService
    {
        protected IMessenger Messenger;

        protected SitecoreInstallerService()
        {
            Messenger = new Messenger();
        }

        public void Init(IMessenger messenger)
        {
            Messenger = messenger;
        }

        [StepPrecondition]
        public bool ProjectNameIsSet(string taskName)
        {
            if (Services.AppSettings.ProjectNameIsSet == false)
            {
                const string message = "'{0}' not executed because project name isn't set. Please set Project name";
                Messenger.Error(message, taskName);
                return false;
            }
            return true;
        }
    }
}

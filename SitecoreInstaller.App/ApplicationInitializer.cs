using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using DotNet.Basics.Autofac;
using DotNet.Basics.Collections;
using DotNet.Basics.NLog;
using Newtonsoft.Json;
using SitecoreInstaller.Domain;

namespace SitecoreInstaller.App
{
    public class ApplicationInitializer
    {
        public IContainer Container { get; private set; }

        public bool RunPreflightChecks()
        {
            var preflightChecks = Container.Resolve<IEnumerable<IPreflightCheck>>();

            return InitArea("Preflight checks", (errorMsgs) =>
            {
                foreach (var preflightCheck in preflightChecks)
                    AssertPreflightCheck(preflightCheck, errorMsgs);

            }, "Starting", "Finished");
        }

        private void AssertPreflightCheck(IPreflightCheck preflightCheck, IList<string> errorMsgs)
        {
            this.NLog().Debug($"Preflight check: {preflightCheck.GetType().Name} started..");
            var result = preflightCheck.Assert();
            if (result.Issues.None())
                this.NLog().Debug($"Preflight check: {preflightCheck.GetType().Name} finished");
            else
                errorMsgs.Add(
                    $"Preflight check {preflightCheck.GetType().Name} failed:\r\n{JsonConvert.SerializeObject(result.Issues)}");
        }

        public void InitApplication()
        {
            var applicationInitializers = Container.Resolve<IEnumerable<IInitializable>>();
            foreach (var applicationInitializer in applicationInitializers)
                applicationInitializer.Init();
        }

        public bool InitRegistrations(Action<AutofacBuilder> iocRegistrations = null)
        {
            return InitArea("IocContainer", errorMsgs =>
            {
                try
                {
                    var builder = new AutofacBuilder(false);
                    builder.Register(new SitecoreInstallerRegistrations());
                    iocRegistrations?.Invoke(builder);
                    Container = builder.Container;
                    foreach (var registration in Container.ComponentRegistry.Registrations)
                        this.NLog().Debug($"{JsonConvert.SerializeObject(registration.Services.Select(s => s.Description)) }");
                }
                catch (Exception e)
                {
                    errorMsgs.Add(e.ToString());
                }
            });
        }

        private bool InitArea(string areaName, Action<IList<string>> initFunc, string startingVerb = "initializing", string endedVerb = "Initialized")
        {
            this.NLog().Debug($"{areaName} {startingVerb}...");
            var errorMessages = new List<string>();
            initFunc(errorMessages);
            var success = errorMessages.Count == 0;
            if (success)
                this.NLog().Debug($"{areaName} {endedVerb}");
            else
            {
                foreach (var errorMessage in errorMessages)
                    this.NLog().Error(errorMessage);

                this.NLog().Fatal($"{startingVerb} of {areaName} failed. Application will not run properly. Aborting...");
            }
            return success;
        }
    }
}

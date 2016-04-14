using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using DotNet.Basics.Collections;
using DotNet.Basics.IO;
using DotNet.Basics.Sys;
using SitecoreInstaller.Domain.BuildLibrary;

namespace SitecoreInstaller.Cmdlets.BuildLibrary
{
    public abstract class BuildLibraryCmdlet : Cmdlet
    {
        protected IEnumerable<IBuildLibraryResource> GetFromBuildLibrary(string[] names, BuildLibraryType buildLibraryType, string blRootPath)
        {
            IBuildLibrary buildLibrary = string.IsNullOrWhiteSpace(blRootPath) ? new IOBuildLibrary() : new IOBuildLibrary(blRootPath.ToDir());

            var results = names.ForEach(n =>
            {
                var res = buildLibrary.Get(n, buildLibraryType);
                if (res == null)
                    WriteWarning($"{buildLibraryType.ToName()} not found: {n}");
                else
                    WriteObject(res);
                return res;
            });
            return results.Where(r => r != null);
        }
    }
}

using System.Collections.Generic;
using System.IO;

namespace SitecoreInstaller.Domain.BuildLibrary
{
    using SitecoreInstaller.Framework.Diagnostics;

    public interface ISource : ISourceRepository
    {
        string Name { get; }
        string Parameters { get; set; }

        bool Contains(string name, SourceType sourceType);

        ILog Log { get; set; }
    }
}

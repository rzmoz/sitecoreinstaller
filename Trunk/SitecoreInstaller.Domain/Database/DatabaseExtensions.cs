using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Domain.Database
{
    public static class DatabaseExtensions
    {
        public static bool IsDatabaseFile(this FileInfo file)
        {
            return (file.Extension.ToLowerInvariant() == ".ldf" || file.Extension.ToLowerInvariant() == ".mdf");
        }
    }
}

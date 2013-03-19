using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SitecoreInstaller.Framework.IO
{
    using SitecoreInstaller.Framework.System;

    using global::System.Diagnostics.Contracts;
    using global::System.IO;

    public class Robocopy : CommandPrompt
    {
        private const string _FileName = @"Robocopy";
        private const string _SourceDestinationFormat = _FileName + @" ""{0}"" ""{1}"" /NP ";
        private const string _IncludeSubfoldersSwitch = " /e ";
        private const string _MoveSwitch = " /move ";

        private void Run(DirectoryInfo source, DirectoryInfo target, string switches)
        {
            Contract.Requires<ArgumentNullException>(target != null);
            Contract.Requires<ArgumentNullException>(source != null);

            var command = string.Format(_SourceDestinationFormat, source.FullName, target.FullName);
            command += switches;
            Run(command);
        }

        public void Copy(DirectoryInfo source, DirectoryInfo target, DirCopyOptions dirCopyOptions)
        {
            var switches = string.Empty;
            if (dirCopyOptions == DirCopyOptions.IncludeSubDirectories)
                switches = _IncludeSubfoldersSwitch;
            Run(source, target, switches);
        }
        public void Move(DirectoryInfo source, DirectoryInfo target)
        {
            Run(source, target, _IncludeSubfoldersSwitch + _MoveSwitch);
            source.Delete(true);
        }
        public void Move(FileInfo file, DirectoryInfo target)
        {
            Run(file.Directory, target, file.Name + _MoveSwitch);
        }
    }
}

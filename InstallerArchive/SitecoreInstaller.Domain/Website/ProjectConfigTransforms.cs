using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharp.Basics.IO;
using CSharp.Basics.Xdt;
using SitecoreInstaller.Framework.IOx;

namespace SitecoreInstaller.Domain.Website
{
    public class ProjectConfigTransforms
    {
        private const string _webConfigName = "Web";
        private const string _connectionstringsConfigName = "ConnectionStrings";

        public ProjectConfigTransforms(ProjectFolder projectFolder, IEnumerable<ProjectDeltaFile> deltas)
        {
            if (projectFolder == null) throw new ArgumentNullException("projectFolder");
            if (deltas == null) throw new ArgumentNullException("deltas");
            ProjectFolder = projectFolder;
            Deltas = deltas.ToList();
        }

        public void Transform()
        {
            //we break if there's no delta files to consider
            if (Deltas.Any() == false)
                return;

            var webDeltas = GetDeltasByName(Deltas, _webConfigName);
            Transform(ProjectFolder.Website.CombineTo<FileInfo>(_webConfigName + ".config"), webDeltas);

            var connectionstringsDeltas = GetDeltasByName(Deltas, _connectionstringsConfigName);
            Transform(ProjectFolder.Website.CombineTo<FileInfo>(_connectionstringsConfigName + ".config"), connectionstringsDeltas);

            Transform(Deltas.ToList());
        }

        private void Transform(IList<ProjectDeltaFile> deltas)
        {
            if (deltas.Any() == false)
                return;

            foreach (var delta in deltas)
            {
                var target = ProjectFolder.CombineTo<FileInfo>(delta.GetRelativePath());
                if (target.Exists)
                    XdtTransform.Transform(target, File.ReadAllText(delta.File.FullName));
            }
        }


        private void Transform(FileInfo target, IList<ProjectDeltaFile> deltas)
        {
            if (deltas.Any() == false)
                return;

            foreach (var fileInfo in deltas)
            {
                Transform(target, fileInfo);
            }

        }

        private void Transform(FileInfo target, ProjectDeltaFile delta)
        {
            target.Refresh();
            if (target.Exists == false)
                return;

            delta.File.Refresh();
            if (delta.File.Exists == false)
                return;

            XdtTransform.Transform(target, File.ReadAllText(delta.File.FullName));
        }


        private IList<ProjectDeltaFile> GetDeltasByName(IEnumerable<ProjectDeltaFile> deltas, string name)
        {
            return deltas.Where(delta => FileTypes.ConfigDelta.IsType(delta.File)).Where(delta => delta.File.Name.ToLowerInvariant().StartsWith(name.ToLowerInvariant())).ToList();
        }

        public ProjectFolder ProjectFolder { get; private set; }
        public IEnumerable<ProjectDeltaFile> Deltas { get; private set; }
    }
}

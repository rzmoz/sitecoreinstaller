using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SitecoreInstaller.Framework.IO
{
    using SitecoreInstaller.Framework.Diagnostics;

    using global::System;
    using global::System.Security.AccessControl;

    public static class DirectoryInfoExtensions
    {
        private static readonly FileSystemInfoFactory _fileSystemInfoFactory;

        static DirectoryInfoExtensions()
        {
            _fileSystemInfoFactory = new FileSystemInfoFactory();
        }

        public static DirectoryInfo ToDirectoryInfo(this string dir)
        {
            if (dir == null) { throw new ArgumentNullException("dir"); }
            return new DirectoryInfo(dir);
        }

        public static void Clean(this DirectoryInfo dir, OnFail onFail = OnFail.LogError)
        {
            dir.DeleteWithLog(onFail);
            dir.CreateIfNotExists();
        }

        public static T Combine<T>(this Folder folder, params T[] paths) where T : FileSystemInfo
        {
            return folder.Directory.Combine(paths);
        }
        public static T Combine<T>(this DirectoryInfo directoryInfo, params T[] paths) where T : FileSystemInfo
        {
            var combinedString = CombineToString(directoryInfo, paths);
            return _fileSystemInfoFactory.Create<T>(combinedString);
        }
        public static T CombineTo<T>(this Folder folder, params string[] paths) where T : FileSystemInfo
        {
            return folder.Directory.CombineTo<T>(paths);
        }
        public static T CombineTo<T>(this DirectoryInfo directoryInfo, params string[] paths) where T : FileSystemInfo
        {
            var tempPathTokens = new List<FileSystemInfo>();

            foreach (var path in paths)
            {
                var tempPath = path.Replace("/", @"\");
                tempPathTokens.AddRange(tempPath.Split('\\').Select(token => new FileInfo(token)));
            }

            var pathTokens = tempPathTokens.Select(x => x).ToArray();

            var combinedString = CombineToString(directoryInfo, pathTokens);
            return _fileSystemInfoFactory.Create<T>(combinedString);
        }

        public static IEnumerable<FileInfo> GetFiles(this DirectoryInfo directory, FileType fileType)
        {
            return fileType.GetFiles(directory);
        }

        public static IEnumerable<FileInfo> GetFiles(this DirectoryInfo directory, FileType fileType, SearchOption searchOption)
        {
            return fileType.GetFiles(directory, searchOption);
        }

        private static string CombineToString(DirectoryInfo rootDirectory, params FileSystemInfo[] pathTokens)
        {
            var paths = new List<string> { rootDirectory.FullName };
            paths.AddRange(pathTokens.Select(path => path.Name));
            var combinedPath = Path.Combine(paths.ToArray());
            return combinedPath;
        }

        public static bool ParentHasIdenticalName(this DirectoryInfo dir)
        {
            if (dir == null)
                return false;
            if (Directory.Exists(dir.FullName) == false)
                return false;
            if (dir.Parent == null)
                return false;
            return dir.Name.Equals(dir.Parent.Name);
        }

        public static bool TryGetIdenticallyNamedSubDir(this DirectoryInfo dir, out DirectoryInfo identicalChild)
        {
            identicalChild = null;
            if (dir == null)
                return false;
            if (Directory.Exists(dir.FullName) == false)
                return false;

            var identicalSubFolders = dir.GetDirectories(dir.Name);
            var hasIdenticalChild = identicalSubFolders.Any();
            if (hasIdenticalChild)
                identicalChild = identicalSubFolders.First();
            return hasIdenticalChild;
        }

        public static void CreateIfNotExists(this DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null)
                return;
            if (Directory.Exists(directoryInfo.FullName))
                return;

            directoryInfo.Create();
        }

        public static void DeleteIfExists(this DirectoryInfo directoryInfo)
        {
            if (directoryInfo == null)
                return;
            if (Directory.Exists(directoryInfo.FullName))
                directoryInfo.Delete();
        }

        public static void CopyTo(this IEnumerable<DirectoryInfo> directoryInfos, Folder target)
        {
            directoryInfos.CopyTo(target.Directory);
        }
        public static void CopyTo(this IEnumerable<DirectoryInfo> directoryInfos, DirectoryInfo target)
        {
            foreach (var dir in directoryInfos)
            {
                var targetFolder = target.Combine(dir);
                dir.CopyTo(targetFolder, DirCopyOptions.IncludeSubDirectories);
            }
        }

        public static void GrantFullControl(this Folder folder, string username)
        {
            folder.Directory.GrantFullControl(username);
        }
        public static void GrantFullControl(this DirectoryInfo dir, string username)
        {
            if (Directory.Exists(dir.FullName) == false)
                return;
            Log.ToApp.Debug("Giving Network Service user write access to: {0}", dir.FullName);

            DirectorySecurity directorySecurity = dir.GetAccessControl();
            CanonicalizeDacl(directorySecurity);

            directorySecurity.AddAccessRule(new FileSystemAccessRule(
                                    username,
                                    FileSystemRights.FullControl,
                                    InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                                    PropagationFlags.None,
                                    AccessControlType.Allow));

            dir.SetAccessControl(directorySecurity);

        }
        static void CanonicalizeDacl(NativeObjectSecurity objectSecurity)
        {
            if (objectSecurity == null) { throw new ArgumentNullException("objectSecurity"); }
            if (objectSecurity.AreAccessRulesCanonical) { return; }

            // A canonical ACL must have ACES sorted according to the following order:
            //   1. Access-denied on the object
            //   2. Access-denied on a child or property
            //   3. Access-allowed on the object
            //   4. Access-allowed on a child or property
            //   5. All inherited ACEs 
            var descriptor = new RawSecurityDescriptor(objectSecurity.GetSecurityDescriptorSddlForm(AccessControlSections.Access));

            var implicitDenyDacl = new List<CommonAce>();
            var implicitDenyObjectDacl = new List<CommonAce>();
            var inheritedDacl = new List<CommonAce>();
            var implicitAllowDacl = new List<CommonAce>();
            var implicitAllowObjectDacl = new List<CommonAce>();

            foreach (CommonAce ace in descriptor.DiscretionaryAcl)
            {
                if ((ace.AceFlags & AceFlags.Inherited) == AceFlags.Inherited) { inheritedDacl.Add(ace); }
                else
                {
                    switch (ace.AceType)
                    {
                        case AceType.AccessAllowed:
                            implicitAllowDacl.Add(ace);
                            break;

                        case AceType.AccessDenied:
                            implicitDenyDacl.Add(ace);
                            break;

                        case AceType.AccessAllowedObject:
                            implicitAllowObjectDacl.Add(ace);
                            break;

                        case AceType.AccessDeniedObject:
                            implicitDenyObjectDacl.Add(ace);
                            break;
                    }
                }
            }

            Int32 aceIndex = 0;
            RawAcl newDacl = new RawAcl(descriptor.DiscretionaryAcl.Revision, descriptor.DiscretionaryAcl.Count);
            implicitDenyDacl.ForEach(x => newDacl.InsertAce(aceIndex++, x));
            implicitDenyObjectDacl.ForEach(x => newDacl.InsertAce(aceIndex++, x));
            implicitAllowDacl.ForEach(x => newDacl.InsertAce(aceIndex++, x));
            implicitAllowObjectDacl.ForEach(x => newDacl.InsertAce(aceIndex++, x));
            inheritedDacl.ForEach(x => newDacl.InsertAce(aceIndex++, x));

            if (aceIndex != descriptor.DiscretionaryAcl.Count)
            {
                //"The DACL cannot be canonicalized since it would potentially result in a loss of information";
                return;
            }

            descriptor.DiscretionaryAcl = newDacl;
            objectSecurity.SetSecurityDescriptorSddlForm(descriptor.GetSddlForm(AccessControlSections.Access), AccessControlSections.Access);
        }
    }
}

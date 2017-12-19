﻿using System.Collections.Generic;
using DotNet.Basics.IO;
using DotNet.Basics.Sys;
using Microsoft.Extensions.Logging;
using SitecoreInstaller.Domain;
using SitecoreInstaller.Domain.Library;

namespace SitecoreInstaller.Infrastructure.Library
{
    public abstract class LibraryIoRepository : ILibraryRepository, IInitializable
    {
        private readonly DirPath _root;
        private readonly ILogger _logger;

        protected LibraryIoRepository(DirPath root, ILogger logger)
        {
            _root = root;
            _logger = logger;
        }

        public bool Insert(IngressAsset ingress, bool overwriteIfExists = false)
        {
            var target = _root.ToPath(ingress.PathType, ingress.Container, ingress.Name);
            if (target.Exists() && !overwriteIfExists)
            {
                _logger.LogTrace($"Aborting insert of {ingress}. Target already exists at {target.FullName()}");
                return false;
            }

            target.DeleteIfExists();

            return ingress.Extract(_root.Add(ingress.Container));
        }

        public IEnumerable<EgressAsset> GetAll<T>() where T : EgressAsset
        {
            throw new System.NotImplementedException();
        }

        public EgressAsset Get(EgressAsset asset)
        {
            throw new System.NotImplementedException();
        }

        public bool Exists(EgressAsset asset)
        {
            return _root.ToPath(asset.PathType, asset.Container, asset.Name).Exists();
        }

        public bool Delete(EgressAsset asset)
        {
            var target = _root.ToPath(asset.PathType, asset.Container, asset.Name);
            return target.DeleteIfExists();
        }

        public void Init()
        {
            _root.CreateIfNotExists();
            _logger.LogDebug($"Library repository initialized to: {_root}");
        }
    }
}

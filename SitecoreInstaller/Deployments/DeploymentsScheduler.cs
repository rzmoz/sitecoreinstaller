﻿using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using DotNet.Basics.Tasks.Pipelines;
using NLog;

namespace SitecoreInstaller.Deployments
{
    public class DeploymentsScheduler
    {
        private readonly ConcurrentDictionary<string, object> _tasks = new ConcurrentDictionary<string, object>();
        private readonly ILogger _logger;

        public DeploymentsScheduler()
        {
            _logger = LogManager.GetLogger(nameof(DeploymentsScheduler));
        }

        public bool IsRunning(string name)
        {
            return _tasks.ContainsKey(name.ToLowerInvariant());
        }

        public bool TryStart<T>(string name, PipelineSection<T> pipeline, T args) where T : new()
        {
            var key = name.ToLowerInvariant();

            if (_tasks.TryAdd(key, null) == false)
                return false;
            try
            {
                Task.Run(async () =>
                {
                    try
                    {
                        await pipeline.RunAsync(args).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        _logger.Error(e.ToString()); ;
                    }
                    finally
                    {
                        object @out;
                        _tasks.TryRemove(key, out @out);
                    }
                });
                return true;
            }
            catch (Exception)
            {
                object @out;
                _tasks.TryRemove(key, out @out);
                return false;
            }
        }
    }
}
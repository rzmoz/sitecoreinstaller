using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using DotNet.Basics.NLog;
using DotNet.Basics.Tasks.Pipelines;
using Newtonsoft.Json;
using NLog;
using SitecoreInstaller.Pipelines;

namespace SitecoreInstaller.Deployments
{
    public class DeploymentsScheduler
    {
        private static readonly ConcurrentDictionary<string, object> _tasks = new ConcurrentDictionary<string, object>();

        public bool IsRunning(string name)
        {
            return _tasks.ContainsKey(name.ToLowerInvariant());
        }

        public bool TryStart<T>(string name, Pipeline<T> pipeline, T args) where T : LocalArgs, new()
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
                        var result = await pipeline.RunAsync(args, CancellationToken.None).ConfigureAwait(false);
                        if (result.NoIssues == false)
                            this.NLog().Warn(JsonConvert.SerializeObject(result.Issues));
                    }
                    catch (Exception e)
                    {
                        args.Info.Task.Status = DeploymentStatus.Failed;
                        args.DeploymentDir.SaveDeploymentInfo(args.Info);
                        this.NLog().Error(e.ToString()); ;
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

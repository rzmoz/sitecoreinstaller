using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;
using DotNet.Basics.Sys;
using NLog;

namespace SitecoreInstaller.Host
{
    public static class EventQueue
    {
        private static readonly IDictionary<string, EventWorker> _workers;
        private static readonly ConcurrentQueue<EventDto> _queue;
        private static readonly ILogger _logger;

        static EventQueue()
        {
            _workers = new Dictionary<string, EventWorker>();
            _queue = new ConcurrentQueue<EventDto>();
            _logger = LogManager.GetLogger(nameof(EventQueue));
        }

        internal static void Init()
        {
            var task = Task.Run(async () =>
            {
                while (true)
                {
                    Push(new EventDto("sdfs", "sdsdf", DateTime.UtcNow.Ticks));

                    try
                    {
                        EventDto dto;
                        if (_queue.TryDequeue(out dto))
                        {
                            _logger.Debug($"Event dispatched: {dto}");
                            Parallel.ForEach(_workers.Values, worker =>
                            {
                                worker?.GiveWork(dto);
                            });
                        }

                        await Task.Delay(250.MilliSeconds()).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        //never crash this thread
                        _logger.Warn(e.ToString);
                    }
                }
            });
        }

        public static void Attach(EventWorker worker)
        {
            _workers.Add(worker.Name.ToLowerInvariant(), worker);
        }

        public static void Detach(string name)
        {
            _workers.Remove(name.ToLowerInvariant());
        }

        public static void Push(EventDto dto)
        {
            if (dto == null)
                return;
            _queue.Enqueue(dto);
        }
    }
}

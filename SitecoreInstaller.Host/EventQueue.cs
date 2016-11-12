using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using DotNet.Basics.NLog;
using DotNet.Basics.Sys;

namespace SitecoreInstaller.Host
{
    public class EventQueue
    {
        private static readonly ConcurrentDictionary<string, EventWorker> _workers;
        private static readonly ConcurrentQueue<EventDto> _queue;

        static EventQueue()
        {
            _workers = new ConcurrentDictionary<string, EventWorker>();
            _queue = new ConcurrentQueue<EventDto>();
        }

        internal static void Init()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    try
                    {
                        bool workFound;
                        do
                        {
                            EventDto dto;
                            workFound = _queue.TryDequeue(out dto);
                            if (workFound)
                            {
                                _queue.NLog<EventQueue>().Debug($"Event dispatched: {dto}");
                                Parallel.ForEach(_workers.Values, worker =>
                                {
                                    worker?.GiveWork(dto);
                                });
                            }
                        } while (workFound);

                        await Task.Delay(200.MilliSeconds()).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        //never crash this thread
                        _queue.NLog<EventQueue>().Warn(e.ToString);
                    }
                }
            });
        }

        public static void Attach(string name, Action<EventDto> giveWork)
        {
            Attach(new EventWorker(name, giveWork));
        }
        public static void Attach(EventWorker worker)
        {
            _workers.TryAdd(worker.Name.ToLowerInvariant(), worker);
        }

        public static void Detach(string name)
        {
            EventWorker worker;
            _workers.TryRemove(name.ToLowerInvariant(), out worker);
        }

        public static void Push(EventDto dto)
        {
            if (dto == null)
                return;
            _queue.Enqueue(dto);
        }
    }
}

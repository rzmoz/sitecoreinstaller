using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SitecoreInstaller.Host
{
    public static class EventMediator
    {
        private static readonly ConcurrentDictionary<string, EventListener> _listeners;
        
        static EventMediator()
        {
            _listeners = new ConcurrentDictionary<string, EventListener>();
            
        }

        public static void Attach(string name, Action<EventDto> tryPush)
        {
            var listener = new EventListener(name, tryPush);
            _listeners.TryAdd(listener.Name.ToLowerInvariant(), listener);
        }

        public static void Push(string group, string name, object data)
        {
            var dto = new EventDto(group, name, JsonConvert.SerializeObject(data));

            Parallel.ForEach(_listeners.Values, l =>
            {
                l.TryPush(dto);
            });
        }

    }
}

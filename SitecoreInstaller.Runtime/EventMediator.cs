using System.Collections.Generic;
using System.Threading.Tasks;

namespace SitecoreInstaller.Runtime
{
    public class EventMediator
    {
        private readonly IDictionary<string, EventListener> _listeners;

        public EventMediator()
        {
            _listeners = new Dictionary<string, EventListener>();
        }

        public void Attach(EventListener listener)
        {
            _listeners.Add(listener.Name.ToLowerInvariant(), listener);
        }

        public void Detach(EventListener listener)
        {
            _listeners.Remove(listener.Name.ToLowerInvariant());
        }

        public void Push(EventDto dto)
        {
            Parallel.ForEach(_listeners.Values, l =>
            {
                l.TryPush(dto);
            });
        }

    }
}

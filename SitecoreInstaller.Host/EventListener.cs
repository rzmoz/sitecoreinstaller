using System;

namespace SitecoreInstaller.Host
{
    public class EventListener
    {
        public EventListener(string name, Action<EventDto> tryPush)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (tryPush == null) throw new ArgumentNullException(nameof(tryPush));
            Name = name;
            TryPush = tryPush;
        }

        public string Name { get; }
        public Action<EventDto> TryPush { get; }

        protected bool Equals(EventListener other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EventListener)obj);
        }

        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

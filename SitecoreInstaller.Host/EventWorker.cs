using System;

namespace SitecoreInstaller.Host
{
    public class EventWorker
    {
        public EventWorker(string name, Action<EventDto> giveWork)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (giveWork == null) throw new ArgumentNullException(nameof(giveWork));
            Name = name;
            GiveWork = giveWork;
        }

        public string Name { get; }
        public Action<EventDto> GiveWork { get; }

        protected bool Equals(EventWorker other)
        {
            return string.Equals(Name, other.Name);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((EventWorker)obj);
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

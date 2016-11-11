using Newtonsoft.Json;

namespace SitecoreInstaller.Host
{
    public class EventDto
    {
        public EventDto(string @group, string name, string data)
        {
            Group = @group;
            Name = name;
            Data = data;
        }

        public string Group { get; }
        public string Name { get; }
        public string Data { get; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

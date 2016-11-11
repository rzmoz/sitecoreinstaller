namespace SitecoreInstaller.Runtime
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
    }
}

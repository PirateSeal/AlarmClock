using System.Collections.Generic;

namespace AlarmClock.Device.DAL.Data
{
    public class ClockData
    {
        public Acl Acl { get; set; }
        public List<PresetData> Presets { get; set; }
    }

    public class Acl
    {
        public Acl(string guid, int pw, string name)
        {
            Guid = guid;
            Password = pw;
            Name = name;
        }

        public string Guid { get; }
        public int Password { get; }
        public string Name { get; set; }
    }
}

using System.Collections.Generic;

namespace AlarmClock.Device.DAL.Data
{
    public class ClockData
    {
        public string Guid { get; set; }
        public int Password { get; set; }
        public string Name { get; set; }
        public List<PresetData> Presets { get; set; }
    }
}

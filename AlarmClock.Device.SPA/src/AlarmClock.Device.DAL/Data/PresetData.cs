using System;

namespace AlarmClock.Device.DAL.Data
{
    public class PresetData
    {
        public int AlarmPresetId { get; set; }
        public TimeSpan WakingTime { get; set; }
        public string Name { get; set; }
        public string Song { get; set; }
        public byte ActivationFlag { get; set; }
        public string Challenge { get; set; }
    }
}

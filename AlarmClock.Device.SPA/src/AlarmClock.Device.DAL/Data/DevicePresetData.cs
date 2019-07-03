using System;

namespace AlarmClock.Device.DAL.Data
{
    public class DevicePresetData
    {
        public int AlarmPresetId { get; set; }
        public TimeSpan WakingTime { get; set; }
        public string Name { get; set; }
        public string Challenge { get; set; }
        public byte ActivationFlag { get; set; }
        public string Song { get; set; }
        public int ClockId { get; set; }
    }
}

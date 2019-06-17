using System;

namespace AlarmClock.Device.WebApp.Models
{
    public class PresetViewModel
    {
        public int AlarmPresetId { get; set; }
        public TimeSpan WakingTime { get; set; }
        public string Name { get; set; }
        public string Song { get; set; }
        public byte ActivationFlag { get; set; }
        public int Challenge { get; set; }
        public int ClockId { get; set; }
    }
}

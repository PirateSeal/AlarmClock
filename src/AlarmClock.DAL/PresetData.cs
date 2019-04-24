using System;

namespace AlarmClock.DAL
{
    internal class PresetData
    {
        public int AlarmPresetId { get; set; }
        public TimeSpan WakingTime { get; set; }
        public string Song { get; set; }
        public byte ActivationFlag { get; set; }
        public int Challenge { get; set; }
        public int ClockId { get; set; }
    }
}

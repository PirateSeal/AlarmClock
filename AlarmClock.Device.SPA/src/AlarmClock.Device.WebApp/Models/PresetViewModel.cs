using System;

namespace AlarmClock.Device.WebApp.Models
{
    public class PresetViewModel
    {
        public int AlarmPresetId { get; set; }
        public TimeSpan WakingTime { get; set; }
        public string Name { get; set; }
        public string Song { get; set; }
        public string SongPath { get; set; }
        public byte ActivationFlag { get; set; }
        public string Challenge { get; set; }
        public string ChallengePath { get; set; }
        public int ClockId { get; set; }
    }
}

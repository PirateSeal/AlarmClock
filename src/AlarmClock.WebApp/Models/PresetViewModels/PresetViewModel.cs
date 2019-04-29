using System;

namespace Alarmclock.WebApp.Models.PresetViewModels
{
    public class PresetViewModel
    {
        public int AlarmPresetId { get; set; }
        public TimeSpan WakingTime { get; set; }
        public string Name { get; set; }
        public int Challenge { get; set; }
        public byte ActivationFlag { get; set; }
        public string Song { get; set; }
        public int ClockId { get; set; }
    }
}
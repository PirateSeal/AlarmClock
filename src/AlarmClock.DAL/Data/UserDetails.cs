using System;
using System.Collections.Generic;

namespace AlarmClock.DAL.Data
{
    public class UserDetails
    {
        public int UserId { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public IEnumerable<Clock> Clocks { get; set; }
    }

    public class Clock
    {
        public int ClockId { get; set; }
        public string ClockName { get; set; }
        public Guid ClockGuid { get; set; }
        public DateTime LastSeenDate { get; set; }
        public IEnumerable<Preset> Presets { get; set; }
    }

    public class Preset
    {   
        public int PresetId { get; set; }
        public string PresetName { get; set; }
        public TimeSpan WakingTime { get; set; }
        public byte ActivationFlag { get; set; }
        public string Challenge { get; set; }
        public string ChallengePath { get; set; }
        public string Song { get; set; }
        public string SongPath { get; set; }
        public int PresetClockId { get; set; }
    }
}

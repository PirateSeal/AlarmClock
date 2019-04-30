using System;

namespace AlarmClock.DAL
{
    class UserFlatDetails
    {
        public int UserId { get; set; }
        public string Pseudo { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public int ClockId { get; set; }
        public string ClockName { get; set; }
        public Guid ClockGuid { get; set; }
        public DateTime LastSeenDate { get; set; }

        public int PresetId { get; set; }
        public string PresetName { get; set; }
        public TimeSpan WakingTime { get; set; }
        public byte ActivationFlag { get; set; }
        public int Challenge { get; set; }
        public string Song { get; set; }
        public int PresetClockId { get; set; }
    }
}

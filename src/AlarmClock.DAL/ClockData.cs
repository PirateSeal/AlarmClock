using System;

namespace AlarmClock.DAL
{
    public class ClockData
    {
        public int ClockId { get; set; }
        public string Name { get; set; }
        public Guid Guid { get; set; }
        public int UserId { get; set; }
    }
}

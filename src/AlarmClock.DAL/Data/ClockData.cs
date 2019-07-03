using System;

namespace AlarmClock.DAL.Data
{
    public class ClockData
    {
        public int ClockId { get; set; }
        public string Name { get; set; }
        public Guid Guid { get; set; }
        public int UserId { get; set; }
    }
}

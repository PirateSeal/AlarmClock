using System;

namespace AlarmClock.DAL
{
    public class ClockData
    {
        public int ClockId { get; set; }
        public string Name { get; set; }
        public Guid Guid { get; set; }
        public int UserId { get; set; }
        public string Pseudo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

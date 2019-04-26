using System;

namespace Alarmclock.WebApp.Models.ClockViewModels
{
    public class ClockViewModel
    {
        public int ClockId { get; set; }
        public string Name { get; set; }
        public Guid Guid { get; set; }
        public int UserId { get; set; }
    }
}

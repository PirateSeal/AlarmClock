using System;
using System.Collections.Generic;
using System.Text;

namespace Alarmclock.WebApp.Models.ClockViewModels
{
    class UnclaimedClockData
    {
        public string Guid { get; set; }
        public int Password { get; set; }
        public string Username { get; set; }
    }
}
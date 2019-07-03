using System;
using System.Collections.Generic;
using Alarmclock.WebApp.Models.PresetViewModels;

namespace Alarmclock.WebApp.Models.ClockViewModels
{
    public class DeviceDataViewModel
    {
        public Acl Acl { get; set; }
        public List<PresetViewModel> Presets { get; set; }
    }

    public class Acl
    {
        public Acl(Guid guid, int pw, string name)
        {
            Guid = guid;
            Password = pw;
            Name = name;
        }

        public Guid Guid { get; }
        public int Password { get; }
        public string Name { get; set; }
    }
}

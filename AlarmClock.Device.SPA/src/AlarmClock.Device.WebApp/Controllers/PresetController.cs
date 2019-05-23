using System.Collections.Generic;
using System.Threading.Tasks;
using AlarmClock.Device.DAL.Data;
using AlarmClock.Device.DAL.Gateways;
using Microsoft.AspNetCore.Mvc;

namespace AlarmClock.Device.WebApp.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class PresetController : Controller
    {
        public PresetController( PresetGateway gateway )
        {
            Gateway = gateway;
        }

        private PresetGateway Gateway { get; }

        [HttpGet]
        public Task<IEnumerable<PresetData>> ShowPresets()
        {
            return Gateway.GetAllPresets();
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using AlarmClock.Device.DAL;
using AlarmClock.Device.DAL.Data;
using AlarmClock.Device.DAL.Gateways;
using Microsoft.AspNetCore.Mvc;

namespace AlarmClock.Device.WebApp.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class PresetController : Controller
    {
        public PresetController( PresetGateway gateway ) => Gateway = gateway;

        private PresetGateway Gateway { get; }

        [HttpGet]
        public async Task<Result<List<PresetData>>> ShowPresets() => await Gateway.GetAllPresetsAsync();

        [HttpGet]
        public async Task<Result<PresetData>> FindPresetById( int id ) => await Gateway.GetPresetByIdAsync( id );
    }
}

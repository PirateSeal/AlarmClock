using System.Collections.Generic;
using System.Threading.Tasks;
using AlarmClock.Device.DAL;
using AlarmClock.Device.DAL.Data;
using AlarmClock.Device.DAL.Gateways;
using AlarmClock.Device.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace AlarmClock.Device.WebApp.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class PresetController : Controller
    {
        public PresetController( PresetGateway presetGateway )
        {
            PresetGateway = presetGateway;
        }

        private PresetGateway PresetGateway { get; }

        [HttpGet]
        public async Task<List<PresetData>> ShowPresets()
        {
            var presets = await PresetGateway.GetAllPresetsAsync();
            return presets.Content;
        }

        [HttpPost]
        public async Task<Result<PresetData>> CreatePreset( [FromBody] PresetViewModel presetData )
        {
            return await PresetGateway.CreatePreset(
                presetData.ActivationFlag,
                presetData.Name,
                presetData.AlarmPresetId,
                presetData.Challenge,
                presetData.ChallengePath,
                presetData.Song,
                presetData.SongPath,
                presetData.WakingTime );
        }
    }
}

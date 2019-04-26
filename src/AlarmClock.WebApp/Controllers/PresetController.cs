using System.Threading.Tasks;
using Alarmclock.WebApp.Models.PresetViewModels;
using AlarmClock.WebApp.Authentication;
using Microsoft.AspNetCore.Authorization;
using AlarmClock.DAL;
using AlarmClock.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Alarmclock.WebApp.Controllers
{
    [Route( "api/[controller]" )]
    [Authorize( AuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme )]
    public class PresetController : Controller
    {
        public PresetGateway Gateway { get; }

        public PresetController( PresetGateway gateway )
        {
            Gateway = gateway;
        }

        [HttpGet]
        public async Task<IActionResult> ShowPresets( [FromBody] PresetViewModel model )
        {
            return Ok( await Gateway.GetAllPresetFromClockId( model.ClockId ) );
        }

        [HttpGet( "{id}", Name = "GetPreset" )]
        public async Task<IActionResult> GetPresetById( int id )
        {
            return this.CreateResult( await Gateway.FindPresetById( id ) );
        }

        [HttpPost]
        public async Task<IActionResult> CreatePreset( [FromBody] PresetViewModel model )
        {
            var result = await Gateway.CreatePreset( model.WakingTime, model.Song, model.ActivationFlag,
                model.Challenge, model.ClockId );
            return this.CreateResult( result, options =>
            {
                options.RouteName = "GetPreset";
                options.RouteValues = id => new {id};
            } );
        }

        [HttpPut( "{id}" )]
        public async Task<IActionResult> UpdatePreset( int id, [FromBody] PresetViewModel model )
        {
            return this.CreateResult( await Gateway.UpdatePreset( model.AlarmPresetId, model.WakingTime, model.Song,
                model.ActivationFlag, model.Challenge ) );
        }

        [HttpDelete( "{id}" )]
        public async Task<IActionResult> DeletePreset( int id )
        {
            return this.CreateResult( await Gateway.DeletePreset( id ) );
        }

    }
}

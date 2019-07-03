using System.Threading.Tasks;
using AlarmClock.DAL;
using AlarmClock.WebApp.Controllers;
using Alarmclock.WebApp.Models.ClockViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Alarmclock.WebApp.Controllers
{
    [Route( "api/[controller]" )]
    public class UpdateController : Controller
    {
        public UpdateController( UpdateGateway gateway )
        {
            Gateway = gateway;
        }

        private UpdateGateway Gateway { get; }

        [HttpGet]
        public async Task<IActionResult> UpdateClock( [FromBody] DeviceDataViewModel model )
        {
            return Ok( await Gateway.UpdateClock( model.Acl.Guid ) );
        }
    }
}

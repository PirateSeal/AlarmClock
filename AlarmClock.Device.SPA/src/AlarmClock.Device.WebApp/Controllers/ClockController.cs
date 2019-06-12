using System.Threading.Tasks;
using AlarmClock.Device.DAL.Data;
using AlarmClock.Device.DAL.Gateways;
using Microsoft.AspNetCore.Mvc;

namespace AlarmClock.Device.WebApp.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class ClockController : ControllerBase
    {
        public ClockController( ClockGateway clockGateway )
        {
            ClockGateway = clockGateway;
        }

        private ClockGateway ClockGateway { get; }

        [HttpGet]
        public async Task<ClockData> GetClockInfo()
        {
            var clock = await ClockGateway.GetClockData();
            return clock.Content;
        }

        [HttpGet( "{name}", Name = "CreateClock" )]
        public async Task<ClockData> CreateClock( string name )
        {
            var clock = await ClockGateway.CreateOrUpdateClockData( name );
            return clock.Content;
        }
    }
}

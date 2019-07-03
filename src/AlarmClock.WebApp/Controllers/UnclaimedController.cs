using System.Threading.Tasks;
using Alarmclock.WebApp.Models.ClockViewModels;
using AlarmClock.DAL;
using AlarmClock.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Alarmclock.WebApp.Controllers
{
    [Route( "api/[controller]" )]

    public class UnclaimedController : Controller
    {
        public UnclaimedController( VernemqGateway vernemqGateway, ClockGateway clockGateway )
        {
            VerneGateway = vernemqGateway;
            ClockGateway = clockGateway;
        }

        private VernemqGateway VerneGateway { get; }
        private ClockGateway ClockGateway { get; }


        [HttpPost]
        public async Task<IActionResult> CreateAcl( [FromBody] AclViewModel model )
        {
            var result = await ClockGateway.CreateUnclaimedClockAclAsync(model.Guid);

            return this.CreateResult(
                 result, options =>
                 {
                     options.RouteName = "GetClock";
                     options.RouteValues = id => new { id };
                 }
             );
            
        }
    }
}

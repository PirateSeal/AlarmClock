using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Alarmclock.WebApp.Models.ClockViewModels;
using AlarmClock.DAL;
using AlarmClock.WebApp.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alarmclock.WebApp.Controllers
{
    [Route( "api/[controller]" )]

    public class UnclaimedController : Controller
    {
        public UnclaimedController( VernemqGateway vernemqGateway )
        {
            Gateway = vernemqGateway;
        }

        private VernemqGateway Gateway { get; }

        [HttpPost]
        public async Task<IActionResult> CreateAcl( [FromBody] UnclaimedViewModel model )
        {
            model.UserId = int.Parse( User.Claims.ElementAt( 0 ).Value );
            var result = await Gateway.CreateClockAsync( model.Name, model.UserId );
            return this.CreateResult( result, options =>
            {
                options.RouteName = "GetClock";
                options.RouteValues = id => new { id };
            } );
        }
    }
    }

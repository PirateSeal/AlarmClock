using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Alarmclock.WebApp.Models.ClockViewModels;
using AlarmClock.DAL;
using AlarmClock.WebApp.Authentication;
using AlarmClock.WebApp.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime;

namespace Alarmclock.WebApp.Controllers
{
    [Route( "api/[controller]" )]

    public class UnclaimedController : Controller
    {
        public UnclaimedController( VernemqGateway vernemqGateway , ClockGateway clockGateway )
        {
            _verneGateway = vernemqGateway;
            _clockGateway = clockGateway;
        }

        private VernemqGateway _verneGateway { get; }
        private ClockGateway _clockGateway { get; }


        [HttpPost]
        public async Task<IActionResult> CreateAcl( [FromBody] AclViewModel model )
        {
            
            var result = await _verneGateway.CreateUnclaimedClockAclAsync( model.Name, model.Guid , model.Password);
            var result2 = await _clockGateway.CreateUnclaimedClockAclAsync( model.Name, model.Guid);
            var results = (result, result2);


            return this.CreateResult( result, options =>
            {
                options.RouteName = "GetClock";
                options.RouteValues = id => new { id };
            } );





        }
    }
    }

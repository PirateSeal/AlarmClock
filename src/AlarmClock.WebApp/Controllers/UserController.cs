using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AlarmClock.DAL;
using AlarmClock.WebApp.Authentication;
using AlarmClock.WebApp.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Alarmclock.WebApp.Controllers
{
    [Route( "api/[controller]" )]
    [Authorize( AuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme )]
    public class UserController : Controller
    {
        public UserController( UserGateway gateway )
        {
            Gateway = gateway;
        }
        private UserGateway Gateway { get; }

        [HttpGet]
        public async Task<IActionResult> GetUserInfo()
        {
            int id = int.Parse( User.Claims.ElementAt<Claim>( 0 ).Value );

            var r = await Gateway.GetUserDetails( id );
            return r.Status == Status.NotFound
                ? this.CreateResult( await Gateway.FindByIdAsync( id ) )
                : this.CreateResult( r );
        }

        [HttpGet( "{id}" )]
        public async Task<IActionResult> GetUserById( int id )
        {
            return this.CreateResult( await Gateway.FindByIdAsync( id ) );
        }
    }
}

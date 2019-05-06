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

        [HttpGet( "GetUserInfo/{id}" )]
        public async Task<IActionResult> GetUserInfo( int id )
        {
            return this.CreateResult(await Gateway.GetUserDetails( id ));
        }

        [HttpGet( "{id}" )]
        public async Task<IActionResult> GetUserById( int id )
        {
            return this.CreateResult( await Gateway.FindByIdAsync( id ) );
        }
    }
}

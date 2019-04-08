using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Alarmclock.WebApp.Authentication;
using Alarmclock.WebApp.Services;
using AlarmClock.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Alarmclock.WebApp.Controllers
{
    [Route( "/api/[controller]" )]
    public class TokenController : Controller
    {
        private readonly TokenService _tokenService;
        private readonly UserGateway _userGateway;

        public TokenController( UserGateway userGateway, TokenService tokenService )
        {
            _userGateway = userGateway;
            _tokenService = tokenService;
        }

        [HttpGet]
        public async Task<IActionResult> Token()
        {
            ClaimsIdentity identity =
                User.Identities.SingleOrDefault(
                    i => i.AuthenticationType == CookieAuthentication.AuthenticationScheme );
            if( identity == null ) return Ok( new {Success = false} );

            string userId = identity.FindFirst( ClaimTypes.NameIdentifier ).Value;
            string email = identity.FindFirst( ClaimTypes.Email ).Value;
            Token token = _tokenService.GenerateToken( userId, email );
            var providers = await _userGateway.GetAuthenticationProviders( userId );
            return Ok( new {Success = true, Bearer = token, Email = email, BoundProviders = providers} );
        }
    }
}

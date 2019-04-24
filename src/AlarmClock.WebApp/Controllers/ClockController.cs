using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AlarmClock.WebApp.Authentication;
using AlarmClock.WebApp.Models.AccountViewModels;
using AlarmClock.WebApp.Services;
using AlarmClock.DAL;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;


namespace AlarmClock.WebApp.Controllers
{
    public class ClockController : Controller
    {
        private readonly IAuthenticationSchemeProvider _authenticationSchemeProvider;
        private readonly Random _random;
        private readonly IOptions<SpaOptions> _spaOptions;
        private readonly TokenService _tokenService;
        private readonly UserGateway _userGateway;
        private readonly ClockGateway _clockGateway;
        private readonly UserService _userService;

        public ClockController( ClockGateway clockGateway, 
           IOptions<SpaOptions> spaOptions )
        {
            _clockGateway = clockGateway;
            _clockGateway = clockGateway;
            _spaOptions = spaOptions;
            _random = new Random();
        }


    }
}

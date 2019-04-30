using System;
using System.Threading.Tasks;
using Alarmclock.WebApp.Models.ClockViewModels;
using AlarmClock.DAL;
using AlarmClock.WebApp.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AlarmClock.WebApp.Controllers
{
  


    [Route( "api/[controller]" )]
    [Authorize( AuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme )]
    public class ClockController : Controller
    {
        public ClockController( ClockGateway clockGateway)
        {
            Gateway = clockGateway;
        }

        private Random rnd { get; }
        private ClockGateway Gateway { get; }

        [HttpGet]
        public async Task<IActionResult> ShowClocks( [FromBody] ClockViewModel model )
        {
            return Ok( await Gateway.GetAllClocksByUserId( model.UserId ) );
        }

        [HttpGet( "{id}", Name = "GetClock" )]
        public async Task<IActionResult> GetClockById( int id )
        {
            return this.CreateResult( await Gateway.FindClockById( id ) );
        }

        [HttpPost]
        public async Task<IActionResult> CreateClock( [FromBody] ClockViewModel model )
        {

            if( model.Guid == "" ) model.Guid = new Guid();
            var result = await Gateway.CreateClockAsync( model.Name, model.Guid, model.UserId );
            return this.CreateResult( result, options =>
            {
                options.RouteName = "GetClock";
                options.RouteValues = id => new {id};
            } );
        }

        [HttpPut( "{id}" )]
        public async Task<IActionResult> UpdateClock( int id, [FromBody] ClockViewModel model )
        {
            return this.CreateResult( await Gateway.UpdateClockAsync( model.Name, id ) );
        }

        [HttpDelete( "{id}" )]
        public async Task<IActionResult> DeleteClock( int id )
        {
            return this.CreateResult( await Gateway.DeleteClockAsync( id ) );
        }
    }
}
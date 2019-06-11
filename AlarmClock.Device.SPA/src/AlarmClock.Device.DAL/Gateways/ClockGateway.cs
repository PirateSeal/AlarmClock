using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlarmClock.Device.DAL.Data;
using AlarmClock.Device.DAL.Services;

namespace AlarmClock.Device.DAL.Gateways
{
    public class ClockGateway
    {
        public ClockGateway()
        {
            JsonHandler = new JsonHandler( "ClockData.json" );
        }

        private JsonHandler JsonHandler { get; }

        public async Task<Result<ClockData>> CreateOrUpdateClockData( string name )
        {
            Random random = new Random();
            ClockData clockData = new ClockData
            {
                Guid = Guid.NewGuid().ToString(),
                Name = name,
                Password = random.Next( 1000, 9999 ),
                Presets = new List<PresetData>()
            };
            await JsonHandler.UpdateJson( clockData );
            return Result.Success( Status.Created, clockData );
        }

        public async Task<Result<ClockData>> GetClockData()
        {
            return await JsonHandler.OpenJsonAsync();
        }
    }
}

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
            JsonHandler = new JsonHandler( "DeviceClockData.json" );
        }

        public JsonHandler JsonHandler { get; }

        public async Task<Result<DeviceClockData>> CreateOrUpdateClockData( string name )
        {
            Random random = new Random();
            DeviceClockData deviceClockData = new DeviceClockData
            {
                Acl = new Acl(Guid.NewGuid().ToString(),random.Next( 1000, 9999 ), name),
                Presets = new List<DevicePresetData>()
            };
            await JsonHandler.UpdateJson( deviceClockData );
            return Result.Success( Status.Created, deviceClockData );
        }

        public async Task<Result<DeviceClockData>> GetClockData()
        {
            return await JsonHandler.OpenJsonAsync();
        }
    }
}

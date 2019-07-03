using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AlarmClock.Device.DAL.Data;
using AlarmClock.Device.DAL.Services;

namespace AlarmClock.Device.DAL.Gateways
{
    //do we need gateways ?
    //mqtt direct update json
    //front direct read json
    //not using http rqst
    public class PresetGateway
    {
        public PresetGateway()
        {
            JsonHandler = new JsonHandler( "DeviceClockData.json" );
        }

        private JsonHandler JsonHandler { get; }

        public async Task UpdateClockInfo( DeviceClockData data )
        {
            await JsonHandler.UpdateJson( data );
        }

        public async Task<Result<List<DevicePresetData>>> GetAllPresetsAsync()
        {
            var result = await JsonHandler.OpenJsonAsync();
            DeviceClockData data = result.Content;
            return Result.Success( data.Presets );
        }

        public async Task<Result<DevicePresetData>> GetPresetByIdAsync( int id )
        {
            var result = await JsonHandler.OpenJsonAsync();
            DeviceClockData data = result.Content;

            try
            {
                var r = Result.Success( Status.Ok, data.Presets.First( preset => preset.AlarmPresetId == id ) );
                return r;
            }
            catch( Exception )
            {
                return Result.Failure<DevicePresetData>( Status.NotFound, "Preset not found" );
            }
        }

        public async Task<Result<DevicePresetData>> CreatePreset( byte activationFlag, string name, int presetId,
            string challenge, string challengePath, string song, string songPath, TimeSpan wakingTime )
        {
            DevicePresetData devicePreset = new DevicePresetData
            {
                ActivationFlag = activationFlag,
                Name = name,
                AlarmPresetId = presetId,
                Challenge = challenge,
                WakingTime = wakingTime,
                Song = song,
            };

            var result = await JsonHandler.OpenJsonAsync();
            DeviceClockData data = result.Content;

            if( data.Presets.Any( dataPreset => dataPreset.AlarmPresetId == devicePreset.AlarmPresetId ) )
                return Result.Failure<DevicePresetData>( Status.BadRequest, "Preset already exists" );

            data.Presets.Add( devicePreset );
            await JsonHandler.UpdateJson( data );

            return Result.Success( Status.Created, devicePreset );
        }

        public async Task<Result<DevicePresetData>> UpdatePreset( int id, TimeSpan wakingTime, string name, string song,
            byte activationFlag, string challenge )
        {
            var result = await JsonHandler.OpenJsonAsync();
            DeviceClockData deviceClockData = result.Content;

            if( deviceClockData.Presets.All( dataPreset => dataPreset.AlarmPresetId != id ) )
                return Result.Failure<DevicePresetData>( Status.NotFound, "Preset not found" );

            DevicePresetData targetDevicePreset = deviceClockData.Presets.First( dataPreset => dataPreset.AlarmPresetId == id );

            targetDevicePreset.Name = name;
            targetDevicePreset.ActivationFlag = activationFlag;
            targetDevicePreset.Challenge = challenge;
            targetDevicePreset.Song = song;
            targetDevicePreset.WakingTime = wakingTime;

            await JsonHandler.UpdateJson( deviceClockData );

            return Result.Success( Status.Ok, targetDevicePreset );
        }

        public async Task<Result> DeletePresetById( int id )
        {
            var result = await JsonHandler.OpenJsonAsync();

            result.Content.Presets.RemoveAll( preset => preset.AlarmPresetId == id );

            await JsonHandler.UpdateJson( result.Content );

            return Result.Success( Status.Ok );
        }
    }
}

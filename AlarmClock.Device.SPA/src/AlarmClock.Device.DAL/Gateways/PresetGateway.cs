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
            JsonHandler = new JsonHandler( "ClockData.json" );
        }

        private JsonHandler JsonHandler { get; }

        private async Task UpdateClockInfo( ClockData data )
        {
            await JsonHandler.UpdateJson( data );
        }

        public async Task<IEnumerable<PresetData>> GetAllPresetsAsync()
        {
            var result = await JsonHandler.OpenJsonAsync();
            ClockData data = result.Content;
            return data.Presets.ToList();
        }

        public async Task<Result<PresetData>> GetPresetByIdAsync( int id )
        {
            var result = await JsonHandler.OpenJsonAsync();
            ClockData data = result.Content;

            try
            {
                var r = Result.Success( Status.Ok, data.Presets.First( preset => preset.AlarmPresetId == id ) );
                return r;
            }
            catch( Exception)
            {
                return Result.Failure<PresetData>( Status.NotFound, "Preset not found" );
            }
        }

        public async Task<Result<PresetData>> CreatePreset( PresetData preset )
        {
            var result = await JsonHandler.OpenJsonAsync();
            ClockData data = result.Content;

            if( data.Presets.Any( dataPreset => dataPreset.AlarmPresetId == preset.AlarmPresetId ) )
                return Result.Failure<PresetData>( Status.BadRequest, "Preset already exists" );

            data.Presets.Add( preset );
            await JsonHandler.UpdateJson( data );

            return Result.Success( Status.Created, preset );
        }

        public async Task<Result<PresetData>> UpdatePreset( int id, TimeSpan wakingTime, string name, string song,
            byte activationFlag, int challenge )
        {
            var result = await JsonHandler.OpenJsonAsync();
            ClockData clockData = result.Content;

            if( clockData.Presets.All( dataPreset => dataPreset.AlarmPresetId != id ) )
                return Result.Failure<PresetData>( Status.NotFound, "Preset not found" );

            PresetData targetPreset = clockData.Presets.First( dataPreset => dataPreset.AlarmPresetId == id );

            targetPreset.Name = name;
            targetPreset.ActivationFlag = activationFlag;
            targetPreset.Challenge = challenge;
            targetPreset.Song = song;
            targetPreset.WakingTime = wakingTime;

            await JsonHandler.UpdateJson( clockData );

            return Result.Success( Status.Ok, targetPreset );
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

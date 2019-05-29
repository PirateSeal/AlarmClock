using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AlarmClock.Device.DAL.Data;
using Newtonsoft.Json;

namespace AlarmClock.Device.DAL.Gateways
{
    //do we need gateways ?
    //mqtt direct update json
    //front direct read json
    //not using http rqst
    public class PresetGateway
    {
        public PresetGateway() => JsonPath = "ClockInfo.json";

        private string JsonPath { get; }

        private dynamic OpenJson() => JsonConvert.DeserializeObject(
            File.ReadAllText( JsonPath ) );

        private void CloseJson( dynamic jsonObj ) =>
            File.WriteAllText( JsonPath,
                JsonConvert.SerializeObject( jsonObj, Formatting.Indented ) );

        public Task<IEnumerable<PresetData>> GetAllPresets()
        {
            dynamic jsonObj = OpenJson();
            return jsonObj["Presets"];
        }

        public Result<PresetData> GetPresetById( int id )
        {
            dynamic jsonObj = OpenJson();
            IEnumerable<PresetData> presetList = jsonObj["Presets"];
            PresetData data = presetList.First( preset => preset.AlarmPresetId == id );
            return Result.Success( data );
        }
    }
}

using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AlarmClock.Device.DAL.Data;
using Newtonsoft.Json;

namespace AlarmClock.Device.DAL.Services
{
    public class JsonHandler
    {
        public JsonHandler( string jsonPath )
        {
            JsonPath = jsonPath;
        }

        private string JsonPath { get; }

        public async Task<Result<ClockData>> OpenJsonAsync()
        {
            if( File.Exists( JsonPath ) )
                try
                {
                    string data = await ReadTextAsync( JsonPath );
                    ClockData clockData = JsonConvert.DeserializeObject<ClockData>( data );
                    return Result.Success( clockData );
                }
                catch( Exception exception )
                {
                    Console.WriteLine( exception );
                }

            return Result.Failure<ClockData>( Status.NotFound, "File not found" );
        }

        public async Task<Result> UpdateJson( ClockData clockData )
        {
            if( !File.Exists( JsonPath ) ) await WriteTextAsync( JsonPath, "" );

            string json;
            ClockData dataJson = OpenJsonAsync().Result.Content;
            switch( dataJson )
            {
                case null:
                    json = JsonConvert.SerializeObject( clockData );
                    break;
                default:
                    dataJson.Name = clockData.Name;
                    dataJson.Presets = clockData.Presets;
                    json = JsonConvert.SerializeObject( dataJson );
                    break;
            }

            await WriteTextAsync( JsonPath, json );

            return Result.Success();
        }

        private async Task<string> ReadTextAsync( string filePath )
        {
            using( FileStream source = File.OpenRead( filePath ) )
            using( TextReader tr = new StreamReader( source, Encoding.UTF8, true ) )
            {
                return await tr.ReadToEndAsync();
            }
        }

        private async Task WriteTextAsync( string filePath, string text )
        {
            using( FileStream source = File.Open( filePath, FileMode.Create, FileAccess.Write ) )
            using( TextWriter streamWriter = new StreamWriter( source, Encoding.UTF8 ) )
            {
                await streamWriter.WriteAsync( text );
            }
        }
    }
}

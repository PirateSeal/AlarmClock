using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AlarmClock.Device.DAL.Data;
using AlarmClock.Device.DAL.Gateways;
using AlarmClock.Device.DAL.Services;
using AlarmClock.Device.DAL;

namespace AlarmClock.Device.WebApp.Services
{

    internal class InitializeClock
    {
        private HttpClient _client;
        private JsonHandler _handler;
        private ClockGateway _clockGateway;

        public InitializeClock()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri( "http://localhost:5000/api/unclaimed" )
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue( "application/json" ) );
            _handler = new JsonHandler( "ClockData.json" );
            _clockGateway = new ClockGateway();
        }

        internal async Task CreateIfNotExist()
        {
            if( _handler.OpenJsonAsync().Result.Status == Status.NotFound )
            {
                await CreateData();
            }
        }

        private string RandomName()
        {
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[10];
            var random = new Random();

            for( int i = 0; i < stringChars.Length; i++ )
            {
                stringChars[i] = chars[random.Next( chars.Length )];
            }

            return  new String( stringChars );
        }

        private async Task CreateData()
        {
            try
            {
                var clockdata = await _clockGateway.CreateOrUpdateClockData(RandomName());
                var url = await CreateAclAsync( clockdata.Content.Acl );
                Console.WriteLine( $"Created at {url}" );
            }
            catch( Exception e )
            {
                Console.WriteLine( e.Message );
            }
        }

        private async Task<Uri> CreateAclAsync( Acl acl )
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync(
                _client.BaseAddress, acl );
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }
    }
}

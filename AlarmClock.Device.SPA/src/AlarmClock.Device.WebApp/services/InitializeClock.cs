using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AlarmClock.Device.DAL.Data;
using AlarmClock.Device.DAL.Gateways;
using AlarmClock.Device.DAL.Services;
using System.IO;
using AlarmClock.Device.DAL;

namespace AlarmClock.Device.WebApp.Services
{

    internal class InitializeClock
    {
        private HttpClient _client;
        public JsonHandler _handler;
        public ClockGateway _clockGateway;


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

        private async Task CreateData()
        {

            try
            {
                Result<ClockData> clockdata = await _clockGateway.CreateClockData( "test" );
                Task<Uri> url =  CreateAclAsync( clockdata );
                Console.WriteLine( $"Created at {url}" );


            }
            catch( Exception e )
            {
                Console.WriteLine( e.Message );
            }
        }

        private async Task<Uri> CreateAclAsync( Result<ClockData> Clock )
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync(
                "api/products", Clock );
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }


    }

    /*

    class Program
    {
        static HttpClient _client = new HttpClient();
        static JsonHandler _JsonHandler = new JsonHandler( "ClockData.json" );

        static async Task<Uri> CreateAclAsync( ClockData Clock )
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync(
                "api/products", Clock );
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }


        static void Main()
        {
            if(_JsonHandler.OpenJsonAsync().Result.Status == Status.NotFound)
            {
                RunAsync().GetAwaiter().GetResult();
            }
        }

        static async Task RunAsync()
        {
            // Update port # in the following line.
            _client.BaseAddress = new Uri( "http://localhost:5000/unclaimed" );
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue( "application/json" ) );

            try
            {
              //  ClockData clockdata = 

                var url = await CreateAclAsync( clockdata );
                Console.WriteLine( $"Created at {url}" );

            }
            catch( Exception e )
            {
                Console.WriteLine( e.Message );
            }

            Console.ReadLine();
        }


    }
    */
}

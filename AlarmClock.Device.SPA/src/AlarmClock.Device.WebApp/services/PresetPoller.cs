using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using AlarmClock.Device.DAL.Gateways;
using AlarmClock.Device.DAL.Services;

namespace AlarmClock.Device.WebApp.services
{
    class PresetPoller
    {
        public HttpClient Client { get; }
        public JsonHandler Handler { get; }
        public ClockGateway Gateway { get; }

        public PresetPoller()
        {
            Client = new HttpClient
            {
                BaseAddress = new Uri( "http://localhost:5000/api/Update" )
            };
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue( "application/json" ) );
            Gateway = new ClockGateway();
            Handler = Gateway.JsonHandler;
        }

        private async Task SendRequest( string data , CancellationToken token)
        {

            HttpResponseMessage response = await Client.GetAsync( Client.BaseAddress, token );
            response.EnsureSuccessStatusCode();
        }

        public void Poll()
        {
            const int delay = 10000; //Milliseconds

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken token = cancellationTokenSource.Token;

            Task.Factory.StartNew( async () =>
            {
                try
                {
                    while( true )
                    {
                        string toJson = await Gateway.JsonHandler.ReadTextAsync("DeviceClockData.json");
                        await SendRequest( toJson, token );
                        Console.WriteLine( "============Poll============" );
                        Console.WriteLine( toJson );
                        Console.WriteLine( "============End Poll============" );
                        Thread.Sleep( delay );
                        if( token.IsCancellationRequested )
                            break;
                    }
                }
                catch( Exception e )
                {
                    Console.WriteLine( e );
                    throw;
                }

                // cleanup, e.g. close connection
            }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default );


        }

    }
}

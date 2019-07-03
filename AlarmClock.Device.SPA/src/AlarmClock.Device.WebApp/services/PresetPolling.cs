using AlarmClock.Device.DAL.Gateways;
using AlarmClock.Device.DAL.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace AlarmClock.Device.WebApp.services
{
    public class PresetPolling
    {
        private HttpClient _client;
        private JsonHandler _handler;
        private ClockGateway _clockGateway;

        public PresetPolling()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri( "http://localhost:5000/api/poll" )
            };
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue( "application/json" ) );
            _handler = new JsonHandler( "ClockData.json" );
            _clockGateway = new ClockGateway();

            Poll();
        }

        private async Task<Uri> sendRequest( string data )
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync(
                _client.BaseAddress, data );
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }

        private async void Poll()
        {
            int delay = 1;
            var cancellationTokenSource = new CancellationTokenSource();
            var token = cancellationTokenSource.Token;
            var listener = Task.Factory.StartNew( () =>
            {
                while( true )
                {
                    var PresetData = await _handler.OpenJsonAsync();
                    sendRequest( PresetData );
                    Thread.Sleep( delay );
                    if( token.IsCancellationRequested )
                        break;
                }

                // cleanup, e.g. close connection
            }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default );


        }


    }
}

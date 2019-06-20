using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using System;
using System.Text;
using System.Threading.Tasks;

//client
namespace AlarmClock.MQTT
{


    public class Sample
    {

        public static async Task MqttClientBuilder()
        {
            var factory = new MqttFactory();

            var mqttClient = factory.CreateMqttClient();

            var options = new MqttClientOptionsBuilder()
                .WithTcpServer( "localhost", 1883 ) // Port is optional
                .WithClientId( "ConfigurationServerId" )
                .WithCredentials( "configurationServer", "vernemq" )
                .Build();


            await mqttClient.ConnectAsync( options );
            var t = DateTime.Now;

            await mqttClient.SubscribeAsync( "clock/#" );

            mqttClient.ApplicationMessageReceivedHandler = new MqttApplicationMessageReceivedHandler();

            for( int i = 0; i < 100; i++ )
            {
                DateTime t1 = DateTime.Now;
                var message = new MqttApplicationMessageBuilder()
                    .WithTopic( "toto" )
                    .WithPayload( t.ToString() + " " + t1.ToString() )
                    .WithExactlyOnceQoS()
                    .WithRetainFlag()
                    .Build();

                await mqttClient.PublishAsync( message );

                await Task.Delay( 1000 );
            }


            Console.WriteLine( "Press any key to exit." );
            Console.ReadLine();

            
        }
    }

    public class MqttApplicationMessageReceivedHandler : IMqttApplicationMessageReceivedHandler
    {
        public Task HandleApplicationMessageReceivedAsync( MqttApplicationMessageReceivedEventArgs eventArgs )
        {
            Console.WriteLine( "### RECEIVED APPLICATION MESSAGE ###" );
            Console.WriteLine( $"+ Topic = {eventArgs.ApplicationMessage.Topic}" );
            Console.WriteLine( $"+ Payload = {Encoding.UTF8.GetString( eventArgs.ApplicationMessage.Payload )}" );
            Console.WriteLine( $"+ QoS = {eventArgs.ApplicationMessage.QualityOfServiceLevel}" );
            Console.WriteLine( $"+ Retain = {eventArgs.ApplicationMessage.Retain}" );
            Console.WriteLine();

            return Task.CompletedTask;

            
        }
    }
}


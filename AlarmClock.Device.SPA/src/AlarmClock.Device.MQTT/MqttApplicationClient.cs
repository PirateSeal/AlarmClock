using System;
using System.Text;
using System.Threading.Tasks;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;
using MQTTnet.Client.Receiving;
using SimpleMsgPack;

namespace AlarmClock.Device.MQTT
{
    public class MqttApplicationClient
    {
        /// <summary>
        ///     Mqtt client configuration
        /// </summary>
        public MqttApplicationClient()
        {
            Factory = new MqttFactory();
            Client = Factory.CreateMqttClient();
            Options = new MqttClientOptionsBuilder()
                .WithTcpServer( "localhost", 1883 )
                .Build();
        }

        private MqttFactory Factory { get; }
        private IMqttClient Client { get; }
        private IMqttClientOptions Options { get; }
        private string ClientTopic { get; set; }

        private async Task EnsureIsConnected()
        {
            if( !Client.IsConnected ) await Client.ConnectAsync( Options );
        }

        private MsgPack InitMsgPack()
        {
            MsgPack msgPack = new MsgPack();


            return msgPack;
        }

        public async Task Init()
        {
            await EnsureIsConnected();
            MqttApplicationMessage message = new MqttApplicationMessageBuilder()
                .WithTopic( ClientTopic )
                .WithPayload( "Message" )
                .WithExactlyOnceQoS()
                .WithRetainFlag()
                .Build();

            await Client.PublishAsync( message );
        }

        /// <summary>
        ///     Check for any message incoming in the subscribed topic
        /// </summary>
        public class MessageReceivedHandler : IMqttApplicationMessageReceivedHandler
        {
            public Task HandleApplicationMessageReceivedAsync( MqttApplicationMessageReceivedEventArgs eventArgs )
            {
                Console.WriteLine();
                Console.WriteLine( "### RECEIVED APPLICATION MESSAGE ###" );
                Console.WriteLine( $"+ Topic = {eventArgs.ApplicationMessage.Topic}" );
                Console.WriteLine( $"+ Payload = {Encoding.UTF8.GetString( eventArgs.ApplicationMessage.Payload )}" );
                Console.WriteLine( $"+ QoS = {eventArgs.ApplicationMessage.QualityOfServiceLevel}" );
                Console.WriteLine( $"+ Retain = {eventArgs.ApplicationMessage.Retain}" );
                Console.WriteLine( "### END OF MESSAGE ###" );
                Console.WriteLine();

                return Task.CompletedTask;
            }
        }
    }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using AlarmClock.Device.DAL.Data;
using AlarmClock.Device.DAL.Gateways;
using NUnit.Framework;

namespace AlarmClock.Device.DAL.Tests
{
    internal class ClockGatewayTests
    {
        public ClockGatewayTests()
        {
            Gateway = new ClockGateway();
        }

        private ClockGateway Gateway { get; }

        public void CheckClockData( Result<DeviceClockData> clockData, string name, string guid, int password,
            IEnumerable<DevicePresetData> presetList )
        {
            DeviceClockData content = clockData.Content;
            Assert.That( clockData.Status, Is.EqualTo( Status.Created ) );
            Assert.That( content.Acl.Guid, Is.EqualTo( guid ) );
            Assert.That( content.Acl.Name, Is.EqualTo( name ) );
            Assert.That( content.Acl.Password, Is.EqualTo( password ) );
            Assert.That( content.Presets, Is.EqualTo( presetList ) );
        }

        [Test]
        public async Task Create_ClockData()
        {
            var clockStatus = await Gateway.CreateOrUpdateClockData( "Test" );

            Assert.That( clockStatus.Status, Is.EqualTo( Status.Created ) );

            DeviceClockData deviceClock = clockStatus.Content;

            CheckClockData( clockStatus, "Test", deviceClock.Acl.Guid, deviceClock.Acl.Password, deviceClock.Presets );
        }
    }
}

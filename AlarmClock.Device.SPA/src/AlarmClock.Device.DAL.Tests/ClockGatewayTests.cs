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

        public void CheckClockData( Result<ClockData> clockData, string name, string guid, int password,
            IEnumerable<PresetData> presetList )
        {
            ClockData content = clockData.Content;
            Assert.That( clockData.Status, Is.EqualTo( Status.Created ) );
            Assert.That( content.Guid, Is.EqualTo( guid ) );
            Assert.That( content.Name, Is.EqualTo( name ) );
            Assert.That( content.Password, Is.EqualTo( password ) );
            Assert.That( content.Presets, Is.EqualTo( presetList ) );
        }

        [Test]
        public async Task Create_ClockData()
        {
            var clockStatus = await Gateway.CreateOrUpdateClockData( "Test" );

            Assert.That( clockStatus.Status, Is.EqualTo( Status.Created ) );

            ClockData clock = clockStatus.Content;

            CheckClockData( clockStatus, "Test", clock.Guid, clock.Password, clock.Presets );
        }
    }
}

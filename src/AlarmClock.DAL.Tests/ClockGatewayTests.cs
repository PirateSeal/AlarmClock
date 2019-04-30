using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AlarmClock.DAL.Tests
{
    [TestFixture]
    public class ClockGatewayTests
    {
        private ClockGateway Gateway { get; }

        public ClockGatewayTests()
        {
            Gateway = new ClockGateway( TestHelpers.ConnectionString );
        }

        private void CheckClock( Result<ClockData> clock, string name, Guid guid, int userId )
        {
            Assert.That( clock.Status, Is.EqualTo( Status.Ok ) );
            Assert.That( clock.Content.Name, Is.EqualTo( name ) );
            Assert.That( clock.Content.Guid, Is.EqualTo( guid ) );
            Assert.That( clock.Content.UserId, Is.EqualTo( userId ) );
        }

        [Test]
        public async Task Test_Create_Find_Update_Delete_Clock()
        {
            string name = TestHelpers.RandomTestName();
            Guid guid = Guid.NewGuid();
            int userId = 0;

            var clockStatus = await Gateway.CreateClockAsync( name, guid, userId );
            Assert.That( clockStatus.Status, Is.EqualTo( Status.Created ) );

            int clockId = clockStatus.Content;

            Result<ClockData> clock;
            {
                clock = await Gateway.FindClockById( clockId );
                CheckClock( clock, name, guid, userId );
            }

            {
                name = TestHelpers.RandomTestName();
                Result r = await Gateway.UpdateClockAsync( name, clockId );
                Assert.That( r.Status, Is.EqualTo( Status.Ok ) );

                clock = await Gateway.FindClockById( clockId );
                CheckClock( clock, name, guid, userId );
            }

            {
                Result r = await Gateway.DeleteClockAsync( clockId );
                Assert.That( r.Status, Is.EqualTo( Status.Ok ) );
                clock = await Gateway.FindClockById( clockId );
                Assert.That( clock.Status, Is.EqualTo( Status.NotFound ) );
            }
        }
    }
}
using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AlarmClock.DAL.Tests
{
    [TestFixture]
    public class PresetGatewayTests
    {
        private Random Random { get; }
        private PresetGateway Gateway { get; }

        public PresetGatewayTests()
        {
            Random = new Random();
            Gateway = new PresetGateway( TestHelpers.ConnectionString );
        }

        private void CheckPreset( Result<PresetData> preset, TimeSpan wakingTime, string song, byte activationFlag,
            int challenge, int clockId )
        {
            Assert.That( preset.Status, Is.EqualTo( Status.Ok ) );
            Assert.That( preset.Content.WakingTime, Is.EqualTo( wakingTime ) );
            Assert.That( preset.Content.Song, Is.EqualTo( song ) );
            Assert.That( preset.Content.ActivationFlag, Is.EqualTo( activationFlag ) );
            Assert.That( preset.Content.Challenge, Is.EqualTo( challenge ) );
            Assert.That( preset.Content.ClockId, Is.EqualTo( clockId ) );
        }

        [Test]
        public async Task Test_Create_Find_Update_Delete_Preset()
        {
            TimeSpan wakingTime = new TimeSpan( 15, 0, 0 );
            string name = TestHelpers.RandomTestName();
            string song = TestHelpers.RandomTestName();
            byte activationFlag = (byte) Random.Next( 255 );
            int challenge = 0;
            int clockId = 0;

            var presetStatus =
                await Gateway.CreatePreset( wakingTime, name, song, activationFlag, challenge, clockId );
            Assert.That( presetStatus.Status, Is.EqualTo( Status.Created ) );

            int presetId = presetStatus.Content;

            Result<PresetData> preset;

            {
                preset = await Gateway.FindPresetById( presetId );

                CheckPreset( preset, wakingTime, song, activationFlag, challenge, clockId );
            }

            {
                wakingTime = new TimeSpan( 9, 30, 0 );
                song = TestHelpers.RandomTestName();
                Result r = await Gateway.UpdatePreset( presetId, wakingTime, name, song, activationFlag, challenge );
                Assert.That( r.Status, Is.EqualTo( Status.Ok ) );

                preset = await Gateway.FindPresetById( presetId );
                CheckPreset( preset, wakingTime, song, activationFlag, challenge, clockId );
            }

            {
                Result r = await Gateway.DeletePreset( presetId );
                Assert.That( r.Status, Is.EqualTo( Status.Ok ) );

                preset = await Gateway.FindPresetById( presetId );
                Assert.That( preset.Status, Is.EqualTo( Status.NotFound ) );
            }
        }
    }
}

using System;
using System.Threading.Tasks;
using AlarmClock.Device.DAL.Data;
using AlarmClock.Device.DAL.Gateways;
using NUnit.Framework;

namespace AlarmClock.Device.DAL.Tests
{
    internal class PresetGatewayTests
    {
        public PresetGatewayTests()
        {
            PresetGateway = new PresetGateway();
            ClockGateway = new ClockGateway();
        }

        private PresetGateway PresetGateway { get; }
        private ClockGateway ClockGateway { get; }

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
        public async Task Create_Update_Delete_Preset()
        {
            await ClockGateway.CreateOrUpdateClockData( "Test" );
            var presetStatus =
                await PresetGateway.CreatePreset( 128, "TestPreset", 0, 0, "oui", new TimeSpan( 15, 30, 0 ) );

            Assert.That( presetStatus.Status, Is.EqualTo( Status.Created ) );

            Result<PresetData> preset;
            int presetId = presetStatus.Content.AlarmPresetId;

            {
                preset = await PresetGateway.GetPresetByIdAsync( presetId );
                CheckPreset( preset, new TimeSpan( 15, 30, 0 ), "oui", 128, 0, 0 );
            }

            {
                preset = await PresetGateway.GetPresetByIdAsync( 0 );
                TimeSpan wakingTime = new TimeSpan( 9, 30, 0 );
                string song = TestHelpers.RandomTestName();

                var r = await PresetGateway.UpdatePreset( presetId, wakingTime, "NewTest", song, 129, 1 );

                Assert.That( r.Status, Is.EqualTo( Status.Ok ) );
                CheckPreset( r, wakingTime, song, 129, 1, r.Content.ClockId );
            }

            {
                Result r = await PresetGateway.DeletePresetById( presetId );
                Assert.That( r.Status, Is.EqualTo( Status.Ok ) );

                preset = await PresetGateway.GetPresetByIdAsync( presetId );
                Assert.That( preset.Status, Is.EqualTo( Status.NotFound ) );
            }
        }
    }
}

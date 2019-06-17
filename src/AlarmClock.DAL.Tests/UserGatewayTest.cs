using System;
using System.Linq;
using System.Threading.Tasks;
using AlarmClock.WebApp;
using NUnit.Framework;

namespace AlarmClock.DAL.Tests
{
    [TestFixture]
    internal class UserGatewayTest
    {
        private PasswordHasher Hasher { get; }
        private UserGateway UserGateway { get; }
        private ClockGateway ClockGateway { get; }
        private PresetGateway PresetGateway { get; }

        public UserGatewayTest()
        {
            Hasher = new PasswordHasher();
            UserGateway = new UserGateway( TestHelpers.ConnectionString );
            ClockGateway = new ClockGateway( TestHelpers.ConnectionString );
            PresetGateway = new PresetGateway( TestHelpers.ConnectionString );
        }

        private void CheckUser( Result<UserData> user, string pseudo, string email, byte[] hashedPassword,
            string firstName, string lastName, DateTime birthDate )
        {
            Assert.That( user.Status, Is.EqualTo( Status.Ok ) );
            Assert.That( user.Content.Pseudo, Is.EqualTo( pseudo ) );
            Assert.That( user.Content.HashedPassword, Is.EqualTo( hashedPassword ) );
            Assert.That( user.Content.Email, Is.EqualTo( email ) );
            Assert.That( user.Content.FirstName, Is.EqualTo( firstName ) );
            Assert.That( user.Content.LastName, Is.EqualTo( lastName ) );
            Assert.That( user.Content.BirthDate, Is.EqualTo( birthDate ) );
        }

        [Test]
        public async Task Create_Update_Delete_User()
        {
            string pseudo = TestHelpers.RandomTestName();
            string email = TestHelpers.RandomTestName();
            var hashedPassword = Hasher.HashPassword( TestHelpers.RandomTestName() );
            string firstName = TestHelpers.RandomTestName();
            string lastName = TestHelpers.RandomTestName();
            DateTime birthDate = TestHelpers.RandomBirthDate( 20 );

            var userResult =
                await UserGateway.CreateUserAsync( pseudo, email, hashedPassword, firstName, lastName, birthDate );
            Assert.That( userResult.Status, Is.EqualTo( Status.Created ) );
            int userId = userResult.Content;

            Result<UserData> user;
            {
                user = await UserGateway.FindByIdAsync( userId );
                CheckUser( user, pseudo, email, hashedPassword, firstName, lastName, birthDate );
            }

            {
                pseudo = TestHelpers.RandomTestName();
                firstName = TestHelpers.RandomTestName();
                lastName = TestHelpers.RandomTestName();
                hashedPassword = Hasher.HashPassword( TestHelpers.RandomTestName() );
                Result r = await UserGateway.UpdateUserAsync( userId, pseudo, hashedPassword, firstName,
                    lastName, birthDate );
                Assert.That( r.Status, Is.EqualTo( Status.Ok ) );

                user = await UserGateway.FindByIdAsync( userId );
                CheckUser( user, pseudo, email, hashedPassword, firstName, lastName, birthDate );
            }

            {
                Result r = await UserGateway.DeleteUserAsync( email, hashedPassword );
                Assert.That( r.Status, Is.EqualTo( Status.Ok ) );
                user = await UserGateway.FindByIdAsync( userId );
                Assert.That( user.Status, Is.EqualTo( Status.NotFound ) );
            }
        }

        [Test]
        public async Task GetUserInfo()
        {
            UserData createUser = new UserData
            {
                Pseudo = TestHelpers.RandomTestName(),
                FirstName = TestHelpers.RandomTestName(),
                LastName = TestHelpers.RandomTestName(),
                Email = TestHelpers.RandomTestName(),
                BirthDate = TestHelpers.RandomBirthDate( 20 ),
                HashedPassword = Hasher.HashPassword( TestHelpers.RandomTestName() )
            };
            var userResult = await UserGateway.CreateUserAsync( createUser.Pseudo, createUser.Email, createUser.HashedPassword, createUser.FirstName, createUser.LastName,
                createUser.BirthDate );
            Assert.That( userResult.Status, Is.EqualTo( Status.Created ) );
            createUser.UserId = userResult.Content;

            var clockResult = await ClockGateway.CreateClockAsync( "Test-Clock", createUser.UserId );
            Assert.That( clockResult.Status, Is.EqualTo( Status.Created ) );
            int clockId = clockResult.Content;

            PresetData createPreset = new PresetData
            {
                WakingTime = new TimeSpan( 15, 0, 0 ),
                ActivationFlag = 0,
                Challenge = TestHelpers.RandomTestName(),
                Name = TestHelpers.RandomTestName(),
                ClockId = clockId,
                Song = TestHelpers.RandomTestName()
            };

            var presetResult = await PresetGateway.CreatePreset( createPreset.WakingTime, createPreset.Name,
                createPreset.Song, createPreset.ActivationFlag, createPreset.Challenge, createPreset.ClockId );
            Assert.That( presetResult.Status, Is.EqualTo( Status.Created ) );
            createPreset.AlarmPresetId = presetResult.Content;

            Result<UserDetails> resultInfo = await UserGateway.GetUserDetails( createUser.UserId );

            {
                UserDetails r = resultInfo.Content;
                {
                    Assert.That( r.UserId, Is.EqualTo( createUser.UserId ) );
                    Assert.That( r.Pseudo, Is.EqualTo( createUser.Pseudo ) );
                    Assert.That( r.Email, Is.EqualTo( createUser.Email ) );
                    Assert.That( r.FirstName, Is.EqualTo( createUser.FirstName ) );
                    Assert.That( r.LastName, Is.EqualTo( createUser.LastName ) );
                    Assert.That( r.BirthDate, Is.EqualTo( createUser.BirthDate ) );
                }

                {
                    Assert.That( r.Clocks.Count(), Is.EqualTo( 1 ) );
                    Clock clock = r.Clocks.First();
                    {
                        Assert.That( clock.ClockId, Is.EqualTo( clockId ) );
                        Assert.That( clock.ClockName, Is.EqualTo( "Test-Clock" ) );
                    }

                    Assert.That( clock.Presets.Count(), Is.EqualTo( 1 ) );
                    Preset preset = clock.Presets.First();
                    {
                        Assert.That( preset.PresetId, Is.EqualTo( createPreset.AlarmPresetId ) );
                        Assert.That( preset.ActivationFlag, Is.EqualTo( createPreset.ActivationFlag ) );
                        Assert.That( preset.Challenge, Is.EqualTo( createPreset.Challenge ) );
                        Assert.That( preset.Song, Is.EqualTo( createPreset.Song ) );
                        Assert.That( preset.PresetClockId, Is.EqualTo( createPreset.ClockId ) );
                        Assert.That( preset.PresetName, Is.EqualTo( createPreset.Name ) );
                    }
                }
            }

            {
                Result r = await PresetGateway.DeletePreset( createPreset.AlarmPresetId );
                Assert.That( r.Status, Is.EqualTo( Status.Ok ) );
                var find = await PresetGateway.FindPresetById( createPreset.AlarmPresetId );
                Assert.That( find.Status, Is.EqualTo( Status.NotFound ) );
            }
            {
                Result r = await ClockGateway.DeleteClockAsync( clockId );
                Assert.That( r.Status, Is.EqualTo( Status.Ok ) );
                var find = await ClockGateway.FindClockById( clockId );
                Assert.That( find.Status, Is.EqualTo( Status.NotFound ) );
            }
            {
                Result r = await UserGateway.DeleteUserAsync( createUser.Email, createUser.HashedPassword );
                Assert.That( r.Status, Is.EqualTo( Status.Ok ) );
                var find = await UserGateway.FindByIdAsync( createUser.UserId );
                Assert.That( find.Status, Is.EqualTo( Status.NotFound ) );
            }
        }
    }
}

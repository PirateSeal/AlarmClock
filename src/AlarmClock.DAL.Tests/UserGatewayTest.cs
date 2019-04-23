using System;
using System.Threading.Tasks;
using Alarmclock.WebApp;
using NUnit.Framework;

namespace AlarmClock.DAL.Tests
{
    [TestFixture]
    internal class UserGatewayTest
    {
        private Random Random { get; }
        private PasswordHasher Hasher { get; set; }

        public UserGatewayTest()
        {
            Random = new Random();
        }

        private void CheckUser( Result<UserData> user, string pseudo, string email )
        {
            Assert.That( user.Status, Is.EqualTo( Status.Ok ) );
            Assert.That( user.Content.Pseudo, Is.EqualTo( pseudo ) );
            Assert.That( user.Content.Email, Is.EqualTo( email ) );
        }

        [Test]
        public async Task Create_Update_Delete_User()
        {
            UserGateway userGateway = new UserGateway( TestHelpers.ConnectionString );
            string pseudo = TestHelpers.RandomTestName();
            string email = TestHelpers.RandomTestName();
            string password = TestHelpers.RandomTestName();

            var userResult = await userGateway.CreateUserAsync( pseudo, email, Hasher.HashPassword( password ) );
            Assert.That( userResult.Status, Is.EqualTo( Status.Created ) );
            int userId = userResult.Content;

            Result<UserData> User;
            {
                User = await userGateway.FindByIdAsync( userId );
                CheckUser( User, pseudo, email );
            }

            {
                pseudo = TestHelpers.RandomTestName();
                email = TestHelpers.RandomTestName();
                password = TestHelpers.RandomTestName();
            }
        }
    }
}

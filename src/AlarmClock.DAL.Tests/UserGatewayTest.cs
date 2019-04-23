using Alarmclock.WebApp;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace AlarmClock.DAL.Tests
{
    [TestFixture]
    class UserGatewayTest
    {
        private Random Random { get; set; }
        private PasswordHasher Hasher { get; set; }

        public UserGatewayTest()
        {
            Random = new Random();
        }

        void CheckUser( Result<UserData> User, string Pseudo, string Email, string Firstname)
        {
            Assert.That( User.Status, Is.EqualTo( Status.Ok ) );
            Assert.That( User.Content.Pseudo, Is.EqualTo( Pseudo ) );
            Assert.That( User.Content.Email, Is.EqualTo( Email ) );
        }

        [Test]
        public async Task Create_Update_Delete_User()
        {
            UserGateway userGateway = new UserGateway( TestHelpers.ConnectionString );
            string Pseudo = TestHelpers.RandomTestName();
            string Email = TestHelpers.RandomTestName();
            string Password =   TestHelpers.RandomTestName();

            var userResult = await userGateway.CreateUser( Pseudo, Email, Hasher.HashPassword(Password));
            Assert.That( userResult.Status, Is.EqualTo( Status.Created ) );
            int UserId = userResult.Content;

            Result<UserData> User;
            {
                User = await userGateway.FindByIdAsync( UserId );
                CheckUser( User, Pseudo, Email, Password );
            }

            {
                 Pseudo = TestHelpers.RandomTestName();
                 Email = TestHelpers.RandomTestName();
                 Password = TestHelpers.RandomTestName();

            }



        }
    }
}

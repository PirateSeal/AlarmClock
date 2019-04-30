using System;
using System.Threading.Tasks;
using AlarmClock.WebApp;
using NUnit.Framework;

namespace AlarmClock.DAL.Tests
{
    [TestFixture]
    internal class UserGatewayTest
    {
        private PasswordHasher Hasher { get; }
        private UserGateway Gateway { get; }

        public UserGatewayTest()
        {
            Hasher = new PasswordHasher();
            Gateway = new UserGateway( TestHelpers.ConnectionString );
        }

        private void CheckUser( Result<UserData> user, string pseudo, string email, byte[] hashedPassword,
            string firstName, string lastName, DateTime birthDate)
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
                await Gateway.CreateUserAsync( pseudo, email, hashedPassword, firstName, lastName, birthDate );
            Assert.That( userResult.Status, Is.EqualTo( Status.Created ) );
            int userId = userResult.Content;

            Result<UserData> user;
            {
                user = await Gateway.FindByIdAsync( userId );
                CheckUser( user, pseudo, email, hashedPassword, firstName, lastName, birthDate );
            }

            {
                pseudo = TestHelpers.RandomTestName();
                firstName = TestHelpers.RandomTestName();
                lastName = TestHelpers.RandomTestName();
                hashedPassword = Hasher.HashPassword( TestHelpers.RandomTestName() );
                Result r = await Gateway.UpdateUserAsync( userId, pseudo, hashedPassword, firstName,
                    lastName, birthDate );
                Assert.That( r.Status, Is.EqualTo( Status.Ok ) );

                user = await Gateway.FindByIdAsync( userId );
                CheckUser(user, pseudo, email, hashedPassword, firstName, lastName, birthDate);
            }

            {
                Result r = await Gateway.DeleteUserAsync( email, hashedPassword );
                Assert.That( r.Status, Is.EqualTo( Status.Ok ) );
                user = await Gateway.FindByIdAsync( userId );
                Assert.That(user.Status,Is.EqualTo(Status.NotFound));
            }
        }
    }
}

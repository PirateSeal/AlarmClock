using System;
using System.Threading.Tasks;
using AlarmClock.DAL;
using AlarmClock.DAL.Data;

namespace AlarmClock.WebApp.Services
{
    public class UserService
    {
        private readonly PasswordHasher _passwordHasher;
        private readonly UserGateway _userGateway;

        public UserService( UserGateway userGateway, PasswordHasher passwordHasher )
        {
            _userGateway = userGateway;
            _passwordHasher = passwordHasher;
        }

        public Task<Result<int>> CreateUser( string pseudo, string email, string password , string firstName, string lastName, DateTime birthDate)
        {
            return _userGateway.CreateUserAsync( pseudo, email, _passwordHasher.HashPassword( password ), firstName, lastName, birthDate );
        }

        public async Task<UserData> FindUser( string email, string password )
        {
            UserData user = await _userGateway.FindByEmailAsync( email );
            if( user != null && _passwordHasher.VerifyHashedPassword( user.HashedPassword, password ) ==
                PasswordVerificationResult.Success ) return user;

            return null;
        }
    }
}

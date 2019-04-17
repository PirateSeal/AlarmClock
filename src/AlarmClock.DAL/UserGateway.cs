using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Dapper;

namespace AlarmClock.DAL
{
    public class UserGateway
    {
        private string ConnectionString { get; set; }

        public UserGateway( string connectionString )
        {
            ConnectionString = connectionString;
        }

        public async Task<IEnumerable<string>> GetAuthenticationProviders( string userId )
        {
            using( SqlConnection con = new SqlConnection( ConnectionString ) )
            {
                return await con.QueryAsync<string>(
                    "select p.ProviderName from iti.vAuthenticationProvider p where p.UserId = @UserId",
                    new { UserId = userId } );
            }
        }

        public async Task<Result<int>> CreatePasswordUser( string pseudo, string email, byte[] password )
        {
            using( SqlConnection con = new SqlConnection( ConnectionString ) )
            {
                DynamicParameters p = new DynamicParameters();

                string FirstName = "titi ";
                string LastName = "tutu ";
                DateTime BirthDate = new DateTime(2018,11,10);


                p.Add( "@Email", email );
                p.Add( "@Pseudo", pseudo );
                p.Add( "@HashedPassword", password );
                p.Add( "@FirstName", FirstName );
                p.Add( "@LastName", LastName );
                p.Add( "@BirthDate", BirthDate );



               p.Add( "@UserId", dbType: DbType.Int32, direction: ParameterDirection.Output );
                p.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "spi.sCreateUser", p, commandType: CommandType.StoredProcedure );

                int status = p.Get<int>( "@Status" );
                if( status == 1 )
                    return Result.Failure<int>( Status.BadRequest, "An account with this email already exists." );

                Debug.Assert( status == 0 );
                return Result.Success( p.Get<int>( "@UserId" ) );
            }
        }

        public async Task<UserData> FindByEmail( string email )
        {
            using( SqlConnection con = new SqlConnection( ConnectionString ) )
            {
                return await con.QueryFirstOrDefaultAsync<UserData>(
                    "select u.UserId, u.Email, u.[Password], u.GithubAccessToken, u.GoogleRefreshToken, u.GoogleId, u.GithubId from iti.vUser u where u.Email = @Email",
                    new { Email = email } );
            }
        }
    }
}

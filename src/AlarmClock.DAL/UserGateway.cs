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
        public UserGateway( string connectionString )
        {
            ConnectionString = connectionString;
        }

        private string ConnectionString { get; }

        public async Task<IEnumerable<string>> GetAuthenticationProvidersAsync( string userId )
        {
            using( SqlConnection con = new SqlConnection( ConnectionString ) )
            {
                return await con.QueryAsync<string>(
                    "select p.ProviderName from spi.vAuthenticationProvider p where p.UserId = @UserId",
                    new {UserId = userId} );
            }
        }

        public async Task<Result<int>> CreateUserAsync( string pseudo, string email, byte[] password )
        {
            using( SqlConnection con = new SqlConnection( ConnectionString ) )
            {
                DynamicParameters p = new DynamicParameters();

                string FirstName = "titi ";
                string LastName = "tutu ";
                DateTime birthDate = new DateTime( 2018, 11, 10 );


                p.Add( "@Email", email );
                p.Add( "@Pseudo", pseudo );
                p.Add( "@HashedPassword", password );
                p.Add( "@FirstName", FirstName );
                p.Add( "@LastName", LastName );
                p.Add( "@BirthDate", birthDate );

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

        public async Task<Result> DeleteUserAsync( string email )
        {
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
            {
                DynamicParameters parameter = new DynamicParameters();

                parameter.Add( "@Email", email );
                parameter.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );

                await connection.ExecuteAsync( "spi.sDeleteUser", parameter, commandType: CommandType.StoredProcedure );

                int status = parameter.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure<int>( Status.BadRequest, "User not found." );

                Debug.Assert( status == 0 );
                return Result.Success();
            }
        }

        public async Task<Result> UpdateUserAsync( int userId, string pseudo, string email, byte[] password,
            string firstName,
            string lastName, DateTime birthDate, char userType )
        {
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add( "@UserId", userId );
                parameters.Add( "@Pseudo", pseudo );
                parameters.Add( "@Email", email );
                parameters.Add( "@HashedPassword", password );
                parameters.Add( "@FirstName", firstName );
                parameters.Add( "@LastName", lastName );
                parameters.Add( "@BirthDate", birthDate );
                parameters.Add( "@UserType", userType );

                parameters.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );

                await connection.ExecuteAsync( "spi.sUpdateUser", parameters,
                    commandType: CommandType.StoredProcedure );

                int status = parameters.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure<int>( Status.BadRequest, "Can't find this user." );

                Debug.Assert( status == 0 );
                return Result.Success();
            }
        }

        public async Task<Result<UserData>> FindByIdAsync( int userId )
        {
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
            {
                UserData user = await connection.QueryFirstOrDefaultAsync<UserData>(
                    @"select u.UserId,
                             u.FirstName,
                             u.LastName,
                             u.BirthDate,
                             u.Email,
                             u.Pseudo,
                            u.HashedPassword
                      from spi.vUsers u
                      where u.UserId = @UserId;",
                    new {UserId = userId} );

                if( user == null ) return Result.Failure<UserData>( Status.NotFound, "User not found." );

                return Result.Success( user );
            }
        }

        public async Task<UserData> FindByEmailAsync( string email )
        {
            using( SqlConnection con = new SqlConnection( ConnectionString ) )
            {
                return await con.QueryFirstOrDefaultAsync<UserData>(
                    "select u.UserId, u.Email, u.Pseudo, u.HashedPassword, u.FirstName, u.LastName, u.BirthDate, u.UserType from spi.vUsers u where u.Email = @Email",
                    new {Email = email} );
            }
        }
    }
}

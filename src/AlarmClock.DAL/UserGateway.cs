using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
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
                    new { UserId = userId } );
            }
        }

        public async Task<Result<UserDetails>> GetUserDetails( int userId )
        {
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
            {
                var userFlatDetails =
                    await connection.QueryAsync<UserFlatDetails>( "SELECT * FROM spi.vUserInfo WHERE UserId = @UserId",
                        new { UserId = userId } );

                if( !userFlatDetails.Any())
                {
                    return Result.Failure<UserDetails>( Status.NotFound, "Details Not Found" );
                }

                UserFlatDetails tempoDetails = userFlatDetails.First();
                var clocks = new List<Clock>();

                UserDetails userDetails = new UserDetails
                {
                    UserId = tempoDetails.UserId,
                    Pseudo = tempoDetails.Pseudo,
                    Email = tempoDetails.Email,
                    FirstName = tempoDetails.FirstName,
                    LastName = tempoDetails.LastName,
                    BirthDate = tempoDetails.BirthDate,
                    Clocks = clocks
                };

                if( tempoDetails.ClockId != 0 )
                {
                    foreach( UserFlatDetails detail in userFlatDetails )
                    {
                        switch( clocks.Count )
                        {
                            case 0:
                                clocks.Add(
                                    new Clock
                                    {
                                        ClockId = detail.ClockId,
                                        ClockName = detail.ClockName,
                                        ClockGuid = detail.ClockGuid,
                                        LastSeenDate = detail.LastSeenDate,
                                        Presets = new List<Preset>()
                                    } );
                                break;
                            default:
                            {
                                if( clocks.Last().ClockId != detail.ClockId )
                                    clocks.Add(
                                        new Clock
                                        {
                                            ClockId = detail.ClockId,
                                            ClockName = detail.ClockName,
                                            ClockGuid = detail.ClockGuid,
                                            Presets = new List<Preset>()
                                        } );
                                break;
                            }
                        }

                        if( detail.PresetId != 0 )
                        {
                            Clock clock = clocks.Find( pClock => pClock.ClockId == detail.ClockId );
                            Preset findPreset = clock.Presets.AsList().Find( pPreset =>
                                pPreset.PresetId == detail.PresetId
                                && pPreset.PresetClockId == detail.PresetClockId );

                            if( findPreset == null )
                            {
                                clock.Presets.AsList().Add( new Preset
                                {
                                    PresetId = detail.PresetId,
                                    PresetName = detail.PresetName,
                                    WakingTime = detail.WakingTime,
                                    ActivationFlag = detail.ActivationFlag,
                                    Song = detail.Song,
                                    Challenge = detail.Challenge,
                                    PresetClockId = detail.PresetClockId
                                } );
                            }
                        }
                    }
                }

                return  Result.Success(Status.Ok, userDetails);
            }
        }

        public async Task<Result<int>> CreateUserAsync( string pseudo, string email, byte[] password, string firstName,
            string lastName, DateTime birthDate )
        {
            using( SqlConnection con = new SqlConnection( ConnectionString ) )
            {
                DynamicParameters p = new DynamicParameters();

                p.Add( "@Email", email );
                p.Add( "@Pseudo", pseudo );
                p.Add( "@HashedPassword", password );
                p.Add( "@FirstName", firstName );
                p.Add( "@LastName", lastName );
                p.Add( "@BirthDate", birthDate );

                p.Add( "@UserId", dbType: DbType.Int32, direction: ParameterDirection.Output );
                p.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );
                await con.ExecuteAsync( "spi.sCreateUser", p, commandType: CommandType.StoredProcedure );

                int status = p.Get<int>( "@Status" );
                if( status == 1 )
                    return Result.Failure<int>( Status.BadRequest, "An account with this email already exists." );

                Debug.Assert( status == 0 );
                return Result.Success( Status.Created, p.Get<int>( "@UserId" ) );
            }
        }

        public async Task<Result> DeleteUserAsync( string email, byte[] password )
        {
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
            {
                DynamicParameters parameter = new DynamicParameters();

                parameter.Add( "@Email", email );
                parameter.Add( "@HashedPassword", password );
                parameter.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );

                await connection.ExecuteAsync( "spi.sDeleteUser", parameter, commandType: CommandType.StoredProcedure );

                int status = parameter.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure<int>( Status.BadRequest, "User not found." );

                Debug.Assert( status == 0 );
                return Result.Success();
            }
        }

        public async Task<Result> UpdateUserAsync( int userId, string pseudo, byte[] password,
            string firstName,
            string lastName, DateTime birthDate, string userType = "U" )
        {
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add( "@UserId", userId );
                parameters.Add( "@Pseudo", pseudo );
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
                             u.Pseudo
                      from spi.vUser u
                      where u.UserId = @UserId;",
                    new { UserId = userId } );

                return user == null
                    ? Result.Failure<UserData>( Status.NotFound, "User not found." )
                    : Result.Success( user );
            }
        }

        public async Task<UserData> FindByEmailAsync( string email )
        {
            using( SqlConnection con = new SqlConnection( ConnectionString ) )
            {
                return await con.QueryFirstOrDefaultAsync<UserData>(
                    "select u.UserId, u.Email, u.Pseudo, u.HashedPassword, u.FirstName, u.LastName, u.BirthDate, u.UserType from spi.vUser u where u.Email = @Email",
                    new { Email = email } );
            }
        }
    }
}

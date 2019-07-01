using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Dapper;

namespace AlarmClock.DAL
{
    public class ClockGateway
    {
        public ClockGateway( string connectionString )
        {
            ConnectionString = connectionString;
        }

        private string ConnectionString { get; }

        public async Task<IEnumerable<ClockData>> GetAllClocksByUserId( int userId )
        {
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
            {
                return await connection.QueryAsync<ClockData>(
                    "SELECT ClockId, [Name], [GUID], UserId" +
                    "FROM spi.vClock " +
                    "WHERE UserId = @UserId", new { UserId = userId } );
            }
        }

        public async Task<Result<int>> CreateClockAsync( string name, int userId )
        {
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add( "@Name", name );
                parameters.Add( "@UserId", userId );

                parameters.Add( "@ClockId", dbType: DbType.Int32, direction: ParameterDirection.Output );
                parameters.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );

                await connection.ExecuteAsync( "spi.sCreateClock", parameters,
                    commandType: CommandType.StoredProcedure );

                int status = parameters.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure<int>( Status.BadRequest, "This clock already exists." );

                Debug.Assert( status == 0 );
                return Result.Success( Status.Created, parameters.Get<int>( "@ClockId" ) );
            }
        }


        public async Task<Result<int>> CreateUnclaimedClockAclAsync(Guid guid)
        {
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add( "@Name", "unclaimed" );
                parameters.Add( "@UserId", 0 );
                parameters.Add( "@Guid", guid );

                parameters.Add( "@ClockId", dbType: DbType.Int32, direction: ParameterDirection.Output );
                parameters.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );

                await connection.ExecuteAsync( "spi.sCreateClock", parameters,
                    commandType: CommandType.StoredProcedure );

                int status = parameters.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure<int>( Status.BadRequest, "This clock already exists." );

                Debug.Assert( status == 0 );
                return Result.Success( Status.Created, parameters.Get<int>( "@ClockId" ) );
            }
        }

        public async Task<Result> UpdateClockAsync( string name, int clockId )
        {
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add( "@ClockId", clockId );
                parameters.Add( "@Name", name );

                parameters.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );

                await connection.ExecuteAsync( "spi.sUpdateClock", parameters,
                    commandType: CommandType.StoredProcedure );

                int status = parameters.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure<int>( Status.BadRequest, "Can't find this clock." );

                Debug.Assert( status == 0 );
                return Result.Success( Status.Ok );
            }
        }

        public async Task<Result> DeleteClockAsync( int clockId )
        {
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add( "@ClockId", clockId );

                parameters.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );

                await connection.ExecuteAsync( "spi.sDeleteClock", parameters,
                    commandType: CommandType.StoredProcedure );

                int status = parameters.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure<int>( Status.BadRequest, "Can't find this clock." );

                Debug.Assert( status == 0 );
                return Result.Success();
            }
        }

        public async Task<Result<ClockData>> FindClockById( int id )
        {
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
            {
                ClockData data = await connection.QueryFirstOrDefaultAsync<ClockData>(
                    @"SELECT ClockId, [Name], UserId
                            FROM spi.vClock
                            WHERE ClockId = @ClockId;",
                    new { ClockId = id } );

                return data != null
                    ? Result.Success( data )
                    : Result.Failure<ClockData>( Status.NotFound, "Clock not found." );
            }
        }

        public async Task<Result> ClaimClock( string guid, string id )
        {
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add( "@ClockId", guid );
                parameters.Add( "@UserId", id );


                parameters.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );

                await connection.ExecuteAsync( "spi.sClaimClock", parameters,
                    commandType: CommandType.StoredProcedure );

                int status = parameters.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure<int>( Status.BadRequest, "Can't find this clock." );

                Debug.Assert( status == 0 );
                return Result.Success( Status.Ok );
            }
        }

    }
}

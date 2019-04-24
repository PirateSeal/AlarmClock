using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Dapper;

namespace AlarmClock.DAL
{
    internal class ClockGateway
    {
        public ClockGateway( string connectionString )
        {
            ConnectionString = connectionString;
        }

        private string ConnectionString { get; }

        public async Task<IEnumerable<ClockData>> GetAllClocksByUserId( int userId )
        {
            using( SqlConnection connection = new SqlConnection() )
            {
                return await connection.QueryAsync<ClockData>(
                    "SELECT ClockId, [Name], [GUID], UserId, Pseudo, FirstName, LastName " +
                    "FROM spi.vClock " +
                    "WHERE UserId = @UserId", new {UserId = userId} );
            }
        }

        public async Task<Result<int>> CreateClockAsync( string name, Guid guid, int userId )
        {
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add( "@Name", name );
                parameters.Add( "@GUID", guid );
                parameters.Add( "@UserId", userId );

                parameters.Add( "@ClockId", dbType: DbType.Int32, direction: ParameterDirection.Output );
                parameters.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );

                await connection.ExecuteAsync( "spi.sCreateClock", parameters,
                    commandType: CommandType.StoredProcedure );

                int status = parameters.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure<int>( Status.BadRequest, "This clock already exist." );

                Debug.Assert( status == 0 );
                return Result.Success( parameters.Get<int>( "@ClockId" ) );
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
                return Result.Success();
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
    }
}

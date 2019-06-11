using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace AlarmClock.DAL
{
    public class VernemqGateway
    {
        public VernemqGateway( string connectionString )
        {
            ConnectionString = connectionString;
        }

        private string ConnectionString { get; }



        public async Task<Result<int>> CreateClockAclAsync()
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

        public async Task<Result<int>> CreateUnclaimedClockAclAsync(string id ,string name)
        {
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add( "@Name", name );
                parameters.Add( "@UserId", 0 );

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


        public Task CreateClockAsync( string guid, string name, int password )
        {
            throw new NotImplementedException();
        }
    }
}

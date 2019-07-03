using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
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



        //public async Task<Result<int>> updtaeClockAclAsync()
        //{
        //    using( SqlConnection connection = new SqlConnection( ConnectionString ) )
        //    {
               
        //    }
        //}

        public async Task<Result<int>> CreateUnclaimedClockAclAsync(string id ,string name ,int password)
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
    }
}

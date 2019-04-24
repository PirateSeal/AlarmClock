using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Dapper;

namespace AlarmClock.DAL
{
    internal class PresetGateway
    {
        public PresetGateway( string connectionString )
        {
            ConnectionString = connectionString;
        }

        private string ConnectionString { get; }

        public async Task<IEnumerable<PresetData>> GetAllPresetFromClockId( int clockId )
        {
            using( SqlConnection connection = new SqlConnection() )
            {
                return await connection.QueryAsync<PresetData>(
                    "SELECT AlarmPresetId, WakingTime, Song, ActivationFlag, Challenge, ClockId " +
                    "FROM spi.vPreset " +
                    "WHERE ClockId = @ClockId", new {ClockId = clockId}
                );
            }
        }

        public async Task<Result<int>> CreatePreset( TimeSpan wakingTime, string song, byte activationFlag,
            int challenge, int clockId )
        {
            using( SqlConnection connection = new SqlConnection() )
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add( "@WakingTime", wakingTime );
                parameters.Add( "@Song", song );
                parameters.Add( "@ActivationFlag", activationFlag );
                parameters.Add( "@Challenge", challenge );
                parameters.Add( "@ClockId", clockId );

                parameters.Add( "@AlarmPresetId", dbType: DbType.Int32, direction: ParameterDirection.Output );
                parameters.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );

                await connection.ExecuteAsync( "spi.sCreatePreset", parameters,
                    commandType: CommandType.StoredProcedure );

                int status = parameters.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure<int>( Status.BadRequest, "This preset already exists." );

                Debug.Assert( status == 0 );
                return Result.Success( parameters.Get<int>( "@ClockId" ) );
            }
        }

        public async Task<Result> UpdatePreset( int alarmPresetId, TimeSpan wakingTime, string song,
            byte activationFlag,
            int challenge )
        {
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add( "@AlarmPresetId", alarmPresetId );
                parameters.Add( "@WakingTime", wakingTime );
                parameters.Add( "@Song", song );
                parameters.Add( "@ActivationFlag", activationFlag );
                parameters.Add( "@Challenge", challenge );

                parameters.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );

                await connection.ExecuteAsync( "spi.sUpdatePreset", parameters,
                    commandType: CommandType.StoredProcedure );

                int status = parameters.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure<int>( Status.BadRequest, "This preset doesn't exists" );

                Debug.Assert( status == 0 );
                return Result.Success();
            }
        }

        public async Task<Result> DeletePreset( int alarmPresetId )
        {
            using( SqlConnection connection = new SqlConnection() )
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add( "@AlarmPresetId", alarmPresetId );

                parameters.Add( "@Status", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue );

                await connection.ExecuteAsync( "spi.sDeletePreset", parameters,
                    commandType: CommandType.StoredProcedure );

                int status = parameters.Get<int>( "@Status" );
                if( status == 1 ) return Result.Failure<int>( Status.BadRequest, "This preset doesn't exists" );

                Debug.Assert( status == 0 );
                return Result.Success();
            }
        }
    }
}

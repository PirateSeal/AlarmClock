using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;
using Dapper;

namespace AlarmClock.DAL
{
    public class PresetGateway
    {
        public PresetGateway( string connectionString )
        {
            ConnectionString = connectionString;
        }

        private string ConnectionString { get; }

        public async Task<IEnumerable<PresetData>> GetAllPresetFromClockId( int clockId )
        {
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
            {
                return await connection.QueryAsync<PresetData>(
                    "SELECT AlarmPresetId, [Name], WakingTime, Song, ActivationFlag, Challenge, ClockId " +
                    "FROM spi.vPreset " +
                    "WHERE ClockId = @ClockId", new {ClockId = clockId}
                );
            }
        }

        public async Task<Result<int>> CreatePreset( TimeSpan wakingTime, string name, string song, byte activationFlag,
            string challenge, int clockId )
        {
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add( "@WakingTime", wakingTime );
                parameters.Add( "@Name", name );
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
                return Result.Success( Status.Created, parameters.Get<int>( "@AlarmPresetId" ) );
            }
        }

        public async Task<Result> UpdatePreset( int alarmPresetId, TimeSpan wakingTime, string name, string song,
            byte activationFlag,
            string challenge )
        {
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add( "@AlarmPresetId", alarmPresetId );
                parameters.Add( "@WakingTime", wakingTime );
                parameters.Add( "@Name", name );
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
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
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

        public async Task<Result<PresetData>> FindPresetById( int id )
        {
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
            {
                PresetData data = await connection.QueryFirstOrDefaultAsync<PresetData>(
                    @"SELECT AlarmPresetId, WakingTime, [Name], Song, ActivationFlag, Challenge, ClockId FROM spi.vPreset WHERE AlarmPresetId = @AlarmPresetId;",
                    new {AlarmPresetId = id}
                );
                return data == null
                    ? Result.Failure<PresetData>( Status.NotFound, "Preset not found." )
                    : Result.Success( Status.Ok, data );
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using AlarmClock.DAL.Data;
using Dapper;

namespace AlarmClock.DAL
{
    public class UpdateGateway
    {
        public UpdateGateway( string connectionString )
        {
            ConnectionString = connectionString;
        }

        private string ConnectionString { get; }

        public async Task<Result> UpdateClock( Guid guid )
        {
            var presets = new List<PresetData>();
            using( SqlConnection connection = new SqlConnection( ConnectionString ) )
            {
                presets = await connection.QueryAsync<PresetData>(
                    @"SELECT
                            p.*
                        FROM
                            spi.tDevice d
                            JOIN spi.tClock c
                                ON d.DeviceId = c.ClockId
                            JOIN spi.tAlarmPreset p
                                ON c.ClockId = p.ClockId
                            WHERE d.GUID = @Guid",
                    new { Guid = guid } ) as List<PresetData>;

            }

            return presets != null
                ? Result.Success( Status.Ok, presets )
                : Result.Failure( Status.NotFound, "Not Found" );
        }
    }
}

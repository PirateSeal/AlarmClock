using System;
using System.IO;
using System.Reflection;
using DbUp;
using DbUp.Engine;
using Microsoft.Extensions.Configuration;

namespace AlarmClock.DB
{
    public class Program
    {
        private static IConfiguration _configuration;

        private static IConfiguration Configuration =>
            _configuration ?? (_configuration = new ConfigurationBuilder()
                .SetBasePath( Directory.GetCurrentDirectory() )
                .AddJsonFile( "appsettings.json", false )
                .AddEnvironmentVariables()
                .Build());

        public static int Main( string[] args )
        {
            string connectionString = Configuration["ConnectionStrings:AlarmClock"];

            EnsureDatabase.For.SqlDatabase( connectionString );

            UpgradeEngine upgrader =
                DeployChanges.To
                    .SqlDatabase( connectionString )
                    .WithScriptsEmbeddedInAssembly( Assembly.GetExecutingAssembly() )
                    .LogToConsole()
                    .Build();

            DatabaseUpgradeResult result = upgrader.PerformUpgrade();

            if( !result.Successful )
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine( result.Error );
                Console.ResetColor();

                return -1;
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine( "Success!" );
            Console.ResetColor();
            return 0;
        }
    }
}

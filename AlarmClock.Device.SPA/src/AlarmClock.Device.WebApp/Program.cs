using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace AlarmClock.Device.WebApp
{
    public class Program
    {
        public static void Main( string[] args )
        {
            BuildWebHost( args ).Run();
        }

        private static IWebHost BuildWebHost( string[] args ) =>
            new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot( Directory.GetCurrentDirectory() )
                .ConfigureAppConfiguration( ( hostingContext, config ) =>
                {
                    config.AddJsonFile( "appsettings.json", false, true );
                    config.AddEnvironmentVariables();
                    if( args != null ) config.AddCommandLine( args );
                })
                .UseStartup<Startup>()
                .Build();
    }
}

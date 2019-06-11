using AlarmClock.Device.DAL.Gateways;
using AlarmClock.Device.WebApp.services;
using AlarmClock.Device.WebApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AlarmClock.Device.WebApp
{
    public class Startup
    {
        public Startup( IConfiguration configuration )
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices( IServiceCollection services )
        {
            services.AddOptions();
            services.AddMvc();
            services.AddSingleton( _ => new ClockGateway() );
            services.AddSingleton( _ => new PresetGateway() );
        }

        public async void Configure( IApplicationBuilder app, IHostingEnvironment env )
        {
            if( env.IsDevelopment() ) app.UseDeveloperExceptionPage();

            app.UseCors( c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyMethod();
                c.AllowCredentials();
                c.WithOrigins( "http://localhost:8080" );
            } );

            app.UseMvc( routes =>
            {
                routes.MapRoute(
                    "default",
                    "{controller}/{action}/{id?}",
                    new {controller = "Preset"} );
            } );

            app.UseStaticFiles();

            InitializeClock initialize = new InitializeClock();
            await initialize.CreateIfNotExist();
        }


    }
    
}

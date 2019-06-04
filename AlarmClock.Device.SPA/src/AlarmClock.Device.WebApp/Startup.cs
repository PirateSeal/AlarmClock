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

        private IConfiguration Configuration { get; set; }

        public void ConfigureServices( IServiceCollection services )
        {
            services.AddOptions();
            services.AddMvc();
        }

        public void Configure( IApplicationBuilder app, IHostingEnvironment env )
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
                    name: "default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Preset" } );
            } );

            app.UseStaticFiles();
        }
    }
}

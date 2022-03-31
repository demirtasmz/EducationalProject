using Hangfire;
using Hangfire.MemoryStorage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NLog;
using System;
using System.IO;

namespace EducationalProject.Hangfire
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/Nlog.config"));
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

           

            services.AddControllers();

            //services.AddHangfire(config => { config.UseSqlServerStorage(@"Server=localhost;Database=Northwind;Trusted_Connection=true;Trusted_Connection=True;MultipleActiveResultSets=true;Integrated Security=false"); });
            services.AddHangfire(config => { config.UseMemoryStorage(); });
            
            services.AddHangfireServer();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseHangfireDashboard("/dashboard");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using System;
using System.Text;
using EducationalProject.Business.Concrete;
using EducationalProject.Business.Interface;
using EducationalProject.Repository.Interface;
using EducationalProject.Repository.Repository;
using EducationalProject.WebApi.Utilities;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace EducationalProject.WebApi
{

    public class Startup
    {
        private const string SECRET_KEY = "mysecretkey123mysecretkey123";
        public static readonly SymmetricSecurityKey SIGNING_KEY = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SECRET_KEY));
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = "JwtBearer";
                options.DefaultChallengeScheme = "JwtBearer";
            }).AddJwtBearer("JwtBearer", jwtOptions =>
            {
                jwtOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    IssuerSigningKey = SIGNING_KEY,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "http://localhost:44312",
                    ValidAudience = "http://localhost:44312",
                    ValidateLifetime = true
                };
            });

            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(LogAttribute));
            });

            services.AddSwaggerGen(config =>
                config.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "1.0.0",
                    Title = "Educational Project",
                    Description = "Staj Eğitim Api",
                    Contact = new OpenApiContact
                    {
                        Email = "zahid.demirtas@dgpaysit.com",
                        Name = "Zahid Demirtaş",
                        Url = new Uri("https://www.dgpays.com")
                    }
                })
                 );

            services.AddScoped<IProductBusiness, ProductBusiness>();
            services.AddScoped<IProductRepository, ProductRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(s =>

                s.SwaggerEndpoint("/swagger/v1/swagger.json", "Educational Project"));

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}

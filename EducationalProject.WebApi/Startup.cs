using EducationalProject.Business.Concrete;
using EducationalProject.Business.Interface;
using EducationalProject.Business.Utilities;
using EducationalProject.Repository.Interface;
using EducationalProject.Repository.Repository;
using EducationalProject.Utilities.Security.Encryption;
using EducationalProject.Utilities.Security.Jwt;
using EducationalProject.WebApi.Utilities;
using EducationalProject.WebApi.Utilities.Security.Jwt;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Web.Mvc;

namespace EducationalProject.WebApi
{

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<Startup>());

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
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

            services.AddScoped<IUserBusiness, UserBusiness>();

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IAuthBusiness, AuthBusiness>();

            services.AddScoped<ITokenHelper, JwtHelper>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            ServiceTool.Create(services);
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

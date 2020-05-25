using AutoMapper;
using ItinerarioSNC.Infra.Data.Context;
using ItinerarioSNC.Infra.Data.Repository;
using ItnerarioSNC.Generics.ApplicationCore.Base.Interfaces.Repositories;
using ItnerarioSNC.Generics.ApplicationCore.Base.Interfaces.Services;
using ItnerarioSNC.Generics.Infra.Base.TokenJWT;
using ItnerarioSNC.Generics.Infra.Base.UnitOfWork;
using ItnerarioSNC.Generics.Infra.Base.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace Modelo.Application
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
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));            
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ITokenJWTService, TokenService>();
            services.AddScoped<MySqlServerContext>();
            services.AddScoped<IMapper, Mapper>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Sql Server Connection
            services.AddDbContext<MySqlServerContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ItinerarioDatabase")));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", 
                    cors => cors
                    .AllowAnyOrigin()
                    .AllowAnyHeader());
            });

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                var secret = Configuration.GetSection("JWTToken:Secret");
                var key = Encoding.ASCII.GetBytes(secret.Value);

                var paramsValidations = jwt.TokenValidationParameters;
                paramsValidations.IssuerSigningKey = new SymmetricSecurityKey(key);
                paramsValidations.ValidateIssuerSigningKey = true;
                paramsValidations.ValidateAudience = false;
                paramsValidations.ValidateIssuer = false;
                paramsValidations.ValidateLifetime = true;
                paramsValidations.ClockSkew = TimeSpan.Zero;
            });
            
            IdentityModelEventSource.ShowPII = true;

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddMvc().AddMvcOptions(s => s.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

                app.UseAuthentication();
                app.UseHttpsRedirection();
                app.UseCors("CorsPolicy");
                app.UseMvc();
            }
        }
    }
}

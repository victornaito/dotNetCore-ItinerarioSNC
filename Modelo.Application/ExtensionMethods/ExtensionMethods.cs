using AutoMapper;
using ItinerarioSNC.Infra.Data.Context;
using ItinerarioSNC.Infra.Data.Repository;
using ItnerarioSNC.Generics.ApplicationCore.Base.Interfaces.Repositories;
using ItnerarioSNC.Generics.ApplicationCore.Base.Interfaces.Services;
using ItnerarioSNC.Generics.Infra.Base.TokenJWT;
using ItnerarioSNC.Generics.Infra.Base.UnitOfWork;
using ItnerarioSNC.Generics.Infra.Base.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace ItinerarioSNC.Infra.CrossCutting.ExtensionMethods
{
    public static class ExtensionMethods
    {
        public static void InjectDependencies(IServiceCollection services, IConfiguration Configuration)
        {
            AddApplicationInjection(services);
            AddSqlServerConnection(services, Configuration);
            AddJWTAuthentication(services, Configuration);
            AddCors(services);
            AddControllersConfiguration(services);
            AddLoggingConfiguration();
        }

        private static void AddLoggingConfiguration()
        {
            IdentityModelEventSource.ShowPII = true;
        }

        private static void AddControllersConfiguration(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
                         options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
        }

        private static void AddCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    cors => cors
                    .AllowAnyOrigin()
                    .AllowAnyHeader());
            });
        }

        private static void AddApplicationInjection(IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ITokenJWTService, TokenService>();
            services.AddScoped<MySqlServerContext>();
            services.AddScoped<IMapper, Mapper>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private static void AddSqlServerConnection(IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<MySqlServerContext>(options =>
                            options.UseSqlServer(Configuration.GetConnectionString("ItinerarioDatabase")));
        }

        private static AuthenticationBuilder AddJWTAuthentication(IServiceCollection services, IConfiguration Configuration)
        {
            return services.AddAuthentication(auth =>
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
        }
    }
}
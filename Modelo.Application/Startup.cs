﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ItinerarioSNC.Domain.Entities;
using ItinerarioSNC.Infra.Data.Context;
using ItinerarioSNC.Infra.Data.Repository;
using ItinerarioSNC.Service.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

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
            services.AddScoped<BaseService<PessoaFisica>>();
            services.AddScoped<BaseService<AnaliseAgendamento>>();
            services.AddScoped<MySqlServerContext>();
            services.AddScoped<BaseRepository<PessoaFisica>>();

            // Sql Server Connection
            services.AddDbContext<MySqlServerContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ItinerarioDatabase")));

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", 
                    cors => cors
                    .AllowAnyOrigin());
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
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


                app.UseHttpsRedirection();
                app.UseCors("CorsPolicy");
                app.UseMvc();
                //app.UseMiddleware(null);
            }
        }
    }
}

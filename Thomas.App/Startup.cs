﻿using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Globalization;
using Thomas.Business.Interfaces;
using Thomas.Data.Context;
using Thomas.Data.Repository;

namespace Thomas.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddControllersWithViews().AddRazorRuntimeCompilation();

            services.AddDbContext<MeuDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
               .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

            services.AddScoped<MeuDbContext>();
            services.AddScoped<IChamadoRepository, ChamadoRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var defaultCulture = new CultureInfo("pt-br");
            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(defaultCulture),
                SupportedCultures = new List<CultureInfo> { defaultCulture },
                SupportedUICultures = new List<CultureInfo> { defaultCulture }
            };

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseRequestLocalization(localizationOptions);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

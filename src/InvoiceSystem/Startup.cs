﻿using DNTCaptcha.Core;
using DNTCommon.Web.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using InvoiceSystem.Common.WebToolkit;
using InvoiceSystem.IocConfig;
using InvoiceSystem.ViewModels.Identity.Settings;
using AutoMapper;
using InvoiceSystem.Mapper;
using System;

namespace InvoiceSystem
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
            services.Configure<SiteSettings>(options => Configuration.Bind(options));

            // Adds all of the ASP.NET Core Identity related services and configurations at once.
            services.AddCustomIdentityServices();

            services.AddMvc(options => options.UseYeKeModelBinder());
            #region Mapper Service

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AppMapping());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            #endregion

            //services.AddKendo();
            services.AddDNTCommonWeb();
            services.AddDNTCaptcha();
            services.AddCloudscribePagination();


            services.AddDistributedMemoryCache();

            //add session 
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(1800);
                //options.Cookie.HttpOnly = true;
                //options.Cookie.IsEssential = true;
            });
            services.AddMemoryCache(o =>
            {
                o.SizeLimit = 99999;

            });

            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseExceptionHandler("/error/index/500");
            app.UseStatusCodePagesWithReExecute("/error/index/{0}");

            app.UseContentSecurityPolicy();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();

                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller=Account}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });
        }
    }
}
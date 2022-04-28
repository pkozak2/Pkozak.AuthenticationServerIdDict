using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pkozak.AuthenticationServerIdDict.Configuration;
using Pkozak.AuthenticationServerIdDict.Configuration.Constants;
using Pkozak.AuthenticationServerIdDict.EntityFramework.DbContexts;
using Pkozak.AuthenticationServerIdDict.EntityFramework.Entities.Identity;
using Pkozak.AuthenticationServerIdDict.Helpers;
using System;

namespace Pkozak.AuthenticationServerIdDict
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
            var rootConfiguration = CreateRootConfiguration();
            services.AddSingleton(rootConfiguration);

            RegisterDbContexts(services);

            services.AddRazorPages();
            // Add services for authentication, including Identity model and external providers
            RegisterAuthentication(services);
            // Add HSTS options
            RegisterHstsOptions(services);

            // Add authorization policies for MVC
            RegisterAuthorization(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCookiePolicy();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseExceptionHandler("/Error");
            }

            app.UsePathBase(Configuration.GetValue<string>("BasePath"));

            app.UseStaticFiles();

            UseAuthentication(app);

            app.UseRouting();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
        public virtual void RegisterDbContexts(IServiceCollection services)
        {
            services.RegisterDbContexts<ServerIdentityDbContext, ServerDbContext>(Configuration);
        }

        public virtual void RegisterAuthentication(IServiceCollection services)
        {
            services.AddAuthenticationServices<ServerIdentityDbContext, UserIdentity, UserIdentityRole>(Configuration);
            services.AddIdDictServer<ServerDbContext, UserIdentity>(Configuration);
        }

        public virtual void RegisterAuthorization(IServiceCollection services)
        {
            var rootConfiguration = CreateRootConfiguration();
            services.AddAuthorizationPolicies(rootConfiguration);
        }

        public virtual void UseAuthentication(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }

        public virtual void RegisterHstsOptions(IServiceCollection services)
        {
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(365);
            });
        }

        protected IRootConfiguration CreateRootConfiguration()
        {
            var rootConfiguration = new RootConfiguration();
            Configuration.GetSection(ConfigurationConsts.RegisterConfigurationKey).Bind(rootConfiguration.RegisterConfiguration);
            return rootConfiguration;
        }
    }
}

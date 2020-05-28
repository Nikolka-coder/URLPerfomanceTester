using System;
using System.Web.Mvc;
using Hangfire;
using Hangfire.SqlServer;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using URLPerformanceTester.Infrastructure;
using System.Net;

namespace URLPerformanceTester
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.DefaultConnectionLimit = 12;
            app.CreatePerOwinContext(AppDbContext.Create);
            app.CreatePerOwinContext(() => DependencyResolver.Current.GetService<AppUserManager>());
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
            GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection",
                new SqlServerStorageOptions {QueuePollInterval = TimeSpan.FromSeconds(15)});
            GlobalConfiguration.Configuration.UseUnityActivator(UnityConfig.GetConfiguredContainer());
            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
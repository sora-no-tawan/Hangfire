using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;
using Hangfire.SqlServer;
using Hangfire.Dashboard;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(CrowdriveHangfire.OwinStartup))]

namespace CrowdriveHangfire
{
    public class OwinStartup
    {
        public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=316888
            app.UseHangfire(config =>
            {                
                config.UseSqlServerStorage(ConfigurationManager.AppSettings["hangfireConnectionString"]);
                config.UseServer();

                config.UseAuthorizationFilters(new MyRestrictiveAuthorizationFilter());
            });
        }
    }

    public class MyRestrictiveAuthorizationFilter : IAuthorizationFilter
    {
        public bool Authorize(IDictionary<string, object> owinEnvironment)
        {
            // In case you need an OWIN context, use the next line.
            return true;
        }
    }
}

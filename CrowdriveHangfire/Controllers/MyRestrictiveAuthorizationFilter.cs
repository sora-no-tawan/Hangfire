using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hangfire.Dashboard;
using Microsoft.Owin;

namespace CrowdriveHangfire.Controllers
{
    public class MyRestrictiveAuthorizationFilter : IAuthorizationFilter
    {
        public bool Authorize(IDictionary<string, object> owinEnvironment)
        {
            var context = new OwinContext(owinEnvironment);
            return false;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hangfire;

namespace CrowdriveHangfire.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            BackgroundJob.Enqueue(() => Console.WriteLine("Fire-and-forget"));
            return View();
        }

        public ActionResult Test()
        {
            BackgroundJob.Enqueue(() => Console.WriteLine("Hello , Word"));                          
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            RecurringJob.AddOrUpdate(@"send-project-fail-email", () => Console.Write("Powerful!"), Cron.Minutely);
            return View();
        }
    }
}
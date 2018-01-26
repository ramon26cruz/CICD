using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.ApplicationInsights;

namespace AzureAppInsightTutorial.Controllers
{
    public class HomeController : Controller
    {
        private TelemetryClient _telemetry;
        public HomeController()
        {
            _telemetry = new TelemetryClient();
        }

        public ActionResult Index()
        {
            ViewBag.SampleVariable = ConfigurationManager.AppSettings["SampleVariable"];
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            throw new Exception("Test");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Track()
        {
            _telemetry.TrackEvent("Win");
            return RedirectToAction("Index");
        }
    }
}
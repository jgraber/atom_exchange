using AtomProducer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AtomProducer.Controllers
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

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            
            return View();
        }

        public ActionResult Feed()
        {
            FeedCreator feedCreator = new FeedCreator();
            var feed = feedCreator.CreateFeed(true);
            return new AtomActionResult(feed);
        }

        // Use http://rehansaeed.com/building-rssatom-feeds-for-asp-net-mvc/ as template
    }
}
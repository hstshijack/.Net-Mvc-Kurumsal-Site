using KurumsalSite.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurumsalSite.Controllers
{
    public class HomeController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            ViewBag.Services = db.Services.ToList().OrderByDescending(x => x.Id);
            ViewBag.Contact = db.Contacts.SingleOrDefault();
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
        public PartialViewResult ServicesPartial()
        {

            return PartialView(db.Services.ToList());
        }
        public ActionResult Services()
        {
            ViewBag.Services = db.Services.ToList().OrderByDescending(x => x.Id);
            ViewBag.Contact = db.Contacts.SingleOrDefault();
            return View(db.Services.ToList());
        }
    }
}
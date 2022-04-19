using KurumsalSite.Models;
using KurumsalSite.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurumsalSite.Controllers.Admin
{
    public class AdminController : Controller
    {
        Context db= new Context();
        // GET: AdminDefault
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Default()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AdminEntity admin)
        {
            var login=db.Admin.Where(x=>x.Mail==admin.Mail && x.Password==admin.Password).SingleOrDefault();
            if(login!=null && login.Mail==admin.Mail && login.Password==admin.Password)
            {
                Session["AdminId"] = login.AdminId;
                Session["Eposta"] = login.Mail;
                return RedirectToAction("Default", "Admin");
            }
            ViewBag.Warning = "Kullanıcı adı veya şifre yanlış";

            return View(admin);
        }
        public ActionResult Logout()
        {
            Session["AdminId"] = null;
            Session["Eposta"] = null;
            Session.Abandon();
            return RedirectToAction("Login", "Admin");
            
        }

    }
}
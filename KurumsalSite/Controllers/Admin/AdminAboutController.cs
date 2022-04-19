using KurumsalSite.Models;
using KurumsalSite.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KurumsalSite.Controllers.Admin
{
    public class AdminAboutController : Controller
    {
         Context db=new Context();
        // GET: AdminAbout
        public ActionResult Index()
        {
            var AboutData = db.Abouts.ToList();
            return View(AboutData);
        }

        // GET: AdminAbout/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminAbout/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminAbout/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminAbout/Edit/5
        public ActionResult Edit(int id)
        {
            var AboutData=db.Abouts.Where(x=>x.Id==id).FirstOrDefault();

            return View(AboutData);
        }

        // POST: AdminAbout/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, About about)
        {
            if (ModelState.IsValid)
            {
                var aboutData=db.Abouts.Where(x=>x.Id == id).SingleOrDefault();
                aboutData.Description=about.Description;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: AdminAbout/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminAbout/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

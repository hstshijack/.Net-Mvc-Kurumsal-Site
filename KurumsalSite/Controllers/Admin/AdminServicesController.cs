using KurumsalSite.Models;
using KurumsalSite.Models.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace KurumsalSite.Controllers.Admin
{
    public class AdminServicesController : Controller
    {
        private Context db = new Context();

        // GET: AdminServices
        public ActionResult Index()
        {
            return View(db.Services.ToList());
        }

        // GET: AdminServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // GET: AdminServices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Ttle,Description,PictureUrl")] Service service, HttpPostedFileBase PictureURL)
        {
            if (ModelState.IsValid)
            {
                if (PictureURL != null)
                {

                    WebImage img = new WebImage(PictureURL.InputStream);
                    FileInfo imgInfo = new FileInfo(PictureURL.FileName);

                    string logoName = PictureURL.FileName + imgInfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Services/" + logoName);
                    service.PictureUrl = "/Uploads/Services/" + logoName;

                }
                db.Services.Add(service);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(service);
        }

        // GET: AdminServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: AdminServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id,[Bind(Include = "Id,Ttle,Description,PictureUrl")] Service service, HttpPostedFileBase PictureURL)
        {

            if(ModelState.IsValid)
            {
                var ServicesData = db.Services.Where(x => x.Id == id).SingleOrDefault();
                if (PictureURL != null)
                {
                   
                    WebImage img = new WebImage(PictureURL.InputStream);
                    FileInfo imgInfo = new FileInfo(PictureURL.FileName);

                    string logoName = PictureURL.FileName + imgInfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/Services/" + logoName);
                    ServicesData.PictureUrl = "/Uploads/Services/" + logoName;

                }
                ServicesData.Description = service.Description;
                ServicesData.Ttle=service.Ttle;
                db.SaveChanges();
                return RedirectToAction("Index");

               
            }

            return View(service);
        }
    

        // GET: AdminServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Service service = db.Services.Find(id);
            if (service == null)
            {
                return HttpNotFound();
            }
            return View(service);
        }

        // POST: AdminServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Service service = db.Services.Find(id);
            db.Services.Remove(service);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

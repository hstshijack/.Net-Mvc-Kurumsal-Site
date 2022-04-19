using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using KurumsalSite.Models;
using KurumsalSite.Models.Context;

namespace KurumsalSite.Controllers.Admin
{
    public class SlidersController : Controller
    {
        private Context db = new Context();

        // GET: Sliders
        public ActionResult Index()
        {
            return View(db.Sliders.ToList());
        }

        // GET: Sliders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // GET: Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sliders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SliderId,Title,Description,PictureUrl")] Slider slider,HttpPostedFileBase PictureURL)
        {
            if (ModelState.IsValid)
            {
                if (PictureURL != null)
                {

                    WebImage img = new WebImage(PictureURL.InputStream);
                    FileInfo imgInfo = new FileInfo(PictureURL.FileName);

                    string logoName = PictureURL.FileName + imgInfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Slider/" + logoName);
                    slider.PictureUrl = "/Uploads/Slider/" + logoName;

                }
                db.Sliders.Add(slider);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slider);
        }

        // GET: Sliders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Sliders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,[Bind(Include = "SliderId,Title,Description,PictureUrl")] Slider slider, HttpPostedFileBase PictureURL)
        {
            if (ModelState.IsValid)
            {
                var SliderData = db.Sliders.Where(x => x.SliderId == id).SingleOrDefault();
                if (PictureURL != null)
                {

                    WebImage img = new WebImage(PictureURL.InputStream);
                    FileInfo imgInfo = new FileInfo(PictureURL.FileName);

                    string logoName = PictureURL.FileName + imgInfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/Slider/" + logoName);
                     SliderData.PictureUrl= "/Uploads/Slider/" + logoName;

                }
                SliderData.Title=slider.Title;
                SliderData.Description=slider.Description;            
            
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slider);
        }

        // GET: Sliders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slider slider = db.Sliders.Find(id);
            if (slider == null)
            {
                return HttpNotFound();
            }
            return View(slider);
        }

        // POST: Sliders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slider slider = db.Sliders.Find(id);
            db.Sliders.Remove(slider);
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

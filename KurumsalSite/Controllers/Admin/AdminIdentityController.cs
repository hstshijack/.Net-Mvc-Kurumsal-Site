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
    public class AdminIdentityController : Controller
    {
        Context db=new Context();
        // GET: AdminIdentity
        public ActionResult Index()
        {
            return View(db.Identities.ToList());
        }

        // GET: AdminIdentity/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Identity identity = db.Identities.Find(id);
            if (identity == null)
            {
                return HttpNotFound();
            }
            return View(identity);
        }

        // GET: AdminIdentity/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminIdentity/Create
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

        // GET: AdminIdentity/Edit/5
      
        public ActionResult Edit(int id)
        {
            var identity = db.Identities.FirstOrDefault(x => x.Id == id);
            return View(identity);
        }

        // POST: AdminIdentity/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, Identity identity,HttpPostedFileBase LogoURL)
        {
           if(ModelState.IsValid)
            {
                var identityData=db.Identities.Where(x=>x.Id == id).SingleOrDefault();
                if(LogoURL !=null)
                {
                    if(System.IO.File.Exists(Server.MapPath(identityData.LogoURL)))
                    {
                        System.IO.File.Delete(Server.MapPath(identityData.LogoURL));
                    }
                    WebImage img = new WebImage(LogoURL.InputStream);
                    FileInfo imgInfo = new FileInfo(LogoURL.FileName);

                    string logoName = LogoURL.FileName+imgInfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/Identity/" + logoName);
                    identityData.LogoURL = "/Uploads/Identity/" + logoName;

                }
                identityData.Title = identity.Title;
                identityData.Description = identity.Description;
                identityData.Keywords = identity.Keywords;
                identityData.SiteTitle = identity.SiteTitle;
                db.SaveChanges();
                return  RedirectToAction("Index");
            }
           return View(identity);
        }

        // GET: AdminIdentity/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminIdentity/Delete/5
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

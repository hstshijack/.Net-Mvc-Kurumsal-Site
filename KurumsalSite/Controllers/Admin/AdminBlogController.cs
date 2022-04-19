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
    public class AdminBlogController : Controller
    {
        private Context db = new Context();

        // GET: AdminBlog
        public ActionResult Index()
        {
            var blogs = db.Blogs.Include(b => b.category);
            return View(blogs.ToList());
        }

        // GET: AdminBlog/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            blog.category = db.Categories.Where(x => x.CategoryId == blog.CategoryId).FirstOrDefault();
            return View(blog);
        }

        // GET: AdminBlog/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name");
            return View();
        }

        // POST: AdminBlog/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "Id,Title,Content,PictureURL,CategoryId")] Blog blog, HttpPostedFileBase PictureURL)
        {
            if (ModelState.IsValid)
            {
                if (PictureURL != null)
                {

                    WebImage img = new WebImage(PictureURL.InputStream);
                    FileInfo imgInfo = new FileInfo(PictureURL.FileName);

                    string logoName = PictureURL.FileName + imgInfo.Extension;
                    img.Resize(500, 500);
                    img.Save("~/Uploads/Blog/" + logoName);
                    blog.PictureURL = "/Uploads/Blog/" + logoName;

                }
                db.Blogs.Add(blog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", blog.CategoryId);
            return View(blog);
        }

        // GET: AdminBlog/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", blog.CategoryId);
            blog.category=db.Categories.Where(x=>x.CategoryId==blog.CategoryId).FirstOrDefault();
            return View(blog);
        }

        // POST: AdminBlog/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(int id, [Bind(Include = "Id,Title,Content,PictureURL,CategoryId")] Blog blog, HttpPostedFileBase PictureURL)
        {
            if (ModelState.IsValid)
            {
                var BlogData = db.Blogs.Where(x => x.Id == id).SingleOrDefault();
                if (PictureURL != null)
                {

                    WebImage img = new WebImage(PictureURL.InputStream);
                    FileInfo imgInfo = new FileInfo(PictureURL.FileName);

                    string logoName = PictureURL.FileName + imgInfo.Extension;
                    img.Resize(300, 200);
                    img.Save("~/Uploads/Blog/" + logoName);
                    BlogData.PictureURL = "/Uploads/Blog/" + logoName;

                }
                BlogData.CategoryId = blog.CategoryId;
                BlogData.Title = blog.Title;
                BlogData.Content = blog.Content;               
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "Name", blog.CategoryId);
            return View(blog);
        }

        // GET: AdminBlog/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            blog.category = db.Categories.Where(x => x.CategoryId == blog.CategoryId).FirstOrDefault();
            return View(blog);
        }

        // POST: AdminBlog/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
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

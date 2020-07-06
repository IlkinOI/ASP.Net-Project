using EduHomeAspProject.Areas.Admin.Filter;
using EduHomeAspProject.DAL;
using EduHomeAspProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduHomeAspProject.Areas.Admin.Controllers
{
    [FilterAdmin]
    public class BlogController : Controller
    {
        // GET: Admin/Blog
        EduHomeContext db = new EduHomeContext();

        // Blog Category CRUD starts
        public ActionResult BlogCategoryIndex()
        {
            List<BlogCategory> bcs = db.BlogCategories.ToList();
            return View(bcs);
        }
        public ActionResult BlogCategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult BlogCategoryCreate(BlogCategory bc)
        {
            if (ModelState.IsValid)
            {
                db.BlogCategories.Add(bc);
                db.SaveChanges();

                return RedirectToAction("BlogCategoryIndex");
            }

            return View(bc);
        }

        public ActionResult BlogCategoryUpdate(int id)
        {
            BlogCategory bc = db.BlogCategories.Find(id);
            if (bc == null)
            {
                return HttpNotFound();
            }

            return View(bc);
        }

        [HttpPost]
        public ActionResult BlogCategoryUpdate(BlogCategory bc)
        {
            if (ModelState.IsValid)
            {

                db.Entry(bc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("BlogCategoryIndex");
            }

            return View(bc);
        }

        public ActionResult BlogCategoryDelete(int id)
        {
            BlogCategory bc = db.BlogCategories.Find(id);
            if (bc == null)
            {
                return HttpNotFound();
            }

            db.BlogCategories.Remove(bc);
            db.SaveChanges();

            return RedirectToAction("BlogCategoryIndex");
        }

        //Blog Category CRUD ends

        //Blogs CRUD starts

        public ActionResult Index()
        {
            List<Blog> blogs = db.Blogs.Include("BlogCategory").Include("User").ToList();
            return View(blogs);
        }
        
        public ActionResult Update(int id)
        {
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.BlogCategories.ToList();
            return View(blog);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Blog blog)
        {
            if (ModelState.IsValid)
            {
                Blog blogg = db.Blogs.Find(blog.Id);

                if (blog.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string OldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), blogg.Image);
                    System.IO.File.Delete(OldImagePath);

                    blog.ImageFile.SaveAs(imagePath);
                    blogg.Image = imageName;
                }

                blogg.Title = blog.Title;
                blogg.BlogCategoryId = blog.BlogCategoryId;
                blogg.UserId = blog.UserId;
                blogg.Content = blog.Content;

                db.Entry(blogg).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categories = db.BlogCategories.ToList();
            return View(blog);
        }

        public ActionResult Delete(int id)
        {
            Blog blog = db.Blogs.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }

            db.Blogs.Remove(blog);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
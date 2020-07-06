using EduHomeAspProject.Areas.Admin.Filter;
using EduHomeAspProject.DAL;
using EduHomeAspProject.Models;
using EduHomeAspProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace EduHomeAspProject.Controllers
{
    
    public class BlogController : Controller
    {
        // GET: Blog
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index(int page = 1)
        {
            ViewBag.Blog = true;
            VMBlog model = new VMBlog();
            model.BGImage = db.BGImages.FirstOrDefault(b => b.Page == "Blog");
            model.Categories = db.BlogCategories.ToList();
            model.Blogs = db.Blogs.Include("BlogCategory").Include("User").OrderByDescending(o=>o.Id).Skip((page-1)*4).Take(4).ToList();
            model.PageCount = Convert.ToInt32(Math.Ceiling(db.Blogs.Count()/4.0));
            model.CurrentPage = page;
            model.LatestBlogs = db.Blogs.Include("BlogCategory").Include("User").OrderByDescending(t => t.Id).Take(3).ToList();
            model.Common = db.Commons.FirstOrDefault();
            model.Messages = db.Messages.Include("Blog").Include("User").ToList();
            return View(model);
        }
        public ActionResult BlogDetails(int id)
        {
            VMBlogDetail model = new VMBlogDetail();
            model.Blogs = db.Blogs.ToList();
            model.BGImage = db.BGImages.FirstOrDefault(c => c.Page == "BlogDetails");
            model.Blog = db.Blogs.Include("User").FirstOrDefault(e => e.Id == id);
            model.LatestBlogs = db.Blogs.Include("BlogCategory").Include("User").OrderByDescending(t => t.Id).Take(3).ToList();
            model.Common = db.Commons.FirstOrDefault();
            model.Categories = db.BlogCategories.ToList();
            return View(model);
        }
        
        public ActionResult BlogPanelIndex()
        {
            List<Blog> blogs = db.Blogs.Include("User").ToList();
            ViewBag.Categories = db.BlogCategories.ToList();
            return View(blogs);
        }
        public ActionResult Create(int? id)
        {
            ViewBag.Categories = db.BlogCategories.ToList();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Blog blog)
        {
            if (ModelState.IsValid)
            {
                if (blog.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(blog);
                }
                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + blog.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                blog.ImageFile.SaveAs(imagePath);
                blog.Image = imageName;

                blog.CreatedDate = DateTime.Now;
                blog.UserId = (int)Session["userId"];

                db.Blogs.Add(blog);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Categories = db.BlogCategories.ToList();
            return View(blog);
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
        public ActionResult Search(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Searched= db.Blogs.Where(s => s.Title.Contains(search)).ToList();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
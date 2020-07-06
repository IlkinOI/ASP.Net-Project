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
    public class CourseController : Controller
    {
        // GET: Admin/Course
        EduHomeContext db = new EduHomeContext();

        // Course Category CRUD starts
        public ActionResult CourseCategoryIndex()
        {
            List<CourseCategory> cats = db.CourseCategories.ToList();
            return View(cats);
        }
        public ActionResult CourseCategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CourseCategoryCreate(CourseCategory cat)
        {
            if (ModelState.IsValid)
            {
                db.CourseCategories.Add(cat);
                db.SaveChanges();

                return RedirectToAction("CourseCategoryIndex");
            }

            return View(cat);
        }

        public ActionResult CourseCategoryUpdate(int id)
        {
            CourseCategory cat = db.CourseCategories.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }

            return View(cat);
        }

        [HttpPost]
        public ActionResult CourseCategoryUpdate(CourseCategory cat)
        {
            if (ModelState.IsValid)
            {

                db.Entry(cat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CourseCategoryIndex");
            }

            return View(cat);
        }

        public ActionResult CourseCategoryDelete(int id)
        {
            CourseCategory cat = db.CourseCategories.Find(id);
            if (cat == null)
            {
                return HttpNotFound();
            }

            db.CourseCategories.Remove(cat);
            db.SaveChanges();

            return RedirectToAction("CourseCategoryIndex");
        }

        //Course Category CRUD ends

        //Course CRUD starts

        public ActionResult Index()
        {
            List<Course> courses = db.Courses.Include("CourseCategory").ToList();
            return View(courses);
        }
        public ActionResult Create()
        {
            ViewBag.Categories = db.CourseCategories.ToList();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                if (course.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(course);
                }
                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + course.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                course.ImageFile.SaveAs(imagePath);
                course.Image = imageName;
                course.CreatedDate = DateTime.Now;
                db.Courses.Add(course);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Categories = db.CourseCategories.ToList();
            return View(course);
        }
        public ActionResult Update(int id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.Categories = db.CourseCategories.ToList();
            return View(course);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Course course)
        {
            if (ModelState.IsValid)
            {
                Course cou = db.Courses.Find(course.Id);

                if (course.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + course.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), cou.Image);
                    System.IO.File.Delete(oldImagePath);

                    course.ImageFile.SaveAs(imagePath);
                    cou.Image = imageName;
                }
                cou.Name = course.Name;
                cou.Content = course.Content;
                cou.Link = course.Link;
                cou.StartDate = course.StartDate;
                cou.CourseDuration = course.CourseDuration;
                cou.ClassDuration = course.ClassDuration;
                cou.SkillLevel = course.SkillLevel;
                cou.Language = course.Language;
                cou.StudentsCount = course.StudentsCount;
                cou.Assessments = course.Assessments;
                cou.CourseCategoryId = course.CourseCategoryId;

                db.Entry(cou).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Categories = db.CourseCategories.ToList();
            return View(course);
        }

        public ActionResult Delete(int id)
        {
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }

            db.Courses.Remove(course);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
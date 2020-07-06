using EduHomeAspProject.DAL;
using EduHomeAspProject.Models;
using EduHomeAspProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduHomeAspProject.Controllers
{
    public class CourseController : Controller
    {
        // GET: Course
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            ViewBag.Courses = true;
            VMCourse coursemodel = new VMCourse();
            coursemodel.BGImage = db.BGImages.FirstOrDefault(b => b.Page == "Course");
            coursemodel.Courses = db.Courses.ToList();
            return View(coursemodel);
        }
        public ActionResult CourseDetails(int id)
        {
            VMCourseDetail model = new VMCourseDetail();
            model.Courses = db.Courses.ToList();
            model.Course = db.Courses.FirstOrDefault(e => e.Id == id);
            model.BGImage = db.BGImages.FirstOrDefault(b => b.Page == "CourseDetails");
            model.LatestBlogs = db.Blogs.Include("BlogCategory").Include("User").OrderByDescending(t => t.Id).Take(3).ToList();
            model.Common = db.Commons.FirstOrDefault();
            model.Categories = db.CourseCategories.ToList();
            return View(model);
        }
        public ActionResult Search(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Searched = db.Courses.Where(s => s.Name.Contains(search)).ToList();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
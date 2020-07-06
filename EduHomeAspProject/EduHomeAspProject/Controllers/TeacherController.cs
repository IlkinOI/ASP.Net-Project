using EduHomeAspProject.DAL;
using EduHomeAspProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduHomeAspProject.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            ViewBag.Teacher = true;
            VMTeacher model = new VMTeacher();
            model.BGImage = db.BGImages.FirstOrDefault(b => b.Page == "Teacher");
            model.Teachers = db.Teachers.Include("Position").ToList();
            model.SocialTeachers = db.SocialTeachers.ToList();
            return View(model);
        }
        public ActionResult TeacherDetails(int id)
        {
            VMTeacherDetail model = new VMTeacherDetail();
            model.Teacher = db.Teachers.FirstOrDefault(e => e.Id == id);
            model.SocialTeachers = db.SocialTeachers.Include("Teacher").Where(v => v.TeacherId == id).ToList();
            model.TeacherSkills = db.TeacherSkills.Include("Skill").Where(v => v.TeacherId == id).ToList();
            model.BGImage = db.BGImages.FirstOrDefault(b => b.Page == "TeacherDetails");
            return View(model);
        }
        public ActionResult Search(string search)
        {
            if (!string.IsNullOrEmpty(search))
            {
                ViewBag.Searched = db.Teachers.Where(s => s.Fullname.Contains(search)).ToList();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
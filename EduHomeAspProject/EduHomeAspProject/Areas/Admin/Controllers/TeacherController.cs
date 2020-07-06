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
    public class TeacherController : Controller
    {
        // GET: Admin/Teacher
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            List<Teacher> teachers = db.Teachers.Include("Position").ToList();
            return View(teachers);
        }
        public ActionResult Create()
        {
            ViewBag.Positions = db.Positions.ToList();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                if (teacher.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(teacher);
                }
                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + teacher.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                teacher.ImageFile.SaveAs(imagePath);
                teacher.Image = imageName;
                db.Teachers.Add(teacher);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Positions = db.Positions.ToList();
            return View(teacher);
        }
        public ActionResult Update(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.Positions = db.Positions.ToList();
            return View(teacher);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                Teacher teach = db.Teachers.Find(teacher.Id);

                if (teacher.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + teacher.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), teach.Image);
                    System.IO.File.Delete(oldImagePath);

                    teacher.ImageFile.SaveAs(imagePath);
                    teach.Image = imageName;
                }
                teach.Fullname = teacher.Fullname;
                teach.About = teacher.About;
                teach.Degree = teacher.Degree;
                teach.Experience = teacher.Experience;
                teach.Hobbies = teacher.Hobbies;
                teach.Faculty = teacher.Faculty;
                teach.Email = teacher.Email;
                teach.Phone = teacher.Phone;
                teach.Skype = teacher.Skype;

                db.Entry(teach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Positions = db.Positions.ToList();
            return View(teacher);
        }

        public ActionResult Delete(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }

            db.Teachers.Remove(teacher);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
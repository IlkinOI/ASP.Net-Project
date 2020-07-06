using EduHomeAspProject.Areas.Admin.Filter;
using EduHomeAspProject.DAL;
using EduHomeAspProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduHomeAspProject.Areas.Admin.Controllers
{
    [FilterAdmin]
    public class TeacherSkillController : Controller
    {
        // GET: Admin/TeacherSkill
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            List<TeacherSkill> shares = db.TeacherSkills.Include("Teacher").Include("Skill").ToList();
            return View(shares);
        }
        public ActionResult Create()
        {
            ViewBag.Teachers = db.Teachers.ToList();
            ViewBag.Skills = db.Skills.ToList();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(TeacherSkill ts)
        {
            if (ModelState.IsValid)
            {
                db.TeacherSkills.Add(ts);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Teachers = db.Teachers.ToList();
            ViewBag.Skills = db.Skills.ToList();
            return View(ts);
        }

        public ActionResult Update(int id)
        {
            TeacherSkill ts = db.TeacherSkills.Find(id);
            if (ts == null)
            {
                return HttpNotFound();
            }
            ViewBag.Teachers = db.Teachers.ToList();
            ViewBag.Skills = db.Skills.ToList();

            return View(ts);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(TeacherSkill ts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Teachers = db.Teachers.ToList();
            ViewBag.Skills = db.Skills.ToList();
            return View(ts);
        }

        public ActionResult Delete(int id)
        {
            TeacherSkill ts = db.TeacherSkills.Find(id);
            if (ts == null)
            {
                return HttpNotFound();
            }

            db.TeacherSkills.Remove(ts);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
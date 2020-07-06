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
    public class SkillController : Controller
    {
        // GET: Admin/Skill
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            List<Skill> skills = db.Skills.ToList();
            return View(skills);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Skill skill)
        {
            if (ModelState.IsValid)
            {
                db.Skills.Add(skill);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(skill);
        }

        public ActionResult Update(int id)
        {
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }

            return View(skill);
        }

        [HttpPost]
        public ActionResult Update(Skill skill)
        {
            if (ModelState.IsValid)
            {
                Skill skil = db.Skills.Find(skill.Id);

                db.Entry(skil).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(skill);
        }

        public ActionResult Delete(int id)
        {
            Skill skill = db.Skills.Find(id);
            if (skill == null)
            {
                return HttpNotFound();
            }

            db.Skills.Remove(skill);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
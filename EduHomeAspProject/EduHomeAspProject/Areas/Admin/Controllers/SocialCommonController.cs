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
    public class SocialCommonController : Controller
    {
        // GET: Admin/SocialCommon
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            List<SocialCommon> socials = db.SocialCommons.Include("Common").ToList();
            return View(socials);
        }
        public ActionResult Create()
        {
            ViewBag.Common = db.Commons.ToList();
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(SocialCommon social)
        {
            if (ModelState.IsValid)
            {
                db.SocialCommons.Add(social);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.Common = db.Commons.ToList();
            return View(social);
        }

        public ActionResult Update(int id)
        {
            SocialCommon social = db.SocialCommons.Find(id);
            if (social == null)
            {
                return HttpNotFound();
            }
            ViewBag.Common = db.Commons.ToList();

            return View(social);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update(SocialCommon social)
        {
            if (ModelState.IsValid)
            {
                db.Entry(social).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Common = db.Commons.ToList();
            return View(social);
        }

        public ActionResult Delete(int id)
        {
            SocialCommon social = db.SocialCommons.Find(id);
            if (social == null)
            {
                return HttpNotFound();
            }

            db.SocialCommons.Remove(social);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
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
    public class PositionController : Controller
    {
        // GET: Admin/Position
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            List<Position> positions = db.Positions.ToList();
            return View(positions);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Position position)
        {
            if (ModelState.IsValid)
            {
                db.Positions.Add(position);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(position);
        }

        public ActionResult Update(int id)
        {
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }

            return View(position);
        }

        [HttpPost]
        public ActionResult Update(Position position)
        {
            if (ModelState.IsValid)
            {
                Position pos = db.Positions.Find(position.Id);

                db.Entry(pos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(position);
        }

        public ActionResult Delete(int id)
        {
            Position position = db.Positions.Find(id);
            if (position == null)
            {
                return HttpNotFound();
            }

            db.Positions.Remove(position);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
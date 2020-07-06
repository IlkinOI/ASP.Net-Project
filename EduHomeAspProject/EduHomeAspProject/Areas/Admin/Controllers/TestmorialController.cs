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
    public class TestmorialController : Controller
    {
        // GET: Admin/Testmorial
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            List<TestMorial> tests = db.TestMorials.ToList();
            return View(tests);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TestMorial test)
        {
            if (ModelState.IsValid)
            {
                if (test.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(test);
                }
                if (test.ImageBGFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(test);
                }
                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + test.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                string imageBGName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + test.ImageBGFile.FileName;
                string imageBGPath = Path.Combine(Server.MapPath("~/Uploads/"), imageBGName);

                test.ImageFile.SaveAs(imagePath);
                test.Image = imageName;

                test.ImageBGFile.SaveAs(imageBGPath);
                test.ImageBG = imageBGName;

                db.TestMorials.Add(test);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(test);
        }

        public ActionResult Update(int id)
        {
            TestMorial test = db.TestMorials.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }

            return View(test);
        }

        [HttpPost]
        public ActionResult Update(TestMorial test)
        {
            if (ModelState.IsValid)
            {
                TestMorial morial = db.TestMorials.Find(test.Id);

                if (test.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + test.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldImagePath = Path.Combine(Server.MapPath("~/Uploads/"), morial.Image);
                    System.IO.File.Delete(oldImagePath);

                    test.ImageFile.SaveAs(imagePath);
                    morial.Image = imageName;
                }
                if (test.ImageBGFile != null)
                {
                    string imageBGName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + test.ImageBGFile.FileName;
                    string imageBGPath = Path.Combine(Server.MapPath("~/Uploads/"), imageBGName);

                    string oldImageBGPath = Path.Combine(Server.MapPath("~/Uploads/"), morial.ImageBG);
                    System.IO.File.Delete(oldImageBGPath);

                    test.ImageBGFile.SaveAs(imageBGPath);
                    test.ImageBG = imageBGName;
                }
                morial.Text = test.Text;
                morial.Fullname = test.Fullname;
                morial.Occupation = test.Occupation;

                db.Entry(morial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(test);
        }

        public ActionResult Delete(int id)
        {
            TestMorial test = db.TestMorials.Find(id);
            if (test == null)
            {
                return HttpNotFound();
            }

            db.TestMorials.Remove(test);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
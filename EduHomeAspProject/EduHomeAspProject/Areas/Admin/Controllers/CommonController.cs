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
    public class CommonController : Controller
    {
        // GET: Admin/Common
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            List<Common> commons = db.Commons.ToList();
            return View(commons);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Common common)
        {
            if (ModelState.IsValid)
            {
                if (common.LogoFooterFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(common);
                }
                string LogoFooterName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + common.LogoFooterFile.FileName;
                string LogoFooterPath = Path.Combine(Server.MapPath("~/Uploads/"), LogoFooterName);

                common.LogoFooterFile.SaveAs(LogoFooterPath);
                common.LogoFooter = LogoFooterName;

                if (common.LogoHeaderFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(common);
                }
                string LogoHeaderName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + common.LogoHeaderFile.FileName;
                string LogoHeaderPath = Path.Combine(Server.MapPath("~/Uploads/"), LogoHeaderName);

                common.LogoHeaderFile.SaveAs(LogoHeaderPath);
                common.LogoHeader = LogoHeaderName;

                if (common.BookLogoWhiteFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(common);
                }
                string BookLogoWhiteName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + common.BookLogoWhiteFile.FileName;
                string BookLogoWhitePath = Path.Combine(Server.MapPath("~/Uploads/"), BookLogoWhiteName);

                common.BookLogoWhiteFile.SaveAs(BookLogoWhitePath);
                common.BookLogoWhite = BookLogoWhiteName;

                if (common.BookLogoRedFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(common);
                }
                string BookLogoRedName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + common.BookLogoRedFile.FileName;
                string BookLogoRedPath = Path.Combine(Server.MapPath("~/Uploads/"), BookLogoRedName);

                common.BookLogoRedFile.SaveAs(BookLogoRedPath);
                common.BookLogoRed = BookLogoRedName;

                if (common.ImageVBGFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(common);
                }
                string imageVBGName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + common.ImageVBGFile.FileName;
                string imageVBGPath = Path.Combine(Server.MapPath("~/Uploads/"), imageVBGName);

                common.ImageVBGFile.SaveAs(imageVBGPath);
                common.ImageVBG = imageVBGName;

                if (common.ImageFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(common);
                }
                string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + common.ImageFile.FileName;
                string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                common.ImageFile.SaveAs(imagePath);
                common.Image = imageName;

                db.Commons.Add(common);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(common);
        }

        public ActionResult Update(int id)
        {
            Common common = db.Commons.Find(id);
            if (common == null)
            {
                return HttpNotFound();
            }

            return View(common);
        }

        [HttpPost]
        public ActionResult Update(Common common)
        {
            if (ModelState.IsValid)
            {
                Common com = db.Commons.Find(common.Id);
                if (common.LogoFooterFile != null)
                {
                    string LogoFooterName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + common.LogoFooterFile.FileName;
                    string LogoFooterPath = Path.Combine(Server.MapPath("~/Uploads/"), LogoFooterName);

                    string oldLogoFooterPath = Path.Combine(Server.MapPath("~/Uploads/"), com.LogoFooter);
                    System.IO.File.Delete(LogoFooterPath);

                    common.LogoFooterFile.SaveAs(LogoFooterPath);
                    common.LogoFooter = LogoFooterName;
                }
                if (common.LogoHeaderFile != null)
                {
                    string LogoHeaderName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + common.LogoHeaderFile.FileName;
                    string LogoHeaderPath = Path.Combine(Server.MapPath("~/Uploads/"), LogoHeaderName);

                    string oldLogoHeaderPath = Path.Combine(Server.MapPath("~/Uploads/"), com.LogoHeader);
                    System.IO.File.Delete(oldLogoHeaderPath);

                    common.LogoHeaderFile.SaveAs(LogoHeaderPath);
                    common.LogoHeader = LogoHeaderName;
                }

                if (common.BookLogoWhiteFile != null)
                {
                    string BookLogoWhiteName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + common.BookLogoWhiteFile.FileName;
                    string BookLogoWhitePath = Path.Combine(Server.MapPath("~/Uploads/"), BookLogoWhiteName);

                    string oldBookLogoWhitePath = Path.Combine(Server.MapPath("~/Uploads/"), com.BookLogoWhite);
                    System.IO.File.Delete(BookLogoWhitePath);

                    common.BookLogoWhiteFile.SaveAs(BookLogoWhitePath);
                    common.BookLogoWhite = BookLogoWhiteName;
                }
                if (common.BookLogoRedFile != null)
                {
                    string BookLogoRedName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + common.BookLogoRedFile.FileName;
                    string BookLogoRedPath = Path.Combine(Server.MapPath("~/Uploads/"), BookLogoRedName);

                    string oldBookLogoRedPath = Path.Combine(Server.MapPath("~/Uploads/"), com.BookLogoRed);
                    System.IO.File.Delete(BookLogoRedPath);

                    common.BookLogoRedFile.SaveAs(BookLogoRedPath);
                    common.BookLogoRed = BookLogoRedName;
                }
                if (common.ImageVBGFile != null)
                {
                    string imageVBGName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + common.ImageVBGFile.FileName;
                    string imageVBGPath = Path.Combine(Server.MapPath("~/Uploads/"), imageVBGName);

                    string oldimageVBGPath = Path.Combine(Server.MapPath("~/Uploads/"), com.ImageVBG);
                    System.IO.File.Delete(imageVBGPath);

                    common.ImageVBGFile.SaveAs(imageVBGPath);
                    common.ImageVBG = imageVBGName;
                }
                if (common.ImageFile != null)
                {
                    string imageName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + common.ImageFile.FileName;
                    string imagePath = Path.Combine(Server.MapPath("~/Uploads/"), imageName);

                    string oldimagePath = Path.Combine(Server.MapPath("~/Uploads/"), com.Image);
                    System.IO.File.Delete(imagePath);

                    common.ImageFile.SaveAs(imagePath);
                    common.Image = imageName;
                }
                com.Address = common.Address;
                com.Phone1 = common.Phone1;
                com.Phone2 = common.Phone2;
                com.Email = common.Email;
                com.Site = common.Site;
                com.Video = common.Video;
                com.Slogan = common.Slogan;

                db.Entry(com).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(common);
        }

        public ActionResult Delete(int id)
        {
            Common common = db.Commons.Find(id);
            if (common == null)
            {
                return HttpNotFound();
            }

            db.Commons.Remove(common);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
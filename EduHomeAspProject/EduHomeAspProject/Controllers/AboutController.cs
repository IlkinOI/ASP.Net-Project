using EduHomeAspProject.DAL;
using EduHomeAspProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EduHomeAspProject.Controllers
{
    public class AboutController : Controller
    {
        EduHomeContext db = new EduHomeContext();
        // GET: About
        public ActionResult Index()
        {
            VMAbout aboutmodel = new VMAbout();
            aboutmodel.BgImage = db.BGImages.FirstOrDefault(b => b.Page == "About");
            aboutmodel.Teachers = db.Teachers.Include("Position").OrderBy(t => t.Id).Take(4).ToList();
            aboutmodel.SocialsT = db.SocialTeachers.ToList();
            aboutmodel.Common = db.Commons.FirstOrDefault();
            aboutmodel.About = db.Abouts.FirstOrDefault();
            aboutmodel.TestMorials = db.TestMorials.ToList();
            aboutmodel.TestMorial = db.TestMorials.FirstOrDefault();
            aboutmodel.Events = db.Events.ToList();
            return View(aboutmodel);
        }
    }
}
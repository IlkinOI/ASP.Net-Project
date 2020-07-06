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
    public class ContactController : Controller
    {
        // GET: Contact
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            VMContact model = new VMContact();
            model.Contact = db.Contacts.FirstOrDefault();
            model.BGImage = db.BGImages.FirstOrDefault(b => b.Page == "Contact");
            return View(model);
        }
    }
}
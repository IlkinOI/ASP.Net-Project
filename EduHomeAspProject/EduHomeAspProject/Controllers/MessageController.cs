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
    public class MessageController : Controller
    {
        EduHomeContext db = new EduHomeContext();
        // GET: Message
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Reply(VMMessage message)
        {
            if (string.IsNullOrEmpty(message.Name) || string.IsNullOrEmpty(message.Email) ||
                string.IsNullOrEmpty(message.Subject) || string.IsNullOrEmpty(message.Text))
            {
                Session["EmptyMail"] = true;
                if (message.Page == "CourseDetails")
                {
                    return RedirectToAction("CourseDetails", "Course", new { id = message.ContactId });
                }
                else if (message.Page == "EventDetails")
                {
                    return RedirectToAction("EventDetails", "Event", new { id = message.EventId });
                }
                else if (message.Page == "BlogDetails")
                {
                    return RedirectToAction("BlogDetails", "Blog", new { id = message.BlogId });
                }
                else
                {
                    return RedirectToAction("Index", "Contact");
                }
            }
            if (Session["User"]!=null)
            {
                Message mes = new Message();

                mes.Name = message.Name;
                mes.Email = message.Email;
                mes.Subject = message.Subject;
                mes.Text = message.Text;
                mes.UserId = message.UserId;
                mes.EventId = message.EventId;
                mes.CourseId = message.CourseId;
                mes.ContactId = message.ContactId;
                mes.CreatedDate = DateTime.Now;
                db.Messages.Add(mes);
                db.SaveChanges();

                Session["Sent"] = true;

                if (message.Page == "CourseDetails")
                {
                    return RedirectToAction("CourseDetails", "Course", new { id = message.ContactId });
                }
                else if (message.Page == "EventDetails")
                {
                    return RedirectToAction("EventDetails", "Event", new { id = message.EventId });
                }
                else if (message.Page == "BlogDetails")
                {
                    return RedirectToAction("BlogDetails", "Blog", new { id = message.BlogId });
                }
                else
                {
                    return RedirectToAction("Index", "Contact");
                }

            }

            return RedirectToAction("Login","Login");
        }
    }
}
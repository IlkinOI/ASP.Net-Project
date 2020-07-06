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
    public class SubscribeController : Controller
    {
        // GET: Subscribe
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Subscribe(VMSubscribe subscribe)
        {
            if (string.IsNullOrEmpty(subscribe.Email))
            {
                Session["Empty"] = true;
                if (subscribe.Page == "Home")
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (subscribe.Page == "About")
                {
                    return RedirectToAction("Index", "About");
                }
                else if (subscribe.Page == "Course")
                {
                    return RedirectToAction("Index", "Course");
                }
                else if (subscribe.Page == "CourseDetails")
                {
                    return RedirectToAction("CourseDetails", "Course", new { id = subscribe.pagedetailId });
                }
                else if (subscribe.Page == "Event")
                {
                    return RedirectToAction("Index", "Event");
                }
                else if (subscribe.Page == "EventDetails")
                {
                    return RedirectToAction("EventDetails", "Event",new { id = subscribe.pagedetailId });
                }
                else if (subscribe.Page == "Teacher")
                {
                    return RedirectToAction("Index", "Teacher");
                }
                else if (subscribe.Page == "TeacherDetails")
                {
                    return RedirectToAction("TeacherDetails", "Teacher", new { id = subscribe.pagedetailId });
                }
                else if (subscribe.Page == "Blog")
                {
                    return RedirectToAction("Index", "Blog");
                }
                else if (subscribe.Page == "BlogDetails")
                {
                    return RedirectToAction("BlogDetails", "Blog", new { id = subscribe.pagedetailId });
                }
                else if (subscribe.Page == "Contact")
                {
                    return RedirectToAction("Index", "Contact");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            Subscribe Subscribe = new Subscribe();
            Subscribe.Email = subscribe.Email;
            Subscribe.CreatedDate = DateTime.Now;

            db.Subscribes.Add(Subscribe);
            db.SaveChanges();

            Session["Subsribed"] = true;

            if (subscribe.Page == "Home")
            {
                return RedirectToAction("Index", "Home");
            }
            else if (subscribe.Page == "About")
            {
                return RedirectToAction("Index", "About");
            }
            else if (subscribe.Page == "Course")
            {
                return RedirectToAction("Index", "Course");
            }
            else if (subscribe.Page == "CourseDetails")
            {
                return RedirectToAction("CourseDetails", "Course", new { id = subscribe.pagedetailId });
            }
            else if (subscribe.Page == "Event")
            {
                return RedirectToAction("Index", "Event");
            }
            else if (subscribe.Page == "EventDetails")
            {
                return RedirectToAction("EventDetails", "Event", new { id = subscribe.pagedetailId });
            }
            else if (subscribe.Page == "Teacher")
            {
                return RedirectToAction("Index", "Teacher");
            }
            else if (subscribe.Page == "TeacherDetails")
            {
                return RedirectToAction("TeacherDetails", "Teacher", new { id = subscribe.pagedetailId });
            }
            else if (subscribe.Page == "Blog")
            {
                return RedirectToAction("Index", "Blog");
            }
            else if (subscribe.Page == "BlogDetails")
            {
                return RedirectToAction("BlogDetails", "Blog", new { id = subscribe.pagedetailId });
            }
            else if (subscribe.Page == "Contact")
            {
                return RedirectToAction("Index", "Contact");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
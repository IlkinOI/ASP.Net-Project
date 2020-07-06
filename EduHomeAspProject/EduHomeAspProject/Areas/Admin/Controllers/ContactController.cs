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
    public class ContactController : Controller
    {
        // GET: Admin/Contact
        EduHomeContext db = new EduHomeContext();
        public ActionResult Index()
        {
            List<Contact> contacts = db.Contacts.ToList();
            return View(contacts);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                if (contact.AddressLogo1File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(contact);
                }
                if (contact.AddressLogo2File == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(contact);
                }
                if (contact.PhoneLogoFile == null)
                {
                    ModelState.AddModelError("", "Image is requred!");
                    return View(contact);
                }
                string AddressLogo1Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + contact.AddressLogo1File.FileName;
                string AddressLogo1Path = Path.Combine(Server.MapPath("~/Uploads/"), AddressLogo1Name);

                string AddressLogo2Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + contact.AddressLogo2File.FileName;
                string AddressLogo2Path = Path.Combine(Server.MapPath("~/Uploads/"), AddressLogo2Name);

                string PhoneLogoName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + contact.PhoneLogoFile.FileName;
                string PhoneLogoPath = Path.Combine(Server.MapPath("~/Uploads/"), PhoneLogoName);

                contact.AddressLogo1File.SaveAs(AddressLogo1Path);
                contact.AddressLogo1 = AddressLogo1Name;

                contact.AddressLogo2File.SaveAs(AddressLogo2Path);
                contact.AddressLogo2 = AddressLogo2Name;

                contact.PhoneLogoFile.SaveAs(PhoneLogoPath);
                contact.PhoneLogo = PhoneLogoName;

                db.Contacts.Add(contact);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(contact);
        }

        public ActionResult Update(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            return View(contact);
        }

        [HttpPost]
        public ActionResult Update(Contact contact)
        {
            if (ModelState.IsValid)
            {
                Contact con = db.Contacts.Find(contact.Id);

                if (contact.AddressLogo1File != null)
                {
                    string AddressLogo1Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + contact.AddressLogo1File.FileName;
                    string AddressLogo1Path = Path.Combine(Server.MapPath("~/Uploads/"), AddressLogo1Name);

                    string oldAddressLogo1Path = Path.Combine(Server.MapPath("~/Uploads/"), con.AddressLogo1);
                    System.IO.File.Delete(oldAddressLogo1Path);

                    contact.AddressLogo1File.SaveAs(AddressLogo1Path);
                    con.AddressLogo1 = AddressLogo1Name;
                }
                if (contact.AddressLogo2File != null)
                {
                    string AddressLogo2Name = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + contact.AddressLogo2File.FileName;
                    string AddressLogo2Path = Path.Combine(Server.MapPath("~/Uploads/"), AddressLogo2Name);

                    string oldAddressLogo2Path = Path.Combine(Server.MapPath("~/Uploads/"), con.AddressLogo2);
                    System.IO.File.Delete(oldAddressLogo2Path);

                    contact.AddressLogo2File.SaveAs(AddressLogo2Path);
                    con.AddressLogo2 = AddressLogo2Name;
                }
                if (contact.PhoneLogoFile != null)
                {
                    string PhoneLogoName = DateTime.Now.ToString("ddMMyyyyHHmmssfff") + contact.PhoneLogoFile.FileName;
                    string PhoneLogoPath = Path.Combine(Server.MapPath("~/Uploads/"), PhoneLogoName);

                    string oldPhoneLogoPath = Path.Combine(Server.MapPath("~/Uploads/"), con.PhoneLogo);
                    System.IO.File.Delete(oldPhoneLogoPath);

                    contact.PhoneLogoFile.SaveAs(PhoneLogoPath);
                    contact.PhoneLogo = PhoneLogoName;
                }
                con.Phone = contact.Phone;
                con.Address1 = contact.Address1;
                con.Address2 = contact.Address2;
                con.Address3 = contact.Address3;

                db.Entry(con).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        public ActionResult Delete(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }

            db.Contacts.Remove(contact);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
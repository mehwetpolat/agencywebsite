using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgencyWebSite.Context;
using AgencyWebSite.Entities;

namespace AgencyWebSite.Controllers
{
    public class AdminController : Controller
    {
        AgencyContext agContext = new AgencyContext();

        public ActionResult AdminList(string searchText)
        {
            // arama listesi
            List<Admin> values = new List<Admin>();
            if (!string.IsNullOrEmpty(searchText))
            {
                values = agContext.Admins.Where(x => x.Name.Contains(searchText)).ToList();
                return View(values);
            }
            values = agContext.Admins.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAdmin(Admin admin)
        {
            agContext.Admins.Add(admin);
            agContext.SaveChanges();

            return RedirectToAction("AdminList");
        }

        public ActionResult DeleteAdmin(int id)
        {
            var value = agContext.Admins.Find(id);
            agContext.Admins.Remove(value);
            agContext.SaveChanges();

            return RedirectToAction("AdminList");
        }

        [HttpGet]
        public ActionResult UpdateAdmin(int id)
        {
            var value = agContext.Admins.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAdmin(Admin admin)
        {
            var value = agContext.Admins.Find(admin.AdminId);

            value.UserName = admin.UserName;
            value.Password = admin.Password;
            value.Name = admin.Name;
            value.Surname = admin.Surname;

            agContext.SaveChanges();

            return RedirectToAction("AdminList");
        }
       
    }
}
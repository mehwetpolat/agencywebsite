using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgencyWebSite.Context;
using AgencyWebSite.Entities;

namespace AgencyWebSite.Controllers
{
    public class AdminLayoutController : Controller
    {
        AgencyContext context = new AgencyContext();

        // GET: AdminLayout
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult HeadPartial()
        {
            return View();
        }

        public ActionResult SidebarPartial()
        {
            return View();
        }

        public ActionResult NavbarPartial()
        {
            var userName = Session["username"];
            var nameSurname = context.Admins.Where(x => x.UserName == userName).Select(x => x.Name + " " + x.Surname).FirstOrDefault();
            ViewBag.profile = nameSurname;           
            return View();
        }

        public ActionResult NotificationPartial()
        {
            var values = context.Notifications.ToList();
            return PartialView(values);
        }
        
    }
}
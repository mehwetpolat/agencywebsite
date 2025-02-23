using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgencyWebSite.Context;
using AgencyWebSite.Entities;

namespace AgencyWebSite.Controllers
{
    [Authorize]
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
            return PartialView();
        }

        public ActionResult SidebarPartial()
        {
            var userName = Session["username"];
            var nameSurname = context.Admins
                .Where(x => x.UserName == userName)
                .Select(x => x.Name + " " + x.Surname)
                .FirstOrDefault();
            ViewBag.nameSurname = nameSurname;

            ViewBag.profilePhoto = context.Admins.Where(x => x.UserName == userName).Select(x => x.ImageUrl).FirstOrDefault();
            return PartialView();
        }

        public ActionResult NavbarPartial()
        {
            var userName = Session["username"];
            var nameSurname = context.Admins.Where(x => x.UserName == userName).Select
                (x => x.Name + " " + x.Surname).FirstOrDefault();
            ViewBag.nameSurname = nameSurname;

            ViewBag.profilePhoto = context.Admins.Where(x => x.UserName == userName).Select(x => x.ImageUrl).FirstOrDefault();

            return PartialView();
        }

        public ActionResult NotificationPartial()
        {
            ViewBag.notificationCount = context.Notifications.ToList().Count();

            var values = context.Notifications.ToList();
            return PartialView(values);
        }
        
        public ActionResult MessagePartial()
        {
            ViewBag.messageCount = context.Messages.ToList().Count();

            var values = context.Messages.ToList();
            return PartialView(values);
        }

        public ActionResult FooterPartial()
        {
            return PartialView();
        }

        public ActionResult JsPartial()
        {
            return PartialView();
        }
    }
}
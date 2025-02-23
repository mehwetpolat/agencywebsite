using AgencyWebSite.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgencyWebSite.Controllers
{
    public class DashboardController : Controller
    {
        AgencyContext agContext = new AgencyContext();
        public ActionResult Index()
        {
            ViewBag.notificationCount = agContext.Notifications.ToList().Count();
            ViewBag.projectCount = agContext.Projects.ToList().Count();

            int categoryGrafik = agContext.Categories.Where(x => x.CategoryName == "Grafik Tasarım").Select(y => y.CategoryId).FirstOrDefault();
            ViewBag.grafikCount = agContext.Projects.Where(x => x.CategoryId == categoryGrafik).Count();

            ViewBag.messageCount = agContext.Messages.ToList().Count();
            ViewBag.personelCount = agContext.Teams.ToList().Count();
            ViewBag.serviceCount = agContext.Services.ToList().Count();
            ViewBag.adminCount = agContext.Admins.ToList().Count();

            ViewBag.falseMessageCount = agContext.Messages.Where(x => x.IsRead == false).Count();
            

            
            return View();
        }

        public ActionResult StaffData()
        {
            var values = agContext.Teams.ToList();
            return PartialView(values);
        }

        public ActionResult LastMessages()
        {
            var values = agContext.Messages.OrderByDescending(x => x.MessageId).Take(5).ToList();
            return PartialView(values);
        }

        public ActionResult BusinessSurvey()
        {
            return PartialView();
        }
    }
}
using AgencyWebSite.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgencyWebSite.Controllers
{
    public class NotificationController : Controller
    {
        AgencyContext agContext = new AgencyContext();
        public ActionResult NotificationList()
        {
            var values = agContext.Notifications.ToList();
            return View(values);
        }

        public ActionResult DeleteNotification(int id)
        {
            var value = agContext.Notifications.Find(id);
            agContext.Notifications.Remove(value);
            agContext.SaveChanges();

            return RedirectToAction("NotificationList");
        }


    }
}
using AgencyWebSite.Context;
using AgencyWebSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgencyWebSite.Controllers
{
    public class MessageController : Controller
    {
        AgencyContext agContext = new AgencyContext();
        public ActionResult MessageList(string searchText)
        {
            // arama listesi
            List<Message> values = new List<Message>();
            if (!string.IsNullOrEmpty(searchText))
            {
                values = agContext.Messages.Where(x => x.NameSurname.Contains(searchText)).ToList();
                return View(values);
            }

            values = agContext.Messages.ToList();
            return View(values);
        }

        public ActionResult DeleteMessage(int id)
        {
            var value = agContext.Messages.Find(id);
            agContext.Messages.Remove(value);
            agContext.SaveChanges();
            return RedirectToAction("MessageList");
        }

        public ActionResult MessageDetail(int id)
        {
            var value = agContext.Messages.Find(id);
            return View(value);
        }
    }
}
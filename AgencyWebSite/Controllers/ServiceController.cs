using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgencyWebSite.Context;
using AgencyWebSite.Entities;

namespace AgencyWebSite.Controllers
{
    public class ServiceController : Controller
    {
        AgencyContext context = new AgencyContext();
        public ActionResult ServiceList()
        {
            var values = context.Services.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateService(Service service)
        {
            context.Services.Add(service);
            context.SaveChanges();

            return RedirectToAction("ServiceList");
        }


        public ActionResult DeleteService(int id)
        {
            var value = context.Services.Find(id);
            context.Services.Remove(value);
            context.SaveChanges();

            return RedirectToAction("ServiceList");
        }


        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = context.Services.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateService(Service service)
        {
            var value = context.Services.Find(service.ServiceId);
            value.ServiceTitle = service.ServiceTitle;
            value.ServiceDescription = service.ServiceDescription;
            value.ServiceImageUrl = service.ServiceImageUrl;
            context.SaveChanges();

            return RedirectToAction("ServiceList");
        }
    }
}
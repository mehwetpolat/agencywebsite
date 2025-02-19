using AgencyWebSite.Context;
using AgencyWebSite.Entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgencyWebSite.Controllers
{
    
    public class AboutController : Controller
    {
        AgencyContext agContext = new AgencyContext();

        public ActionResult AboutList(string searchText)
        {
            // arama listesi
            List<About> values = new List<About>();
            if (!string.IsNullOrEmpty(searchText))
            {
                values = agContext.Abouts.Where(x => x.AboutTitle.Contains(searchText)).ToList();
                return View(values);
            }
            values = agContext.Abouts.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAbout(About about)
        {
            agContext.Abouts.Add(about);
            agContext.SaveChanges();
            return RedirectToAction("AboutList");
        }

        public ActionResult DeleteAbout(int id)
        {
            var value = agContext.Abouts.Find(id);
            agContext.Abouts.Remove(value);
            agContext.SaveChanges();
            return RedirectToAction("AboutList");
        }

        [HttpGet]
        public ActionResult UpdateAbout(int id)
        {
            var value = agContext.Abouts.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateAbout(About about)
        {
            var value = agContext.Abouts.Find(about.AboutId);
            value.AboutTitle = about.AboutTitle;
            value.AboutDescription = about.AboutDescription;
            value.AboutImageUrl = about.AboutImageUrl;

            agContext.SaveChanges();
            return RedirectToAction("AboutList");
        }

    }
}
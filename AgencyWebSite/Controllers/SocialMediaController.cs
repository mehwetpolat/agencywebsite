using AgencyWebSite.Context;
using AgencyWebSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgencyWebSite.Controllers
{
    public class SocialMediaController : Controller
    {
        AgencyContext agContext = new AgencyContext();
        public ActionResult SocialMediaList()
        {
            var values = agContext.SocialMedias.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateSocialMedia()
        {
            // dropdown listesi c# combobox
            List<SelectListItem> values = (from x in agContext.Teams.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.NameSurname,
                                               Value = x.TeamId.ToString()
                                           }).ToList();
            ViewBag.data = values;

            return View();
        }

        [HttpPost]
        public ActionResult CreateSocialMedia(SocialMedia socialmedias)
        {
            agContext.SocialMedias.Add(socialmedias);
            agContext.SaveChanges();

            return RedirectToAction("SocialMediaList");
        }

        public ActionResult DeleteSocialMedia(int id)
        {
            var value = agContext.SocialMedias.Find(id);
            agContext.SocialMedias.Remove(value);
            agContext.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }


        [HttpGet]
        public ActionResult UpdateSocialMedia(int id)
        {
            List<SelectListItem> values = (from x in agContext.Teams.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.NameSurname,
                                              Value = x.TeamId.ToString()
                                          }).ToList();
            ViewBag.teamId = values;


            var value = agContext.SocialMedias.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            var value = agContext.SocialMedias.Find(socialMedia.SocialMediaId);
            value.FacebookUrl = socialMedia.FacebookUrl;
            value.TwitterUrl = socialMedia.TwitterUrl;
            value.LinkedinUrl = socialMedia.LinkedinUrl;
            value.TeamId = socialMedia.TeamId;
            agContext.SaveChanges();
            return RedirectToAction("SocialMediaList");
        }

    }
}
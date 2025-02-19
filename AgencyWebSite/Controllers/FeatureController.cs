using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AgencyWebSite.Context;
using AgencyWebSite.Entities;

namespace AgencyWebSite.Controllers
{
    public class FeatureController : Controller
    {
        AgencyContext agContext = new AgencyContext();
        public ActionResult FeatureList()
        {
            var value = agContext.Features.ToList();
            return View(value);
        }

        [HttpGet]
        public ActionResult CreateFeature()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateFeature(Feature feature)
        {
            agContext.Features.Add(feature);
            agContext.SaveChanges();
            return RedirectToAction("FeatureList");
        }

        public ActionResult DeleteFeature(int id)
        {
            var value = agContext.Features.Find(id);
            agContext.Features.Remove(value);
            agContext.SaveChanges();

            return RedirectToAction("FeatureList");
        }

        [HttpGet]
        public ActionResult UpdateFeature(int id)
        {
            var value = agContext.Features.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateFeature(Feature feature)
        {
            var value = agContext.Features.Find(feature.FeatureId);
            value.FeatureTitle = feature.FeatureTitle;
            value.FeatureDescription = feature.FeatureDescription;
            value.FeatureImageUrl = feature.FeatureImageUrl;
            agContext.SaveChanges();

            return RedirectToAction("FeatureList");
        }
    }
}
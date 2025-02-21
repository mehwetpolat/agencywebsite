using AgencyWebSite.Context;
using AgencyWebSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgencyWebSite.Controllers
{
    public class ProjectDetailController : Controller
    {
        AgencyContext agContext = new AgencyContext();
        public ActionResult ProjectDetailList()
        {
            var values = agContext.ProjectDetails.ToList();
            return View(values);
        }

        public ActionResult DeleteProjectDetail(int id)
        {
            var value = agContext.ProjectDetails.Find(id);
            agContext.ProjectDetails.Remove(value);
            agContext.SaveChanges();

            return RedirectToAction("ProjectDetailList");
        }

        [HttpGet]
        public ActionResult CreateProjectDetail()
        {
            // dropdown listesi c# combobox
            List<SelectListItem> values = (from x in agContext.Projects.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.ProjectTitle,
                                               Value = x.ProjectId.ToString()
                                           }).ToList();
            ViewBag.v = values;

            return View();
        }
        [HttpPost]
        public ActionResult CreateProjectDetail(ProjectDetail projectDetail)
        {
            agContext.ProjectDetails.Add(projectDetail);
            agContext.SaveChanges();

            return RedirectToAction("ProjectDetailList");

        }

        [HttpGet]
        public ActionResult UpdateProjectDetail(int id)
        {
            List<SelectListItem> value = (from x in agContext.Projects.ToList()
                                          select new SelectListItem
                                          {
                                              Text = x.ProjectTitle,
                                              Value = x.ProjectId.ToString()
                                          }).ToList();
            ViewBag.projectId = value;


            var values = agContext.ProjectDetails.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateProjectDetail(ProjectDetail projectDetail)
        {
            var value = agContext.ProjectDetails.Find(projectDetail.ProjectDetailId);
            value.ProjectDetailTitle = projectDetail.ProjectDetailTitle;
            value.ProjectDetailDescription = projectDetail.ProjectDetailDescription;
            value.ProjectId = projectDetail.ProjectId;

            agContext.SaveChanges();

            return RedirectToAction("ProjectDetailList");
        }
    }
}
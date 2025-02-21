using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using AgencyWebSite.Context;
using AgencyWebSite.Entities;
using Microsoft.Ajax.Utilities;

namespace AgencyWebSite.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        AgencyContext agContext = new AgencyContext();
        public ActionResult ProjectList(string searchText)
        {
            // arama listesi
            List<Project> values = new List<Project>();
            if(!string.IsNullOrEmpty(searchText))
            {
                values = agContext.Projects.Where(value => value.ProjectTitle.Contains(searchText)).ToList();
                return View(values);
            }
            values = agContext.Projects.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateProject()
        {
            // dropdown listesi c# combobox
            List<SelectListItem> values = (from x in agContext.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.v = values;

            return View();
        }
        [HttpPost]
        public ActionResult CreateProject(Project project)
        {
            agContext.Projects.Add(project);
            agContext.SaveChanges();

            return RedirectToAction("ProjectList");
        }

        public ActionResult DeleteProject(int id)
        {
            var value = agContext.Projects.Find(id);
            agContext.Projects.Remove(value);
            agContext.SaveChanges();
            return RedirectToAction("ProjectList");
        }

        [HttpGet]
        public ActionResult UpdateProject(int id)
        {
            List<SelectListItem> value = (from x in agContext.Categories.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CategoryName,
                                                Value = x.CategoryId.ToString()
                                            }).ToList();
            ViewBag.cat = value;

            var values = agContext.Projects.Find(id);
            return View(values);
        }
        [HttpPost]
        public ActionResult UpdateProject(Project project)
        {
            var value = agContext.Projects.Find(project.ProjectId);

            value.ProjectTitle = project.ProjectTitle;
            value.ProjectImageUrl = project.ProjectImageUrl;
            value.CategoryId = project.CategoryId;

            agContext.SaveChanges();

            return RedirectToAction("ProjectList");
        }
    }
}
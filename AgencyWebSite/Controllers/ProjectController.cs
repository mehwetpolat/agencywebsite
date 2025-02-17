using System;
using System.Collections.Generic;
using System.Linq;
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
            List<Project> values = new List<Project>();
            if(!string.IsNullOrEmpty(searchText))
            {
                values = agContext.Projects.Where(x => x.ProjectTitle.Contains(searchText)).ToList();
                return View(values);
            }
            var value = agContext.Projects.ToList();
            return View(value);
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
    }
}
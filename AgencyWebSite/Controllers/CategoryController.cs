using AgencyWebSite.Context;
using AgencyWebSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgencyWebSite.Controllers
{
    public class CategoryController : Controller
    {
        AgencyContext agContext = new AgencyContext();
        public ActionResult CategoryList()
        {
            var values = agContext.Categories.ToList();
            return View(values);
        }

        public ActionResult DeleteCategory(int id)
        {
            var value = agContext.Categories.Find(id);
            agContext.Categories.Remove(value);
            agContext.SaveChanges();

            return RedirectToAction("CategoryList");

        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            agContext.Categories.Add(category);
            agContext.SaveChanges();

            return RedirectToAction("CategoryList");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = agContext.Categories.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var value = agContext.Categories.Find(category.CategoryId);

            value.CategoryName = category.CategoryName;
            agContext.SaveChanges();
            return RedirectToAction("CategoryList");
        }
    }
}
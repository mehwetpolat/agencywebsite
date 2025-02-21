using AgencyWebSite.Context;
using AgencyWebSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgencyWebSite.Controllers
{
    public class BranchController : Controller
    {
        AgencyContext agContext = new AgencyContext();
        public ActionResult BranchList()
        {
            var values = agContext.Branchs.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateBranch()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBranch(Branch branch)
        {
            agContext.Branchs.Add(branch);
            agContext.SaveChanges();

            return RedirectToAction("BranchList");
        }

        public ActionResult DeleteBranch(int id)
        {
            var value = agContext.Branchs.Find(id);
            agContext.Branchs.Remove(value);
            agContext.SaveChanges();
            return RedirectToAction("BranchList");
        }

        [HttpGet]
        public ActionResult UpdateBranch(int id)
        {
            var value = agContext.Branchs.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateBranch(Branch branch)
        {
            var value = agContext.Branchs.Find(branch.BranchId);
            value.BranchName = branch.BranchName;
            agContext.SaveChanges();

            return RedirectToAction("BranchList");
        }
    }
}
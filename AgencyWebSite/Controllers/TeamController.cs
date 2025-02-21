using AgencyWebSite.Context;
using AgencyWebSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgencyWebSite.Controllers
{
    public class TeamController : Controller
    {
        AgencyContext agContext = new AgencyContext();
        public ActionResult TeamList()
        {
            var values = agContext.Teams.ToList();
            return View(values);
        }

        public ActionResult DeleteTeam(int id)
        {
            var value = agContext.Teams.Find(id);
            agContext.Teams.Remove(value);
            agContext.SaveChanges();

            return RedirectToAction("TeamList");
        }

        [HttpGet]
        public ActionResult CreateTeam()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateTeam(Team team)
        {
            agContext.Teams.Add(team);
            agContext.SaveChanges();
            return RedirectToAction("TeamList");
        }


        [HttpGet]
        public ActionResult UpdateTeam(int id)
        {
            var value = agContext.Teams.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateTeam(Team team)
        {
            var value = agContext.Teams.Find(team.TeamId);

            value.NameSurname = team.NameSurname;
            value.ImageUrl = team.ImageUrl;
            agContext.SaveChanges();
            return RedirectToAction("TeamList");
        }

    }
}
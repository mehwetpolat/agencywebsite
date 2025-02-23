using AgencyWebSite.Context;
using AgencyWebSite.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AgencyWebSite.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        AgencyContext agContext = new AgencyContext();
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var result = agContext.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (result != null)
            {
                FormsAuthentication.SetAuthCookie(admin.UserName, true);
                Session["username"] = result.UserName;
                return RedirectToAction("ProjectList", "Project");
            }

            return View();
        }

        [HttpGet]
        public ActionResult AdminLogout()
        {
            Session["username"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("AdminLogin", "Login");
        }

    }
}
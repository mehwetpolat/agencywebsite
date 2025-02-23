using AgencyWebSite.Context;
using AgencyWebSite.Migrations;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgencyWebSite.Controllers
{

    /* 
    ui:
    navbar yapılacak 
    partiallara ayrılacak veriler dinamik
    takımları haftaya dedi ama sen yap
    clients static gelsin markalar
    mesajlar aktif
    alt footerde sosyal medya sitelerinin ana sayfasına yön ver
    hakkında kısmı düzgün gelsin gptden metin çıkar
    sol üstteki logo
    eklenen son 3 hizmeti listele
    mesajlar kısmının altına haritalardan konum bilgisi alma iframe mnrmine/kidkinder

    admin:
    bildirimlerin üstündeki sayı doğru gelecek viewbag +
    mesajlar gelsin mesajın içeriği kimden geldiği +
    sidebardaki 3 yazısına gerek yok +
    sidebar tüm linkler çalışacak +
    sign out işlevli (gösterilmeyen) +
    diller kalksın +

    haftaya branchlar ile team ilişkilendirilecek
    dashboardda bir tablolardan örnek çek

     */
    public class DefaultController : Controller
    {
        AgencyContext agContext = new AgencyContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult ProjectPartial()
        {
            var values = agContext.Projects.OrderBy(x => x.ProjectId).Take(3).ToList();
            return PartialView(values);
        }

        public PartialViewResult ModalDetailPartial()
        {
            var values = agContext.ProjectDetails.ToList();
            return PartialView(values);
        }

        public PartialViewResult MastheadPartial()
        {
            var value = agContext.Features.ToList();
            return PartialView(value);
        }

        public PartialViewResult ServicePartial()
        {
            var values = agContext.Services.ToList();
            return PartialView(values);
        }

        public PartialViewResult AboutPartial()
        {
            var values = agContext.Abouts.OrderByDescending(x =>x.AboutId).Take(6).ToList();
            return PartialView(values);
        }


        public PartialViewResult TeamPartial()
        {
            var values = agContext.Teams.Include("SocialMedias").Include("Branch").Take(3).ToList();

            return PartialView(values);
        }

        public PartialViewResult ContactPartial()
        {
            return PartialView();
        }

        public PartialViewResult ClientPartial()
        {
            return PartialView();
        }

        public PartialViewResult HeadPartial()
        {
            return PartialView();
        }

        public PartialViewResult FooterPartial()
        {
            return PartialView();
        }

        public PartialViewResult JsPartial()
        {
            return PartialView();
        }

        public PartialViewResult NavbarPartial()
        {
            return PartialView();
        }

       
    }
}
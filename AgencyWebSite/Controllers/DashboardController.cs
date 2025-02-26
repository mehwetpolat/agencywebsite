using AgencyWebSite.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgencyWebSite.Controllers
{
    public class DashboardController : Controller
    {
        AgencyContext agContext = new AgencyContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Board()
        {
            ViewBag.notificationCount = agContext.Notifications.ToList().Count();
            ViewBag.projectCount = agContext.Projects.ToList().Count();

            int categoryGrafik = agContext.Categories.Where(x => x.CategoryName == "Grafik Tasarım").Select(y => y.CategoryId).FirstOrDefault();
            ViewBag.grafikCount = agContext.Projects.Where(x => x.CategoryId == categoryGrafik).Count();

            ViewBag.messageCount = agContext.Messages.ToList().Count();
            ViewBag.personelCount = agContext.Teams.ToList().Count();
            ViewBag.serviceCount = agContext.Services.ToList().Count();
            ViewBag.adminCount = agContext.Admins.ToList().Count();

            ViewBag.falseMessageCount = agContext.Messages.Where(x => x.IsRead == false).Count();

            return PartialView();
        }

        public ActionResult StaffData()
        {
            var values = agContext.Teams.ToList();
            return PartialView(values);
        }

        public ActionResult LastMessages()
        {
            var values = agContext.Messages.OrderByDescending(x => x.MessageId).Take(5).ToList();
            return PartialView(values);
        }

        public ActionResult BusinessSurvey()
        {
            return PartialView();
        }

        public ActionResult MonthlyEarning()
        {
            // toplam satış
            ViewBag.totalSalesRevenue = agContext.Sales.Sum(x => x.SalesRevenue);
            ViewBag.totalSalesCount = agContext.Sales.Sum(x => x.SalesCount);


            // şubat ayı satışları
            ViewBag.februarySalesCount = agContext.Sales.Where(x => x.SalesDate >= new DateTime(2025, 2, 1) && x.SalesDate <= new DateTime(2025, 02, 28)).Sum(x => x.SalesCount);
            ViewBag.februarySalesRevenue = agContext.Sales.Where(x => x.SalesDate >= new DateTime(2025, 2, 1) && x.SalesDate <= new DateTime(2025, 02, 28)).Sum(x => x.SalesRevenue);


            // son bir haftalık satış
            var lastWeek = DateTime.Now.AddDays(-7);

            var lastWeekSalesCount = agContext.Sales
                .Where(s => s.SalesDate >= lastWeek)
                .Sum(s => s.SalesCount);

            var lastWeekSalesRevenue = agContext.Sales
                .Where(s => s.SalesDate >= lastWeek)
                .Sum(s => s.SalesRevenue);

            ViewBag.lastWeekSalesCount = lastWeekSalesCount;
            ViewBag.lastWeekSalesRevenue = lastWeekSalesRevenue;


            // bugünün satışları
            var today = DateTime.Today;

            var todaySalesCount = agContext.Sales
                .Where(s => System.Data.Entity.DbFunctions.TruncateTime(s.SalesDate) == today)
                .Sum(s => (int?)s.SalesCount ?? 0);

            var todaySalesRevenue = agContext.Sales
                .Where(s => System.Data.Entity.DbFunctions.TruncateTime(s.SalesDate) == today)
                .Sum(s => (decimal?)s.SalesRevenue ?? 0);

            ViewBag.todaySalesCount = todaySalesCount;
            ViewBag.todaySalesRevenue = todaySalesRevenue;



            var values = agContext.Sales.ToList();
            return PartialView(values);
        }
    }
}

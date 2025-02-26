using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgencyWebSite.Entities
{
    public class Sales
    {
        public int SalesId { get; set; }
        public string SalesName { get; set; }
        public int SalesCount { get; set; }
        public int SalesRevenue { get; set; }
        public DateTime SalesDate { get; set; }
    }
}
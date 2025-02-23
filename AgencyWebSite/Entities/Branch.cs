using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgencyWebSite.Entities
{
    public class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public List<Team> Teams { get; set; }
    }
}
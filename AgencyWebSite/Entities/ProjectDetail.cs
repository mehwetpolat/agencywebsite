using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgencyWebSite.Entities
{
    public class ProjectDetail
    {
        public int ProjectDetailId { get; set; }
        public string ProjectDetailDescription { get; set; }
        public string ProjectDetailTitle { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Projects { get; set; }

    }
}
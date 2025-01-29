using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgencyWebSite.Entities
{
    public class ProjectDetail
    {
        public int ProjectDetailId { get; set; }
        public string ProjectDetailName { get; set; }
        public string ProjectDetailTitle { get; set; }
        public string ProjectDetailDescription { get; set; }
        public string ProjectDetailImageUrl { get; set; }

    }
}
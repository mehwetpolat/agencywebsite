using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgencyWebSite.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectTitle { get; set; }
        public string ProjectImageUrl { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
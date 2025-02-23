using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgencyWebSite.Entities
{
    public class Team
    {
        public int TeamId { get; set; }
        public string NameSurname { get; set; }
        public string ImageUrl { get; set; }
        public int BranchId { get; set; }
        public virtual Branch Branch { get; set; }
        public List<SocialMedia> SocialMedias { get; set; }
    }
}
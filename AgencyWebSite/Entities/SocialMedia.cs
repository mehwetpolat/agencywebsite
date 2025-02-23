using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgencyWebSite.Entities
{
    public class SocialMedia
    {
        public int SocialMediaId { get; set; }
        public string TwitterUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public int TeamId { get; set; }
        public virtual Team Teams { get; set; }
    }
}
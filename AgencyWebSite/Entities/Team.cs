﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgencyWebSite.Entities
{
    public class Team
    {
        public int TeamId { get; set; }
        public string NameSurname { get; set; }
        public string Work { get; set; }
        public string ImageUrl { get; set; }
    }
}
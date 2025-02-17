﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgencyWebSite.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}
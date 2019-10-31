﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Core.Entities
{
    public class JobUrl
    {
        public int Id { get; set; }
        public string Url { get; set; }

        public JobInfo JobInfo { get; set; }
        public int? JobInfoId { get; set; }
    }
}

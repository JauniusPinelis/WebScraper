using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Core.Dtos
{
    public class JobUrl
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int CategoryId { get; set; }
    }
}

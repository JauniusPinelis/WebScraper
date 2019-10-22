using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Core.Dtos
{
    public class JobUrlDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int CategoryId { get; set; }
    }
}

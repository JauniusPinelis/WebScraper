using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Core.Dtos
{
    public class jobHtmlDto
    {
        public int Id { get; set; }
        public string HtmlCode { get; set; }
        public int JobUrlId { get; set; }
    }
}

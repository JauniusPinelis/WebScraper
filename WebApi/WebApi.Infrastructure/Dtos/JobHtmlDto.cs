using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Infrastructure.Dtos
{
    public class JobHtmlDto
    {
        public int Id { get; set; }
        public string HtmlCode { get; set; }
        public int JobUrlId { get; set; }
    }
}

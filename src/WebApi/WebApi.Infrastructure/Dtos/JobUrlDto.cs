using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Infrastructure.Dtos
{
    public class JobUrlDto
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Salary { get; set; }
    }
}

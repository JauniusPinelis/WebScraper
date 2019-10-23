using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebScraper.Infrastructure.Entities
{
    public class JobHtml
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string HtmlCode { get; set; }

        [ForeignKey("JobUrl")]
        public int JobUrlId { get; set; }
        public JobUrl JobUrl { get; set; }

    }
}

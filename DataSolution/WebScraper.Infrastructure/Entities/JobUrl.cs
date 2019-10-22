using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebScraper.Infrastructure.Entities
{
    [Table("tblData_JobUrl")]
    public class JobUrl
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public JobUrlCategory Category { get; set; }

    }
}

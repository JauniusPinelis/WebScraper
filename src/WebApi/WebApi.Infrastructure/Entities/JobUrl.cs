using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApi.Infrastructure.Entities
{
    [Table("tblData_JobUrl")]
    public class JobUrl
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public string Salary { get; set; }

    }
}

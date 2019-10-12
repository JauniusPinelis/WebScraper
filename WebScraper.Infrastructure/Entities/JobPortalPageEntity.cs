using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebScraper.Infrastructure.Entities
{
    [Table("tblData_PortalPage")]
    public class JobPortalPageEntity
    {
        public int Id { get; set; }
        
    }
}

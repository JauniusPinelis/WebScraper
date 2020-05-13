using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Salary : AuditableEntity
    {
        public decimal? From { get; set; }
        public decimal? To { get; set; }

        public decimal? Exact { get; set; }
        public string Currency { get; set; } = "EUR";

        // Brutto or Netto
        public string Type { get; set; } = "Brutto";

        public string Period { get; set; } = "Monthly";

        //Foreign
        public JobUrl JobUrl { get; set; }
        public int? JObUrlId { get; set; }

    }
}

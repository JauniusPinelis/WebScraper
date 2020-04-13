using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper.Infrastructure.Services
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}

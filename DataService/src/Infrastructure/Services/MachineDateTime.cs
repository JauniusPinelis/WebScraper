using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Services
{
    public class MachineDateTime : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}

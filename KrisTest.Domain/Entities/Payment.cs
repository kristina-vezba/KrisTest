using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Domain.Entities
{
    public class Payment
    {
        public string Id { get; set; }
        public DateTime paid { get; set; }
        public decimal total { get; set; }
        public string details { get; set; }
    }
}

using KrisTest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Domain.Entities
{
    public class Payment : BaseEntity
    {
        public DateTime Paid { get; set; }
        public double Total { get; set; }
        public string Details { get; set; }
        public Order Order { get; set; }
        public Account Account { get; set; }
    }
}

using KrisTest.Domain.Common;
using KrisTest.Domain.Enums;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string Number { get; set; }
        public DateTime Ordered { get; set; }
        public DateTime Shipped { get; set; }
        public Address ShipTo { get; set; }
        public OrderStatus Status { get; set; }
        public double Total { get; set; }
        public Account Account { get; set; }
    }
}

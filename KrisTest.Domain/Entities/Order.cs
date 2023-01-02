using KrisTest.Domain.Enums;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Domain.Entities
{
    public class Order
    {
        public String number { get; set; }
        public DateTime ordered { get; set; }
        public DateTime shipped { get; set; }
        public Address ship_to { get; set; }
        public OrderStatus status { get; set; }
        public decimal total { get; set; }
        public Account Account { get; set; }
    }
}

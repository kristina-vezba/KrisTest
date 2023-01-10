using KrisTest.Domain.Common;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string BillingAddress { get; set; }
        public bool IsClosed { get; set; }
        public DateTime Open { get; set; }
        public DateTime Closed { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Payment>? Payments { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}

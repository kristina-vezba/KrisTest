using KrisTest.Domain.Common;
using NodaTime;
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
        public LocalDateTime Open { get; set; }
        public LocalDateTime Closed { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Payment>? Payments { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}

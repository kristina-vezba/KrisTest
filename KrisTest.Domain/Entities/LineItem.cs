using KrisTest.Domain.Common;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Domain.Entities
{
    public class LineItem : BaseEntity
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public Order Order { get; set; }
    }
}

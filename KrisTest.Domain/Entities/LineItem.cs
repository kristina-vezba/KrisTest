using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Domain.Entities
{
    public class LineItem
    {
        public int quantity { get; set; }
        public Price price { get; set; }
        public Product Product { get; set; }
        public string ShoppigCartId { get; set; }
    }
}

using KrisTest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Domain.Entities
{
    public class LineItem : BaseEntity
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
        public int ShoppingCartId { get; set; }
        public Order Order { get; set; }
        public int OrderId { get; set; }
    }
}

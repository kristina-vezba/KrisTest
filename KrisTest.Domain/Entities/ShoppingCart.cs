using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Domain.Entities
{
    public class ShoppingCart
    {
        public DateTime created { get; set; }
        public Account Account { get; set; }
    }
}

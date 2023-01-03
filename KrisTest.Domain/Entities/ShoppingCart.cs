using KrisTest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Domain.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public DateTime Created { get; set; }
        public Account Account { get; set; }
        public WebUser User { get; set; }
    }
}

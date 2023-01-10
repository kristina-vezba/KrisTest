using KrisTest.Domain.Common;
using KrisTest.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Domain.Entities
{
    public class WebUser : BaseEntity
    {
        public string Name { get; set; } = String.Empty;
        public string Password { get; set; }
        public UserState State { get; set; }
        public ShoppingCart? ShoppingCart { get; set; }
        public Customer Customer { get; set; }
    }
}

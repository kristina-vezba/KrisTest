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
        public string LoginId { get; set; }
        public string Password { get; set; }
        public UserState State { get; set; }
        public Nullable<int> ShoppinCartId { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}

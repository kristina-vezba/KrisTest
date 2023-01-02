using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Domain.Entities
{
    public class Account
    {
        public string Id { get; set; }
        public Address billing_address { get; set; }
        public Boolean is_closed { get; set; }
        public DateTime open { get; set; }
        public DateTime closed { get; set; }
        public Customer Customer { get; set; }
    }
}

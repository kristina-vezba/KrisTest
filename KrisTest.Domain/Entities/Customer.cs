using Microsoft.Graph;
using Stripe;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Domain.Entities
{
    public class Customer
    {
        public string id { get; set; }
        public Address address { get; set; }
        public Phone phone { get; set; }
        public string email { get; set; }

    }
}

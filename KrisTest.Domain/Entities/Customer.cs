using KrisTest.Domain.Common;
using Microsoft.Graph;
using Stripe;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public Address Address { get; set; }
        public Phone Phone { get; set; }
        public string Email { get; set; }
        public Account Account { get; set; }
        public Nullable<int> WebUserId { get; set; }
        public WebUser User { get; set; }

    }
}

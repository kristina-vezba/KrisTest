using KrisTest.Domain.Common;
using Microsoft.Graph;
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
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Account Account { get; set; }
        public int AccountId { get; set; }
        public WebUser? WebUser { get; set; }
        public int WebUserId { get; set; }
    }
}

using KrisTest.Domain.Common;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Domain.Entities
{
    public class ShoppingCart : BaseEntity
    {
        public LocalDateTime Created { get; set; }
        public Account Account { get; set; }
        public int AccountId { get; set; }
        public WebUser WebUser { get; set; }
        public int WebUserId { get; set; }
        public ICollection<LineItem> LineItems { get; set; }
    }
}

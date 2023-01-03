using KrisTest.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<LineItem> LineItems { get; set; }

        //public Supplier supplier { get; set; }
    }
}

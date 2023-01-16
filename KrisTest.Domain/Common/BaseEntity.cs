using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public Guid Uid { get; set; }
        public Instant CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public Instant? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }

    }
}

using KrisTest.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KrisTest.Infrastructure.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasOne(c => c.Account)
                .WithOne(a => a.Customer)
                .HasForeignKey<Account>(a => a.Id)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(c => c.WebUser)
                .WithOne(wu => wu.Customer)
                .HasForeignKey<WebUser>(wu => wu.Id);
		}
    }
}

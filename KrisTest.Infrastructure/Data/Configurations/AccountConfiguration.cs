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
    internal class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasOne(a => a.ShoppingCart)
                .WithOne(sc => sc.Account)
                .HasForeignKey<ShoppingCart>(sc => sc.Id)
                .OnDelete(DeleteBehavior.SetNull);

			builder.HasMany(a => a.Orders)
                .WithOne(o => o.Account)
				.OnDelete(DeleteBehavior.SetNull);
		}
    }
}
